using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic.Logging;

namespace DB_Proj_00
{
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Retrieve input from text fields
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string ageText = txtAge.Text.Trim();
            string gender = comboGender.SelectedItem as string;
            string contact = txtContact.Text.Trim();

            // Validate fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(ageText) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(contact))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageText, out int age) || age < 0)
            {
                MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert into the ISUSER and ADMIN tables

            using (var connection = DBHandler.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Start transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        // Insert into ISUSER table
                        string insertUserQuery = @"
                            INSERT INTO ISUSER (UserName, Password, Age, Gender, RegistrationDate, Contact, AccountType)
                            VALUES (@UserName, @Password, @Age, @Gender, @RegistrationDate, @Contact, 'Admin');
                            SELECT SCOPE_IDENTITY();";

                        int userId;
                        using (SqlCommand cmdUser = new SqlCommand(insertUserQuery, connection, transaction))
                        {
                            cmdUser.Parameters.AddWithValue("@UserName", username);
                            cmdUser.Parameters.AddWithValue("@Password", password);
                            cmdUser.Parameters.AddWithValue("@Age", age);
                            cmdUser.Parameters.AddWithValue("@Gender", gender);
                            cmdUser.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);
                            cmdUser.Parameters.AddWithValue("@Contact", contact);

                            // Execute and retrieve the new UserID
                            object result = cmdUser.ExecuteScalar();
                            if (result == null || !int.TryParse(result.ToString(), out userId))
                            {
                                throw new Exception("Failed to insert user.");
                            }
                        }

                        // Insert into ADMIN table
                        string insertAdminQuery = @"
                            INSERT INTO ADMIN (UserID, Role)
                            VALUES (@UserID, 'Admin');";

                        using (SqlCommand cmdAdmin = new SqlCommand(insertAdminQuery, connection, transaction))
                        {
                            cmdAdmin.Parameters.AddWithValue("@UserID", userId);
                            cmdAdmin.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }

                    MessageBox.Show("Admin registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate back to login form
                    Login form1 = new Login();
                    form1.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBackSignupRole_Click(object sender, EventArgs e)
        {
            // Navigate back to the role selection form
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }
    }
}