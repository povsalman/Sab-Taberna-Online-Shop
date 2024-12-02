namespace DB_Proj_00
{
    partial class Form11
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtSearch;
        private ComboBox cmbCategory;
        private ComboBox cmbPriceRange;
        private ComboBox cmbRating;
        private ComboBox cmbShipping;
        private Button btnSearch;
        private Button btnBack; 
        private FlowLayoutPanel flowLayoutPanelProducts;

        

        private void InitializeComponent()
        {
            this.txtSearch = new TextBox();
            this.cmbCategory = new ComboBox();
            this.cmbPriceRange = new ComboBox();
            this.cmbRating = new ComboBox();
            this.cmbShipping = new ComboBox();
            this.btnSearch = new Button();
            this.btnBack = new Button(); 
            this.flowLayoutPanelProducts = new FlowLayoutPanel();

            
            this.txtSearch.Location = new Point(20, 20);
            this.txtSearch.Size = new Size(200, 25);


            this.cmbCategory.Location = new Point(240, 20);
            this.cmbCategory.Size = new Size(150, 25);


            this.cmbPriceRange.Location = new Point(410, 20);
            this.cmbPriceRange.Size = new Size(150, 25);

            
            this.cmbRating.Location = new Point(580, 20);
            this.cmbRating.Size = new Size(100, 25);

            
            this.cmbShipping.Location = new Point(700, 20);
            this.cmbShipping.Size = new Size(150, 25);

            // Search button
            this.btnSearch.Location = new Point(870, 20);
            this.btnSearch.Size = new Size(100, 25);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Button for back
            this.btnBack.Location = new Point(20, 580); 
            this.btnBack.Size = new Size(100, 30);
            this.btnBack.Text = "Back";
            this.btnBack.BackColor = Color.LightCoral; 
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

           
            this.flowLayoutPanelProducts.Location = new Point(20, 70);
            this.flowLayoutPanelProducts.Size = new Size(950, 500);
            this.flowLayoutPanelProducts.AutoScroll = true;


            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbPriceRange);
            this.Controls.Add(this.cmbRating);
            this.Controls.Add(this.cmbShipping);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnBack); 
            this.Controls.Add(this.flowLayoutPanelProducts);




            this.ClientSize = new Size(1000, 800); 
            this.Text = "Products Page";
            this.Load += new EventHandler(this.Form11_Load);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Form10 customerDashboard = new Form10();
            customerDashboard.Show();
            this.Close(); 
        }

    }
}


