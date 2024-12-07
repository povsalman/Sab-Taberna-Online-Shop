using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class CustomerReview : Form
    {
        public CustomerReview()
        {
            InitializeComponent();
            LoadReviewedProducts();
        }

        private void LoadReviewedProducts()
        {
            flowLayoutPanelReviews.Controls.Clear();
            string query = @"
                SELECT DISTINCT P.ProductID, P.Name, P.Price, P.ImageURL
                FROM ISPRODUCT P
                INNER JOIN ORDER_ITEM OI ON P.ProductID = OI.ProductID
                INNER JOIN ISORDER O ON O.OrderID = OI.OrderID
                WHERE O.CustomerID = @CustomerID";

            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@CustomerID", SessionManager.UserID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product(
                                    productID: Convert.ToInt32(reader["ProductID"]),
                                    name: reader["Name"].ToString(),
                                    price: reader["Price"].ToString(),
                                    description: null, // Not needed here
                                    stockLevel: 0, // Not needed here
                                    imagePath: reader["ImageURL"].ToString()
                                );

                                AddProductToReviewPanel(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading reviewed products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddProductToReviewPanel(Product product)
        {
            Panel productPanel = new Panel
            {
                Size = new Size(300, 500),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(15),
                BackColor = Color.FromArgb(180, 255, 255, 255)
            };

            PictureBox pictureBox = new PictureBox
            {
                ImageLocation = product.ImagePath,
                Size = new Size(280, 200),
                Location = new Point(10, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            Label lblName = new Label
            {
                Text = product.Name,
                Location = new Point(10, 220),
                AutoSize = false,
                Size = new Size(280, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            Label lblPrice = new Label
            {
                Text = $"Price: {product.Price}",
                Location = new Point(10, 270),
                AutoSize = false,
                Size = new Size(280, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            Button btnRate = new Button
            {
                Text = "Rate",
                Location = new Point(90, 320),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 40)
            };

            btnRate.Click += (s, e) => OpenRatingForm(product);

            productPanel.Controls.Add(pictureBox);
            productPanel.Controls.Add(lblName);
            productPanel.Controls.Add(lblPrice);
            productPanel.Controls.Add(btnRate);

            flowLayoutPanelReviews.Controls.Add(productPanel);
        }

        private void OpenRatingForm(Product product)
        {
            using (Form ratingForm = new Form())
            {
                ratingForm.Text = $"Rate {product.Name}";
                ratingForm.Size = new Size(600, 500);

                Label lblRating = new Label { Text = "Rating (1-5):", Location = new Point(50, 50), AutoSize = true };
                NumericUpDown nudRating = new NumericUpDown
                {
                    Location = new Point(200, 50),
                    Minimum = 1,
                    Maximum = 5,
                    Value = 1
                };

                Label lblComment = new Label { Text = "Comment:", Location = new Point(50, 100), AutoSize = true };
                TextBox txtComment = new TextBox { Location = new Point(150, 100), Size = new Size(200, 100), Multiline = true };

                Button btnSubmit = new Button
                {
                    Text = "Submit",
                    Location = new Point(150, 220),
                    Size = new Size(150, 50),
                    BackColor = Color.LightGreen
                };

                btnSubmit.Click += (s, e) =>
                {
                    SubmitReview(product, (int)nudRating.Value, txtComment.Text);
                    ratingForm.Close();
                };

                ratingForm.Controls.Add(lblRating);
                ratingForm.Controls.Add(nudRating);
                ratingForm.Controls.Add(lblComment);
                ratingForm.Controls.Add(txtComment);
                ratingForm.Controls.Add(btnSubmit);

                ratingForm.ShowDialog();
            }
        }

        private void SubmitReview(Product product, int rating, string comment)
        {
            string query = @"
                INSERT INTO REVIEW (ProductID, CustomerID, Rating, Comment, ReviewDate)
                VALUES (@ProductID, @CustomerID, @Rating, @Comment, GETDATE())";

            try
            {
                using (var conn = DBHandler.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ProductID", product.ProductID);
                        command.Parameters.AddWithValue("@CustomerID", SessionManager.UserID);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Thank you for your review!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting review: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerDashboard form10 = new CustomerDashboard();
            form10.Show();
            this.Close();
        }

    }
}
