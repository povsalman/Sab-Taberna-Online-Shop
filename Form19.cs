using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form19 : Form
    {
        public Form19()
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
            Form9 adminDashboard = new Form9(); 
            adminDashboard.Show();
            this.Close();
        }
    }
}
