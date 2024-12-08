using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Customer_Purchase_Behavior : Form
    {
        public Customer_Purchase_Behavior()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"SELECT TOP 1 c.Name, COUNT(o.OrderID) AS NumberOfOrders
                             FROM CUSTOMER c
                             JOIN ISORDER o ON c.CustomerID = o.CustomerID
                             GROUP BY c.Name
                             ORDER BY NumberOfOrders DESC;";
            DisplayData(query);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"SELECT c.Name, AVG(o.TotalAmount) AS AverageSpend
                             FROM CUSTOMER c
                             JOIN ISORDER o ON c.CustomerID = o.CustomerID
                             GROUP BY c.Name;";
            DisplayData(query);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
    WITH CustomerOrders AS (
        SELECT c.CustomerID, COUNT(o.OrderID) AS OrdersCount
        FROM CUSTOMER c
        JOIN ISORDER o ON c.CustomerID = o.CustomerID
        GROUP BY c.CustomerID
    )
    SELECT cu.Name, COUNT(*) AS RepeatOrders
    FROM CustomerOrders co
    JOIN CUSTOMER cu ON co.CustomerID = cu.CustomerID
    WHERE co.OrdersCount > 1
    GROUP BY cu.Name;
    ";
            DisplayData(query);
        }


        private void DisplayData(string query)
        {
            using (var conn = DBHandler.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This can be used if you want to handle cell click events.
        }
    }
}
