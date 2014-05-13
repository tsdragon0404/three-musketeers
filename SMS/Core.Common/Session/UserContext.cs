namespace Core.Common.Session
{
    public class UserContext
    {
        public static long UserID { get; set; }
        public static string UserName { get; set; } 
        public static int PageSize { get; set; }

        private static string language;
        public static string Language
        {
            get
            {
                if (language.IsNullOrEmpty() || (language != "en" && language != "vn"))
                    language = "vn";
                return language;
            } 
            set { language = value.ToLower(); }
        }
    }
}