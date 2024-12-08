namespace DB_Proj_00
{
    partial class SellerOrderFullfillment
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView Ord;
        private Button btnPrintShippingLabel;
        private Button btnMarkShipped;
        private Button btnMarkDelivered;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Ord = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnPrintShippingLabel = new Button();
            btnMarkShipped = new Button();
            btnMarkDelivered = new Button();
            btnBack = new Button();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)Ord).BeginInit();
            SuspendLayout();
            // 
            // Ord
            // 
            Ord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Ord.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            Ord.Location = new Point(20, 20);
            Ord.Name = "Ord";
            Ord.RowHeadersWidth = 62;
            Ord.Size = new Size(944, 449);
            Ord.TabIndex = 0;
            Ord.CellContentClick += Ord_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "OrderID";
            dataGridViewTextBoxColumn1.HeaderText = "Order ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            dataGridViewTextBoxColumn2.HeaderText = "Customer Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            dataGridViewTextBoxColumn3.HeaderText = "Product";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "ShippingStatus";
            dataGridViewTextBoxColumn4.HeaderText = "Status";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 200;
            // 
            // btnPrintShippingLabel
            // 
            btnPrintShippingLabel.Location = new Point(20, 500);
            btnPrintShippingLabel.Name = "btnPrintShippingLabel";
            btnPrintShippingLabel.Size = new Size(170, 38);
            btnPrintShippingLabel.TabIndex = 1;
            btnPrintShippingLabel.Text = "Print Shipping Label";
            btnPrintShippingLabel.Click += btnPrintShippingLabel_Click;
            // 
            // btnMarkShipped
            // 
            btnMarkShipped.Location = new Point(220, 500);
            btnMarkShipped.Name = "btnMarkShipped";
            btnMarkShipped.Size = new Size(150, 48);
            btnMarkShipped.TabIndex = 2;
            btnMarkShipped.Text = "Shipped";
            btnMarkShipped.Click += btnMarkShipped_Click;
            // 
            // btnMarkDelivered
            // 
            btnMarkDelivered.Location = new Point(400, 500);
            btnMarkDelivered.Name = "btnMarkDelivered";
            btnMarkDelivered.Size = new Size(150, 38);
            btnMarkDelivered.TabIndex = 3;
            btnMarkDelivered.Text = " Delivered";
            btnMarkDelivered.Click += btnMarkDelivered_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(848, 500);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(150, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // button1
            // 
            button1.Location = new Point(970, 20);
            button1.Name = "button1";
            button1.Size = new Size(28, 29);
            button1.TabIndex = 5;
            button1.Text = "↻";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(580, 500);
            button2.Name = "button2";
            button2.Size = new Size(150, 38);
            button2.TabIndex = 6;
            button2.Text = "Pending";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // SellerOrderFullfillment
            // 
            ClientSize = new Size(1050, 550);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Ord);
            Controls.Add(btnPrintShippingLabel);
            Controls.Add(btnMarkShipped);
            Controls.Add(btnMarkDelivered);
            Controls.Add(btnBack);
            Name = "SellerOrderFullfillment";
            Text = "Order Fulfillment";
            ((System.ComponentModel.ISupportInitialize)Ord).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button button1;
        private Button button2;
    }
}
