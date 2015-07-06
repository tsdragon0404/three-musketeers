using System;
using System.Linq;
using System.Threading;
using TM.Chat.Models;

namespace TM.ChatServer
{
    public class ServerTimer : IDisposable
    {
        private readonly ChatServer server;
        private readonly Timer timer;

        public ServerTimer(IServerConfig config, ChatServer server)
        {
            this.server = server;
            timer = new Timer(TimerCallbackAction, null, config.TimerInterval, config.TimerInterval);
        }

        private void TimerCallbackAction(object state)
        {
            foreach (var client in server.Clients)
            {
                ListClientModel listClientModel = new ListClientModel
                {
                    Clients = server.Clients.Where(x => x.Id != client.Id).Select(x => new ClientModel { Id = x.Id, Name = x.Name }).ToArray()
                };
                TransferPackage package = new TransferPackage(TransferAction.ListClient, listClientModel);

                client.Socket.Send(package.ToByteArray());
            }
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
