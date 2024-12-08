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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpRole form2 = new SignUpRole();

            form2.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();

            form1.Show();

            this.Close();
        }
    }
}
