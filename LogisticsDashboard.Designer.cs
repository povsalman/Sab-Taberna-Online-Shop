namespace DB_Proj_00
{
    partial class LogisticsDashboard
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
        /// 
        private Button btnLogisticsInterface;
        private Button btnDeliveryNotifications;
        private Button btnShipmentScheduling;



        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnLogisticsInterface = new Button();
            button4 = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            btnDeliveryNotifications = new Button();
            btnShipmentScheduling = new Button();
            panel2 = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPage2 = new TabPage();
            label15 = new Label();
            button7 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            tabPage3 = new TabPage();
            button8 = new Button();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(btnLogisticsInterface);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnDeliveryNotifications);
            panel1.Controls.Add(btnShipmentScheduling);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(142, 539);
            panel1.TabIndex = 0;
            // 
            // btnLogisticsInterface
            // 
            btnLogisticsInterface.BackColor = Color.DarkGray;
            btnLogisticsInterface.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnLogisticsInterface.ForeColor = Color.White;
            btnLogisticsInterface.Location = new Point(0, 180);
            btnLogisticsInterface.Name = "btnLogisticsInterface";
            btnLogisticsInterface.Size = new Size(142, 29);
            btnLogisticsInterface.TabIndex = 5;
            btnLogisticsInterface.Text = "Order trackinge";
            btnLogisticsInterface.UseVisualStyleBackColor = false;
            btnLogisticsInterface.Click += btnLogisticsInterface_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Gray;
            button4.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 180);
            button4.Name = "button4";
            button4.Size = new Size(142, 29);
            button4.TabIndex = 4;
            button4.Text = "Account Mng.";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Gray;
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 420);
            button3.Name = "button3";
            button3.Size = new Size(142, 29);
            button3.TabIndex = 3;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Tabby;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(142, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnDeliveryNotifications
            // 
            btnDeliveryNotifications.BackColor = Color.DarkGray;
            btnDeliveryNotifications.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeliveryNotifications.ForeColor = Color.White;
            btnDeliveryNotifications.Location = new Point(0, 228);
            btnDeliveryNotifications.Name = "btnDeliveryNotifications";
            btnDeliveryNotifications.Size = new Size(142, 54);
            btnDeliveryNotifications.TabIndex = 7;
            btnDeliveryNotifications.Text = "Delivery Notifications";
            btnDeliveryNotifications.UseVisualStyleBackColor = false;
            btnDeliveryNotifications.Click += btnDeliveryNotifications_Click;
            // 
            // btnShipmentScheduling
            // 
            btnShipmentScheduling.BackColor = Color.DarkGray;
            btnShipmentScheduling.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnShipmentScheduling.ForeColor = Color.White;
            btnShipmentScheduling.Location = new Point(3, 303);
            btnShipmentScheduling.Name = "btnShipmentScheduling";
            btnShipmentScheduling.Size = new Size(136, 60);
            btnShipmentScheduling.TabIndex = 8;
            btnShipmentScheduling.Text = "Shipment Scheduling";
            btnShipmentScheduling.UseVisualStyleBackColor = false;
            btnShipmentScheduling.Click += btnShipmentScheduling_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(142, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(855, 539);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(tabControl1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(855, 539);
            panel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.Location = new Point(193, 9);
            label1.Name = "label1";
            label1.Size = new Size(298, 32);
            label1.TabIndex = 0;
            label1.Text = "Account Management";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(6, 43);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(837, 493);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 3, 3, 3);
            tabPage1.Size = new Size(829, 460);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Prof. Info.";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 21F, FontStyle.Bold | FontStyle.Italic);
            label8.Location = new Point(186, 51);
            label8.Name = "label8";
            label8.Size = new Size(337, 40);
            label8.TabIndex = 6;
            label8.Text = "Welcome, Logistics";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(267, 262);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10F, FontStyle.Bold);
            label6.Location = new Point(153, 263);
            label6.Name = "label6";
            label6.Size = new Size(105, 19);
            label6.TabIndex = 4;
            label6.Text = "Shop Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 203);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 10F, FontStyle.Bold);
            label4.Location = new Point(153, 203);
            label4.Name = "label4";
            label4.Size = new Size(136, 19);
            label4.TabIndex = 2;
            label4.Text = "Account Status:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(267, 143);
            label3.Name = "label3";
            label3.Size = new Size(0, 20);
            label3.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 10F, FontStyle.Bold);
            label2.Location = new Point(153, 143);
            label2.Name = "label2";
            label2.Size = new Size(94, 19);
            label2.TabIndex = 0;
            label2.Text = "Username:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label9);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 3, 3, 3);
            tabPage2.Size = new Size(633, 370);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Chng. Pwd.";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 19F, FontStyle.Bold);
            label15.Location = new Point(193, 33);
            label15.Name = "label15";
            label15.Size = new Size(292, 37);
            label15.TabIndex = 5;
            label15.Text = "Password Change";
            // 
            // button7
            // 
            button7.BackColor = Color.WhiteSmoke;
            button7.Location = new Point(265, 288);
            button7.Name = "button7";
            button7.Size = new Size(94, 29);
            button7.TabIndex = 4;
            button7.Text = "Save";
            button7.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(300, 193);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(177, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(300, 133);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 27);
            textBox1.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 7F, FontStyle.Bold);
            label10.Location = new Point(153, 203);
            label10.Name = "label10";
            label10.Size = new Size(116, 15);
            label10.TabIndex = 1;
            label10.Text = "Confirm Password:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 7F, FontStyle.Bold);
            label9.Location = new Point(153, 143);
            label9.Name = "label9";
            label9.Size = new Size(96, 15);
            label9.TabIndex = 0;
            label9.Text = "New Password:";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button8);
            tabPage3.Controls.Add(textBox5);
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(label11);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(633, 370);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Edit Prof.";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.BackColor = Color.WhiteSmoke;
            button8.Location = new Point(272, 304);
            button8.Name = "button8";
            button8.Size = new Size(94, 29);
            button8.TabIndex = 7;
            button8.Text = "Save";
            button8.UseVisualStyleBackColor = false;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(284, 235);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(168, 27);
            textBox5.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(284, 175);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(168, 27);
            textBox4.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(284, 115);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(168, 27);
            textBox3.TabIndex = 4;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9F, FontStyle.Bold);
            label14.Location = new Point(160, 240);
            label14.Name = "label14";
            label14.Size = new Size(93, 18);
            label14.TabIndex = 3;
            label14.Text = "Shop Name:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9F, FontStyle.Bold);
            label13.Location = new Point(160, 180);
            label13.Name = "label13";
            label13.Size = new Size(70, 18);
            label13.TabIndex = 2;
            label13.Text = "Address:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9F, FontStyle.Bold);
            label12.Location = new Point(160, 120);
            label12.Name = "label12";
            label12.Size = new Size(84, 18);
            label12.TabIndex = 1;
            label12.Text = "Username:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 19F, FontStyle.Bold);
            label11.Location = new Point(240, 30);
            label11.Name = "label11";
            label11.Size = new Size(188, 37);
            label11.TabIndex = 0;
            label11.Text = "Edit Profile";
            // 
            // LogisticsDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 539);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "LogisticsDashboard";
            Text = "Taberna -Logistics Provider UI";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button4;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TabPage tabPage2;
        private Label label15;
        private Button button7;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label10;
        private Label label9;
        private TabPage tabPage3;
        private Button button8;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
    }
}