using System;


namespace DB_Proj_00
{
    public static class LogisticsSessionManager
    {
        public static int UserID { get; private set; }
        public static string UserName { get; private set; }
        public static bool IsLoggedIn { get; private set; }

        public static void LogIn(int userId, string userName)
        {
            UserID = userId;
            UserName = userName;
            IsLoggedIn = true;
        }

        public static void LogOut()
        {
            UserID = 0;
            UserName = string.Empty;
            IsLoggedIn = false;
        }
    }
}
