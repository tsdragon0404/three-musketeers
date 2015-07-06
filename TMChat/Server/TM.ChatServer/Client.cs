using System;
using System.Net;
using System.Net.Sockets;
using TM.Chat.Models;

namespace TM.ChatServer
{
    public class Client
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public IPEndPoint EndPoint { get; private set; }
        public DateTime ConnectedTime { get; private set; }

        public Socket Socket { get; private set; }

        #region Client events
        
        public delegate void ClientReceivedHandler(Client sender, TransferPackage package);
        public event ClientReceivedHandler Received;

        public delegate void ClientDisconnectedHandler(Client sender);
        public event ClientDisconnectedHandler Disconnected; 

        #endregion

        public Client(Socket accepted)
        {
            Id = Guid.NewGuid();
            Socket = accepted;
            EndPoint = (IPEndPoint)Socket.RemoteEndPoint;
            ConnectedTime = DateTime.Now;

            Socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
        }

        public void ReceivedCallback(IAsyncResult ar)
        {
            try
            {
                Socket.EndReceive(ar);

                byte[] buffer = new byte[8192];
                int received = Socket.Receive(buffer, buffer.Length, SocketFlags.None);

                if (received < buffer.Length)
                    Array.Resize(ref buffer, received);

                TransferPackage package = new TransferPackage(buffer);
                ProcessPackage(package);

                if (Received != null)
                    Received(this, package);

                Socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
            }
            catch (Exception)
            {
                Close();
            }
        }

        private void ProcessPackage(TransferPackage package)
        {
            switch (package.TransferAction)
            {
                case TransferAction.Login:
                    Name = ((package.Data) as LoginModel).Name;
                    break;
            }
        }

        public void Close()
        {
            Socket.Close();
            Socket.Dispose();

            if (Disconnected != null)
                Disconnected(this);
        }
    }
}
