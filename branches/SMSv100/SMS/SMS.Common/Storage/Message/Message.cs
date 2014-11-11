using SMS.Common.Session;

namespace SMS.Common.Storage.Message
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
}