using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form10 : Form
    {
        // Shared data between forms
        private List<Product> shoppingCart;
        private Dictionary<Product, List<Review>> productReviews;
        public Form10()
        {
            InitializeComponent();

            // Initialize the shared data
            shoppingCart = new List<Product>();
            productReviews = new Dictionary<Product, List<Review>>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 productsForm = new Form11(shoppingCart, productReviews);
            productsForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 cartForm = new Form12();
            cartForm.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form13 reviewForm = new Form13();
            reviewForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form15 reviewForm = new Form15();
            reviewForm.Show();
            this.Hide();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
