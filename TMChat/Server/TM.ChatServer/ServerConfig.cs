namespace TM.ChatServer
{
    public interface IServerConfig
    {
        int Port { get; set; }
        int MaxConnections { get; set; }
        int BufferSize { get; set; }
        int TimerInterval { get; set; }
    }

    public class ServerConfig : IServerConfig
    {
        public int Port { get; set; }
        public int MaxConnections { get; set; }
        public int BufferSize { get; set; }
        public int TimerInterval { get; set; }

        public static IServerConfig DevConfig
        {
            get
            {
                return new ServerConfig
                {
                    Port = 9999,
                    MaxConnections = 10,
                    BufferSize = 8192,
                    TimerInterval = 5000,
                };
            }
        }
    }
}
