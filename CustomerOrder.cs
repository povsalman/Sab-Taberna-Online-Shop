using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class CustomerOrder : Form
    {
        public CustomerOrder()
        {
            InitializeComponent();
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order has been placed. ", "Order Placement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerDashboard form10 = new CustomerDashboard();
            form10.Show();
            this.Close();
        }
    }
}
