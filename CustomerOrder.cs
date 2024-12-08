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
    public partial class CustomerOrder : Form
    {
        public CustomerOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Customer_Purchase_Behavior behaviorForm = new Customer_Purchase_Behavior();
            behaviorForm.Show();
            this.Hide();


        }



        private void button6_Click(object sender, EventArgs e)
        {
            CustomerDashboard customerDashboard = new CustomerDashboard();
            customerDashboard.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Customer_Feedback_and_Product_Rating_Analysis_Report feedbackForm = new Customer_Feedback_and_Product_Rating_Analysis_Report();
            feedbackForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sales_Performance_Report sales_Performance_Report = new Sales_Performance_Report();
            sales_Performance_Report.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Inventory_Management_Report inventory_Management_Report = new Inventory_Management_Report();
            inventory_Management_Report.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Seller_Performance_Report seller_Performance_Report = new Seller_Performance_Report();
            seller_Performance_Report.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Abandoned_Cart_Report abandoned_Cart_ = new Abandoned_Cart_Report();
            abandoned_Cart_.Show();
            this.Hide();
        }
    }
}
