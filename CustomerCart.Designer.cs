namespace DB_Proj_00
{
    partial class CustomerCart
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCart;
        private System.Windows.Forms.Button btnBack;



        private void InitializeComponent()
        {
            flowLayoutPanelCart = new FlowLayoutPanel();
            btnBack = new Button();
            btnReview = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            flowLayoutPanelCart.AutoScroll = true;
            flowLayoutPanelCart.Location = new Point(20, 20);
            flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            flowLayoutPanelCart.Size = new Size(1348, 500);
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
            // btnReview
            // 
            btnReview.Location = new Point(0, 0);
            btnReview.Name = "btnReview";
            btnReview.Size = new Size(75, 23);
            btnReview.TabIndex = 0;
            // 
            // CustomerCart
            // 
            ClientSize = new Size(1392, 600);
            Controls.Add(flowLayoutPanelCart);
            Controls.Add(btnBack);
            Name = "CustomerCart";
            Text = "Shopping Cart";
            Load += Form12_Load;
            ResumeLayout(false);
        }

        private Button btnReview;
    }
}
