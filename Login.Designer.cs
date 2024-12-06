namespace DB_Proj_00
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboRole = new ComboBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            btnLogin = new Button();
            button2 = new Button();
            toolTip1 = new ToolTip(components);
            linkLabel2 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(200, 150);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(200, 200);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(200, 250);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 4;
            label3.Text = "Role:";
            // 
            // comboRole
            // 
            comboRole.FormattingEnabled = true;
            comboRole.Items.AddRange(new object[] { "Customer", "Seller", "Admin", "Logistics" });
            comboRole.Location = new Point(300, 250);
            comboRole.Name = "comboRole";
            comboRole.Size = new Size(200, 28);
            comboRole.TabIndex = 5;
            toolTip1.SetToolTip(comboRole, "Select your role from the dropdown.");
            //comboRole.SelectedIndexChanged += comboRole_SelectedIndexChanged;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(300, 150);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 27);
            txtUsername.TabIndex = 1;
            toolTip1.SetToolTip(txtUsername, "Enter your username (e.g., johndoe123).");
            //txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(300, 200);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 3;
            toolTip1.SetToolTip(txtPassword, "Enter your secure password.");
            //txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 16F, FontStyle.Bold);
            label4.Location = new Point(320, 50);
            label4.Name = "label4";
            label4.Size = new Size(90, 32);
            label4.TabIndex = 8;
            label4.Text = "Login";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            //label4.Click += label4_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(270, 300);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 30);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // button2
            // 
            button2.Location = new Point(410, 300);
            button2.Name = "button2";
            button2.Size = new Size(100, 30);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(256, 367);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(254, 20);
            linkLabel2.TabIndex = 11;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Don't have an account? Sign up here!";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLabel2);
            Controls.Add(button2);
            Controls.Add(btnLogin);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(comboRole);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboRole;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private LinkLabel linkLabel1;
        private Label label4;
        private Button btnLogin;
        private Button button2;
        private ToolTip toolTip1;
        private LinkLabel linkLabel2;
    }
}
