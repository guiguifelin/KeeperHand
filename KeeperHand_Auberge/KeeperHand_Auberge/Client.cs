using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
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

    public class ClientTCP
    {
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
                // Afficher message d'erreur
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
                // Afficher ton texte que tu viens de recevoir
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
    }
}
