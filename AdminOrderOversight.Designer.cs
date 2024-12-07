
namespace DB_Proj_00
{
    partial class AdminOrderOversight
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.Button btnBack;

        private void InitializeComponent()
        {
            dataGridViewOrders = new DataGridView();
            OrderId = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            SellerName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            DatePlaced = new DataGridViewTextBoxColumn();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbFilterStatus = new ComboBox();
            labelFilter = new Label();
            btnBack = new Button();
            label3 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewOrders.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { OrderId, CustomerName, SellerName, Status, TotalAmount, DatePlaced });
            dataGridViewOrders.Location = new Point(22, 68);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.Size = new Size(967, 455);
            dataGridViewOrders.TabIndex = 0;
            // 
            // OrderId
            // 
            OrderId.HeaderText = "Order ID";
            OrderId.MinimumWidth = 30;
            OrderId.Name = "OrderId";
            OrderId.Width = 95;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Customer";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 101;
            // 
            // SellerName
            // 
            SellerName.HeaderText = "Seller";
            SellerName.MinimumWidth = 6;
            SellerName.Name = "SellerName";
            SellerName.Width = 75;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 78;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Width = 128;
            // 
            // DatePlaced
            // 
            DatePlaced.HeaderText = "Date Placed";
            DatePlaced.MinimumWidth = 6;
            DatePlaced.Name = "DatePlaced";
            DatePlaced.Width = 118;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(137, 562);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 27);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(305, 562);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 27);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbFilterStatus
            // 
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "None", "Pending", "Shipped", "Delivered" });
            cmbFilterStatus.Location = new Point(524, 561);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(150, 28);
            cmbFilterStatus.TabIndex = 4;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(462, 565);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(45, 20);
            labelFilter.TabIndex = 5;
            labelFilter.Text = "Filter:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(898, 560);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 16F, FontStyle.Bold);
            label3.Location = new Point(394, 20);
            label3.Name = "label3";
            label3.Size = new Size(225, 32);
            label3.TabIndex = 8;
            label3.Text = "Order Oversight";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 565);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 9;
            label1.Text = "Order ID:";
            // 
            // AdminOrderOversight
            // 
            ClientSize = new Size(1022, 616);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(labelFilter);
            Controls.Add(cmbFilterStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridViewOrders);
            Controls.Add(btnBack);
            Name = "AdminOrderOversight";
            Text = "Order Oversight";
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label labelFilter;
        private DataGridViewTextBoxColumn OrderId;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn SellerName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn DatePlaced;
        private Label label3;
        private Label label1;
    }
}
