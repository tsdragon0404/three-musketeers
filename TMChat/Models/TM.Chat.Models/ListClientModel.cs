using System;

namespace TM.Chat.Models
{
    [Serializable]
    public class ListClientModel
    {
        public ClientModel[] Clients { get; set; }
    }

    [Serializable]
    public class ClientModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}