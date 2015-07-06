using System;
using TM.Chat.Models;

namespace TM.ChatServer.Log
{
    public class AuditLog
    {
        public AuditType Type { get; set; }

        public Client Client { get; set; }

        public MessageModel MessageModel { get; set; }

        public AuditLog(AuditType type, Client client) : this (type, client, null) { }

        public AuditLog(AuditType type, Client client, MessageModel messageModel)
        {
            Type = type;
            Client = client;
            MessageModel = messageModel;
        }

        public override string ToString()
        {
            string msg = string.Empty;
            
            switch (Type)
            {
                case AuditType.Login:
                    msg = string.Format("Login: {0} from IP {1} at {2}", Client.Name, Client.EndPoint, Client.ConnectedTime);
                    break;
                case AuditType.Logout:
                    msg = string.Format("Logout: {0} from IP {1} at {2}", Client.Name, Client.EndPoint, DateTime.Now);
                    break;
                case AuditType.SendMessage:
                    msg = string.Format("{0} send {1} a message: {2}", Client.Name, MessageModel.ClientName, MessageModel.Message);
                    break;
            }

            return msg;
        }
    }

    public enum AuditType
    {
        Login = 1,
        Logout = 2,
        SendMessage = 3,
    }
}