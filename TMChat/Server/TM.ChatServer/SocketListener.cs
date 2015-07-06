using System;
using System.Net;
using System.Net.Sockets;

namespace TM.ChatServer
{
    public class SocketListener
    {
        private readonly IServerConfig config;
        private Socket mainListener;

        public bool Listening { get; private set; }

        public delegate void ClientConnectedEventHandler(Socket s);
        public event ClientConnectedEventHandler ClientConnected;

        public SocketListener(IServerConfig serverConfig)
        {
            config = serverConfig;
        }

        public void Start()
        {
            if (Listening)
                return;

            mainListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            mainListener.Bind(GetIpEndPoint());
            mainListener.Listen(config.MaxConnections);

            mainListener.BeginAccept(AcceptCallback, null);
            Listening = true;
        }

        public void Stop()
        {
            if (!Listening)
                return;

            mainListener.Close();
            mainListener.Dispose();

            Listening = false;
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket handler = mainListener.EndAccept(ar);

            if (ClientConnected != null)
                ClientConnected(handler);

            mainListener.BeginAccept(AcceptCallback, null);
        }

        private IPEndPoint GetIpEndPoint()
        {
            //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            //IPAddress ipAddress = ipHostInfo.AddressList[0];
            
            return new IPEndPoint(0, config.Port);
        }
    }
}
