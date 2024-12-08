namespace DB_Proj_00
{
    partial class CustomerOrder
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox t;
        
        private Label lblOrderStatus;
        private Button btnPlaceOrder;
        private Button btnBack;
        private ComboBox Shipppingopt;

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
            t = new TextBox();
            Shipppingopt = new ComboBox();
            lblOrderStatus = new Label();
            btnPlaceOrder = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // t
            // 
            t.Location = new Point(289, 35);
            t.Name = "t";
            t.PlaceholderText = "Enter your address";
            t.Size = new Size(300, 27);
            t.TabIndex = 0;
            // 
            // Shipppingopt
            // 
            Shipppingopt.DropDownStyle = ComboBoxStyle.DropDownList;
            Shipppingopt.Items.AddRange(new object[] { "Standard", "Express", "Overnight" });
            Shipppingopt.Location = new Point(311, 112);
            Shipppingopt.Name = "Shipppingopt";
            Shipppingopt.Size = new Size(200, 28);
            Shipppingopt.TabIndex = 1;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.Font = new Font("Arial", 10F, FontStyle.Italic);
            lblOrderStatus.Location = new Point(289, 185);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new Size(300, 50);
            lblOrderStatus.TabIndex = 2;
            lblOrderStatus.Text = "Order Status: ";
            // 
            // btnPlaceOrder
            // 
            btnPlaceOrder.Location = new Point(354, 252);
            btnPlaceOrder.Name = "btnPlaceOrder";
            btnPlaceOrder.Size = new Size(100, 30);
            btnPlaceOrder.TabIndex = 3;
            btnPlaceOrder.Text = "Place Order";
            btnPlaceOrder.Click += btnPlaceOrder_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(354, 320);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // CustomerOrder
            // 
            ClientSize = new Size(886, 390);
            Controls.Add(t);
            Controls.Add(Shipppingopt);
            Controls.Add(lblOrderStatus);
            Controls.Add(btnPlaceOrder);
            Controls.Add(btnBack);
            Name = "CustomerOrder";
            Text = "Order Placement and Tracking";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
