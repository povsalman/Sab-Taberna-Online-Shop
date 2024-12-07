using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Proj_00
{
    internal class DBHandler
    {
        private static string connectionString = @"Server=DESKTOP-36T2U50\SQLEXPRESS;Database=SABTaberna;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}