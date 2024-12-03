using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SignUpRole form2 = new SignUpRole();


            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Enter Username 
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        // Enter Password
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedRole = comboRole.SelectedItem as string;

            // Validate input fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please fill in all fields and select a role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Define the base query for ISUSER table
                string query = @"
            SELECT u.UserID 
            FROM ISUSER u
            WHERE u.UserName = @UserName AND u.Password = @Password";

                // Parameters for the query
                SqlParameter[] userParams = new SqlParameter[]
                {
            new SqlParameter("@UserName", username),
            new SqlParameter("@Password", password)
                };

                int userId = ExecuteScalar(query, userParams); // Method to execute the query and return scalar value (UserID)

                if (userId <= 0)
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check role-specific tables
                bool roleValid = false;

                switch (selectedRole)
                {
                    case "Customer":
                        roleValid = RoleExistsInTable("CUSTOMER", userId);
                        if (roleValid)
                        {
                            Form10 customerForm = new Form10();
                            customerForm.Show();
                        }
                        break;

                    case "Seller":
                        roleValid = RoleExistsInTable("SELLER", userId);
                        if (roleValid)
                        {
                            Form7 sellerForm = new Form7();
                            sellerForm.Show();
                        }
                        break;

                    case "Admin":
                        if (IsAdmin(userId))
                        {
                            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
                            adminNewDashboard.Show();
                            roleValid = true;
                        }
                        break;

                    case "Logistics Provider":
                        roleValid = RoleExistsInTable("LOGISTICS_PROVIDER", userId);
                        if (roleValid)
                        {
                            Form8 logisticsForm = new Form8();
                            logisticsForm.Show();
                        }
                        break;

                    default:
                        MessageBox.Show("Invalid role selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                if (!roleValid)
                {
                    MessageBox.Show($"The role '{selectedRole}' is not associated with this user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.Hide(); // Hide login form on successful login
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to check if a user exists in a specific role table
        private bool RoleExistsInTable(string tableName, int userId)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE UserID = @UserID";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            int count = ExecuteScalar(query, parameters);
            return count > 0;
        }

        // Helper method to check if a user is an admin
        private bool IsAdmin(int userId)
        {
            string query = "SELECT COUNT(*) FROM ISUSER WHERE UserID = @UserID AND AccountType = 'Admin'";
            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };
            int count = ExecuteScalar(query, parameters);
            return count > 0;
        }


        // Combo box for Roles (Customer, Seller, Logistics, Admin)
        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private int ExecuteScalar(string query, SqlParameter[] parameters)
        {
            int result = -1; // Default value if query fails or returns no rows

            string connectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False"; // Replace with your database connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        // Execute the query and retrieve the scalar value
                        object scalarValue = command.ExecuteScalar();
                        if (scalarValue != null && int.TryParse(scalarValue.ToString(), out int parsedValue))
                        {
                            result = parsedValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }


    }
}
