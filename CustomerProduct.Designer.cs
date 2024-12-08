namespace DB_Proj_00
{
    partial class CustomerProduct
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSearch;
        private Button btnBack;
        private FlowLayoutPanel flowLayoutPanelProducts;
        private ComboBox cbCategory;
        private ComboBox cbRating;
        private ComboBox cbBrand;
        private TextBox txtMinPrice;
        private TextBox txtMaxPrice;




        private void InitializeComponent()
        {
            cbCategory = new ComboBox();
            cbRating = new ComboBox();
            cbBrand = new ComboBox();
            txtMinPrice = new TextBox();
            txtMaxPrice = new TextBox();
            btnSearch = new Button();
            btnBack = new Button();
            flowLayoutPanelProducts = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // cbCategory
            // 
            cbCategory.Font = new Font("Microsoft PhagsPa", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbCategory.ForeColor = SystemColors.ScrollBar;
            cbCategory.Items.AddRange(new object[] { "All Categories", "Fashion", "Electronics", "Home and Living", "Health and Beauty", "Food and Beverages" });
            cbCategory.Location = new Point(241, 16);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 31);
            cbCategory.TabIndex = 0;
            cbCategory.Tag = "";
            cbCategory.Text = "Category";
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // cbRating
            // 
            cbRating.BackColor = SystemColors.Window;
            cbRating.ForeColor = SystemColors.ScrollBar;
            cbRating.Items.AddRange(new object[] { "All Ratings", "1", "2", "3", "4", "5" });
            cbRating.Location = new Point(430, 20);
            cbRating.Name = "cbRating";
            cbRating.Size = new Size(110, 33);
            cbRating.TabIndex = 1;
            cbRating.Text = "Rating";
            cbRating.SelectedIndexChanged += cbRating_SelectedIndexChanged;
            // 
            // cbBrand
            // 
            cbBrand.ForeColor = SystemColors.ScrollBar;
            cbBrand.Items.AddRange(new object[] { "All Brands", "Brand A", "Brand B", "Brand C", "Brand D", "Brand E" });
            cbBrand.Location = new Point(617, 18);
            cbBrand.Name = "cbBrand";
            cbBrand.Size = new Size(110, 33);
            cbBrand.TabIndex = 2;
            cbBrand.Text = "Brand ";
            cbBrand.SelectedIndexChanged += cbBrand_SelectedIndexChanged;
            // 
            // txtMinPrice
            // 
            txtMinPrice.ForeColor = SystemColors.ScrollBar;
            txtMinPrice.Location = new Point(769, 20);
            txtMinPrice.Name = "txtMinPrice";
            txtMinPrice.Size = new Size(100, 31);
            txtMinPrice.TabIndex = 3;
            txtMinPrice.TextChanged += txtMinPrice_TextChanged;
            // 
            // txtMaxPrice
            // 
            txtMaxPrice.ForeColor = SystemColors.ScrollBar;
            txtMaxPrice.Location = new Point(906, 20);
            txtMaxPrice.Name = "txtMaxPrice";
            txtMaxPrice.Size = new Size(100, 31);
            txtMaxPrice.TabIndex = 4;
            txtMaxPrice.TextChanged += txtMaxPrice_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.GradientActiveCaption;
            btnSearch.ForeColor = SystemColors.Desktop;
            btnSearch.Location = new Point(1026, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(86, 33);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Go";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightCoral;
            btnBack.Location = new Point(2, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 40);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // flowLayoutPanelProducts
            // 
            flowLayoutPanelProducts.AutoScroll = true;
            flowLayoutPanelProducts.BackColor = Color.Transparent;
            flowLayoutPanelProducts.Location = new Point(2, 70);
            flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            flowLayoutPanelProducts.Size = new Size(1332, 644);
            flowLayoutPanelProducts.TabIndex = 4;
            flowLayoutPanelProducts.Paint += flowLayoutPanelProducts_Paint;
            // 
            // Form11
            // 
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1332, 800);
            Controls.Add(txtMinPrice);
            Controls.Add(cbCategory);
            Controls.Add(cbRating);
            Controls.Add(cbBrand);
            Controls.Add(txtMaxPrice);
            Controls.Add(btnSearch);
            Controls.Add(btnBack);
            Controls.Add(flowLayoutPanelProducts);
            Name = "Form11";
            Text = "Products Page";
            Load += Form11_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
