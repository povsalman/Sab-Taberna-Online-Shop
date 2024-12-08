using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace DB_Proj_00
{
    public partial class AdminReports : Form
    {
        public AdminReports()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminNewDashboard adminNewDashboard = new AdminNewDashboard();
            adminNewDashboard.Show();
            this.Close();
        }

        private void btnUDReport_Click(object sender, EventArgs e)
        {
            // Create a DataTable to hold the report data
            DataTable reportData = new DataTable();

            try
            {
                using (var connection = DBHandler.GetConnection())
                {
                    connection.Open();

                    // Query to get user demographic insights
                    string query = @"
                   WITH AgeDistribution AS (
                    SELECT 
                        CASE 
                            WHEN Age BETWEEN 0 AND 18 THEN '0-18'
                            WHEN Age BETWEEN 19 AND 25 THEN '19-25'
                            WHEN Age BETWEEN 26 AND 35 THEN '26-35'
                            WHEN Age BETWEEN 36 AND 50 THEN '36-50'
                            ELSE '51+' 
                        END AS AgeGroup,
                        COUNT(*) AS UserCount
                    FROM ISUSER
                    WHERE AccountType = 'Customer'
                    GROUP BY 
                        CASE 
                            WHEN Age BETWEEN 0 AND 18 THEN '0-18'
                            WHEN Age BETWEEN 19 AND 25 THEN '19-25'
                            WHEN Age BETWEEN 26 AND 35 THEN '26-35'
                            WHEN Age BETWEEN 36 AND 50 THEN '36-50'
                            ELSE '51+' 
                        END
                ),
                GenderDistribution AS (
                    SELECT 
                        Gender, 
                        COUNT(*) AS GenderCount
                    FROM ISUSER
                    WHERE AccountType = 'Customer'
                    GROUP BY Gender
                ),
                LocationInsights AS (
                    SELECT 
                        Country, 
                        City, 
                        COUNT(*) AS UserCount
                    FROM ISUSER
                    WHERE AccountType = 'Customer'
                    GROUP BY Country, City
                ),
                DemographicPreferences AS (
                    SELECT 
                        u.Gender,
                        CASE 
                            WHEN u.Age BETWEEN 0 AND 18 THEN '0-18'
                            WHEN u.Age BETWEEN 19 AND 25 THEN '19-25'
                            WHEN u.Age BETWEEN 26 AND 35 THEN '26-35'
                            WHEN u.Age BETWEEN 36 AND 50 THEN '36-50'
                            ELSE '51+' 
                        END AS AgeGroup,
                        c.CategoryName,
                        COUNT(o.OrderID) AS TotalOrders
                    FROM ISUSER u
                    JOIN CUSTOMER cu ON u.UserID = cu.UserID
                    JOIN ISORDER o ON cu.CustomerID = o.CustomerID
                    JOIN ORDER_ITEM oi ON o.OrderID = oi.OrderID
                    JOIN ISPRODUCT p ON oi.ProductID = p.ProductID
                    JOIN CATEGORY c ON p.CategoryID = c.CategoryID
                    GROUP BY 
                        u.Gender, 
                        CASE 
                            WHEN u.Age BETWEEN 0 AND 18 THEN '0-18'
                            WHEN u.Age BETWEEN 19 AND 25 THEN '19-25'
                            WHEN u.Age BETWEEN 26 AND 35 THEN '26-35'
                            WHEN u.Age BETWEEN 36 AND 50 THEN '36-50'
                            ELSE '51+' 
                        END,
                        c.CategoryName
                )
                SELECT 
                    'Age Distribution' AS InsightType,
                    AgeGroup AS KeyMetric,
                    UserCount AS Value
                FROM AgeDistribution

                UNION ALL

                SELECT 
                    'Gender Analysis' AS InsightType,
                    Gender AS KeyMetric,
                    GenderCount AS Value
                FROM GenderDistribution

                UNION ALL

                SELECT 
                    'Location Insights' AS InsightType,
                    CONCAT(Country, ', ', City) AS KeyMetric,
                    UserCount AS Value
                FROM LocationInsights

                UNION ALL

                SELECT 
                    'Demographic Preferences' AS InsightType,
                    CONCAT(Gender, ' (', AgeGroup, ') prefers ', CategoryName) AS KeyMetric,
                    TotalOrders AS Value
                FROM DemographicPreferences;
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(reportData);
                    }
                }

                // Bind the report data to the DataGridView
                dataGridView1.DataSource = reportData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}");
            }
        }

        private void btnPGreport_Click(object sender, EventArgs e)
        {
            string query = @"
                WITH NewUserRegistrations AS (
                    SELECT 
                        FORMAT(RegistrationDate, 'yyyy-MM') AS RegistrationMonth,
                        COUNT(UserID) AS NewRegistrations
                    FROM ISUSER
                    GROUP BY FORMAT(RegistrationDate, 'yyyy-MM')
                ),
                UserLoginFrequency AS (
                    SELECT 
                        u.UserID,
                        u.UserName,
                        COUNT(lh.LoginID) AS LoginCount
                    FROM ISUSER u
                    LEFT JOIN LOGIN_HISTORY lh ON u.UserID = lh.UserID
                    GROUP BY u.UserID, u.UserName
                ),
                ChurnRateCalculation AS (
                    SELECT 
                        CAST(SUM(CASE WHEN o.CustomerID IS NULL THEN 1 ELSE 0 END) AS FLOAT) / COUNT(*) * 100 AS ChurnRate
                    FROM CUSTOMER c
                    LEFT JOIN ISORDER o ON c.CustomerID = o.CustomerID
                    WHERE c.AccountStatus = 'Active'
                ),
                ActiveUserRatio AS (
                    SELECT 
                        CAST(COUNT(DISTINCT o.CustomerID) AS FLOAT) / (SELECT COUNT(*) FROM ISUSER WHERE AccountType = 'Customer') * 100 AS ActiveUserRatio
                    FROM ISORDER o
                    WHERE o.OrderDate >= DATEADD(MONTH, -6, GETDATE())
                )
                SELECT 
                    'New User Registrations' AS MetricType,
                    RegistrationMonth AS MetricKey,
                    NewRegistrations AS MetricValue
                FROM NewUserRegistrations

                UNION ALL

                SELECT 
                    'User Login Frequency' AS MetricType,
                    UserName AS MetricKey,
                    LoginCount AS MetricValue
                FROM UserLoginFrequency

                UNION ALL

                SELECT 
                    'Churn Rate' AS MetricType,
                    'Percentage of Inactive Customers' AS MetricKey,
                    ChurnRate AS MetricValue
                FROM ChurnRateCalculation

                UNION ALL

                SELECT 
                    'Active User Ratio' AS MetricType,
                    'Percentage of Active Users' AS MetricKey,
                    ActiveUserRatio AS MetricValue
                FROM ActiveUserRatio;";

            using (var connection = DBHandler.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void btnOFReport_Click(object sender, EventArgs e)
        {
            string query = @"
                WITH FulfillmentTimes AS (
                    SELECT 
                        o.OrderID,
                        DATEDIFF(DAY, o.OrderDate, MIN(s.PickupDate)) AS FulfillmentTime
                    FROM ISORDER o
                    JOIN SHIPMENT s ON o.OrderID = s.OrderID
                    WHERE s.PickupDate IS NOT NULL AND o.ShippingStatus = 'Shipped'
                    GROUP BY o.OrderID, o.OrderDate
                ),
                ShippingDelays AS (
                    SELECT 
                        o.OrderID,
                        s.TrackingNumber,
                        s.EstimatedDeliveryDate,
                        s.DeliveryDate,
                        DATEDIFF(DAY, s.EstimatedDeliveryDate, s.DeliveryDate) AS DelayDays
                    FROM ISORDER o
                    JOIN SHIPMENT s ON o.OrderID = s.OrderID
                    WHERE s.DeliveryDate > s.EstimatedDeliveryDate
                ),
                ReliableShippingProviders AS (
                    SELECT 
                        lp.ProviderName,
                        AVG(DATEDIFF(DAY, s.PickupDate, s.DeliveryDate)) AS AvgDeliveryTime,
                        COUNT(s.ShipmentID) AS TotalShipments
                    FROM LOGISTICS_PROVIDER lp
                    JOIN SHIPMENT s ON lp.LogisticsProviderID = s.LogisticsProviderID
                    WHERE s.DeliveryStatus = 'Delivered'
                    GROUP BY lp.ProviderName
                ),
                OrderCompletionRate AS (
                    SELECT 
                        CAST(SUM(CASE WHEN o.ShippingStatus = 'Delivered' THEN 1 ELSE 0 END) AS FLOAT) 
                        / COUNT(o.OrderID) * 100 AS CompletionRate
                    FROM ISORDER o
                )
                SELECT 
                    'Average Fulfillment Time' AS MetricType,
                    'Average Days to Fulfill Order' AS MetricKey,
                    AVG(FulfillmentTime) AS MetricValue
                FROM FulfillmentTimes

                UNION ALL

                SELECT 
                    'Shipping Delays' AS MetricType,
                    CONCAT('OrderID: ', OrderID, ', Tracking: ', TrackingNumber) AS MetricKey,
                    DelayDays AS MetricValue
                FROM ShippingDelays

                UNION ALL

                SELECT 
                    'Reliable Shipping Providers' AS MetricType,
                    ProviderName AS MetricKey,
                    AvgDeliveryTime AS MetricValue
                FROM ReliableShippingProviders

                UNION ALL

                SELECT 
                    'Order Completion Rate' AS MetricType,
                    'Percentage of Orders Delivered' AS MetricKey,
                    CompletionRate AS MetricValue
                FROM OrderCompletionRate;";

            using (var connection = DBHandler.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }


        private void btnRPCReport_Click(object sender, EventArgs e)
        {
            string query = @"
                WITH RevenueByCategory AS (
                    SELECT 
                        c.CategoryID,
                        c.CategoryName,
                        SUM(oi.Quantity * oi.Price) AS TotalRevenue
                    FROM CATEGORY c
                    JOIN ISPRODUCT p ON c.CategoryID = p.CategoryID
                    JOIN ORDER_ITEM oi ON p.ProductID = oi.ProductID
                    GROUP BY c.CategoryID, c.CategoryName
                ),
                TotalRevenue AS (
                    SELECT SUM(TotalRevenue) AS TotalRevenueSum
                    FROM RevenueByCategory
                ),
                CategoryTrends AS (
                    SELECT 
                        c.CategoryID,
                        c.CategoryName,
                        COUNT(o.OrderID) AS TotalOrders,
                        SUM(oi.Quantity) AS TotalItemsSold,
                        DATEDIFF(MONTH, MIN(o.OrderDate), MAX(o.OrderDate)) AS SalesDurationMonths
                    FROM CATEGORY c
                    JOIN ISPRODUCT p ON c.CategoryID = p.CategoryID
                    JOIN ORDER_ITEM oi ON p.ProductID = oi.ProductID
                    JOIN ISORDER o ON oi.OrderID = o.OrderID
                    GROUP BY c.CategoryID, c.CategoryName
                )
                SELECT 
                    'Revenue Per Category' AS MetricType,
                    CategoryName AS MetricKey,
                    CAST(TotalRevenue AS DECIMAL(10, 2)) AS MetricValue
                FROM RevenueByCategory

                UNION ALL

                SELECT 
                    'Percentage Contribution' AS MetricType,
                    CategoryName AS MetricKey,
                    CAST((TotalRevenue / (SELECT TotalRevenueSum FROM TotalRevenue)) * 100 AS DECIMAL(5, 2)) AS MetricValue
                FROM RevenueByCategory

                UNION ALL

                SELECT 
                    'Trending Categories' AS MetricType,
                    CategoryName AS MetricKey,
                    CAST((TotalItemsSold / SalesDurationMonths) AS DECIMAL(10, 2)) AS MetricValue
                FROM CategoryTrends
                WHERE SalesDurationMonths > 0
                ORDER BY MetricValue DESC;";

            using (var connection = DBHandler.GetConnection())
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

    }
}