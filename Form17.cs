using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void btnPrintShippingLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shipping label printed. This is a placeholder message.", "Print Shipping Label", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarkShipped_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order marked as shipped.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMarkDelivered_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order marked as delivered.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form7 sellerDashboard = new Form7();
            sellerDashboard.Show();
            this.Close();
        }
    }
}
