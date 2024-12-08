namespace DB_Proj_00
{
    partial class AdminReviews
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewReviews = new DataGridView();
            label1 = new Label();
            txtReviewID = new TextBox();
            btnFlagProduct = new Button();
            button1 = new Button();
            btnUnflagProduct = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewReviews
            // 
            dataGridViewReviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewReviews.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewReviews.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridViewReviews.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReviews.Location = new Point(42, 48);
            dataGridViewReviews.Name = "dataGridViewReviews";
            dataGridViewReviews.RowHeadersWidth = 51;
            dataGridViewReviews.Size = new Size(927, 448);
            dataGridViewReviews.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(42, 552);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Review ID:";
            // 
            // txtReviewID
            // 
            txtReviewID.Location = new Point(149, 548);
            txtReviewID.Name = "txtReviewID";
            txtReviewID.Size = new Size(171, 27);
            txtReviewID.TabIndex = 2;
            txtReviewID.TextChanged += txtReviewID_TextChanged;
            // 
            // btnFlagProduct
            // 
            btnFlagProduct.Location = new Point(392, 548);
            btnFlagProduct.Name = "btnFlagProduct";
            btnFlagProduct.Size = new Size(94, 29);
            btnFlagProduct.TabIndex = 3;
            btnFlagProduct.Text = "Flag";
            btnFlagProduct.UseVisualStyleBackColor = true;
            btnFlagProduct.Click += btnFlagProduct_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(875, 548);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnUnflagProduct
            // 
            btnUnflagProduct.Location = new Point(515, 548);
            btnUnflagProduct.Name = "btnUnflagProduct";
            btnUnflagProduct.Size = new Size(94, 29);
            btnUnflagProduct.TabIndex = 5;
            btnUnflagProduct.Text = "Unflag";
            btnUnflagProduct.UseVisualStyleBackColor = true;
            btnUnflagProduct.Click += btnUnflagProduct_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial", 16F, FontStyle.Bold);
            label3.Location = new Point(301, 9);
            label3.Name = "label3";
            label3.Size = new Size(384, 32);
            label3.TabIndex = 7;
            label3.Text = "User Feedback Management";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AdminReviews
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Tabby_Photoroom;
            ClientSize = new Size(1008, 606);
            Controls.Add(label3);
            Controls.Add(btnUnflagProduct);
            Controls.Add(button1);
            Controls.Add(btnFlagProduct);
            Controls.Add(txtReviewID);
            Controls.Add(label1);
            Controls.Add(dataGridViewReviews);
            Name = "AdminReviews";
            Text = "AdminReviews";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewReviews;
        private Label label1;
        private TextBox txtReviewID;
        private Button btnFlagProduct;
        private Button button1;
        private Button btnUnflagProduct;
        private Label label3;
    }
}