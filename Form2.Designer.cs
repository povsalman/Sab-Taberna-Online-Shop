namespace DB_Proj_00
{
    partial class Form2
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
            label1 = new Label();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 20F, FontStyle.Bold);
            label1.Location = new Point(282, 39);
            label1.Name = "label1";
            label1.Size = new Size(147, 40);
            label1.TabIndex = 8;
            label1.Text = "Sign-Up";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Customer", "Seller", "Admin", "Logistics Provider" });
            comboBox1.Location = new Point(248, 124);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(200, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(164, 127);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 4;
            label2.Text = "Role:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(304, 195);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 6;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(282, 409);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 5);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 9;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 250);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Sign-Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private Button button1;
        private ProgressBar progressBar1;
    }
}