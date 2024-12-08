using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not done.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not done.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not done.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form7 sellerDashboard = new Form7();
            sellerDashboard.Show();
            this.Close();
        }
    }
}
