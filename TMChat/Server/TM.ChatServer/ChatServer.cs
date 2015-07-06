using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using TM.Chat.Models;

namespace TM.ChatServer
{
    public class ChatServer
    {
        private readonly IServerConfig config;

        private Thread mainThread;
        private SocketListener listener;
        private ServerTimer timer;

        public List<Client> Clients { get; private set; }

        #region Server events
        
        public delegate void ChatServerStartedEventHandler(object sender);
        public event ChatServerStartedEventHandler Started;

        public delegate void ClientLogedInEventHandler(Client client);
        public event ClientLogedInEventHandler ClientLogedIn;

        public delegate void ClientLogedOutEventHandler(Client client);
        public event ClientLogedOutEventHandler ClientLogedOut;

        public delegate void ClientSendMessageEventHandler(Client client, MessageModel message);
        public event ClientSendMessageEventHandler ClientSendMessage; 

        #endregion

        public ChatServer(IServerConfig config)
        {
            this.config = config;
        }

        public void Start()
        {
            mainThread = new Thread(StartListen);
            mainThread.Start();
        }

        public void Stop()
        {
            if (mainThread.IsAlive && listener != null)
            {
                timer.Dispose();

                listener.Stop();
                mainThread.Abort();
            }
        }

        private void StartListen()
        {
            Clients = new List<Client>();

            listener = new SocketListener(config);
            listener.ClientConnected += ClientConnectedHandler;

            listener.Start();

            if (Started != null)
                Started(this);

            timer = new ServerTimer(config, this);
        }

        #region Event handlers

        private void ClientConnectedHandler(Socket s)
        {
            Client client = new Client(s);
            client.Received += ClientReceived;
            client.Disconnected += ClientDisconnected;

            Clients.Add(client);
        }

        private void ClientReceived(Client sender, TransferPackage package)
        {
            switch (package.TransferAction)
            {
                case TransferAction.Login:
                    if (ClientLogedIn != null)
                        ClientLogedIn(sender);
                    break;
                case TransferAction.SendMessage:
                    MessageModel messageModel = package.Data as MessageModel;
                    Client targetClient = Clients.FirstOrDefault(x => x.Id == messageModel.ClientId);
                    if(targetClient != null)
                    {
                        messageModel.ClientName = targetClient.Name;

                        TransferPackage pkg = new TransferPackage(TransferAction.SendMessage, new MessageModel
                        {
                            ClientId = sender.Id,
                            ClientName = sender.Name,
                            Message = messageModel.Message
                        });

                        targetClient.Socket.Send(pkg.ToByteArray());

                        if (ClientSendMessage != null)
                            ClientSendMessage(sender, messageModel);
                    }
                    break;
            }
        }

        private void ClientDisconnected(Client sender)
        {
            Clients.RemoveAll(x => x.Id == sender.Id);

            if (ClientLogedOut != null)
                ClientLogedOut(sender);
        } 

        #endregion
    }
}
