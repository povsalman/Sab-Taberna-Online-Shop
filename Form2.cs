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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedRole = comboBox1.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (selectedRole)
            {
                case "Customer":
                    CustomerSignup customerForm = new CustomerSignup();
                    customerForm.Show();
                    break;

                case "Seller":
                    Form4 sellerForm = new Form4();
                    sellerForm.Show();
                    break;

                case "Admin":
                    AdminSignUp adminForm = new AdminSignUp();
                    adminForm.Show();
                    break;

                case "Logistics Provider":
                    Form6 logisticsForm = new Form6();
                    logisticsForm.Show();
                    break;

                default:
                    MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            this.Hide();
        }
    }
}
