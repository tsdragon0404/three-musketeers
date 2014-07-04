using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.Message
{
    public class SystemMessages
    {
        private static List<Message> messages;

        public static bool IsInitialized { get; set; }

        public static void Initialize(List<Message> errorMessages)
        {
            messages = errorMessages;
            IsInitialized = true;
        }

        public static void Clear()
        {
            messages = new List<Message>();
            IsInitialized = false;
        }

        public static string Get(long id)
        {
            return messages.Exists(x => x.ID == id) && IsInitialized
                ? SmsSystem.UserContext.Language == Language.Vietnamese ? messages.First(x => x.ID == id).VNText : messages.First(x => x.ID == id).ENText
                : string.Empty;
        }
    }
}