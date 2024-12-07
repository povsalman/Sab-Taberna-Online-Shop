namespace DB_Proj_00
{
    partial class AdminUserMng
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView Acc;
        private Button btnApprove;
        private Button btnReject;
        private Button btnBack;


        private void InitializeComponent()
        {
            Acc = new DataGridView();
            btnApprove = new Button();
            btnReject = new Button();
            btnBack = new Button();
            btnShowCustomers = new Button();
            btnShowSellers = new Button();
            btnUpdate = new Button();
            label1 = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUserID = new TextBox();
            label3 = new Label();
            txtContact = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            comboVerification = new ComboBox();
            comboAccountStatus = new ComboBox();
            comboGender = new ComboBox();
            txtName = new TextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)Acc).BeginInit();
            SuspendLayout();
            // 
            // Acc
            // 
            Acc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Acc.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Acc.BackgroundColor = SystemColors.GradientActiveCaption;
            Acc.BorderStyle = BorderStyle.Fixed3D;
            Acc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Acc.Location = new Point(20, 20);
            Acc.Name = "Acc";
            Acc.RowHeadersWidth = 62;
            Acc.Size = new Size(957, 299);
            Acc.TabIndex = 0;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(544, 561);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(150, 30);
            btnApprove.TabIndex = 1;
            btnApprove.Text = "Approve Seller";
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(700, 561);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(150, 30);
            btnReject.TabIndex = 2;
            btnReject.Text = "Reject Seller";
            btnReject.Click += btnReject_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(877, 561);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // btnShowCustomers
            // 
            btnShowCustomers.Location = new Point(23, 337);
            btnShowCustomers.Name = "btnShowCustomers";
            btnShowCustomers.Size = new Size(139, 29);
            btnShowCustomers.TabIndex = 5;
            btnShowCustomers.Text = "Show Customers";
            btnShowCustomers.UseVisualStyleBackColor = true;
            btnShowCustomers.Click += btnShowCustomers_Click;
            // 
            // btnShowSellers
            // 
            btnShowSellers.Location = new Point(838, 337);
            btnShowSellers.Name = "btnShowSellers";
            btnShowSellers.Size = new Size(139, 29);
            btnShowSellers.TabIndex = 6;
            btnShowSellers.Text = "Show Sellers";
            btnShowSellers.UseVisualStyleBackColor = true;
            btnShowSellers.Click += btnShowSellers_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(378, 561);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 30);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 444);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 8;
            label1.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(112, 441);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(159, 27);
            txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(112, 494);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(159, 27);
            txtPassword.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 497);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 10;
            label2.Text = "Password:";
            // 
            // txtUserID
            // 
            txtUserID.Location = new Point(112, 386);
            txtUserID.Name = "txtUserID";
            txtUserID.Size = new Size(159, 27);
            txtUserID.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 389);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 12;
            label3.Text = "User ID:";
            // 
            // txtContact
            // 
            txtContact.Location = new Point(476, 436);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(159, 27);
            txtContact.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(384, 439);
            label4.Name = "label4";
            label4.Size = new Size(63, 20);
            label4.TabIndex = 14;
            label4.Text = "Contact:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(720, 390);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 16;
            label5.Text = "Verification:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(358, 498);
            label6.Name = "label6";
            label6.Size = new Size(107, 20);
            label6.TabIndex = 18;
            label6.Text = "Account Status";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(717, 439);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 20;
            label7.Text = "Gender:";
            // 
            // comboVerification
            // 
            comboVerification.FormattingEnabled = true;
            comboVerification.Items.AddRange(new object[] { "Pending", "Verified", "Rejected" });
            comboVerification.Location = new Point(826, 386);
            comboVerification.Name = "comboVerification";
            comboVerification.Size = new Size(151, 28);
            comboVerification.TabIndex = 22;
            // 
            // comboAccountStatus
            // 
            comboAccountStatus.FormattingEnabled = true;
            comboAccountStatus.Items.AddRange(new object[] { "Active", "Suspended" });
            comboAccountStatus.Location = new Point(484, 494);
            comboAccountStatus.Name = "comboAccountStatus";
            comboAccountStatus.Size = new Size(151, 28);
            comboAccountStatus.TabIndex = 23;
            // 
            // comboGender
            // 
            comboGender.FormattingEnabled = true;
            comboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            comboGender.Location = new Point(826, 439);
            comboGender.Name = "comboGender";
            comboGender.Size = new Size(151, 28);
            comboGender.TabIndex = 24;
            // 
            // txtName
            // 
            txtName.Location = new Point(476, 386);
            txtName.Name = "txtName";
            txtName.Size = new Size(159, 27);
            txtName.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(384, 389);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 25;
            label8.Text = "Name:";
            // 
            // AdminUserMng
            // 
            ClientSize = new Size(998, 603);
            Controls.Add(txtName);
            Controls.Add(label8);
            Controls.Add(comboGender);
            Controls.Add(comboAccountStatus);
            Controls.Add(comboVerification);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtContact);
            Controls.Add(label4);
            Controls.Add(txtUserID);
            Controls.Add(label3);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Controls.Add(btnUpdate);
            Controls.Add(btnShowSellers);
            Controls.Add(btnShowCustomers);
            Controls.Add(Acc);
            Controls.Add(btnApprove);
            Controls.Add(btnReject);
            Controls.Add(btnBack);
            Name = "AdminUserMng";
            Text = "Admin - User and Seller Management";
            ((System.ComponentModel.ISupportInitialize)Acc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnShowCustomers;
        private Button btnShowSellers;
        private Button btnUpdate;
        private Label label1;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUserID;
        private Label label3;
        private TextBox txtContact;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ComboBox comboVerification;
        private ComboBox comboAccountStatus;
        private ComboBox comboGender;
        private TextBox txtName;
        private Label label8;
    }
}