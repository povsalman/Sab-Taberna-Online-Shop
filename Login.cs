using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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
                // Query to validate user credentials and role in a single step
                string query = @"
                    SELECT u.UserID 
                    FROM ISUSER u
                    WHERE u.UserName = @UserName 
                          AND u.Password = @Password 
                          AND u.AccountType = @AccountType";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserName", username),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@AccountType", selectedRole)
                };

                int userId = ExecuteScalar(query, parameters);

                if (userId > 0)
                {
                    NavigateToDashboard(selectedRole, userId);
                    this.Hide(); // Hide login form on successful login
                }
                else
                {
                    MessageBox.Show("Invalid username, password, or role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigate to the appropriate dashboard based on role
        private void NavigateToDashboard(string role, int userId)
        {
            switch (role)
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
                    //Store admin details in AdminSessionManager
                    FetchAndStoreAdminSessionData(userId);
                    AdminNewDashboard adminDashboard = new AdminNewDashboard();
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
        }

        // Save details in AdminSessionManager 
        private void FetchAndStoreAdminSessionData(int userId)
        {
            string query = @"
                SELECT u.UserID, u.UserName, u.Contact AS Email, u.Password, 
                       a.Role AS AdminRole
                FROM ISUSER u
                INNER JOIN ADMIN a ON u.UserID = a.UserID
                WHERE u.UserID = @UserID";

            SqlParameter[] parameters = { new SqlParameter("@UserID", userId) };

            try
            {
                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Store admin data in session
                                AdminSessionManager.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                AdminSessionManager.UserName = reader.GetString(reader.GetOrdinal("UserName"));
                                AdminSessionManager.Email = reader.GetString(reader.GetOrdinal("Email"));
                                AdminSessionManager.Password = reader.GetString(reader.GetOrdinal("Password"));
                                AdminSessionManager.Role = "Admin"; // AccountType
                                AdminSessionManager.FullName = reader.GetString(reader.GetOrdinal("AdminRole")); // Role from ADMIN table
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while fetching admin session data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int ExecuteScalar(string query, SqlParameter[] parameters)
        {
            int result = -1;

            string connectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

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

