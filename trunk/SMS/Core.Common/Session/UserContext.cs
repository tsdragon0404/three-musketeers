namespace Core.Common.Session
{
    public class UserContext
    {
        public static long UserID { get; set; }
        public static string UserName { get; set; } 
        public static int PageSize { get; set; }
        public static bool IsSuperAdmin { get; set; }

        public static Language Language { get; set; }
    }
}