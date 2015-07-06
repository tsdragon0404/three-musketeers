using System;
using System.Windows.Forms;
using TM.Chat.Models;
using TM.ChatServer.Log;

namespace TM.ChatServer.WinFormApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ChatServer server = new ChatServer(ServerConfig.DevConfig);
            server.Started += ServerStarted;
            server.ClientLogedIn += ClientLogedIn;
            server.ClientLogedOut += ClientLogedOut;
            server.ClientSendMessage += ClientSendMessage;

            server.Start();
        }

        private void ClientLogedIn(Client client)
        {
            Invoke((MethodInvoker) (() =>
                {
                    dgClients.Rows.Add(client.Id, client.Name, client.EndPoint, client.ConnectedTime);
                    lstLogs.Items.Add(new AuditLog(AuditType.Login, client));
                }));
        }

        private void ClientLogedOut(Client client)
        {
            Invoke((MethodInvoker) delegate
                {
                    for(int i = 0; i < dgClients.Rows.Count; i++)
                    {
                        if (Guid.Parse(dgClients.Rows[i].Cells[0].Value.ToString()) == client.Id)
                        {
                            dgClients.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    lstLogs.Items.Add(new AuditLog(AuditType.Logout, client));
                });
        }

        private void ClientSendMessage(Client client, MessageModel message)
        {
            Invoke((MethodInvoker)(() => lstLogs.Items.Add(new AuditLog(AuditType.SendMessage, client, message))));
        }

        private void ServerStarted(object sender)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    tsServerStatus.Text = "Connected";
                });
            }
        }
    }
}
