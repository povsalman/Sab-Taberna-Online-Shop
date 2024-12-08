namespace DB_Proj_00
{
    partial class CustomerCart
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCart;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCheckout;

        

        private void InitializeComponent()
        {
            flowLayoutPanelCart = new FlowLayoutPanel();
            btnBack = new Button();
            btnCheckout = new Button();
            btnReview = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            flowLayoutPanelCart.AutoScroll = true;
            flowLayoutPanelCart.Location = new Point(20, 20);
            flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            flowLayoutPanelCart.Size = new Size(1360, 500);
            flowLayoutPanelCart.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(29, 558);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // btnCheckout
            // 
           

            Load += Form12_Load;

            btnReview.Location = new Point(0, 0);
            btnReview.Name = "btnReview";
            btnReview.Size = new Size(75, 23);
            btnReview.TabIndex = 0;
            // 
            // Form12
            // 
            ClientSize = new Size(1392, 600);
            Controls.Add(flowLayoutPanelCart);
            Controls.Add(btnBack);
            Controls.Add(btnCheckout);
            Name = "Form12";
            Text = "Shopping Cart";
            ResumeLayout(false);
        }

        private Button btnReview;
    }
}
