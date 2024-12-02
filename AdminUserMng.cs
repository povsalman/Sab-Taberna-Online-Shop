using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminUserMng : Form
    {
        private string connectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False"; // Replace with your actual database connection string

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

            string userUpdateQuery = @"
        UPDATE ISUSER 
        SET UserID = @UserID";

            List<SqlParameter> userParameters = new List<SqlParameter>
    {
        new SqlParameter("@UserID", txtUserID.Text)
    };

            // Conditionally update UserName
            if (!string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                userUpdateQuery += ", UserName = @UserName";
                userParameters.Add(new SqlParameter("@UserName", txtUsername.Text));
            }

            // Conditionally update Password
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                userUpdateQuery += ", Password = @Password";
                userParameters.Add(new SqlParameter("@Password", txtPassword.Text));
            }

            // Conditionally update Gender
            if (!string.IsNullOrWhiteSpace(comboGender.Text))
            {
                userUpdateQuery += ", Gender = @Gender";
                userParameters.Add(new SqlParameter("@Gender", comboGender.Text));
            }

            // Conditionally update Contact
            if (!string.IsNullOrWhiteSpace(txtContact.Text))
            {
                userUpdateQuery += ", Contact = @Contact";
                userParameters.Add(new SqlParameter("@Contact", txtContact.Text));
            }

            // First, check if UserID exists in the SELLER table
            string queryCheckSeller = "SELECT COUNT(*) FROM SELLER WHERE UserID = @UserID";
            SqlParameter[] checkSellerParameters = new SqlParameter[]
            {
        new SqlParameter("@UserID", txtUserID.Text)
            };

            int sellerExists = ExecuteScalar(queryCheckSeller, checkSellerParameters);

            // Then, check if UserID exists in the CUSTOMER table
            string queryCheckCustomer = "SELECT COUNT(*) FROM CUSTOMER WHERE UserID = @UserID";
            SqlParameter[] checkCustomerParameters = new SqlParameter[]
            {
        new SqlParameter("@UserID", txtUserID.Text)
            };

            int customerExists = ExecuteScalar(queryCheckCustomer, checkCustomerParameters);

            // If the UserID is found in SELLER table
            if (sellerExists > 0)
            {
                string sellerUpdateQuery = @"
            UPDATE SELLER
            SET AccountStatus = @AccountStatus"; // Only AccountStatus is always updated for SELLER

                List<SqlParameter> sellerParameters = new List<SqlParameter>
        {
            new SqlParameter("@AccountStatus", comboAccountStatus.Text),
            new SqlParameter("@SellerID", txtUserID.Text)
        };

                // Conditionally update StoreName
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    sellerUpdateQuery += ", StoreName = @StoreName";
                    sellerParameters.Add(new SqlParameter("@StoreName", txtName.Text));
                }

                // Conditionally update VerificationStatus
                if (!string.IsNullOrWhiteSpace(comboVerification.Text))
                {
                    sellerUpdateQuery += ", VerificationStatus = @VerificationStatus";
                    sellerParameters.Add(new SqlParameter("@VerificationStatus", comboVerification.Text));
                }

                // Execute update on ISUSER table
                ExecuteQuery(userUpdateQuery, userParameters.ToArray()); // Convert List to array
                                                                         // Execute update on SELLER table
                ExecuteQuery(sellerUpdateQuery, sellerParameters.ToArray()); // Convert List to array
            }
            // If the UserID is found in CUSTOMER table
            else if (customerExists > 0)
            {
                string customerUpdateQuery = @"
            UPDATE CUSTOMER
            SET AccountStatus = @AccountStatus"; // AccountStatus is always updated for CUSTOMER

                List<SqlParameter> customerParameters = new List<SqlParameter>
        {
            new SqlParameter("@AccountStatus", comboAccountStatus.Text),
            new SqlParameter("@CustomerID", txtUserID.Text)
        };

                // Conditionally update Name
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    customerUpdateQuery += ", Name = @Name";
                    customerParameters.Add(new SqlParameter("@Name", txtName.Text));
                }

                // Execute update on ISUSER table
                ExecuteQuery(userUpdateQuery, userParameters.ToArray()); // Convert List to array
                                                                         // Execute update on CUSTOMER table
                ExecuteQuery(customerUpdateQuery, customerParameters.ToArray()); // Convert List to array
            }
            else
            {
                MessageBox.Show("User ID not found in either SELLER or CUSTOMER table.");
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
                ISUSER.Gender,
                ISUSER.Contact,
                ISUSER.Age,
                ISUSER.RegistrationDate,
                CUSTOMER.CustomerID,
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
                ISUSER.Gender,
                ISUSER.Contact,
                ISUSER.Age,
                ISUSER.RegistrationDate,
                SELLER.SellerID,
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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
                using (SqlConnection conn = new SqlConnection(connectionString)) // Ensure your connection string is defined
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
                using (SqlConnection conn = new SqlConnection(connectionString))
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
