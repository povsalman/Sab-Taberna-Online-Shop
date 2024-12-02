namespace DB_Proj_00
{
    partial class Form26
    {
        private Label lblTitle;
        private Button btnAddSchedule;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.btnAddSchedule = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(400, 40);
            this.lblTitle.Text = "Shipment Scheduling";

            // btnAddSchedule
            this.btnAddSchedule.Location = new Point(20, 80);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new Size(200, 30);
            this.btnAddSchedule.Text = "Add Schedule";
            this.btnAddSchedule.UseVisualStyleBackColor = true;
            this.btnAddSchedule.Click += new EventHandler(this.btnAddSchedule_Click);

            // Form26
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(500, 200);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAddSchedule);
            this.Name = "Form26";
            this.Text = "Shipment Scheduling";
            this.ResumeLayout(false);
        }
    }
}
