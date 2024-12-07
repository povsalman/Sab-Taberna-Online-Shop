using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminProductMng : Form
    {
        public AdminProductMng()
        {
            InitializeComponent();
            RefreshCategoryList();
            RefreshProductList();
        }

        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            string categoryName = txtCategoryName.Text.Trim();
            string description = txtCategoryDescription.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string query = "INSERT INTO CATEGORY (CategoryName, Description) VALUES (@CategoryName, @Description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Description", description);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCategoryList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCategoryRemove_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCategoryID.Text, out int categoryId))
            {
                MessageBox.Show("Invalid Category ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string query = "DELETE FROM CATEGORY WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category and related records removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCategoryList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCategoryRefresh_Click(object sender, EventArgs e)
        {
            RefreshCategoryList();
        }

        private void RefreshCategoryList()
        {
            using (var conn = DBHandler.GetConnection())
            {
                string query = "SELECT CategoryID, CategoryName, Description FROM CATEGORY";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCategoryUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCategoryID.Text, out int categoryId))
            {
                MessageBox.Show("Invalid Category ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string categoryName = txtCategoryName.Text.Trim();
            string description = txtCategoryDescription.Text.Trim();

            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Category name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string query = "UPDATE CATEGORY SET CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Description", description);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCategoryList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void btnApproveListing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product listing approved successfully!", "Moderation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRejectListing_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product listing rejected successfully!", "Moderation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }

        // Product Section
        // Approve product
        private void btnApproveProduct_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductID.Text, out int productId))
            {
                MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string query = "UPDATE ISPRODUCT SET IsApproved = 'Yes' WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product approved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshProductList();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Reject product
        private void btnRejectProduct_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductID.Text, out int productId))
            {
                MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string query = "UPDATE ISPRODUCT SET IsApproved = 'No' WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product rejected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshProductList();
                    }
                    else
                    {
                        MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Show approved products
        private void btnShowApproved_Click(object sender, EventArgs e)
        {
            using (var conn = DBHandler.GetConnection())
            {
                string query = "SELECT * FROM ISPRODUCT WHERE IsApproved = 'Yes'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dgvProducts.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Show rejected products
        private void btnShowRejected_Click(object sender, EventArgs e)
        {
            using (var conn = DBHandler.GetConnection())
            {
                string query = "SELECT * FROM ISPRODUCT WHERE IsApproved = 'No'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dgvProducts.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Refresh product list (utility method)
        private void RefreshProductList()
        {
            using (var conn = DBHandler.GetConnection())
            {
                string query = "SELECT * FROM ISPRODUCT";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dgvProducts.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtRemoveProduct_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductID.Text.Trim(), out int productId))
            {
                MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = DBHandler.GetConnection())
            {
                string checkQuery = "SELECT IsApproved FROM ISPRODUCT WHERE ProductID = @ProductID";
                string deleteQuery = "DELETE FROM ISPRODUCT WHERE ProductID = @ProductID";

                try
                {
                    conn.Open();

                    // Check the approval status
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@ProductID", productId);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string isApproved = result.ToString();
                        if (isApproved.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Product cannot be removed as it is already approved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Remove the product
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@ProductID", productId);
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshProductList(); // Ensure the product grid is updated
                        }
                        else
                        {
                            MessageBox.Show("Failed to remove the product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
