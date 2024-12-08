using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class SellerReports : Form
    {
        public SellerReports()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            SellerDashboard sellerDashboard = new SellerDashboard();
            sellerDashboard.Show();
            this.Close();
        }
    }
}
