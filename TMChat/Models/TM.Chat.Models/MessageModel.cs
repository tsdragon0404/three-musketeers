using System;

namespace TM.Chat.Models
{
    [Serializable]
    public class MessageModel
    {
        public Guid ClientId { get; set; }
        public string ClientName { get; set; }
        public string Message { get; set; }
    }
}
