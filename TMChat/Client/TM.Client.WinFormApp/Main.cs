using System;
using System.Net.Sockets;
using System.Windows.Forms;
using TM.Chat.Models;

namespace TM.Client.WinFormApp
{
    public partial class Main : Form
    {
        private Socket sock;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == @"Connect")
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.BeginConnect("127.0.0.1", 9999, ConnectedCallback, null);
            }
            else
            {
                sock.Close();
                sock.Dispose();

                ChangeStatus(false);
            }
        }

        private void ConnectedCallback(IAsyncResult ar)
        {
            sock.EndConnect(ar);

            TransferPackage package = new TransferPackage(TransferAction.Login, new LoginModel{ Name = txtName.Text });
            sock.Send(package.ToByteArray());

            Invoke((MethodInvoker) (() => ChangeStatus(true)));

            sock.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
        }

        public void ReceivedCallback(IAsyncResult ar)
        {
            if (!sock.Connected)
                return;

            sock.EndReceive(ar);

            byte[] buffer = new byte[8192];
            int received = sock.Receive(buffer, buffer.Length, SocketFlags.None);

            if (received < buffer.Length)
                Array.Resize(ref buffer, received);

            HandleReceivedData(buffer);

            sock.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
        }

        private void HandleReceivedData(byte[] buffer)
        {
            MethodInvoker method = null;

            TransferPackage package = new TransferPackage(buffer);
            switch (package.TransferAction)
            {
                case TransferAction.ListClient:
                    method = () =>
                        {
                            ListClientModel listModel = package.Data as ListClientModel;

                            lstClients.Items.Clear();
                            lstClients.Items.AddRange(listModel.Clients);
                        };
                    break;
                case TransferAction.SendMessage:
                    method = () =>
                    {
                        MessageModel messageModel = package.Data as MessageModel;

                        lstMessages.Items.Add(messageModel.ClientName + ": " + messageModel.Message);
                    };
                    break;
            }

            if (method != null)
                Invoke(method);
        }

        private void ChangeStatus(bool isConnected)
        {
            tsStatus.Text = isConnected ? "Connected" : "Disconnected";
            btnConnect.Text = isConnected ? "Disconnect" : "Connect";

            txtName.Enabled = !isConnected;

            btnSend.Enabled = isConnected;
            lstMessages.Enabled = isConnected;
            txtMessage.Enabled = isConnected;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.Close();
            sock.Dispose();
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblClientName.Text = (lstClients.SelectedItem as ClientModel).Name;
            lblClientId.Text = (lstClients.SelectedItem as ClientModel).Id.ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim().Length == 0)
                return;

            lstMessages.Items.Add("Me: " + txtMessage.Text);

            TransferPackage package = new TransferPackage(TransferAction.SendMessage, new MessageModel
                {
                    ClientId = Guid.Parse(lblClientId.Text), 
                    Message = txtMessage.Text
                });
            sock.Send(package.ToByteArray());
        }
    }
}
