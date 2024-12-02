using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Navigate to User and Seller Management (Form19)
            Form19 userSellerManagement = new Form19();
            userSellerManagement.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to Product and Category Management (Form20)
            Form20 productCategoryManagement = new Form20();
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

            Form21 orderOversightForm = new Form21(orders);
            orderOversightForm.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form23 reportsForm = new Form23();
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
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
    }
}
