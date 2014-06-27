namespace SMS.Common.Session
{
    public class UserContext
    {
        public static long UserID { get; set; }
        public static string UserName { get; set; } 
        public static int PageSize { get; set; }
        public static bool IsSystemAdmin { get; set; }
        public static int BranchID { get; set; }

        public static long DefaultAreaID { get; set; }

        /// <summary>
        /// Contain height value for List table section in Cashier page (in percent)
        /// </summary>
        public static int ListTableHeight { get; set; }

        public static Language Language { get; set; }
    }
}