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
    public partial class Abandoned_Cart_Report : Form
    {
        public Abandoned_Cart_Report()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            COUNT(DISTINCT c.CartID) AS AbandonedCartCount
        FROM CART c
        LEFT JOIN ISORDER o ON c.UserID = o.CustomerID
        WHERE o.OrderID IS NULL AND DATEDIFF(DAY, GETDATE(), c.LastUpdatedDate) > @Timeframe;";

            var parameters = new Dictionary<string, object> { { "@Timeframe", 7 } }; // Example: 7 days
            ExecuteQuery(query, dataGridView1, parameters);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            AVG(cart_value) AS AverageAbandonedCartValue
        FROM (
            SELECT 
                SUM(p.Price * c.Quantity) AS cart_value
            FROM CART c
            JOIN ISPRODUCT p ON c.ProductID = p.ProductID
            LEFT JOIN ISORDER o ON c.UserID = o.CustomerID
            WHERE o.OrderID IS NULL
            GROUP BY c.CartID
        ) cart_values;";

            ExecuteQuery(query, dataGridView1);
        }



        private void Abandoned_Cart_Report_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            Reason, 
            COUNT(*) AS Occurrences
        FROM CART_ABANDONMENT_SURVEYS
        GROUP BY Reason
        ORDER BY Occurrences DESC;";

            ExecuteQuery(query, dataGridView1);
        }



        private void button5_Click(object sender, EventArgs e)
        {
            CustomerOrder bilalReports = new CustomerOrder();
            bilalReports.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            p.Name AS ProductName, 
            COUNT(c.CartID) AS TimesAbandoned
        FROM CART c
        JOIN ISPRODUCT p ON c.ProductID = p.ProductID
        LEFT JOIN ISORDER o ON c.UserID = o.CustomerID
        WHERE o.OrderID IS NULL
        GROUP BY p.Name
        ORDER BY TimesAbandoned DESC;";

            ExecuteQuery(query, dataGridView1);
        }


    }
}
