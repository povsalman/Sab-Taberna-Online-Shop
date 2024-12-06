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



    }
}
