using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Static session class to store the UserID
        public static class Session
        {
            public static int UserID { get; set; }
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
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string selectedRole = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please fill all fields and select a role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Server=DESKTOP-36T2U50\SQLEXPRESS;Database=SABTaberna;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT UserID FROM ISUSER WHERE UserName = @UserName AND Password = @Password";
                    int userId;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        object result = command.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        userId = Convert.ToInt32(result);
                    }

                    // Verify role in the appropriate table
                    string roleQuery = selectedRole switch
                    {
                        "Customer" => "SELECT COUNT(*) FROM CUSTOMER WHERE UserID = @UserID",
                        "Seller" => "SELECT COUNT(*) FROM SELLER WHERE UserID = @UserID",
                        "Admin" => "SELECT COUNT(*) FROM ADMIN WHERE UserID = @UserID",
                        _ => null
                    };

                    if (roleQuery == null)
                    {
                        MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (SqlCommand roleCommand = new SqlCommand(roleQuery, connection))
                    {
                        roleCommand.Parameters.AddWithValue("@UserID", userId);
                        int roleExists = Convert.ToInt32(roleCommand.ExecuteScalar());
                        if (roleExists == 0)
                        {
                            MessageBox.Show($"User does not have the {selectedRole} role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Store session information
                    SessionManager.UserID = userId;
                    SessionManager.Role = selectedRole;
                    SessionManager.UserName = userName;


                    
                    if (selectedRole == "Customer")
                    {
                        CustomerDashboard customerDashboard = new CustomerDashboard();
                        customerDashboard.Show();
                    }
                    else if (selectedRole == "Seller")
                    {
                        Form8 sellerDashboard = new Form8(); 
                        sellerDashboard.Show();
                    }
                    else if (selectedRole == "Admin")
                    {
                        AdminNewDashboard adminDashboard = new AdminNewDashboard();
                        adminDashboard.Show();
                       
                    }

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
