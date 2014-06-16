using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeeperHand_Auberge
{
    public partial class Form_Tchat : Form
    {
        private static bool ClientSet = false, ServerSet = false;
        public Form_Tchat()
        {
            InitializeComponent();
            button_send.Enabled = false;
            button_disconnect.Enabled = false;
            button_Server.Enabled = true;
            textBox_Tchat.KeyPress += new KeyPressEventHandler(KeyPressed);
        }

        /* Différentes régions */

        #region Elements

        private void KeyPressed(Object o, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (textBox_Tchat.Text != string.Empty)
                {
                    if (textBox_Tchat.Text[0] == '/')
                    {
                        SendRequest(textBox_Tchat.Text);
                    }
                    else
                    {
                        SendRequest("/talk " + textBox_Tchat.Text);
                    }
                    textBox_Tchat.Clear();
                }
                else
                {
                    MessageBox.Show("Please enter a message...");
                }
            }
        }

        private void button_Server_Click(object sender, EventArgs e)
        {
                if(textBox_Port.Text != string.Empty)
                {
                    richTextBox_Tchat.AppendText("[SERVER] Setting up...\n[SERVER] IPAdress : " + textBox_IPAddress.Text + "\n[SERVER] Port : " + textBox_Port.Text + "\n");
                    try
                    {
                        SetupServer(textBox_Port.Text);
                        button_Client.Enabled = false;
                        button_send.Enabled = false;
                        button_Server.Enabled = false;
                        ServerSet = true;
                        ClientSet = false;
                    }
                    catch
                    {
                        MessageBox.Show("Wrong IP Address or Port !");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a port !");
                }
            }
        

        private void button_Client_Click(object sender, EventArgs e)
        {
            if (textBox_IPAddress.Text != string.Empty)
            {
                if (textBox_Port.Text != string.Empty)
                {
                    if (textBox_Username.Text != string.Empty)
                    {
                        try
                        {
                            client = new Client(clientSocket, textBox_Username.Text);
                            StartClient(textBox_IPAddress.Text, textBox_Port.Text);
                            button_send.Enabled = true;
                            button_Server.Enabled = false;
                            button_Client.Enabled = false;
                            button_disconnect.Enabled = true;
                            ClientSet = true;
                            ServerSet = false;
                        }
                        catch
                        {
                            MessageBox.Show("Wrong IPAddress or port, try again...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a username...");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a port...");
                    textBox_Port.Text = "????";
                }
            }
            else
            {
                MessageBox.Show("Please enter an IPAddress...");
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_Tchat.Text != string.Empty)
            {
                if (textBox_Tchat.Text[0] == '/')
                {
                    SendRequest(textBox_Tchat.Text);
                }
                else
                {
                    SendRequest("/talk " + textBox_Tchat.Text);
                }
                textBox_Tchat.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a message...");
            }
        }

        private void connexionAutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_IPAddress.Text = "188.165.201.172";
            textBox_Port.Text = "25000";
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            if (ClientSet)
            {
                DisconnectClient();
                button_Client.Enabled = true;
                button_disconnect.Enabled = false;
                button_send.Enabled = false;
                button_Server.Enabled = true;
            }
            if (ServerSet)
            {
                DisconnectServer();
            }
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Server

        // Fields.
        private static byte[] buffer = new byte[1024];
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static List<Client> clientSockets = new List<Client>();

        // Server.
        private void SetupServer(string port)
        {
            IPEndPoint myEP = new IPEndPoint(IPAddress.Any, Convert.ToInt32(port));

            try
            {
                serverSocket.Bind(myEP);
                serverSocket.Listen(100);
                richTextBox_Tchat.AppendText("[SERVER] IPAddress : " + myEP.Address.ToString() + "\n");
                richTextBox_Tchat.AppendText("[SERVER] En attente de clients...\n");
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), serverSocket);
            }
            catch (SocketException e)
            {
                richTextBox_Tchat.AppendText("[ERROR] Message : " + e.ToString() + "\n");
            }
        }

        private void DisconnectServer()
        {
            byte[] sendData = Encoding.ASCII.GetBytes("/exit");
            for (int i = 0; i < clientSockets.Count; i++)
            {
                try
                {
                    if (clientSockets[i].socket.Connected)
                    {
                        clientSockets[i].socket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, new AsyncCallback(ServerSendCallBack), clientSockets[i].socket);
                    }
                    else
                    {
                        richTextBox_Tchat.AppendText("[SERVER] A client has been disconnected !\n");
                        clientSockets[i].socket.Close();
                        clientSockets.RemoveAt(i);
                        i--;
                    }
                }
                catch (SocketException e)
                {
                    richTextBox_Tchat.AppendText("[SERVER] Error : " + e.ToString() + "\n");
                }
            }
            try
            {
                serverSocket.Shutdown(SocketShutdown.Both);
            }
            catch { }
            serverSocket.Close();
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket server = (Socket)ar.AsyncState;
            Socket client = server.EndAccept(ar);

            richTextBox_Tchat.AppendText("[SERVER] Socket connected to : " + client.RemoteEndPoint.ToString() + "\n");

            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ServerReceiveCallBack), client);
            server.BeginAccept(new AsyncCallback(AcceptCallBack), server);
        }

        private Client FindClient(Socket socket)
        {
            foreach (Client client in clientSockets)
            {
                if (client.socket == socket)
                {
                    return client;
                }
            }
            return null;
        }

        private void ServerReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                bool multiClient = false;
                Socket client = (Socket)ar.AsyncState;
                int sizeReceive = client.EndReceive(ar);
                if (sizeReceive > 0)
                {
                    byte[] dataBuffer = new byte[sizeReceive];
                    Array.Copy(buffer, dataBuffer, sizeReceive);

                    string str = Encoding.ASCII.GetString(dataBuffer);
                    string response = string.Empty;
                    string request = string.Empty;
                    try
                    {
                        request = str.Substring(0, 5).ToLower();
                    }
                    catch { request = str; }

                    switch (request)
                    {
                        case "/time":
                            richTextBox_Tchat.AppendText("[SERVER] Demande de l'heure par : " +  client.RemoteEndPoint.ToString() + "\n");
                            response = "[SERVER] Time : " + DateTime.Now.ToLongTimeString();
                            multiClient = false;
                            break;
                        case "/talk":
                            Client talker = FindClient(client);
                            response = "[" + talker.pseudo + "] " + str.Substring(6, str.Length - 6);
                            multiClient = true;
                            break;
                        case "/welc":
                            response = "[SERVER] Bienvenue sur le serveur de Keeper Hand ! Vous pouvez discuter avec les autres joueurs de notre communauté !";
                            clientSockets.Add(new Client(client, str.Substring(6, str.Length - 6)));
                            break;
                        default:
                            response = "[SERVER] Error : Invalid request !";
                            multiClient = false;
                            break;
                    }

                    byte[] sendData = Encoding.ASCII.GetBytes(response);
                    if (multiClient)
                    {
                        for (int i = 0; i < clientSockets.Count; i++)
                        {
                            try
                            {
                                if (clientSockets[i].socket.Connected)
                                {
                                    clientSockets[i].socket.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, new AsyncCallback(ServerSendCallBack), clientSockets[i].socket);
                                }
                                else
                                {
                                    richTextBox_Tchat.AppendText("[SERVER] A client has been disconnected !\n");
                                    clientSockets.RemoveAt(i);
                                    i--;
                                }
                            }
                            catch (SocketException e)
                            {
                                richTextBox_Tchat.AppendText("[SERVER] Error : " + e.ToString() + "\n");
                            }
                        }
                    }
                    else
                    {
                        client.BeginSend(sendData, 0, sendData.Length, SocketFlags.None, new AsyncCallback(ServerSendCallBack), client);
                    }
                }
                else
                {
                    client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ServerReceiveCallBack), client);
                }
            }
            catch
            {
                richTextBox_Tchat.AppendText("[SERVER] A client has been disconnected !\n");
                for (int i = 0; i < clientSockets.Count; i++)
                {
                    if (!clientSockets[i].socket.Connected)
                    {
                        clientSockets.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void ServerSendCallBack(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ServerReceiveCallBack), client);
            }
            catch
            {
                richTextBox_Tchat.AppendText("[SERVER] A client has been disconnected !\n");
                for (int i = 0; i < clientSockets.Count; i++)
                {
                    if (!clientSockets[i].socket.Connected)
                    {
                        try
                        {
                            clientSockets[i].socket.Shutdown(SocketShutdown.Both);
                        }
                        catch { }
                        clientSockets.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        #endregion

        #region Client

        // Fields.
        private static Client client;
        private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static byte[] bufferClient = new byte[1024];
        private static string response = string.Empty;

        private void StartClient(string IPAddress, string port)
        {
            IPHostEntry iHost = Dns.GetHostEntry(IPAddress);
            IPAddress ipAddress = iHost.AddressList[0];
            IPEndPoint hostEndPoint = new IPEndPoint(ipAddress, Convert.ToInt32(port));

            try
            {
                client.socket.BeginConnect(hostEndPoint, new AsyncCallback(ConnectCallBack), client.socket);
            }
            catch (SocketException e)
            {
                MessageBox.Show("[ERROR] Error : {0}", e.ToString());
            }
        }

        private void DisconnectClient()
        {
            client.socket.BeginDisconnect(true, new AsyncCallback(DisconnectCallBack), client.socket);
        }

        private void DisconnectCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            client.socket.BeginReceive(bufferClient, 0, bufferClient.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndConnect(ar);
            richTextBox_Tchat.AppendText("[SERVER] You are connected to the server !\n");

            byte[] data = Encoding.ASCII.GetBytes("/welc " + client.pseudo);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);
            socket.BeginReceive(bufferClient, 0, bufferClient.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int sizeReceive = socket.EndReceive(ar);
            byte[] receiveData = new byte[sizeReceive];
            Array.Copy(bufferClient, receiveData, sizeReceive);
            string response = Encoding.ASCII.GetString(receiveData);
            string request = string.Empty;

            try
            {
                request = response.Substring(0, 5).ToLower();
            }
            catch { request = response; }

            if (response == "/exit")
            {
                socket.EndDisconnect(ar);
            }
            else
            {
                richTextBox_Tchat.AppendText(response + "\n");
            }
            socket.BeginReceive(bufferClient, 0, bufferClient.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), socket);
        }

        private void SendRequest(string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            client.socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallBack), client.socket);
            client.socket.BeginReceive(bufferClient, 0, bufferClient.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

        #endregion

        private void Form_Tchat_Load(object sender, EventArgs e)
        {

        }
    }

    public class Client
    {
        public Socket socket;
        public string pseudo;

        public Client(Socket socket, string name)
        {
            this.socket = socket;
            pseudo = name;
        }
    }
}
