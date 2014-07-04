using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.Message
{
    public class SystemMessages
    {
        private static List<Message> messages;
        private static List<Message> systemMessages;

        public static void SetMessages(List<Message> errorMessages)
        {
            messages = errorMessages;
        }

        public static void SetSystemMessages(List<Message> systemMgs)
        {
            if (systemMgs != null)
                systemMessages = systemMgs;
        }

        public static void Clear(bool clearSystemMessage = false)
        {
            messages = new List<Message>();
            if(clearSystemMessage)
                systemMessages = new List<Message>();
        }

        public static string Get(long id)
        {
            if (id < 0)
                return systemMessages.Exists(x => x.ID == id)
                    ? SmsSystem.Language == Language.Vietnamese ? systemMessages.First(x => x.ID == id).VNText : systemMessages.First(x => x.ID == id).ENText
                    : string.Empty;

            return messages.Exists(x => x.ID == id)
                ? SmsSystem.Language == Language.Vietnamese ? messages.First(x => x.ID == id).VNText : messages.First(x => x.ID == id).ENText
                : string.Empty;
        }
    }
}