using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class LogisticsDashboard : Form
    {
        public LogisticsDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Login form1 = new Login();
            form1.ShowDialog();
        }


        private void btnLogisticsInterface_Click(object sender, EventArgs e)
        {
            LogisticsShipping logisticsInterface = new LogisticsShipping();
            logisticsInterface.Show();
            this.Hide();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnDeliveryNotifications_Click(object sender, EventArgs e)
        {
            Form25 deliveryNotifications = new Form25();
            deliveryNotifications.Show();
            this.Hide();
        }

        private void btnShipmentScheduling_Click(object sender, EventArgs e)
        {
            Form26 shipmentScheduling = new Form26();
            shipmentScheduling.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
