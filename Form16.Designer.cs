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
            btnAddProduct = new Button();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            btnBack = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            
            

            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dgvProducts.Location = new Point(97, 82);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(748, 187);
            dgvProducts.TabIndex = 0;
            


            btnAddProduct.Location = new Point(209, 316);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(100, 30);
            btnAddProduct.TabIndex = 1;
            btnAddProduct.Text = "Add";
            btnAddProduct.Click += btnAddProduct_Click;
            
            
            btnEditProduct.Location = new Point(371, 316);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(100, 30);
            btnEditProduct.TabIndex = 2;
            btnEditProduct.Text = "Edit";
            btnEditProduct.Click += btnEditProduct_Click;
            


            btnDeleteProduct.Location = new Point(542, 316);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(100, 30);
            btnDeleteProduct.TabIndex = 3;
            btnDeleteProduct.Text = "Delete";
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            
            btnBack.Location = new Point(697, 316);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            


            dataGridViewTextBoxColumn1.HeaderText = "Product Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            


            dataGridViewTextBoxColumn2.HeaderText = "Price";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 150;
            


            dataGridViewTextBoxColumn3.HeaderText = "Stock";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            


            dataGridViewTextBoxColumn4.HeaderText = "Description";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 150;
            


            ClientSize = new Size(1148, 417);
            Controls.Add(dgvProducts);
            Controls.Add(btnAddProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnBack);
            Name = "Form16";
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
