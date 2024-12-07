using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminUserMng : Form
    {

        public AdminUserMng()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please enter a User ID.");
                return;
            }

            string query = "UPDATE SELLER SET VerificationStatus = 'Verified' WHERE UserID = @UserID";

            ExecuteQuery(query, new SqlParameter("@UserID", txtUserID.Text));
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please enter a User ID.");
                return;
            }

            string query = "UPDATE SELLER SET VerificationStatus = 'Rejected' WHERE UserID = @UserID";

            ExecuteQuery(query, new SqlParameter("@UserID", txtUserID.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtUserID.Text) || string.IsNullOrWhiteSpace(comboAccountStatus.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Parse UserID
            if (!int.TryParse(txtUserID.Text, out int userId))
            {
                MessageBox.Show("Invalid UserID format.");
                return;
            }

            // Update ISUSER Table
            string userUpdateQuery = @"
                UPDATE ISUSER
                SET UserName = COALESCE(@UserName, UserName),
                    Password = COALESCE(@Password, Password),
                    Gender = COALESCE(@Gender, Gender),
                    Contact = COALESCE(@Contact, Contact)
                WHERE UserID = @UserID";

            List<SqlParameter> userParameters = new List<SqlParameter>
            {
                new SqlParameter("@UserID", userId),
                new SqlParameter("@UserName", string.IsNullOrWhiteSpace(txtUsername.Text) ? DBNull.Value : (object)txtUsername.Text),
                new SqlParameter("@Password", string.IsNullOrWhiteSpace(txtPassword.Text) ? DBNull.Value : (object)txtPassword.Text),
                new SqlParameter("@Gender", string.IsNullOrWhiteSpace(comboGender.Text) ? DBNull.Value : (object)comboGender.Text),
                new SqlParameter("@Contact", string.IsNullOrWhiteSpace(txtContact.Text) ? DBNull.Value : (object)txtContact.Text),
            };

            ExecuteQuery(userUpdateQuery, userParameters.ToArray());

            // Check if UserID exists in SELLER or CUSTOMER tables
            string queryCheckSeller = "SELECT COUNT(*) FROM SELLER WHERE UserID = @UserID";
            string queryCheckCustomer = "SELECT COUNT(*) FROM CUSTOMER WHERE UserID = @UserID";

            int sellerExists = ExecuteScalar(queryCheckSeller, new SqlParameter[] { new SqlParameter("@UserID", userId) });
            int customerExists = ExecuteScalar(queryCheckCustomer, new SqlParameter[] { new SqlParameter("@UserID", userId) });

            // Update SELLER Table
            if (sellerExists > 0)
            {
                string sellerUpdateQuery = @"
                    UPDATE SELLER
                    SET StoreName = COALESCE(@StoreName, StoreName),
                        VerificationStatus = COALESCE(@VerificationStatus, VerificationStatus),
                        AccountStatus = @AccountStatus
                    WHERE UserID = @UserID";

                List<SqlParameter> sellerParameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@StoreName", string.IsNullOrWhiteSpace(txtName.Text) ? DBNull.Value : (object)txtName.Text),
                    new SqlParameter("@VerificationStatus", string.IsNullOrWhiteSpace(comboVerification.Text) ? DBNull.Value : (object)comboVerification.Text),
                    new SqlParameter("@AccountStatus", comboAccountStatus.Text)
                };

                ExecuteQuery(sellerUpdateQuery, sellerParameters.ToArray());
            }

            // Update CUSTOMER Table
            else if (customerExists > 0)
            {
                string customerUpdateQuery = @"
                    UPDATE CUSTOMER
                    SET Name = COALESCE(@Name, Name),
                        AccountStatus = @AccountStatus
                    WHERE UserID = @UserID";

                List<SqlParameter> customerParameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserID", userId),
                    new SqlParameter("@Name", string.IsNullOrWhiteSpace(txtName.Text) ? DBNull.Value : (object)txtName.Text),
                    new SqlParameter("@AccountStatus", comboAccountStatus.Text)
                };

                ExecuteQuery(customerUpdateQuery, customerParameters.ToArray());
            }
            else
            {
                MessageBox.Show("User ID not found in either SELLER or CUSTOMER table.");
                return;
            }

            MessageBox.Show("User information updated successfully.");
        }



        // Will show only customers in the table
        private void btnShowCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT 
                ISUSER.UserID,
                ISUSER.UserName,
                ISUSER.Password,
                ISUSER.Gender,
                ISUSER.Contact,
                ISUSER.Age,
                ISUSER.RegistrationDate,
                CUSTOMER.Name,
                CUSTOMER.PaymentPreferences,
                CUSTOMER.AccountStatus
            FROM ISUSER
            INNER JOIN CUSTOMER ON ISUSER.UserID = CUSTOMER.UserID
            WHERE ISUSER.AccountType = 'Customer'";

                // Use the DisplayData function to execute the query and bind the results to the DataGridView
                DisplayData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Will show only sellers in the table
        private void btnShowSellers_Click(object sender, EventArgs e)
        {
            try
            {
                string query = @"
            SELECT 
                ISUSER.UserID,
                ISUSER.UserName,
                ISUSER.Password,
                ISUSER.Gender,
                ISUSER.Contact,
                ISUSER.Age,
                ISUSER.RegistrationDate,
                SELLER.StoreName,
                SELLER.StoreAddress,
                SELLER.VerificationStatus,
                SELLER.AccountStatus
            FROM ISUSER
            INNER JOIN SELLER ON ISUSER.UserID = SELLER.UserID
            WHERE ISUSER.AccountType = 'Seller'";

                // Use the DisplayData function to execute the query and bind the results to the DataGridView
                DisplayData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Operation successful!" : "No changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private int ExecuteScalar(string query, SqlParameter[] parameters)
        {
            int result = 0;

            try
            {
                using (var conn = DBHandler.GetConnection()) // Ensure your connection string is defined
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Add parameters to the command
                        cmd.Parameters.AddRange(parameters);

                        // Execute the query and get the scalar result
                        result = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return result;
        }



        private void DisplayData(string query)
        {
            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        Acc.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
