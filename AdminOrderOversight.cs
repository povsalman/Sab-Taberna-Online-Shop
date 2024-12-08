using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminOrderOversight : Form
    {
        public AdminOrderOversight()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void LoadOrders(string filterStatus = null, int? orderId = null)
        {
            try
            {
                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            o.OrderID,
                            c.Name AS CustomerName,
                            s.StoreName AS SellerName,
                            o.ShippingStatus AS Status,
                            o.TotalAmount,
                            o.OrderDate AS DatePlaced
                        FROM ISORDER o
                        INNER JOIN CUSTOMER c ON o.CustomerID = c.CustomerID
                        INNER JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
                        INNER JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
                        INNER JOIN SELLER s ON p.SellerID = s.SellerID
                        WHERE (@FilterStatus IS NULL OR o.ShippingStatus = @FilterStatus)
                          AND (@OrderId IS NULL OR o.OrderID = @OrderId)
                        GROUP BY 
                            o.OrderID, c.Name, s.StoreName, o.ShippingStatus, o.TotalAmount, o.OrderDate";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Pass NULL for 'None' filter to show all records
                        command.Parameters.AddWithValue("@FilterStatus", string.IsNullOrEmpty(filterStatus) || filterStatus == "None" ? (object)DBNull.Value : filterStatus);
                        command.Parameters.AddWithValue("@OrderId", orderId.HasValue ? (object)orderId.Value : DBNull.Value);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable orderTable = new DataTable();
                            adapter.Fill(orderTable);
                            dataGridViewOrders.DataSource = orderTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading orders: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filterStatus = cmbFilterStatus.SelectedItem?.ToString();
            string orderIdText = txtSearch.Text.Trim();
            int? orderId = null;

            if (!string.IsNullOrEmpty(orderIdText) && int.TryParse(orderIdText, out int parsedOrderId))
            {
                orderId = parsedOrderId;
            }

            // Reload data grid based on search criteria
            LoadOrders(filterStatus, orderId);
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string SellerName { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DatePlaced { get; set; }

        public Order(int orderId, string customerName, string sellerName, string status, decimal totalAmount, DateTime datePlaced)
        {
            OrderId = orderId;
            CustomerName = customerName;
            SellerName = sellerName;
            Status = status;
            TotalAmount = totalAmount;
            DatePlaced = datePlaced;
        }
    }
}