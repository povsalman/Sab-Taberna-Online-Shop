namespace DB_Proj_00
{
    partial class AdminProductMng
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Button btnAddCategory;
        private Button btnRemoveCategory;
        private Button btnApproveListing;
        private Button btnRejectListing;
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
            dgvProducts = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnAddCategory = new Button();
            btnRemoveCategory = new Button();
            btnApproveListing = new Button();
            btnRejectListing = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvProducts.Location = new Point(20, 20);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(600, 250);
            dgvProducts.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Product Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Category";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Status";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            // 
            // btnAddCategory
            // 
            btnAddCategory.Location = new Point(20, 300);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(150, 30);
            btnAddCategory.TabIndex = 1;
            btnAddCategory.Text = "Add Category";
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // btnRemoveCategory
            // 
            btnRemoveCategory.Location = new Point(200, 300);
            btnRemoveCategory.Name = "btnRemoveCategory";
            btnRemoveCategory.Size = new Size(150, 30);
            btnRemoveCategory.TabIndex = 2;
            btnRemoveCategory.Text = "Remove Category";
            btnRemoveCategory.Click += btnRemoveCategory_Click;
            // 
            // btnApproveListing
            // 
            btnApproveListing.Location = new Point(20, 350);
            btnApproveListing.Name = "btnApproveListing";
            btnApproveListing.Size = new Size(150, 30);
            btnApproveListing.TabIndex = 3;
            btnApproveListing.Text = "Approve Listing";
            btnApproveListing.Click += btnApproveListing_Click;
            // 
            // btnRejectListing
            // 
            btnRejectListing.Location = new Point(200, 350);
            btnRejectListing.Name = "btnRejectListing";
            btnRejectListing.Size = new Size(150, 30);
            btnRejectListing.TabIndex = 4;
            btnRejectListing.Text = "Reject Listing";
            btnRejectListing.Click += btnRejectListing_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(508, 389);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // AdminProductMng
            // 
            ClientSize = new Size(944, 579);
            Controls.Add(dgvProducts);
            Controls.Add(btnAddCategory);
            Controls.Add(btnRemoveCategory);
            Controls.Add(btnApproveListing);
            Controls.Add(btnRejectListing);
            Controls.Add(btnBack);
            Name = "AdminProductMng";
            Text = "Admin - Product and Category Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}
