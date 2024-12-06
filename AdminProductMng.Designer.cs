namespace DB_Proj_00
{
    partial class AdminProductMng
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Button btnCategoryAdd;
        private Button btnCategoryRemove;
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
            btnCategoryAdd = new Button();
            btnCategoryRemove = new Button();
            btnApproveListing = new Button();
            btnRejectListing = new Button();
            btnBack = new Button();
            dataGridView1 = new DataGridView();
            btnCategoryUpdate = new Button();
            label3 = new Label();
            label1 = new Label();
            txtCategoryID = new TextBox();
            txtCategoryName = new TextBox();
            txtCategoryDescription = new TextBox();
            btnCategoryRefresh = new Button();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvProducts.Location = new Point(29, 333);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(986, 282);
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
            // btnCategoryAdd
            // 
            btnCategoryAdd.Location = new Point(845, 232);
            btnCategoryAdd.Name = "btnCategoryAdd";
            btnCategoryAdd.Size = new Size(140, 30);
            btnCategoryAdd.TabIndex = 1;
            btnCategoryAdd.Text = "Add Category";
            btnCategoryAdd.Click += btnCategoryAdd_Click;
            // 
            // btnCategoryRemove
            // 
            btnCategoryRemove.Location = new Point(845, 268);
            btnCategoryRemove.Name = "btnCategoryRemove";
            btnCategoryRemove.Size = new Size(140, 30);
            btnCategoryRemove.TabIndex = 2;
            btnCategoryRemove.Text = "Remove Category";
            btnCategoryRemove.Click += btnCategoryRemove_Click;
            // 
            // btnApproveListing
            // 
            btnApproveListing.Location = new Point(566, 634);
            btnApproveListing.Name = "btnApproveListing";
            btnApproveListing.Size = new Size(180, 30);
            btnApproveListing.TabIndex = 3;
            btnApproveListing.Text = "Approve Listing";
            btnApproveListing.Click += btnApproveListing_Click;
            // 
            // btnRejectListing
            // 
            btnRejectListing.Location = new Point(732, 634);
            btnRejectListing.Name = "btnRejectListing";
            btnRejectListing.Size = new Size(180, 30);
            btnRejectListing.TabIndex = 4;
            btnRejectListing.Text = "Reject Listing";
            btnRejectListing.Click += btnRejectListing_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(901, 634);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 30);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(572, 220);
            dataGridView1.TabIndex = 6;
            // 
            // btnCategoryUpdate
            // 
            btnCategoryUpdate.Location = new Point(716, 269);
            btnCategoryUpdate.Name = "btnCategoryUpdate";
            btnCategoryUpdate.Size = new Size(112, 29);
            btnCategoryUpdate.TabIndex = 7;
            btnCategoryUpdate.Text = "Update";
            btnCategoryUpdate.UseVisualStyleBackColor = true;
            btnCategoryUpdate.Click += btnCategoryUpdate_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 16F, FontStyle.Bold);
            label3.Location = new Point(29, 298);
            label3.Name = "label3";
            label3.Size = new Size(293, 32);
            label3.TabIndex = 8;
            label3.Text = "Product Management";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.Location = new Point(29, 26);
            label1.Name = "label1";
            label1.Size = new Size(308, 32);
            label1.TabIndex = 9;
            label1.Text = "Category Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCategoryID
            // 
            txtCategoryID.Location = new Point(731, 61);
            txtCategoryID.Name = "txtCategoryID";
            txtCategoryID.Size = new Size(240, 27);
            txtCategoryID.TabIndex = 10;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(731, 109);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(240, 27);
            txtCategoryName.TabIndex = 11;
            // 
            // txtCategoryDescription
            // 
            txtCategoryDescription.Location = new Point(731, 164);
            txtCategoryDescription.Name = "txtCategoryDescription";
            txtCategoryDescription.Size = new Size(240, 27);
            txtCategoryDescription.TabIndex = 12;
            // 
            // btnCategoryRefresh
            // 
            btnCategoryRefresh.Location = new Point(716, 234);
            btnCategoryRefresh.Name = "btnCategoryRefresh";
            btnCategoryRefresh.Size = new Size(112, 29);
            btnCategoryRefresh.TabIndex = 13;
            btnCategoryRefresh.Text = "Refresh";
            btnCategoryRefresh.UseVisualStyleBackColor = true;
            btnCategoryRefresh.Click += btnCategoryRefresh_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(634, 68);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 14;
            label2.Text = "Category ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(609, 116);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 15;
            label4.Text = "Category Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(634, 171);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 16;
            label5.Text = "Description:";
            // 
            // AdminProductMng
            // 
            ClientSize = new Size(1052, 672);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(btnCategoryRefresh);
            Controls.Add(txtCategoryDescription);
            Controls.Add(txtCategoryName);
            Controls.Add(txtCategoryID);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(btnCategoryUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(dgvProducts);
            Controls.Add(btnCategoryAdd);
            Controls.Add(btnCategoryRemove);
            Controls.Add(btnApproveListing);
            Controls.Add(btnRejectListing);
            Controls.Add(btnBack);
            Name = "AdminProductMng";
            Text = "Admin - Product and Category Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView dataGridView1;
        private Button btnCategoryUpdate;
        private Label label3;
        private Label label1;
        private TextBox txtCategoryID;
        private TextBox txtCategoryName;
        private TextBox txtCategoryDescription;
        private Button btnCategoryRefresh;
        private Label label2;
        private Label label4;
        private Label label5;
    }
}
