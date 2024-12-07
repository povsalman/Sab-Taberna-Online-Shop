using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Proj_00
{
    internal class AdminSessionManager
    {
        public static int UserID { get; set; } = -1; // Default to -1 (no user logged in)
        public static string UserName { get; set; }
        public static string Role { get; set; } // AccountType or Admin Role
        public static string Email { get; set; } // Contact info from ISUSER
        public static string FullName { get; set; } // For Admin, use "Role"
        public static string Password { get; set; } // Store for reference if needed

        // Clear all session data
        public static void ClearSession()
        {
            UserID = -1;
            UserName = null;
            Role = null;
            Email = null;
            FullName = null;
            Password = null;
        }
    }
}