using Microsoft.Data.SqlClient;
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
    public partial class AdminNewDashboard : Form
    {
        private string adminUsername; // Store logged-in admin username.

        public AdminNewDashboard()
        {
            InitializeComponent();
            LoadAdminData();
        }

        private void LoadAdminData()
        {
            // Use AdminSessionManager to set label values
            lblUsername.Text = AdminSessionManager.UserName; // Display logged-in admin's username
            lblRole.Text = AdminSessionManager.FullName;     // Display logged-in admin's role
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string newUsername = txtUsername.Text.Trim();
            string newContact = txtContact.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newContact))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    UPDATE ISUSER
                    SET UserName = @newUsername, Contact = @newContact
                    WHERE UserID = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newUsername", newUsername);
                        cmd.Parameters.AddWithValue("@newContact", newContact);
                        cmd.Parameters.AddWithValue("@userID", AdminSessionManager.UserID);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Update session with new username
                AdminSessionManager.UserName = newUsername;

                MessageBox.Show("Profile updated successfully!");
                LoadAdminData(); // Refresh displayed data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        // dashboard change password
        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPass.Text.Trim();
            string confirmPassword = txtNewConfirmPass.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    string query = @"
                    UPDATE ISUSER
                    SET Password = @newPassword
                    WHERE UserID = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@userID", AdminSessionManager.UserID);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Optionally update the session
                AdminSessionManager.Password = newPassword;

                MessageBox.Show("Password changed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnUserSeller_Click(object sender, EventArgs e)
        {
            // Navigate to User and Seller Management (Form19)
            AdminUserMng userSellerManagement = new AdminUserMng();
            userSellerManagement.Show();
            this.Hide();
        }

        private void btnProductCategory_Click(object sender, EventArgs e)
        {
            // Navigate to Product and Category Management (Form20)
            AdminProductMng productCategoryManagement = new AdminProductMng();
            productCategoryManagement.Show();
            this.Hide();
        }

        private void btnOrderOversight_Click(object sender, EventArgs e)
        {
            var orders = new List<Order>
            {
                new Order(1, "Bilal", "Seller A", "Processing", 100.50m, DateTime.Now.AddDays(-2)),
                new Order(2, "Salman", "Seller B", "Shipped", 250.75m, DateTime.Now.AddDays(-1)),
                new Order(3, "Arshiq", "Seller C", "Delivered", 320.20m, DateTime.Now.AddDays(-3))
            };

            AdminOrderOversight orderOversightForm = new AdminOrderOversight(orders);
            orderOversightForm.Show();
            this.Hide();
        }

        private void btnPlatform_Click(object sender, EventArgs e)
        {
            // Navigate to Platform Settings (Placeholder for now)
            MessageBox.Show("Platform Settings Section is under development!", "Platform Settings");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            AdminReports reportsForm = new AdminReports();
            reportsForm.Show();
            this.Hide();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            AdminReviews reviewsForm = new AdminReviews();
            reviewsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out and clear session
            AdminSessionManager.ClearSession();
            Login loginPage = new Login();
            loginPage.Show();
            this.Hide();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

    }
}
