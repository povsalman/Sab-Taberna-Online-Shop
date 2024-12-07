namespace DB_Proj_00
{
    partial class AdminSignUp
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
            comboGender = new ComboBox();
            btnSignup = new Button();
            btnBackSignupRole = new Button();
            txtContact = new TextBox();
            txtAge = new TextBox();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboGender
            // 
            comboGender.FormattingEnabled = true;
            comboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            comboGender.Location = new Point(320, 258);
            comboGender.Name = "comboGender";
            comboGender.Size = new Size(201, 28);
            comboGender.TabIndex = 29;
            // 
            // btnSignup
            // 
            btnSignup.Location = new Point(430, 385);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(91, 28);
            btnSignup.TabIndex = 33;
            btnSignup.Text = "Sign-Up";
            btnSignup.UseVisualStyleBackColor = true;
            btnSignup.Click += btnSignup_Click;
            // 
            // btnBackSignupRole
            // 
            btnBackSignupRole.Location = new Point(320, 385);
            btnBackSignupRole.Name = "btnBackSignupRole";
            btnBackSignupRole.Size = new Size(91, 28);
            btnBackSignupRole.TabIndex = 32;
            btnBackSignupRole.Text = "Back";
            btnBackSignupRole.UseVisualStyleBackColor = true;
            btnBackSignupRole.Click += btnBackSignupRole_Click;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(320, 308);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(201, 27);
            txtContact.TabIndex = 30;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(320, 208);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(201, 27);
            txtAge.TabIndex = 28;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(320, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(201, 27);
            txtPassword.TabIndex = 26;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(320, 102);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(201, 27);
            txtUsername.TabIndex = 25;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(144, 311);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 23;
            label7.Text = "Contact";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(144, 261);
            label6.Name = "label6";
            label6.Size = new Size(57, 20);
            label6.TabIndex = 22;
            label6.Text = "Gender";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(144, 211);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 21;
            label5.Text = "Age";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 155);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 19;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(144, 105);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 18;
            label2.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.Location = new Point(260, 38);
            label1.Name = "label1";
            label1.Size = new Size(215, 32);
            label1.TabIndex = 17;
            label1.Text = "Admin Sign-Up";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AdminSignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboGender);
            Controls.Add(btnSignup);
            Controls.Add(btnBackSignupRole);
            Controls.Add(txtContact);
            Controls.Add(txtAge);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AdminSignUp";
            Text = "Admin Sign-Up";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboGender;
        private Button btnSignup;
        private Button btnBackSignupRole;
        private TextBox txtContact;
        private TextBox txtAge;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}