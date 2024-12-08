using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DB_Proj_00
{
    public partial class LogisticsShipping : Form
    {
        public LogisticsShipping()
        {
            InitializeComponent();
        }

        private void btnAssignAgent_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch pending orders
                string query = @"
            SELECT 
                o.OrderID, 
                o.ShippingAddress, 
                o.TotalAmount, 
                o.ShippingStatus 
            FROM 
                ISORDER o
            WHERE 
                o.ShippingStatus = 'Pending'";

                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the data to a DataGridView for display
                        DataGridView dgvOrderDetails = new DataGridView
                        {
                            DataSource = dataTable,
                            Dock = DockStyle.Fill,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                        };

                        panelOrderDetails.Controls.Clear();
                        panelOrderDetails.Controls.Add(dgvOrderDetails);

                        // Add a button column for assigning delivery agent
                        if (!dgvOrderDetails.Columns.Contains("Assign"))
                        {
                            DataGridViewButtonColumn btnAssign = new DataGridViewButtonColumn
                            {
                                HeaderText = "Assign",
                                Text = "Assign",
                                UseColumnTextForButtonValue = true,
                                Name = "btnAssign"
                            };
                            dgvOrderDetails.Columns.Add(btnAssign);
                        }

                        dgvOrderDetails.CellClick += (s, ev) =>
                        {
                            if (ev.RowIndex >= 0 && ev.ColumnIndex == dgvOrderDetails.Columns["btnAssign"].Index)
                            {
                                int orderId = Convert.ToInt32(dgvOrderDetails.Rows[ev.RowIndex].Cells["OrderID"].Value);

                                // Update the shipping status in the database
                                AssignDeliveryAgent(orderId);
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AssignDeliveryAgent(int orderId)
        {
            try
            {
                string updateQuery = @"
            UPDATE ISORDER 
            SET ShippingStatus = 'Shipped'
            WHERE OrderID = @OrderID";

                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order has been assigned.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to assign the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTrackShipment_Click(object sender, EventArgs e)
        {
            // Placeholder for Track Shipment functionality
            MessageBox.Show("Track Shipment functionality will be implemented here.", "Info");
        }

        private void btnPendingOrders_Click(object sender, EventArgs e)
        {
            // Placeholder for View Pending Orders functionality
            MessageBox.Show("View Pending Orders functionality will be implemented here.", "Info");
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            // Placeholder for Generate Shipping Reports functionality
            MessageBox.Show("Generate Shipping Reports functionality will be implemented here.", "Info");
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            SellerDashboard sellerDashboard = new SellerDashboard();
            sellerDashboard.Show();
            this.Close();
        }

    }
}
