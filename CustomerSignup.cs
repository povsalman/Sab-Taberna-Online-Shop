using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class CustomerSignup : Form
    {
        public CustomerSignup()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string age = textBox4.Text;
            string gender = comboBox1.SelectedItem?.ToString();
            string contact = textBox6.Text;
            string paymentPreference = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(paymentPreference))
            {
                MessageBox.Show("Please fill all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = DBHandler.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Insert into ISUSER
                    string insertUserQuery = @"
                INSERT INTO ISUSER (UserName, Password, Age, Gender, RegistrationDate, Contact,AccountType)
                VALUES (@UserName, @Password, @Age, @Gender, @RegistrationDate, @Contact,'Customer');
                SELECT SCOPE_IDENTITY();";
                    int userId;
                    using (SqlCommand command = new SqlCommand(insertUserQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Age", age ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Gender", gender ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Contact", contact);

                        userId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert into CUSTOMER
                    string insertCustomerQuery = @"
                INSERT INTO CUSTOMER (UserID, Name, PaymentPreferences)
                VALUES (@UserID, @Name, @PaymentPreferences);";
                    using (SqlCommand command = new SqlCommand(insertCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);
                        command.Parameters.AddWithValue("@Name", userName);
                        command.Parameters.AddWithValue("@PaymentPreferences", paymentPreference);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Signup successful! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    Login loginForm = new Login();
                    loginForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SignUpRole form2 = new SignUpRole();

            form2.Show();

            this.Close();
        }
    }
}
