using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            Form7 sellerDashboard = new Form7();
            sellerDashboard.Show();
            this.Close();
        }
    }
}
