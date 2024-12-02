using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to User and Seller Management (Form19)
            AdminUserMng userSellerManagement = new AdminUserMng();
            userSellerManagement.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to Product and Category Management (Form20)
            AdminProductMng productCategoryManagement = new AdminProductMng();
            productCategoryManagement.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var orders = new List<Order>
    {
        new Order(1, "Bilal", "Seller A", "Processing", 100.50m, DateTime.Now.AddDays(-2)),
        new Order(2, "Salman", "Seller B", "Shipped", 250.75m, DateTime.Now.AddDays(-1)),
        new Order(3, "Arshiq", "Seller C", "Delivered", 320.20m, DateTime.Now.AddDays(-3))
    };

            AdminOrderOversight orderOversightForm = new AdminOrderOversight(orders);
            orderOversightForm.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            AdminReports reportsForm = new AdminReports();
            reportsForm.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            // Navigate to Platform Settings (Placeholder for now)
            MessageBox.Show("Platform Settings Section is under development!", "Platform Settings");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Logout and return to Login (Form1)
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }
    }
}
