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
    public partial class Seller_Performance_Report : Form
    {
        public Seller_Performance_Report()
        {
            InitializeComponent();
        }

        private void ExecuteQuery(string query, DataGridView gridView)
        {
            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
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
            string query = @"
        SELECT 
            s.SellerID, 
            s.StoreName, 
            SUM(o.TotalAmount) AS TotalSales 
        FROM ISORDER o
        JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
        JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
        JOIN SELLER s ON p.SellerID = s.SellerID
        GROUP BY s.SellerID, s.StoreName;";
            ExecuteQuery(query, dataGridView1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.SellerID, 
            s.StoreName, 
            AVG(r.Rating) AS AverageRating 
        FROM REVIEW r
        JOIN ISPRODUCT p ON r.ProductID = p.ProductID
        JOIN SELLER s ON p.SellerID = s.SellerID
        GROUP BY s.SellerID, s.StoreName;";
            ExecuteQuery(query, dataGridView1);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            s.SellerID, 
            s.StoreName, 
            CAST(SUM(CASE WHEN r.RefundAmount > 0 THEN 1 ELSE 0 END) AS FLOAT) / COUNT(o.OrderID) * 100 AS ReturnRefundRate 
        FROM ISORDER o
        JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
        JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
        JOIN SELLER s ON p.SellerID = s.SellerID
        LEFT JOIN ISRETURN r ON o.OrderID = r.OrderID
        GROUP BY s.SellerID, s.StoreName;";
            ExecuteQuery(query, dataGridView1);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            CustomerOrder bilalReports =new CustomerOrder();
            bilalReports.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
