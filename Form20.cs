using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Category added successfully! (Placeholder)", "Category Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Category removed successfully! (Placeholder)", "Category Management", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnApproveListing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product listing approved successfully!", "Moderation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRejectListing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product listing rejected successfully!", "Moderation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form9 adminDashboard = new Form9();
            adminDashboard.Show();
            this.Close();
        }
    }
}
