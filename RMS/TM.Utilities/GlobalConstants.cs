namespace TM.Utilities
{
    /// <summary>
    /// Contains all constants for global uses
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// Contains parameters need for calling stored procedure
        /// </summary>
        public static class SystemParameters
        {
            public static readonly string ReturnParameter = "RETURN_VALUE";
            public static readonly string CurrentUserID = "I_vUserID";
            public static readonly string BranchID = "I_vBranchID";
            public static readonly string LanguageCode = "I_vLanguageID";
            public static readonly string FunctionID = "I_vFunctionID";

            public static readonly string ErrorNumber = "I_vErrNumber";
        }

        /// <summary>
        /// Contains name of some system menu
        /// </summary>
        public static class SystemMenuButtonName
        {
            public static readonly string MenuIcon = "SystemMenuItem";
            public static readonly string MenuMinimize = "Mi&nimize";
            public static readonly string MenuRestore = "&Restore";
            public static readonly string MenuClose = "&Close";
        }

        /// <summary>
        /// Contains Function Ids
        /// </summary>
        public static class FunctionIds
        {
            public const int FormMain = 1000;
            public const int FormUser = 1001;
            public const int FormBranch = 1002;
            public const int FormLoginAdmin = 1003;
            public const int FormProductCategory = 1004;
            public const int FormProduct = 1005;
        }
    }

    /// <summary>
    /// Contains data of active form
    /// </summary>
    public static class ActivatedForm
    {
        public static int FunctionID { get; set; }
    }
}