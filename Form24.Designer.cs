namespace DB_Proj_00
{
    partial class Form24
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Button btnAssignAgent;
        private Button btnTrackShipment;
        private Button btnPendingOrders;
        private Button btnGenerateReports;
        private Panel panelOrderDetails;

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
            this.lblTitle = new Label();
            this.btnAssignAgent = new Button();
            this.btnTrackShipment = new Button();
            this.btnPendingOrders = new Button();
            this.btnGenerateReports = new Button();
            this.panelOrderDetails = new Panel();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(250, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Logistics and Shipping";

            // btnAssignAgent
            this.btnAssignAgent.Location = new Point(50, 100);
            this.btnAssignAgent.Name = "btnAssignAgent";
            this.btnAssignAgent.Size = new Size(200, 40);
            this.btnAssignAgent.TabIndex = 1;
            this.btnAssignAgent.Text = "Assign Delivery Agent";
            this.btnAssignAgent.UseVisualStyleBackColor = true;
            this.btnAssignAgent.Click += new EventHandler(this.btnAssignAgent_Click);

            // btnTrackShipment
            this.btnTrackShipment.Location = new Point(300, 100);
            this.btnTrackShipment.Name = "btnTrackShipment";
            this.btnTrackShipment.Size = new Size(200, 40);
            this.btnTrackShipment.TabIndex = 2;
            this.btnTrackShipment.Text = "Track Shipment";
            this.btnTrackShipment.UseVisualStyleBackColor = true;
            this.btnTrackShipment.Click += new EventHandler(this.btnTrackShipment_Click);

            // btnPendingOrders
            this.btnPendingOrders.Location = new Point(50, 180);
            this.btnPendingOrders.Name = "btnPendingOrders";
            this.btnPendingOrders.Size = new Size(200, 40);
            this.btnPendingOrders.TabIndex = 3;
            this.btnPendingOrders.Text = "View Pending Orders";
            this.btnPendingOrders.UseVisualStyleBackColor = true;
            this.btnPendingOrders.Click += new EventHandler(this.btnPendingOrders_Click);

            // btnGenerateReports
            this.btnGenerateReports.Location = new Point(300, 180);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Size = new Size(200, 40);
            this.btnGenerateReports.TabIndex = 4;
            this.btnGenerateReports.Text = "Generate Shipping Reports";
            this.btnGenerateReports.UseVisualStyleBackColor = true;
            this.btnGenerateReports.Click += new EventHandler(this.btnGenerateReports_Click);

            // panelOrderDetails
            this.panelOrderDetails.BackColor = SystemColors.ControlLight;
            this.panelOrderDetails.Location = new Point(50, 260);
            this.panelOrderDetails.Name = "panelOrderDetails";
            this.panelOrderDetails.Size = new Size(600, 200);
            this.panelOrderDetails.TabIndex = 5;

            // Form24
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAssignAgent);
            this.Controls.Add(this.btnTrackShipment);
            this.Controls.Add(this.btnPendingOrders);
            this.Controls.Add(this.btnGenerateReports);
            this.Controls.Add(this.panelOrderDetails);
            this.Name = "Form24";
            this.Text = "Logistics and Shipping Interface";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
