using System.Collections.Generic;
using System.Linq;
using SMS.Common.Session;

namespace SMS.Common.Message
{
    public class SystemMessages
    {
        private static IList<Message> messages;
        private static IList<Message> systemMessages;

        public static void SetMessages(IList<Message> errorMessages)
        {
            messages = errorMessages;
        }

        public static void SetSystemMessages(IList<Message> systemMgs)
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

        public static string Get(long id, string fallbackMessage)
        {
            if (id < 0)
                return systemMessages.Any(x => x.MessageID == id)
                    ? SmsSystem.Language == Language.Vietnamese ? systemMessages.First(x => x.MessageID == id).VNMessage : systemMessages.First(x => x.MessageID == id).ENMessage
                    : string.Format("[{0}]", fallbackMessage);

            return messages.Any(x => x.MessageID == id)
                ? SmsSystem.Language == Language.Vietnamese ? messages.First(x => x.MessageID == id).VNMessage : messages.First(x => x.MessageID == id).ENMessage
                : string.Format("[{0}]", fallbackMessage);
        }
    }
}