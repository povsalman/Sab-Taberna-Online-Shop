using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class AdminPlatform : Form
    {
        public AdminPlatform()
        {
            InitializeComponent();
            RefreshPlatformSettings();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }

        private void btnUpdatePlatform_Click(object sender, EventArgs e)
        {
            // Retrieve values from text fields
            string newShopName = txtShopName.Text.Trim();
            string newShopEmail = txtShopEmail.Text.Trim();
            string newShopContact = txtShopContact.Text.Trim();
            string newShopBranchesText = txtShopBranches.Text.Trim();
            int newShopBranches;

            // Validate numeric input for TotalBranches
            if (!int.TryParse(newShopBranchesText, out newShopBranches) || newShopBranches < 0)
            {
                MessageBox.Show("Please enter a valid number for Total Branches.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();

                    // Update query
                    string updateQuery = @"
                        UPDATE PLATFORM_SETTINGS
                        SET ShopName = @ShopName,
                            ShopEmail = @ShopEmail,
                            ShopContactHelpline = @ShopContact,
                            TotalBranches = @TotalBranches,
                            LastUpdated = GETDATE(),
                            UpdatedBy = @UpdatedBy
                        WHERE SettingID = 1"; // Assuming there is always one record

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Assign parameters
                        command.Parameters.AddWithValue("@ShopName", newShopName);
                        command.Parameters.AddWithValue("@ShopEmail", newShopEmail);
                        command.Parameters.AddWithValue("@ShopContact", newShopContact);
                        command.Parameters.AddWithValue("@TotalBranches", newShopBranches);
                        command.Parameters.AddWithValue("@UpdatedBy", AdminSessionManager.UserID); // Replace 1 with the actual admin UserID

                        // Execute update
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Platform settings updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshPlatformSettings(); // Refresh the labels
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the settings.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the platform settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void RefreshPlatformSettings()
        {
            try
            {
                // Example query to fetch the current platform settings
                string query = "SELECT TOP 1 * FROM PLATFORM_SETTINGS";

                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblShopName.Text = reader["ShopName"].ToString();
                                lblShopEmail.Text = reader["ShopEmail"].ToString();
                                lblShopContact.Text = reader["ShopContactHelpline"].ToString();
                                lblShopBranches.Text = reader["TotalBranches"].ToString();
                                lblShopLastUpdated.Text = Convert.ToDateTime(reader["LastUpdated"]).ToString("yyyy-MM-dd");
                                lblShopUpdatedBy.Text = reader["UpdatedBy"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing platform settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}