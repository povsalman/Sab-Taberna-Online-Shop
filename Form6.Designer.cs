namespace DB_Proj_00
{
    partial class Form6
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
            comboBox1 = new ComboBox();
            button2 = new Button();
            button1 = new Button();
            textBox6 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Male", "Female", "Other" });
            comboBox1.Location = new Point(320, 277);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(201, 28);
            comboBox1.TabIndex = 29;
            // 
            // button2
            // 
            button2.Location = new Point(430, 430);
            button2.Name = "button2";
            button2.Size = new Size(91, 28);
            button2.TabIndex = 33;
            button2.Text = "Sign-Up";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(320, 430);
            button1.Name = "button1";
            button1.Size = new Size(91, 28);
            button1.TabIndex = 32;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(320, 327);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(201, 27);
            textBox6.TabIndex = 30;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(320, 227);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(201, 27);
            textBox4.TabIndex = 28;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(320, 177);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(201, 27);
            textBox3.TabIndex = 27;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(320, 127);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(201, 27);
            textBox2.TabIndex = 26;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(320, 77);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 27);
            textBox1.TabIndex = 25;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(144, 380);
            label8.Name = "label8";
            label8.Size = new Size(129, 20);
            label8.TabIndex = 24;
            label8.Text = "Area of Operation";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(144, 330);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 23;
            label7.Text = "Contact";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(144, 280);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 22;
            label6.Text = "Gender";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(144, 230);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 21;
            label5.Text = "Age";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(144, 180);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 20;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 130);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 19;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 80);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 18;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.Location = new Point(180, 20);
            label1.Name = "label1";
            label1.Size = new Size(369, 32);
            label1.TabIndex = 17;
            label1.Text = "Logistics Provider Sign-Up";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(320, 380);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(201, 27);
            textBox5.TabIndex = 34;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(textBox5);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Logistics Provider Sign-Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Button button2;
        private Button button1;
        private TextBox textBox6;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
    }
}