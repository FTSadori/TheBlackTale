using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TheBlackTale.Client
{
    public class Client
    {
        public Client()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(IPAddress.Parse("25.60.223.48"), 5050);
        }

        public void Send(string message)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(message));
        }

        ~Client()
        {
            clientSocket.Close();
        }

        Socket clientSocket;
    }
}
