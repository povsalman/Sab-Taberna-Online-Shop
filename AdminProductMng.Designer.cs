namespace DB_Proj_00
{
    partial class AdminProductMng
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvProducts;
        private Button btnCategoryAdd;
        private Button btnCategoryRemove;
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
            btnCategoryAdd = new Button();
            btnCategoryRemove = new Button();
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
            btnRejectProduct = new Button();
            btnApproveProduct = new Button();
            label6 = new Label();
            txtProductID = new TextBox();
            btnShowApproved = new Button();
            btnShowRejected = new Button();
            txtRemoveProduct = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dgvProducts
            // 
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProducts.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvProducts.BorderStyle = BorderStyle.Fixed3D;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(29, 333);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.RowHeadersWidth = 62;
            dgvProducts.Size = new Size(986, 282);
            dgvProducts.TabIndex = 0;
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
            dataGridView1.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
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
            label3.BackColor = Color.Transparent;
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
            label1.BackColor = Color.Transparent;
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
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(634, 68);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 14;
            label2.Text = "Category ID:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(609, 116);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 15;
            label4.Text = "Category Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(634, 171);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 16;
            label5.Text = "Description:";
            // 
            // btnRejectProduct
            // 
            btnRejectProduct.Location = new Point(698, 633);
            btnRejectProduct.Name = "btnRejectProduct";
            btnRejectProduct.Size = new Size(98, 29);
            btnRejectProduct.TabIndex = 17;
            btnRejectProduct.Text = "Reject";
            btnRejectProduct.UseVisualStyleBackColor = true;
            btnRejectProduct.Click += btnRejectProduct_Click;
            // 
            // btnApproveProduct
            // 
            btnApproveProduct.Location = new Point(594, 633);
            btnApproveProduct.Name = "btnApproveProduct";
            btnApproveProduct.Size = new Size(98, 29);
            btnApproveProduct.TabIndex = 18;
            btnApproveProduct.Text = "Approve";
            btnApproveProduct.UseVisualStyleBackColor = true;
            btnApproveProduct.Click += btnApproveProduct_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(35, 640);
            label6.Name = "label6";
            label6.Size = new Size(82, 20);
            label6.TabIndex = 20;
            label6.Text = "Product ID:";
            // 
            // txtProductID
            // 
            txtProductID.Location = new Point(132, 633);
            txtProductID.Name = "txtProductID";
            txtProductID.Size = new Size(113, 27);
            txtProductID.TabIndex = 19;
            // 
            // btnShowApproved
            // 
            btnShowApproved.Location = new Point(269, 634);
            btnShowApproved.Name = "btnShowApproved";
            btnShowApproved.Size = new Size(123, 29);
            btnShowApproved.TabIndex = 21;
            btnShowApproved.Text = "Show Approved";
            btnShowApproved.UseVisualStyleBackColor = true;
            btnShowApproved.Click += btnShowApproved_Click;
            // 
            // btnShowRejected
            // 
            btnShowRejected.Location = new Point(398, 634);
            btnShowRejected.Name = "btnShowRejected";
            btnShowRejected.Size = new Size(123, 29);
            btnShowRejected.TabIndex = 22;
            btnShowRejected.Text = "Show Rejected";
            btnShowRejected.UseVisualStyleBackColor = true;
            btnShowRejected.Click += btnShowRejected_Click;
            // 
            // txtRemoveProduct
            // 
            txtRemoveProduct.Location = new Point(797, 633);
            txtRemoveProduct.Name = "txtRemoveProduct";
            txtRemoveProduct.Size = new Size(98, 29);
            txtRemoveProduct.TabIndex = 23;
            txtRemoveProduct.Text = "Remove";
            txtRemoveProduct.UseVisualStyleBackColor = true;
            txtRemoveProduct.Click += txtRemoveProduct_Click;
            // 
            // AdminProductMng
            // 
            BackgroundImage = Properties.Resources.Tabby_Photoroom;
            ClientSize = new Size(1052, 672);
            Controls.Add(txtRemoveProduct);
            Controls.Add(btnShowRejected);
            Controls.Add(btnShowApproved);
            Controls.Add(label6);
            Controls.Add(txtProductID);
            Controls.Add(btnApproveProduct);
            Controls.Add(btnRejectProduct);
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
            Controls.Add(btnBack);
            Name = "AdminProductMng";
            Text = "Admin - Product and Category Management";
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

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
        private Button btnRejectProduct;
        private Button btnApproveProduct;
        private Label label6;
        private TextBox txtProductID;
        private Button btnShowApproved;
        private Button btnShowRejected;
        private Button txtRemoveProduct;
    }
}