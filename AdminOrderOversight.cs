using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DB_Proj_00
{
    public partial class AdminOrderOversight : Form
    {
        private List<Order> orders; 

        public AdminOrderOversight(List<Order> orderList)
        {
            InitializeComponent();
            orders = orderList; 
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            PopulateOrderGrid();
        }

        private void PopulateOrderGrid()
        {
            dataGridViewOrders.Rows.Clear(); 

            foreach (var order in orders)
            {
                dataGridViewOrders.Rows.Add(
                    order.OrderId,
                    order.CustomerName,
                    order.SellerName,
                    order.Status,
                    order.TotalAmount,
                    order.DatePlaced
                );
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower();
            string filterStatus = cmbFilterStatus.SelectedItem?.ToString();

            var filteredOrders = orders.FindAll(order =>
                (string.IsNullOrEmpty(keyword) || order.CustomerName.ToLower().Contains(keyword)) &&
                (string.IsNullOrEmpty(filterStatus) || order.Status == filterStatus)
            );

            dataGridViewOrders.Rows.Clear();

            foreach (var order in filteredOrders)
            {
                dataGridViewOrders.Rows.Add(
                    order.OrderId,
                    order.CustomerName,
                    order.SellerName,
                    order.Status,
                    order.TotalAmount,
                    order.DatePlaced
                );
            }
        }

        private void btnResolveConflict_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an order to resolve.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedOrderId = (int)dataGridViewOrders.SelectedRows[0].Cells["OrderId"].Value;
            var selectedOrder = orders.Find(order => order.OrderId == selectedOrderId);

            if (selectedOrder != null)
            {
                MessageBox.Show($"Conflict resolution initiated for Order ID: {selectedOrder.OrderId}.", "Conflict Resolution", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
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
