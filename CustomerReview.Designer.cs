namespace DB_Proj_00
{
    partial class CustomerReview
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowLayoutPanelReviews;
        private Button btnBack;

        private void InitializeComponent()
        {
            flowLayoutPanelReviews = new FlowLayoutPanel();
            btnBack = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanelReviews
            // 
            flowLayoutPanelReviews.AutoScroll = true;
            flowLayoutPanelReviews.BackColor = Color.Transparent;
            flowLayoutPanelReviews.Location = new Point(20, 20);
            flowLayoutPanelReviews.Name = "flowLayoutPanelReviews";
            flowLayoutPanelReviews.Size = new Size(1360, 500);
            flowLayoutPanelReviews.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(20, 550);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 38);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // Form13
            // 
            ClientSize = new Size(1400, 600);
            Controls.Add(flowLayoutPanelReviews);
            Controls.Add(btnBack);
            Name = "Form13";
            Text = "Product Reviews";
            ResumeLayout(false);
        }
    }
}
