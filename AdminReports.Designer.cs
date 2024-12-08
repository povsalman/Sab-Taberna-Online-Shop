using System.Windows.Forms.DataVisualization.Charting;
namespace DB_Proj_00
{
    partial class AdminReports
    {
        private System.ComponentModel.IContainer components = null;

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
            btnBack = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnUDReport = new Button();
            btnPGreport = new Button();
            btnOFReport = new Button();
            btnRPCReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(879, 608);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(33, 71);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(922, 494);
            dataGridView1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 16F, FontStyle.Bold);
            label1.Location = new Point(429, 20);
            label1.Name = "label1";
            label1.Size = new Size(118, 32);
            label1.TabIndex = 7;
            label1.Text = "Reports";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUDReport
            // 
            btnUDReport.Location = new Point(62, 595);
            btnUDReport.Name = "btnUDReport";
            btnUDReport.Size = new Size(143, 43);
            btnUDReport.TabIndex = 8;
            btnUDReport.Text = "User Demographic";
            btnUDReport.UseVisualStyleBackColor = true;
            btnUDReport.Click += btnUDReport_Click;
            // 
            // btnPGreport
            // 
            btnPGreport.Location = new Point(237, 595);
            btnPGreport.Name = "btnPGreport";
            btnPGreport.Size = new Size(143, 43);
            btnPGreport.TabIndex = 9;
            btnPGreport.Text = "Platform Growth";
            btnPGreport.UseVisualStyleBackColor = true;
            btnPGreport.Click += btnPGreport_Click;
            // 
            // btnOFReport
            // 
            btnOFReport.Location = new Point(418, 595);
            btnOFReport.Name = "btnOFReport";
            btnOFReport.Size = new Size(143, 43);
            btnOFReport.TabIndex = 10;
            btnOFReport.Text = "Order Fulfilment";
            btnOFReport.UseVisualStyleBackColor = true;
            btnOFReport.Click += btnOFReport_Click;
            // 
            // btnRPCReport
            // 
            btnRPCReport.Location = new Point(597, 595);
            btnRPCReport.Name = "btnRPCReport";
            btnRPCReport.Size = new Size(143, 43);
            btnRPCReport.TabIndex = 11;
            btnRPCReport.Text = "Revenue Prd-Cat.";
            btnRPCReport.UseVisualStyleBackColor = true;
            btnRPCReport.Click += btnRPCReport_Click;
            // 
            // AdminReports
            // 
            ClientSize = new Size(1000, 650);
            Controls.Add(btnRPCReport);
            Controls.Add(btnOFReport);
            Controls.Add(btnPGreport);
            Controls.Add(btnUDReport);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnBack);
            Name = "AdminReports";
            Text = "Reports and Analytics";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnBack;
        private DataGridView dataGridView1;
        private Label label1;
        private Button btnUDReport;
        private Button btnPGreport;
        private Button btnOFReport;
        private Button btnRPCReport;
    }
}