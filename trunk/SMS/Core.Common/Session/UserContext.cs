namespace Core.Common.Session
{
    public class UserContext
    {
        public static long UserID { get; set; }
        public static string UserName { get; set; } 
        public static int PageSize { get; set; }
        public static bool IsSuperAdmin { get; set; }

        private static string _language;
        public static string Language
        {
            get
            {
                if (_language.IsNullOrEmpty() || (_language != "en" && _language != "vn"))
                    _language = "vn";
                return _language;
            } 
            set { _language = value.ToLower(); }
        }
    }
}