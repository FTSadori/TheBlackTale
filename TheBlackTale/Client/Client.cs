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
    public static class ClientHandler
    {
        class SocketGuard
        {
            public Socket Socket { get; private set; }
            public SocketGuard(Socket socket)
            {
                Socket = socket ?? throw new ArgumentNullException(nameof(socket));
            }
            ~SocketGuard()
            {
                Socket.Close(); 
            }
        }

        class Command
        {
            private List<string> args = new();
            private string Mode { get; set; }

            public string this[int index] { get { return args[index]; } }
            public int Count { get { return args.Count; } }

            public Command(string mode, string cmd)
            {
                Mode = mode;
                args = cmd.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        static ClientHandler()
        {
            clientSocket = new(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
        }

        public static void Connect()
        {
            clientSocket.Socket.Connect(IPAddress.Parse("25.60.223.48"), 5050);
        }

        public static void Send(string message)
        {
            clientSocket.Socket.Send(Encoding.ASCII.GetBytes(message));
        }

        public static void Close()
        {
            clientSocket.Socket.Close();
        }

        readonly static SocketGuard clientSocket;

    }
}
