using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
        }

        private void btnSimulateNotification_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulated notification: 'Order #123 is Out for Delivery.'",
                            "Notification",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
