namespace DB_Proj_00
{
    partial class Form12
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelCartHeader;
        private System.Windows.Forms.Label labelNameHeader;
        private System.Windows.Forms.Label labelQuantityHeader;
        private System.Windows.Forms.Label labelPriceHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label labelQuantity1;
        private System.Windows.Forms.Label labelQuantity2;
        private System.Windows.Forms.Label labelQuantity3;
        private System.Windows.Forms.Label labelPrice1;
        private System.Windows.Forms.Label labelPrice2;
        private System.Windows.Forms.Label labelPrice3;
        private System.Windows.Forms.Button btnBack;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed of; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            labelTitle = new Label();
            panelCartHeader = new Panel();
            labelNameHeader = new Label();
            labelQuantityHeader = new Label();
            labelPriceHeader = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            labelQuantity1 = new Label();
            labelQuantity2 = new Label();
            labelQuantity3 = new Label();
            labelPrice1 = new Label();
            labelPrice2 = new Label();
            labelPrice3 = new Label();
            btnBack = new Button();
            panelCartHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Arial", 16F, FontStyle.Bold);
            labelTitle.Location = new Point(0, 12);
            labelTitle.Margin = new Padding(4, 0, 4, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(1000, 50);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Your Cart";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCartHeader
            // 
            panelCartHeader.BackColor = Color.LightGray;
            panelCartHeader.Controls.Add(labelNameHeader);
            panelCartHeader.Controls.Add(labelQuantityHeader);
            panelCartHeader.Controls.Add(labelPriceHeader);
            panelCartHeader.Location = new Point(12, 75);
            panelCartHeader.Margin = new Padding(4, 4, 4, 4);
            panelCartHeader.Name = "panelCartHeader";
            panelCartHeader.Size = new Size(975, 50);
            panelCartHeader.TabIndex = 1;
            // 
            // labelNameHeader
            // 
            labelNameHeader.Font = new Font("Arial", 10F, FontStyle.Bold);
            labelNameHeader.Location = new Point(12, 6);
            labelNameHeader.Margin = new Padding(4, 0, 4, 0);
            labelNameHeader.Name = "labelNameHeader";
            labelNameHeader.Size = new Size(250, 38);
            labelNameHeader.TabIndex = 2;
            labelNameHeader.Text = "Name";
            labelNameHeader.TextAlign = ContentAlignment.MiddleLeft;
            

            //Quantity
            labelQuantityHeader.Font = new Font("Arial", 10F, FontStyle.Bold);
            labelQuantityHeader.Location = new Point(375, 6);
            labelQuantityHeader.Margin = new Padding(4, 0, 4, 0);
            labelQuantityHeader.Name = "labelQuantityHeader";
            labelQuantityHeader.Size = new Size(188, 38);
            labelQuantityHeader.TabIndex = 3;
            labelQuantityHeader.Text = "Quantity";
            labelQuantityHeader.TextAlign = ContentAlignment.MiddleCenter;
            

            //Price 
            labelPriceHeader.Font = new Font("Arial", 10F, FontStyle.Bold);
            labelPriceHeader.Location = new Point(688, 6);
            labelPriceHeader.Margin = new Padding(4, 0, 4, 0);
            labelPriceHeader.Name = "labelPriceHeader";
            labelPriceHeader.Size = new Size(188, 38);
            labelPriceHeader.TabIndex = 4;
            labelPriceHeader.Text = "Price";
            labelPriceHeader.TextAlign = ContentAlignment.MiddleCenter;
            
            
            //Pictures
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(25, 150);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 188);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            
            
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(25, 350);
            pictureBox2.Margin = new Padding(4, 4, 4, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(250, 188);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            
            
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(25, 550);
            pictureBox3.Margin = new Padding(4, 4, 4, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(250, 188);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            



            labelQuantity1.Font = new Font("Arial", 10F);
            labelQuantity1.Location = new Point(400, 212);
            labelQuantity1.Margin = new Padding(4, 0, 4, 0);
            labelQuantity1.Name = "labelQuantity1";
            labelQuantity1.Size = new Size(188, 38);
            labelQuantity1.TabIndex = 5;
            labelQuantity1.Text = "1";
            labelQuantity1.TextAlign = ContentAlignment.MiddleCenter;
            
            

            labelQuantity2.Font = new Font("Arial", 10F);
            labelQuantity2.Location = new Point(400, 412);
            labelQuantity2.Margin = new Padding(4, 0, 4, 0);
            labelQuantity2.Name = "labelQuantity2";
            labelQuantity2.Size = new Size(188, 38);
            labelQuantity2.TabIndex = 6;
            labelQuantity2.Text = "2";
            labelQuantity2.TextAlign = ContentAlignment.MiddleCenter;
            

            labelQuantity3.Font = new Font("Arial", 10F);
            labelQuantity3.Location = new Point(400, 612);
            labelQuantity3.Margin = new Padding(4, 0, 4, 0);
            labelQuantity3.Name = "labelQuantity3";
            labelQuantity3.Size = new Size(188, 38);
            labelQuantity3.TabIndex = 7;
            labelQuantity3.Text = "3";
            labelQuantity3.TextAlign = ContentAlignment.MiddleCenter;
           

            //Prices
            labelPrice1.Font = new Font("Arial", 10F);
            labelPrice1.Location = new Point(688, 212);
            labelPrice1.Margin = new Padding(4, 0, 4, 0);
            labelPrice1.Name = "labelPrice1";
            labelPrice1.Size = new Size(188, 38);
            labelPrice1.TabIndex = 8;
            labelPrice1.Text = "$125";
            labelPrice1.TextAlign = ContentAlignment.MiddleCenter;
            
            labelPrice2.Font = new Font("Arial", 10F);
            labelPrice2.Location = new Point(688, 412);
            labelPrice2.Margin = new Padding(4, 0, 4, 0);
            labelPrice2.Name = "labelPrice2";
            labelPrice2.Size = new Size(188, 38);
            labelPrice2.TabIndex = 9;
            labelPrice2.Text = "$259";
            labelPrice2.TextAlign = ContentAlignment.MiddleCenter;
            
            labelPrice3.Font = new Font("Arial", 10F);
            labelPrice3.Location = new Point(688, 612);
            labelPrice3.Margin = new Padding(4, 0, 4, 0);
            labelPrice3.Name = "labelPrice3";
            labelPrice3.Size = new Size(188, 38);
            labelPrice3.TabIndex = 10;
            labelPrice3.Text = "$175";
            labelPrice3.TextAlign = ContentAlignment.MiddleCenter;
            


            //Back button
            btnBack.BackColor = Color.Gray;
            btnBack.Font = new Font("Arial", 10F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(25, 775);
            btnBack.Margin = new Padding(4, 4, 4, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(125, 50);
            btnBack.TabIndex = 11;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            



            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 784);
            Controls.Add(labelTitle);
            Controls.Add(panelCartHeader);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox3);
            Controls.Add(labelQuantity1);
            Controls.Add(labelQuantity2);
            Controls.Add(labelQuantity3);
            Controls.Add(labelPrice1);
            Controls.Add(labelPrice2);
            Controls.Add(labelPrice3);
            Controls.Add(btnBack);
            Margin = new Padding(4, 4, 4, 4);
            Name = "Form12";
            Text = "Cart";
            panelCartHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }
    }
}
