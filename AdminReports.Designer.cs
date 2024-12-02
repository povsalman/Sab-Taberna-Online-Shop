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
            ChartArea chartArea1 = new ChartArea();
            Series series1 = new Series();
            Title title1 = new Title();
            ChartArea chartArea2 = new ChartArea();
            Series series2 = new Series();
            Title title2 = new Title();
            chartSalesTrends = new Chart();
            chartUserActivity = new Chart();
            lblTotalSales = new Label();
            lblBestSelling = new Label();
            lblActiveUsers = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)chartSalesTrends).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartUserActivity).BeginInit();
            SuspendLayout();
            // 
            // chartSalesTrends
            // 
            chartSalesTrends.Anchor = AnchorStyles.Top;
            chartArea1.Name = "ChartArea1";
            chartSalesTrends.ChartAreas.Add(chartArea1);
            chartSalesTrends.Location = new Point(112, 12);
            chartSalesTrends.Name = "chartSalesTrends";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Sales";
            chartSalesTrends.Series.Add(series1);
            chartSalesTrends.Size = new Size(600, 300);
            chartSalesTrends.TabIndex = 0;
            chartSalesTrends.Text = "Sales Trends";
            title1.Name = "Title1";
            title1.Text = "Monthly Sales Trends";
            chartSalesTrends.Titles.Add(title1);
            // 
            // chartUserActivity
            // 
            chartUserActivity.Anchor = AnchorStyles.Top;
            chartArea2.Name = "ChartArea2";
            chartUserActivity.ChartAreas.Add(chartArea2);
            chartUserActivity.Location = new Point(112, 318);
            chartUserActivity.Name = "chartUserActivity";
            series2.ChartArea = "ChartArea2";
            series2.Name = "Active Users";
            chartUserActivity.Series.Add(series2);
            chartUserActivity.Size = new Size(600, 300);
            chartUserActivity.TabIndex = 1;
            chartUserActivity.Text = "User Activity";
            title2.Name = "Title1";
            title2.Text = "Weekly Active Users";
            chartUserActivity.Titles.Add(title2);
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblTotalSales.Location = new Point(756, 31);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(121, 24);
            lblTotalSales.TabIndex = 2;
            lblTotalSales.Text = "Total Sales:";
            // 
            // lblBestSelling
            // 
            lblBestSelling.AutoSize = true;
            lblBestSelling.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblBestSelling.Location = new Point(727, 100);
            lblBestSelling.Name = "lblBestSelling";
            lblBestSelling.Size = new Size(210, 24);
            lblBestSelling.TabIndex = 3;
            lblBestSelling.Text = "Best Selling Product:";
            // 
            // lblActiveUsers
            // 
            lblActiveUsers.AutoSize = true;
            lblActiveUsers.Font = new Font("Arial", 10F, FontStyle.Bold);
            lblActiveUsers.Location = new Point(741, 164);
            lblActiveUsers.Name = "lblActiveUsers";
            lblActiveUsers.Size = new Size(136, 24);
            lblActiveUsers.TabIndex = 4;
            lblActiveUsers.Text = "Active Users:";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(630, 600);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Form23
            // 
            ClientSize = new Size(1000, 650);
            Controls.Add(btnBack);
            Controls.Add(lblActiveUsers);
            Controls.Add(lblBestSelling);
            Controls.Add(lblTotalSales);
            Controls.Add(chartUserActivity);
            Controls.Add(chartSalesTrends);
            Name = "Form23";
            Text = "Reports and Analytics";
            Load += Form23_Load;
            ((System.ComponentModel.ISupportInitialize)chartSalesTrends).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartUserActivity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesTrends;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUserActivity;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblBestSelling;
        private System.Windows.Forms.Label lblActiveUsers;
        private System.Windows.Forms.Button btnBack;
    }
}
