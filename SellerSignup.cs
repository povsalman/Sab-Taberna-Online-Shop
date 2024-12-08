using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class SellerSignup : Form
    {
        public SellerSignup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUpRole form2 = new SignUpRole();

            form2.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Retrieve input from text fields
            // Retrieve input from text fields
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string address = textBox3.Text.Trim(); // Full address (e.g., "Country, City")
            string ageText = textBox4.Text.Trim();
            string gender = comboBox1.SelectedItem as string;
            string contact = textBox6.Text.Trim();
            string storeName = textBox5.Text.Trim();
            string storeLocation = textBox7.Text.Trim();

            // Validate input fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(ageText) ||
                string.IsNullOrWhiteSpace(gender) || string.IsNullOrWhiteSpace(contact) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(storeLocation) || string.IsNullOrWhiteSpace(storeName))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate age
            if (!int.TryParse(ageText, out int age) || age < 0)
            {
                MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse address to separate country and city (assuming format "Country, City")
            string country = string.Empty;
            string city = string.Empty;

            string[] addressParts = address.Split(',');
            if (addressParts.Length == 2)
            {
                country = addressParts[0].Trim();
                city = addressParts[1].Trim();
            }
            else
            {
                MessageBox.Show("Invalid address format. Please use 'Country, City'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
                            INSERT INTO ISUSER (UserName, Password, Age, Gender, RegistrationDate, Contact, AccountType, Country, City)
                            VALUES (@UserName, @Password, @Age, @Gender, @RegistrationDate, @Contact, 'Seller', @Country, @City);
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
                            cmdUser.Parameters.AddWithValue("@Country", country);
                            cmdUser.Parameters.AddWithValue("@City", city);

                            // Execute and retrieve the new UserID
                            object result = cmdUser.ExecuteScalar();
                            if (result == null || !int.TryParse(result.ToString(), out userId))
                            {
                                throw new Exception("Failed to insert user.");
                            }
                        }

                        // Insert into SELLER table (SellerID, UserID, StoreName, StoreLocation)
                        string insertSellerQuery = @"
                            INSERT INTO SELLER (UserID, StoreName, StoreAddress)
                            VALUES (@UserID, @StoreName, @StoreLocation);";

                        using (SqlCommand cmdSeller = new SqlCommand(insertSellerQuery, connection, transaction))
                        {
                            cmdSeller.Parameters.AddWithValue("@UserID", userId);
                            cmdSeller.Parameters.AddWithValue("@StoreName", storeName);
                            cmdSeller.Parameters.AddWithValue("@StoreLocation", storeLocation);

                            cmdSeller.ExecuteNonQuery();
                        }

                        // Commit transaction
                        transaction.Commit();
                    }

                    MessageBox.Show("Seller registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
