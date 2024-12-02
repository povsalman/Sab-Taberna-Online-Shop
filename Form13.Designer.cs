using System.Drawing;

namespace DB_Proj_00
{
    partial class Form13
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblProductName;
        private NumericUpDown numericUpDownRating;
        private TextBox txtReview;
        private Button btnSubmitReview;
        private Button btnBack;

        private void InitializeComponent()
        {
            lblProductName = new Label();
            numericUpDownRating = new NumericUpDown();
            txtReview = new TextBox();
            btnSubmitReview = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).BeginInit();
            SuspendLayout();

            //Name of Product
            lblProductName.Location = new Point(210, 28);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(300, 36);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Leave a Review for: Product Name";

            //Review rating
            numericUpDownRating.Location = new Point(322, 82);
            numericUpDownRating.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownRating.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRating.Name = "numericUpDownRating";
            numericUpDownRating.Size = new Size(50, 31);
            numericUpDownRating.TabIndex = 1;
            numericUpDownRating.Value = new decimal(new int[] { 1, 0, 0, 0 });

            
            txtReview.Location = new Point(194, 133);
            txtReview.Multiline = true;
            txtReview.Name = "txtReview";
            txtReview.Size = new Size(300, 100);
            txtReview.TabIndex = 2;

           
            btnSubmitReview.Location = new Point(303, 275);
            btnSubmitReview.Name = "btnSubmitReview";
            btnSubmitReview.Size = new Size(100, 30);
            btnSubmitReview.TabIndex = 3;
            btnSubmitReview.Text = "Submit";
            btnSubmitReview.Click += btnSubmitReview_Click;

           
            btnBack.BackColor = Color.LightCoral;
            btnBack.Location = new Point(20, 580);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;

            
            ClientSize = new Size(718, 562);
            Controls.Add(lblProductName);
            Controls.Add(numericUpDownRating);
            Controls.Add(txtReview);
            Controls.Add(btnSubmitReview);
            Controls.Add(btnBack);
            Name = "Form13";
            Text = "Submit Review";
            ((System.ComponentModel.ISupportInitialize)numericUpDownRating).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
