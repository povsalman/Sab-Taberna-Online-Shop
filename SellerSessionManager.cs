using System;

namespace DB_Proj_00
{
    public static class SellerSessionManager
    {
        public static int UserID { get; private set; }
        public static int SellerID { get; private set; } // Add SellerID
        public static string UserName { get; private set; }
        public static bool IsLoggedIn { get; private set; }

        public static void LogIn(int userId, int sellerId, string userName)
        {
            UserID = userId;
            SellerID = sellerId; // Set SellerID
            UserName = userName;
            IsLoggedIn = true;
        }

        public static void LogOut()
        {
            UserID = 0;
            SellerID = 0; // Reset SellerID
            UserName = string.Empty;
            IsLoggedIn = false;
        }
    }

}
