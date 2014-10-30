using System.Collections.Generic;

namespace SMS.Common.Constant
{
    public static class ConstMessageIds
    {
        public const long Login_UsernamePasswordInvalid = -1;
        public const long Login_UserLocked = -2;
        public const long Login_NoPermissionOnBranch = -3;
        public const long Login_BranchNotAvailable = -6;

        public const long UnAuthorize_NoPermission = -4;
        public const long UnAuthorize_LoginRequired = -5;

        public const long Validate_NotValid = -7;

        public const long Business_DataNotExist = -8;

        public const long Forbidden = -9;

        public const long Popup_Title_Warning = -10;
        public const long Popup_Message_DeleteSessionConfirm = -11;
        public const long Popup_Title_Error = -12;
        public const long Popup_Title_Success = -13;
        public const long Popup_Message_Error = -14;
        public const long Popup_Message_ResetSystemDataSuccess = -15;
        public const long Popup_Message_FileReaderNotSupported = -16;
        public const long Popup_Message_IncorrectFileFormat = -17;
        public const long Popup_Message_ShortErrorMessage = -22;

        public const long Button_Yes = -18;
        public const long Button_No = -19;
        public const long Button_Ok = -20;
        public const long Button_Cancel = -21;

        public const long DataTable_First = -23;
        public const long DataTable_Last = -24;
        public const long DataTable_Next = -25;
        public const long DataTable_Previous = -26;
        public const long DataTable_NoData = -27;
        public const long DataTable_ShowingRecords = -28;
        public const long DataTable_NoEntries = -29;
        public const long DataTable_Filter = -30;
        public const long DataTable_ShowEntries = -31;
        public const long DataTable_Search = -32;
        public const long DataTable_NoMatchingData = -33;

    }

    public static class FallbackMessages
    {
        private static readonly Dictionary<long, string> fallbackMessages = new Dictionary<long, string>
        {
            {ConstMessageIds.Login_UsernamePasswordInvalid, "Username or password invalid"},
            {ConstMessageIds.Login_UserLocked, "This user is temporary locked. Please contact Administrator."},
            {ConstMessageIds.Login_NoPermissionOnBranch, "This user cannot log into this branch. Please contact administrator."},
            {ConstMessageIds.Login_BranchNotAvailable, "Branch not available."},
            {ConstMessageIds.UnAuthorize_NoPermission, "You dont have permission to access this function."},
            {ConstMessageIds.UnAuthorize_LoginRequired, "Login required."},
            {ConstMessageIds.Validate_NotValid, "{0} is not valid"},
            {ConstMessageIds.Business_DataNotExist, "The requested data does not existed"},
            {ConstMessageIds.Forbidden, "Forbidden"},
            {ConstMessageIds.Popup_Title_Warning, "Warning"},
            {ConstMessageIds.Popup_Message_DeleteSessionConfirm, "Are you sure you want to delete this session?"},
            {ConstMessageIds.Popup_Title_Error, "Error"},
            {ConstMessageIds.Popup_Title_Success, "Success"},
            {ConstMessageIds.Popup_Message_Error, "Error occurs. Please contact administrator."},
            {ConstMessageIds.Popup_Message_ResetSystemDataSuccess, "System data have been reseted."},
            {ConstMessageIds.Popup_Message_FileReaderNotSupported, "This browser does not support FileReader. Please contact administrator."},
            {ConstMessageIds.Popup_Message_IncorrectFileFormat, "Incorrect file format. Please try again."},
            {ConstMessageIds.Button_Yes, "Yes"},
            {ConstMessageIds.Button_No, "No"},
            {ConstMessageIds.Button_Ok, "Ok"},
            {ConstMessageIds.Button_Cancel, "Cancel"},
            {ConstMessageIds.Popup_Message_ShortErrorMessage, "Something went wrong.</br><a class=\"{0}\">Click here</a> for more detail."},
        };

        public static string Get(long messageId)
        {
            return fallbackMessages.ContainsKey(messageId) ? fallbackMessages[messageId] : "Message not available";
        }
    }
}