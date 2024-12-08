using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            panel2.BringToFront();
            LoadData();
        }

        private void LoadData()
        {
            // Use AdminSessionManager to set label values
            int currentID = AdminSessionManager.UserID;
            // Display logged-in Seller's info
            LoadUserInfo(currentID);
        }

        public void LoadUserInfo(int userId) // Or you can pass username if needed
        {
            // Set up your SQL query
            string query = @"
        SELECT UserName, AccountType, StoreName
        FROM ISUSER
        LEFT JOIN SELLER ON ISUSER.UserID = SELLER.UserID
        WHERE ISUSER.UserID = @UserID;";  // Or use UserName instead of UserID

            // Create a connection to the database
            using (var connection = DBHandler.GetConnection())
            {
                try
                {
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL query
                        cmd.Parameters.AddWithValue("@UserID", userId); // Or use UserName if passing UserName

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // If data is returned
                            if (reader.Read())
                            {
                                // Set the label texts based on the retrieved data
                                string userName = reader["UserName"].ToString();
                                string accountStatus = reader["AccountType"].ToString();
                                string shopName = reader["StoreName"].ToString();

                                // Assuming you have labels named labelUserName, labelAccountStatus, and labelShopName
                                label16.Text = "Username: " + userName;
                                label17.Text = "Account Status: " + accountStatus;
                                label18.Text = "Shop Name: " + (string.IsNullOrEmpty(shopName) ? "No shop" : shopName);
                            }
                            else
                            {
                                // Handle the case where no data is found
                                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            // panel3.Visible = false;
            // panel4.Visible = false;
            // panel5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Navigate to the Product Management page
            Form16 productManagementForm = new Form16();
            productManagementForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Navigate to the Order Fulfillment page
            Form17 orderFulfillmentForm = new Form17();
            orderFulfillmentForm.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to the Sales Reports and Analytics page
            Form18 salesReportForm = new Form18();
            salesReportForm.Show();
            this.Hide();
        }


        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login form1 = new Login();
            form1.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text.Trim();
            string confirmPassword = textBox2.Text.Trim();

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string newUsername = textBox3.Text.Trim();
            string newContact = textBox4.Text.Trim();
            string newShopName = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newContact) || string.IsNullOrEmpty(newShopName))
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
                    SET UserName = @newUsername, Contact = @newContact, shopName = @newShopName
                    WHERE UserID = @userID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newUsername", newUsername);
                        cmd.Parameters.AddWithValue("@newContact", newContact);
                        cmd.Parameters.AddWithValue("@newShopName", newShopName);
                        cmd.Parameters.AddWithValue("@userID", AdminSessionManager.UserID);

                        cmd.ExecuteNonQuery();
                    }
                }


                MessageBox.Show("Profile updated successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating profile: " + ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
