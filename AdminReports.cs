using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DB_Proj_00
{
    public partial class AdminReports : Form
    {
        public AdminReports()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {
            PopulateSalesTrendsChart();
            PopulateUserActivityChart();
            PopulatePlatformPerformance();
        }

        private void PopulateSalesTrendsChart()
        {
            chartSalesTrends.Series["Sales"].Points.Clear();

            var random = new Random();
            for (int month = 1; month <= 12; month++)
            {
                chartSalesTrends.Series["Sales"].Points.AddXY($"Month {month}", random.Next(1000, 5000));
            }
        }

        private void PopulateUserActivityChart()
        {
            chartUserActivity.Series["Active Users"].Points.Clear();

            // Add random user activity data
            var random = new Random();
            for (int week = 1; week <= 12; week++)
            {
                chartUserActivity.Series["Active Users"].Points.AddXY($"Week {week}", random.Next(50, 300));
            }
        }

        private void PopulatePlatformPerformance()
        {
            // Fill random values in labels
            lblTotalSales.Text = $"Total Sales: ${new Random().Next(50000, 200000):N0}";
            lblBestSelling.Text = "Best Selling Product: Digital Watch";
            lblActiveUsers.Text = $"Active Users: {new Random().Next(1000, 5000):N0}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }
    }
}