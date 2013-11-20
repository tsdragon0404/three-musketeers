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
    }
}