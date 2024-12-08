using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
        namespace DB_Proj_00
{
    public static class SessionManager
    {
        public static int UserID { get; set; } = -1; // Default to -1 (no user logged in)
        public static string UserName { get; set; }
        public static string Role { get; set; }
       
            public static List<Product> ShoppingCart { get; set; } = new List<Product>();
        


        public static void ClearSession()
        {
            UserID = -1;
            UserName = null;
            Role = null;
        }
    }


}


