using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        /*private void btnBack_Click(object sender, EventArgs e)
        {
            Form10 customerForm = new Form10(userId);
            customerForm.Show();
            this.Close();
        }*/

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order has been placed. ", "Order Placement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblOrderStatus_Click(object sender, EventArgs e)
        {

        }
    }
}
