using System.Collections.Generic;

namespace SMS.Common.Constant
{
    public class ConstMessageIds
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
        public const long Popup_Message_DeleteSession = -11;
        public const long Popup_Title_Error = -12;
    }

    public class FallbackMessages
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
            {ConstMessageIds.Popup_Message_DeleteSession, "Are you sure you want to delete this session?"},
            {ConstMessageIds.Popup_Title_Error, "Error"},
        };

        public static string Get(long messageId)
        {
            return fallbackMessages.ContainsKey(messageId) ? fallbackMessages[messageId] : "Message not available";
        }
    }
}