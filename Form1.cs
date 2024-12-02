namespace DB_Proj_00
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            Form2 form2 = new Form2();

            
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add Password Check Here
            string selectedRole = comboBox1.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please select a role before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (selectedRole)
            {
                case "Customer":
                    Form10 customerForm = new Form10();
                    customerForm.Show();
                    break;

                case "Seller":
                    Form7 sellerForm = new Form7();
                    sellerForm.Show();
                    break;

                case "Admin":
                    Form9 adminDashboard = new Form9(); 
                    adminDashboard.Show();
                    break;

                case "Logistics Provider":
                    Form8 logisticsForm = new Form8();
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
