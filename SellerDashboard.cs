using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class SellerDashboard : Form
    {
        public SellerDashboard()
        {
            InitializeComponent();
            panel2.BringToFront();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
           // panel3.Visible = false;
           // panel4.Visible = false;
           // panel5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the Product Management page
            SellerProductManagement productManagementForm = new SellerProductManagement();
            productManagementForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Navigate to the Order Fulfillment page
            SellerOrderFullfillment orderFulfillmentForm = new SellerOrderFullfillment();
            orderFulfillmentForm.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {

        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login form1 = new Login();
            form1.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
