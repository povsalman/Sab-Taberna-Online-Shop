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



    public partial class Sales_Performance_Report : Form
    {
        public Sales_Performance_Report()
        {
            InitializeComponent();
        }


        private void ExecuteQuery(string query, DataGridView gridView, DateTime startDate, DateTime endDate)
        {
            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

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


        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(TotalAmount) AS TotalSales FROM ISORDER WHERE OrderDate BETWEEN @StartDate AND @EndDate";
            ExecuteQuery(query, dataGridView1, DateTime.Today.AddDays(-30), DateTime.Today); // Example: Last 30 days
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT AVG(TotalAmount) AS AverageOrderValue FROM ISORDER WHERE OrderDate BETWEEN @StartDate AND @EndDate";
            ExecuteQuery(query, dataGridView1, DateTime.Today.AddDays(-30), DateTime.Today); // Example: Last 30 days
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            p.Name AS ProductName, 
            SUM(oi.Quantity) AS QuantitySold 
        FROM ORDER_ITEM oi
        JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
        JOIN ISORDER o ON oi.OrderID = o.OrderID
        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
        GROUP BY p.Name
        ORDER BY QuantitySold DESC";
            ExecuteQuery(query, dataGridView1, DateTime.Today.AddDays(-30), DateTime.Today); // Example: Last 30 days
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            c.CategoryName, 
            SUM(oi.Quantity) AS QuantitySold 
        FROM ORDER_ITEM oi
        JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
        JOIN CATEGORY c ON p.CategoryID = c.CategoryID
        JOIN ISORDER o ON oi.OrderID = o.OrderID
        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
        GROUP BY c.CategoryName
        ORDER BY QuantitySold DESC";
            ExecuteQuery(query, dataGridView1, DateTime.Today.AddDays(-30), DateTime.Today); // Example: Last 30 days
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // Replace 'PreviousForm' with the name of the form to navigate back to
           CustomerOrder bilalReports= new CustomerOrder();
            bilalReports.Show();
            this.Hide();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
