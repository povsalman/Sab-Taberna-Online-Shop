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
            btnResolveConflict = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            cmbFilterStatus = new ComboBox();
            labelFilter = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            SuspendLayout();
            
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { OrderId, CustomerName, SellerName, Status, TotalAmount, DatePlaced });
            dataGridViewOrders.Location = new Point(12, 70);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.RowTemplate.Height = 29;
            dataGridViewOrders.Size = new Size(760, 300);
            dataGridViewOrders.TabIndex = 0;
            
            OrderId.HeaderText = "Order ID";
            OrderId.MinimumWidth = 6;
            OrderId.Name = "OrderId";
            OrderId.Width = 80;
           
            CustomerName.HeaderText = "Customer";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 150;
             
            SellerName.HeaderText = "Seller";
            SellerName.MinimumWidth = 6;
            SellerName.Name = "SellerName";
            SellerName.Width = 150;
            
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 120;
            
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.MinimumWidth = 6;
            TotalAmount.Name = "TotalAmount";
            
            DatePlaced.HeaderText = "Date Placed";
            DatePlaced.MinimumWidth = 6;
            DatePlaced.Name = "DatePlaced";
            DatePlaced.Width = 150;
            
            btnResolveConflict.Location = new Point(12, 380);
            btnResolveConflict.Name = "btnResolveConflict";
            btnResolveConflict.Size = new Size(150, 30);
            btnResolveConflict.TabIndex = 1;
            btnResolveConflict.Text = "Resolve Conflict";
            btnResolveConflict.UseVisualStyleBackColor = true;
            btnResolveConflict.Click += btnResolveConflict_Click;
            
            txtSearch.Location = new Point(12, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 2;
             
            btnSearch.Location = new Point(180, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 27);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            
            cmbFilterStatus.FormattingEnabled = true;
            cmbFilterStatus.Items.AddRange(new object[] { "Processing", "Shipped", "Delivered" });
            cmbFilterStatus.Location = new Point(300, 20);
            cmbFilterStatus.Name = "cmbFilterStatus";
            cmbFilterStatus.Size = new Size(150, 33);
            cmbFilterStatus.TabIndex = 4;
           
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(300, 0);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(54, 25);
            labelFilter.TabIndex = 5;
            labelFilter.Text = "Filter:";
            
            btnBack.Location = new Point(254, 389);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
          
            ClientSize = new Size(833, 450);
            Controls.Add(labelFilter);
            Controls.Add(cmbFilterStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnResolveConflict);
            Controls.Add(dataGridViewOrders);
            Controls.Add(btnBack);
            Name = "Form21";
            Text = "Order Oversight";
            Load += Form21_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatePlaced;
        private System.Windows.Forms.Button btnResolveConflict;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbFilterStatus;
        private System.Windows.Forms.Label labelFilter;
    }
}
