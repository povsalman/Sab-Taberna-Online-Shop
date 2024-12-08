using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Inventory_Management_Report : Form
    {
        public Inventory_Management_Report()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string query, DataGridView gridView, Dictionary<string, object> parameters = null)
        {
            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT Name AS ProductName, StockLevel FROM ISPRODUCT WHERE StockLevel < @Threshold";
            var parameters = new Dictionary<string, object> { { "@Threshold", 10 } }; // Example threshold
            ExecuteQuery(query, dataGridView1, parameters);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            p.Name AS ProductName, 
            p.StockLevel 
        FROM ISPRODUCT p
        LEFT JOIN ORDER_ITEM oi ON p.ProductID = oi.ProductID
        LEFT JOIN ISORDER o ON oi.OrderID = o.OrderID AND o.OrderDate >= @TimeFrame
        WHERE o.OrderID IS NULL";
            var parameters = new Dictionary<string, object> { { "@TimeFrame", DateTime.Today.AddMonths(-6) } }; // Example: last 6 months
            ExecuteQuery(query, dataGridView1, parameters);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            p.Name AS ProductName,
            SUM(oi.Quantity) AS TotalUnitsSold,
            (p.StockLevel + p.StockLevel / 2) / 2 AS AverageInventory, -- Approximation
            (SUM(oi.Quantity) / NULLIF((p.StockLevel + p.StockLevel / 2) / 2, 0)) AS TurnoverRate
        FROM ISPRODUCT p
        LEFT JOIN ORDER_ITEM oi ON p.ProductID = oi.ProductID
        GROUP BY p.Name, p.StockLevel";
            ExecuteQuery(query, dataGridView1);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            CustomerOrder bilalReports = new CustomerOrder();
            bilalReports.Show();
            this.Hide();
        }
    }
}
