using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminUserMng : Form
    {
        public AdminUserMng()
        {
            InitializeComponent();
        }

        private void App_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seller approved successfully!", "Seller Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Rej_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seller rejected successfully!", "Seller Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void View_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Viewing suspicious activity. .", "Monitor Activity", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard(); 
            adminDashboard.Show();
            this.Close();
        }
    }
}
