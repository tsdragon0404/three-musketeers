using System.Collections.Generic;
using System.Linq;
using SMS.Common.Constant;
using SMS.Common.Session;

namespace SMS.Common.Storage.CacheObjects
{
    public class Message
    {
        public long MessageID { get; set; }
        private string VNMessage { get; set; }
        private string ENMessage { get; set; }

        public Message(long messageId, string vnMessage, string enMessage)
        {
            MessageID = messageId;
            VNMessage = vnMessage;
            ENMessage = enMessage;
        }

        public string Content
        {
            get { return SmsSystem.Language == Language.Vietnamese ? VNMessage : ENMessage; }
        }
    }

    public class MessageDictionary : Dictionary<long, List<Message>>
    {
        public string Get(long messageID)
        {
            var fallbackMessage = FallbackMessages.Get(messageID);
            var targetBranchID = messageID < 0 ? ConstConfig.NoBranchID : SmsCache.UserContext.CurrentBranchId;

            if (ContainsKey(targetBranchID) && this[targetBranchID].Any(x => x.MessageID == messageID))
                return this[targetBranchID].First(x => x.MessageID == messageID).Content;

            return string.Format("[{0}]", fallbackMessage);
        }
    }
}