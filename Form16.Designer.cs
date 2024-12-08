namespace DB_Proj_00
{
    partial class Form16
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Button btnAddProduct;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
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
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            btnBack = new Button();
            button1 = new Button();
            numPrice = new NumericUpDown();
            numStockLevel = new NumericUpDown();
            txtProductName = new TextBox();
            txtDescription = new TextBox();
            btnSaveNew = new Button();
            btnSaveChanges = new Button();
            numSellerID = new NumericUpDown();
            numCategoryID = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSellerID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCategoryID).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvProducts.Location = new Point(20, 20);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(900, 450);
            dgvProducts.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Product Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Price";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Stock";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Description";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 200;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(20, 500);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(150, 30);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Add";
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnEditProduct
            // 
            btnEditProduct.Location = new Point(220, 500);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(150, 30);
            btnEditProduct.TabIndex = 2;
            btnEditProduct.Text = "Edit";
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.Location = new Point(420, 500);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(150, 30);
            btnDeleteProduct.TabIndex = 3;
            btnDeleteProduct.Text = "Delete";
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(820, 500);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // button1
            // 
            button1.Location = new Point(620, 500);
            button1.Name = "button1";
            button1.Size = new Size(150, 30);
            button1.TabIndex = 5;
            button1.Text = "↻ Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // numPrice
            // 
            numPrice.Location = new Point(926, 156);
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(122, 27);
            numPrice.TabIndex = 6;
            numPrice.Visible = false;
            // 
            // numStockLevel
            // 
            numStockLevel.Location = new Point(926, 226);
            numStockLevel.Name = "numStockLevel";
            numStockLevel.Size = new Size(122, 27);
            numStockLevel.TabIndex = 7;
            numStockLevel.Visible = false;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(926, 100);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(125, 27);
            txtProductName.TabIndex = 8;
            txtProductName.Visible = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(926, 306);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(125, 27);
            txtDescription.TabIndex = 9;
            txtDescription.Visible = false;
            // 
            // btnSaveNew
            // 
            btnSaveNew.Location = new Point(935, 500);
            btnSaveNew.Name = "btnSaveNew";
            btnSaveNew.Size = new Size(94, 29);
            btnSaveNew.TabIndex = 10;
            btnSaveNew.Text = "btnSaveNew";
            btnSaveNew.UseVisualStyleBackColor = true;
            btnSaveNew.Visible = false;
            btnSaveNew.Click += btnSaveNew_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(935, 430);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(94, 29);
            btnSaveChanges.TabIndex = 11;
            btnSaveChanges.Text = "btnSaveChanges";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // numSellerID
            // 
            numSellerID.Location = new Point(926, 48);
            numSellerID.Name = "numSellerID";
            numSellerID.Size = new Size(122, 27);
            numSellerID.TabIndex = 12;
            // 
            // numCategoryID
            // 
            numCategoryID.Location = new Point(926, 360);
            numCategoryID.Name = "numCategoryID";
            numCategoryID.Size = new Size(122, 27);
            numCategoryID.TabIndex = 13;
            // 
            // Form16
            // 
            ClientSize = new Size(1050, 550);
            Controls.Add(numCategoryID);
            Controls.Add(numSellerID);
            Controls.Add(btnSaveChanges);
            Controls.Add(btnSaveNew);
            Controls.Add(txtDescription);
            Controls.Add(txtProductName);
            Controls.Add(numStockLevel);
            Controls.Add(numPrice);
            Controls.Add(button1);
            Controls.Add(dgvProducts);
            Controls.Add(btnAddProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnBack);
            Name = "Form16";
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSellerID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCategoryID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Button button1;
        private NumericUpDown numPrice;
        private NumericUpDown numStockLevel;
        private TextBox txtProductName;
        private TextBox txtDescription;
        private Button btnSaveNew;
        private Button btnSaveChanges;
        private NumericUpDown numSellerID;
        private NumericUpDown numCategoryID;
    }
}
