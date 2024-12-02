using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Microsoft.Data.SqlClient;


namespace DB_Proj_00
{
    public partial class AdminReviews : Form
    {

        SqlConnection con;
        string ConnectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False";

        public AdminReviews()
        {
            InitializeComponent();

            con = new SqlConnection(ConnectionString);

            LoadReviews();

        }

        private void LoadReviews()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    string query = @"
                SELECT
                    r.ReviewID, 
                    r.ProductID, 
                    p.Name AS ProductName, 
                    r.CustomerID, 
                    r.Rating, 
                    r.Comment AS ReviewText, 
                    r.ReviewDate,
                    p.IsFlaggedInappropriate
                FROM REVIEW r
                INNER JOIN ISPRODUCT p ON r.ProductID = p.ProductID
                INNER JOIN CUSTOMER c ON r.CustomerID = c.CustomerID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    DataTable reviewsTable = new DataTable();
                    adapter.Fill(reviewsTable);

                    // Create a new column to store "Yes"/"No" values for the flag status
                    reviewsTable.Columns.Add("FlaggedStatus", typeof(string));

                    // Populate the new column with "Yes" or "No" based on the IsFlaggedInappropriate value
                    foreach (DataRow row in reviewsTable.Rows)
                    {
                        bool isFlagged = row["IsFlaggedInappropriate"] != DBNull.Value && (bool)row["IsFlaggedInappropriate"];
                        row["FlaggedStatus"] = isFlagged ? "Yes" : "No";
                    }

                    // Remove the IsFlaggedInappropriate column so it does not appear in the DataGridView
                    reviewsTable.Columns.Remove("IsFlaggedInappropriate");

                    // Bind the DataTable to the DataGridView
                    dataGridViewReviews.DataSource = reviewsTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reviews: " + ex.Message);
            }
        }



        private void btnFlagProduct_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReviewID.Text))
            {
                MessageBox.Show("Please enter a Review ID.");
                return;
            }

            int reviewID;
            if (!int.TryParse(txtReviewID.Text, out reviewID))
            {
                MessageBox.Show("Review ID must be a valid number.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    string selectQuery = @"
                        SELECT ProductID, Rating 
                        FROM REVIEW 
                        WHERE ReviewID = @ReviewID";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                    selectCommand.Parameters.AddWithValue("@ReviewID", reviewID);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int productID = (int)reader["ProductID"];
                        int rating = (int)reader["Rating"];
                        reader.Close();

                        if (rating <= 2)
                        {
                            string updateQuery = @"
                                UPDATE ISPRODUCT 
                                SET IsFlaggedInappropriate = 1 
                                WHERE ProductID = @ProductID";

                            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                            updateCommand.Parameters.AddWithValue("@ProductID", productID);
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Product flagged as inappropriate.");
                        }
                        else
                        {
                            MessageBox.Show("The review's rating is above 2. No action taken.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Review ID not found.");
                    }
                }

                LoadReviews();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error flagging product: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }

        private void btnUnflagProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReviewID.Text))
            {
                MessageBox.Show("Please enter a Review ID.");
                return;
            }

            int reviewID;
            if (!int.TryParse(txtReviewID.Text, out reviewID))
            {
                MessageBox.Show("Review ID must be a valid number.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();

                    // Query to check if the product is flagged
                    string selectQuery = @"
                SELECT IsFlaggedInappropriate, ProductID
                FROM ISPRODUCT 
                WHERE ProductID IN (SELECT ProductID FROM REVIEW WHERE ReviewID = @ReviewID)";

                    SqlCommand selectCommand = new SqlCommand(selectQuery, con);
                    selectCommand.Parameters.AddWithValue("@ReviewID", reviewID);

                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        bool isFlagged = reader["IsFlaggedInappropriate"] != DBNull.Value && (bool)reader["IsFlaggedInappropriate"];
                        int productID = (int)reader["ProductID"];
                        reader.Close();

                        // If the product is flagged, unflag it by setting IsFlaggedInappropriate to 0
                        if (isFlagged)
                        {
                            string updateQuery = @"
                        UPDATE ISPRODUCT 
                        SET IsFlaggedInappropriate = 0 
                        WHERE ProductID = @ProductID";

                            SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                            updateCommand.Parameters.AddWithValue("@ProductID", productID);
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Product has been unflagged.");
                        }
                        else
                        {
                            MessageBox.Show("The product is not flagged.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Review ID not found.");
                    }
                }

                // Refresh the DataGridView to reflect the changes
                LoadReviews();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error unflagging product: " + ex.Message);
            }
        }

        private void txtReviewID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
