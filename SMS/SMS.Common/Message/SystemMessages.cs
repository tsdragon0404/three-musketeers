using System.Collections.Generic;

namespace SMS.Common.Message
{
    public class SystemMessages
    {
        private static Dictionary<long, string> messages;

        public static void Initialize(Dictionary<long, string> errorMessages)
        {
            messages = errorMessages;
        }

        public static string Get(long id)
        {
            return messages[id];
        }

        public static void Update(long id, string message)
        {
            if (messages.ContainsKey(id))
                messages[id] = message;
            else
                messages.Add(id, message);
        }
    }
}