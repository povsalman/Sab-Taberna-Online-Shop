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
        private string connectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False"; // Replace with your database connection string.


        public AdminNewDashboard()
        {
            InitializeComponent();
            LoadAdminData();
        
        }

        public AdminNewDashboard(string username)
        {
            InitializeComponent();
            adminUsername = username;
            LoadAdminData();
        }

        private void LoadAdminData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, Role, ShopName FROM ADMIN WHERE Username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", adminUsername);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            label3.Text = reader["Username"].ToString(); // Username
                            label5.Text = reader["Role"].ToString();     // Role
                            label7.Text = reader["ShopName"].ToString(); // Shop Name
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin data: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e) // Save Profile Changes
        {
            string newUsername = txtUsername.Text.Trim();
            string newAddress = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ADMIN SET Username = @newUsername, Address = @newAddress WHERE Username = @oldUsername";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newUsername", newUsername);
                        cmd.Parameters.AddWithValue("@newAddress", newAddress);
                        cmd.Parameters.AddWithValue("@oldUsername", adminUsername);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Profile updated successfully!");
                adminUsername = newUsername; // Update the stored username.
                LoadAdminData(); // Refresh the displayed data.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e) // Change Password
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
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ADMIN SET Password = @newPassword WHERE Username = @username";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@username", adminUsername);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Password changed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing password: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to User and Seller Management (Form19)
            AdminUserMng userSellerManagement = new AdminUserMng();
            userSellerManagement.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Navigate to Product and Category Management (Form20)
            AdminProductMng productCategoryManagement = new AdminProductMng();
            productCategoryManagement.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            // Navigate to Platform Settings (Placeholder for now)
            MessageBox.Show("Platform Settings Section is under development!", "Platform Settings");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminReports reportsForm = new AdminReports();
            reportsForm.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AdminReviews reviewsForm = new AdminReviews();
            reviewsForm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login loginPage = new Login();
            loginPage.Show();
            this.Hide();
        }
    }
}
