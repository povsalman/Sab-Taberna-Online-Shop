namespace DB_Proj_00
{
    partial class Form18
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBoxProduct;
        private Label Prod;
        private Label Sal;
        private Label Rev;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form18));
            pictureBoxProduct = new PictureBox();
            Prod = new Label();
            Sal = new Label();
            Rev = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).BeginInit();
            SuspendLayout();
            
            pictureBoxProduct.Image = (Image)resources.GetObject("pictureBoxProduct.Image");
            pictureBoxProduct.Location = new Point(20, 20);
            pictureBoxProduct.Name = "pictureBoxProduct";
            pictureBoxProduct.Size = new Size(200, 200);
            pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxProduct.TabIndex = 0;
            pictureBoxProduct.TabStop = false;
            
            Prod.AutoSize = true;
            Prod.Font = new Font("Arial", 14F, FontStyle.Bold);
            Prod.Location = new Point(250, 20);
            Prod.Name = "Prod";
            Prod.Size = new Size(479, 33);
            Prod.TabIndex = 1;
            Prod.Text = "Product Name: Digital Wrist Watch";
            
            Sal.AutoSize = true;
            Sal.Font = new Font("Arial", 12F);
            Sal.Location = new Point(250, 80);
            Sal.Name = "Sal";
            Sal.Size = new Size(197, 27);
            Sal.TabIndex = 2;
            Sal.Text = "Sales Count: 150";
            
            Rev.AutoSize = true;
            Rev.Font = new Font("Arial", 12F);
            Rev.Location = new Point(250, 140);
            Rev.Name = "Rev";
            Rev.Size = new Size(206, 27);
            Rev.TabIndex = 3;
            Rev.Text = "Revenue: $18,750";
            

            btnBack.Location = new Point(20, 250);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            


            ClientSize = new Size(942, 324);
            Controls.Add(pictureBoxProduct);
            Controls.Add(Prod);
            Controls.Add(Sal);
            Controls.Add(Rev);
            Controls.Add(btnBack);
            Name = "Form18";
            Text = "Sales Reports and Analytics";
            ((System.ComponentModel.ISupportInitialize)pictureBoxProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
