﻿using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DB_Proj_00
{
    internal class DBHandler
    {
        private static string connectionString = "Data Source=SALMAN\\SQLEXPRESS;Initial Catalog=SABTaberna;Integrated Security=True;Encrypt=False";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}