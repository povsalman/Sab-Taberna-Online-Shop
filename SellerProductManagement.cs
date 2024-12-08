using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class SellerProductManagement : Form
    {
        private int? selectedProductId = null; // To hold the product ID during editing

        public SellerProductManagement()
        {
            InitializeComponent();
            PopulateProductGrid();
            HideInputControls();
        }

        private void PopulateProductGrid()
        {
            if (!SellerSessionManager.IsLoggedIn)
            {
                MessageBox.Show("Please log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
        SELECT ProductID, Name, Price, StockLevel, Description 
        FROM ISPRODUCT
        WHERE SellerID = @SellerID";

            DataTable dt = new DataTable();

            try
            {
                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@SellerID", SellerSessionManager.SellerID); // Use SellerID

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }

                dgvProducts.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Customizedgv()
        {
            // Set the column headers (use the actual column names as returned by the SQL query)
            dgvProducts.Columns["Name"].HeaderText = "Product Name";
            dgvProducts.Columns["Price"].HeaderText = "Price";
            dgvProducts.Columns["StockLevel"].HeaderText = "Stock Level";
            dgvProducts.Columns["Description"].HeaderText = "Description";

            // Optional: Adjust column widths
            dgvProducts.Columns["Name"].Width = 150;
            dgvProducts.Columns["Price"].Width = 200;
            dgvProducts.Columns["StockLevel"].Width = 200;
            dgvProducts.Columns["Description"].Width = 450;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Show the input controls
            txtProductName.Visible = true;
            numPrice.Visible = true;
            numStockLevel.Visible = true;
            txtDescription.Visible = true;
            btnSaveNew.Visible = true;
            numSellerID.Visible = true;
            numCategoryID.Visible = true;

            // Clear existing values
            txtProductName.Clear();
            numPrice.Value = 0;
            numStockLevel.Value = 0;
            txtDescription.Clear();

            // Enable the fields for input
            txtProductName.Enabled = true;
            numPrice.Enabled = true;
            numStockLevel.Enabled = true;
            txtDescription.Enabled = true;

            // Change button text to "Save New Product"
            btnSaveNew.Text = "Save New Product";
        }


        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Get the selected product's details
                string productName = dgvProducts.SelectedRows[0].Cells["Name"].Value.ToString();
                decimal price = Convert.ToDecimal(dgvProducts.SelectedRows[0].Cells["Price"].Value);
                int stockLevel = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["StockLevel"].Value);
                string description = dgvProducts.SelectedRows[0].Cells["Description"].Value.ToString();

                // Show the input controls
                txtProductName.Visible = true;
                numPrice.Visible = true;
                numStockLevel.Visible = true;
                txtDescription.Visible = true;
                btnSaveChanges.Visible = true;
                numSellerID.Visible = true;
                numCategoryID.Visible = true;

                // Pre-fill the fields with the selected product's data
                txtProductName.Text = productName;
                numPrice.Value = price;
                numStockLevel.Value = stockLevel;
                txtDescription.Text = description;

                // Enable the fields for editing
                txtProductName.Enabled = true;
                numPrice.Enabled = true;
                numStockLevel.Enabled = true;
                txtDescription.Enabled = true;

                // Change button text to "Save Changes"
                btnSaveChanges.Text = "Save Changes";
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Get the ProductID of the selected row
                int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);

                // Confirm the deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    // SQL query to delete the selected product
                    string deleteQuery = "DELETE FROM ISPRODUCT WHERE ProductID = @ProductID";

                    using (var connection = DBHandler.GetConnection())
                    {
                        try
                        {
                            connection.Open();
                            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@ProductID", productId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    PopulateProductGrid(); // Refresh the grid
                                }
                                else
                                {
                                    MessageBox.Show("Product deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void HideInputControls()
        {
            // Hide the controls after save or cancel
            txtProductName.Visible = false;
            numPrice.Visible = false;
            numStockLevel.Visible = false;
            txtDescription.Visible = false;
            btnSaveNew.Visible = false;
            btnSaveChanges.Visible = false;
            numCategoryID.Visible = false;
            numSellerID.Visible = false;
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard();
            sellerDashboard.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateProductGrid();
            MessageBox.Show("Product data refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            // Validate that all fields have been filled out correctly
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                numPrice.Value <= 0 ||
                numStockLevel.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                numSellerID.Value <= 0 ||  // Ensure SellerID is provided (NumericUpDown check)
                numCategoryID.Value <= 0)   // Ensure CategoryID is provided (NumericUpDown check)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SQL query to insert a new product, including SellerID and CategoryID
            string query = @"INSERT INTO ISPRODUCT (Name, Price, StockLevel, Description, SellerID, CategoryID) 
                     VALUES (@Name, @Price, @StockLevel, @Description, @SellerID, @CategoryID)";

            using (var connection = DBHandler.GetConnection()) // Ensure DBHandler.GetConnection() works as expected
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", numPrice.Value);
                        cmd.Parameters.AddWithValue("@StockLevel", numStockLevel.Value);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@SellerID", Convert.ToInt32(numSellerID.Value));  // Use NumericUpDown value for SellerID
                        cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(numCategoryID.Value)); // Use NumericUpDown value for CategoryID

                        // Execute the query and get the number of affected rows
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateProductGrid(); // Refresh the grid
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // After saving, hide the input controls to reset the UI
            HideInputControls();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validate that all fields have been filled out correctly
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                numPrice.Value <= 0 ||
                numStockLevel.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                numSellerID.Value <= 0 ||  // Ensure SellerID is provided (NumericUpDown check)
                numCategoryID.Value <= 0)   // Ensure CategoryID is provided (NumericUpDown check)
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure a row is selected for editing
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the ProductID of the selected row
            int productId = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);

            // SQL query to update the existing product, including SellerID and CategoryID
            string query = @"UPDATE ISPRODUCT 
                     SET Name = @Name, Price = @Price, StockLevel = @StockLevel, Description = @Description, 
                         SellerID = @SellerID, CategoryID = @CategoryID
                     WHERE ProductID = @ProductID";

            using (var connection = DBHandler.GetConnection()) // Ensure DBHandler.GetConnection() works as expected
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@Price", numPrice.Value);
                        cmd.Parameters.AddWithValue("@StockLevel", numStockLevel.Value);
                        cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmd.Parameters.AddWithValue("@SellerID", Convert.ToInt32(numSellerID.Value));  // Use NumericUpDown value for SellerID
                        cmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(numCategoryID.Value)); // Use NumericUpDown value for CategoryID
                        cmd.Parameters.AddWithValue("@ProductID", productId); // Add ProductID for update

                        // Execute the query and get the number of affected rows
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateProductGrid(); // Refresh the grid
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while updating the product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // After saving, hide the input controls to reset the UI
            HideInputControls();
        }



    }
}
