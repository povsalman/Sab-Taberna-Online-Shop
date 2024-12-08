using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class CustomerDashboard : Form
    {

        private Dictionary<Product, List<Review>> productReviews;
        private List<Product> shoppingCart;




        public CustomerDashboard()
        {
            InitializeComponent();

            shoppingCart = new List<Product>();
            productReviews = new Dictionary<Product, List<Review>>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CustomerProduct productsForm = new CustomerProduct(shoppingCart);
            productsForm.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CustomerCart cartForm = new CustomerCart();
            cartForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerReview reviewForm = new CustomerReview();
            reviewForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerOrder corder = new CustomerOrder();
            corder.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string newPassword = textBoxnewpassword.Text;
            string confirmPassword = textBoxnewpasswordconfirm.Text;

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "UPDATE ISUSER SET Password = @Password WHERE UserID = @UserID;";

            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@UserID", SessionManager.UserID);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            string newUsername = textBoxusername.Text.Trim();
            string newAddress = textBoxnewadress.Text.Trim();
            string newPaymentMethod = textBoxnewpayement.Text.Trim();

            if (string.IsNullOrWhiteSpace(newUsername) &&
                string.IsNullOrWhiteSpace(newAddress) &&
                string.IsNullOrWhiteSpace(newPaymentMethod))
            {
                MessageBox.Show("Please fill in at least one field to update your profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (var conn = DBHandler.GetConnection())
            {
                try
                {
                    conn.Open();

                    if (!string.IsNullOrWhiteSpace(newUsername) || !string.IsNullOrWhiteSpace(newAddress))
                    {
                        List<string> userUpdates = new List<string>();
                        if (!string.IsNullOrWhiteSpace(newUsername))
                            userUpdates.Add("UserName = @UserName");
                        if (!string.IsNullOrWhiteSpace(newAddress))
                            userUpdates.Add("Contact = @Contact");

                        string userQuery = $@"
                    UPDATE ISUSER
                    SET {string.Join(", ", userUpdates)}
                    WHERE UserID = @UserID;";

                        using (SqlCommand userCommand = new SqlCommand(userQuery, conn))
                        {
                            userCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                            if (!string.IsNullOrWhiteSpace(newUsername))
                                userCommand.Parameters.AddWithValue("@UserName", newUsername);
                            if (!string.IsNullOrWhiteSpace(newAddress))
                                userCommand.Parameters.AddWithValue("@Contact", newAddress);

                            userCommand.ExecuteNonQuery();
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(newPaymentMethod))
                    {
                        string customerQuery = @"
                    UPDATE CUSTOMER
                    SET PaymentPreferences = @PaymentPreferences
                    WHERE UserID = @UserID;";

                        using (SqlCommand customerCommand = new SqlCommand(customerQuery, conn))
                        {
                            customerCommand.Parameters.AddWithValue("@UserID", SessionManager.UserID);
                            customerCommand.Parameters.AddWithValue("@PaymentPreferences", newPaymentMethod);

                            customerCommand.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Profile updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxusername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
