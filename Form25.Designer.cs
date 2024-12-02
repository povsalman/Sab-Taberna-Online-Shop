namespace DB_Proj_00
{
    partial class Form25
    {
        private Label lblTitle;
        private Button btnSimulateNotification;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.btnSimulateNotification = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 40);
            this.lblTitle.Text = "Delivery Notifications";

            // btnSimulateNotification
            this.btnSimulateNotification.Location = new Point(20, 80);
            this.btnSimulateNotification.Name = "btnSimulateNotification";
            this.btnSimulateNotification.Size = new Size(200, 30);
            this.btnSimulateNotification.Text = "Simulate Notification";
            this.btnSimulateNotification.UseVisualStyleBackColor = true;
            this.btnSimulateNotification.Click += new EventHandler(this.btnSimulateNotification_Click);

            // Form25
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSimulateNotification);
            this.Name = "Form25";
            this.Text = "Delivery Notifications";
            this.ResumeLayout(false);
        }
    }
}
