namespace SMS.Common.Message
{
    public class Message
    {
        public long ID { get; set; }
        public string VNText { get; set; }
        public string ENText { get; set; }

        public Message(){}
        public Message(long id, string vnText, string enText)
        {
            ID = id;
            VNText = vnText;
            ENText = enText;
        }
    }
}