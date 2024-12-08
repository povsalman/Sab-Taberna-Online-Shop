using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders()
        {
            string query = @"
        SELECT 
            o.OrderID, 
            c.Name, 
            p.Name, 
            o.ShippingStatus 
        FROM 
            ISORDER o
        JOIN 
            Customer c ON o.CustomerID = c.CustomerID
        JOIN 
            Order_Item oi ON o.OrderID = oi.OrderID
        JOIN 
            ISProduct p ON oi.ProductID = p.ProductID";

            // Open database connection
            using (var connection = DBHandler.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Set the DataGridView's data source
                        Ord.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FilterOrders(string status)
        {
            string query = @"
        SELECT 
            o.OrderID, 
            c.Name, 
            p.Name, 
            o.ShippingStatus 
        FROM 
            ISORDER o
        JOIN 
            Customer c ON o.CustomerID = c.CustomerID
        JOIN 
            Order_Item oi ON o.OrderID = oi.OrderID
        JOIN 
            ISProduct p ON oi.ProductID = p.ProductID";

            // Add WHERE clause if filtering by status
            if (!string.IsNullOrEmpty(status))
            {
                query += " WHERE o.ShippingStatus = @ShippingStatus";
            }

            using (var connection = DBHandler.GetConnection())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(status))
                        {
                            cmd.Parameters.AddWithValue("@ShippingStatus", status);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Set the DataGridView's data source to the filtered data
                        Ord.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnPrintShippingLabel_Click(object sender, EventArgs e)
        {
            // Ensure that an order is selected
            if (Ord.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Ord.SelectedRows[0];

                // Get order details from the selected row
                int orderId = Convert.ToInt32(selectedRow.Cells["OrderID"].Value);
                string customerName = selectedRow.Cells["Name"].Value.ToString();
                string product = selectedRow.Cells["Name"].Value.ToString();

                // Example: Display the shipping label information
                string shippingLabel = $"Order ID: {orderId}\nCustomer: {customerName}\nProduct: {product}";

                MessageBox.Show(shippingLabel, "Shipping Label", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select an order to print the shipping label.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMarkShipped_Click(object sender, EventArgs e)
        {
            // If no row is selected, just filter the grid by "Shipped"
            if (Ord.SelectedRows.Count == 0)
            {
                FilterOrders("Shipped");
                MessageBox.Show("Showing only shipped orders.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Check if the selected row's "Order ID" cell contains a valid value
                var orderIdCell = Ord.SelectedRows[0].Cells["OrderID"].Value;

                if (orderIdCell != null && orderIdCell != DBNull.Value)
                {
                    // Try to convert the OrderID to integer
                    int selectedOrderId;
                    if (int.TryParse(orderIdCell.ToString(), out selectedOrderId))
                    {
                        string updateStatusQuery = @"
                    UPDATE ISORDER 
                    SET ShippingStatus = @ShippingStatus 
                    WHERE OrderID = @OrderID";

                        // Open database connection
                        using (var connection = DBHandler.GetConnection())
                        {
                            try
                            {
                                connection.Open();

                                using (SqlCommand cmd = new SqlCommand(updateStatusQuery, connection))
                                {
                                    // Set parameters for OrderID and ShippingStatus
                                    cmd.Parameters.AddWithValue("@ShippingStatus", "Shipped");
                                    cmd.Parameters.AddWithValue("@OrderID", selectedOrderId);

                                    // Execute the update query
                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // If the update is successful, refresh the DataGridView to reflect the change
                                        FilterOrders("Shipped");
                                        MessageBox.Show("Order marked as shipped.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update the shipping status. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Order ID is missing or invalid in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnMarkDelivered_Click(object sender, EventArgs e)
        {
            // If no row is selected, just filter the grid by "Delivered"
            if (Ord.SelectedRows.Count == 0)
            {
                FilterOrders("Delivered");
                MessageBox.Show("Showing only delivered orders.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If a row is selected, update the shipping status of that order to "Delivered"
                int selectedOrderId = Convert.ToInt32(Ord.SelectedRows[0].Cells["OrderID"].Value);

                string updateStatusQuery = @"
            UPDATE ISORDER 
            SET ShippingStatus = @ShippingStatus 
            WHERE OrderID = @OrderID";

                // Open database connection
                using (var connection = DBHandler.GetConnection())
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(updateStatusQuery, connection))
                        {
                            // Set parameters for OrderID and ShippingStatus
                            cmd.Parameters.AddWithValue("@ShippingStatus", "Delivered");
                            cmd.Parameters.AddWithValue("@OrderID", selectedOrderId);

                            // Execute the update query
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // If the update is successful, refresh the DataGridView to reflect the change
                                FilterOrders("Delivered");
                                MessageBox.Show("Order marked as delivered.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to update the shipping status. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void btnBack_Click(object sender, EventArgs e)
        {
            Form7 sellerDashboard = new Form7();
            sellerDashboard.Show();
            this.Close();
        }

        private void Ord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // If no row is selected, just filter the grid by "Pending"
            if (Ord.SelectedRows.Count == 0)
            {
                FilterOrders("Pending");
                MessageBox.Show("Showing only pending orders.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Check for valid OrderID cell value
                var orderIdCell = Ord.SelectedRows[0].Cells["OrderID"].Value; // Use the correct column name here

                if (orderIdCell != null && orderIdCell != DBNull.Value)
                {
                    // Try to convert the OrderID to an integer
                    int selectedOrderId;
                    if (int.TryParse(orderIdCell.ToString(), out selectedOrderId))
                    {
                        string updateStatusQuery = @"
                    UPDATE ISORDER 
                    SET ShippingStatus = @ShippingStatus 
                    WHERE OrderID = @OrderID";

                        using (var connection = DBHandler.GetConnection())
                        {
                            try
                            {
                                connection.Open();
                                using (SqlCommand cmd = new SqlCommand(updateStatusQuery, connection))
                                {
                                    cmd.Parameters.AddWithValue("@ShippingStatus", "Pending"); // Set to "Pending"
                                    cmd.Parameters.AddWithValue("@OrderID", selectedOrderId);

                                    int rowsAffected = cmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // If the update is successful, refresh the DataGridView to reflect the change
                                        FilterOrders("Pending");
                                        MessageBox.Show("Order marked as pending.", "Order Fulfillment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to update the shipping status. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Order ID is missing or invalid in the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
