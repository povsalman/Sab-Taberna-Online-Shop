namespace DB_Proj_00
{
    partial class Form17
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
            btnPrintShippingLabel = new Button();
            btnMarkShipped = new Button();
            btnMarkDelivered = new Button();
            btnBack = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Ord).BeginInit();
            SuspendLayout();
            


            Ord.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Ord.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            Ord.Location = new Point(20, 20);
            Ord.Name = "Ord";
            Ord.RowHeadersWidth = 62;
            Ord.Size = new Size(600, 300);
            Ord.TabIndex = 0;
            // 
            // btnPrintShippingLabel
            // 
            btnPrintShippingLabel.Location = new Point(20, 340);
            btnPrintShippingLabel.Name = "btnPrintShippingLabel";
            btnPrintShippingLabel.Size = new Size(150, 30);
            btnPrintShippingLabel.TabIndex = 1;
            btnPrintShippingLabel.Text = "Print Shipping Label";
            btnPrintShippingLabel.Click += btnPrintShippingLabel_Click;
            // 
            // btnMarkShipped
            // 
            btnMarkShipped.Location = new Point(200, 340);
            btnMarkShipped.Name = "btnMarkShipped";
            btnMarkShipped.Size = new Size(120, 30);
            btnMarkShipped.TabIndex = 2;
            btnMarkShipped.Text = "Shipped";
            btnMarkShipped.Click += btnMarkShipped_Click;
         


            btnMarkDelivered.Location = new Point(350, 340);
            btnMarkDelivered.Name = "btnMarkDelivered";
            btnMarkDelivered.Size = new Size(150, 30);
            btnMarkDelivered.TabIndex = 3;
            btnMarkDelivered.Text = " Delivered";
            btnMarkDelivered.Click += btnMarkDelivered_Click;
            
            btnBack.Location = new Point(530, 340);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
          


            dataGridViewTextBoxColumn1.HeaderText = "Order ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            
            dataGridViewTextBoxColumn2.HeaderText = "Customer Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 150;
           
            dataGridViewTextBoxColumn3.HeaderText = "Product";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            
            dataGridViewTextBoxColumn4.HeaderText = "Status";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 150;
            
            ClientSize = new Size(809, 391);
            Controls.Add(Ord);
            Controls.Add(btnPrintShippingLabel);
            Controls.Add(btnMarkShipped);
            Controls.Add(btnMarkDelivered);
            Controls.Add(btnBack);
            Name = "Form17";
            Text = "Order Fulfillment";
            ((System.ComponentModel.ISupportInitialize)Ord).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
