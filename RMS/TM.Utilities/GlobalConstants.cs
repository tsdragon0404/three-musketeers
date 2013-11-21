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
             public const string ReturnParameter = "RETURN_VALUE";
             public const string CurrentUserID = "I_vUserID";
             public const string BranchID = "I_vBranchID";
             public const string LanguageCode = "I_vLanguageID";
             public const string FunctionID = "I_vFunctionID"; 

             public const string ErrorNumber = "I_vErrNumber";
         }

        public static class FunctionIds
        {
            public const int FormMain = 1000;
            public const int FormUser = 1001;
            public const int FormBranch = 1002;
            public const int FormLoginAdmin = 1003;
            public const int FormProductCategory = 1004;
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