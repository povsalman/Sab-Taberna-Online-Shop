using System;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class Form26 : Form
    {
        public Form26()
        {
            InitializeComponent();
        }

        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simulated schedule creation: 'Pickup scheduled for Order #456 at 10:00 AM.'",
                            "Shipment Scheduling",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}
