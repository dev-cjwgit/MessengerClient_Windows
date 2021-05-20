
using System;
using System.Net.Sockets;
using System.Threading;

namespace SocketComponent
{
    public delegate void SocketData(byte[] data);
    public class ServerConnect
    {
        public SocketData recv;
        private readonly string ip; private readonly int port;
        private Socket client;
        
        public ServerConnect(string ip, int port, SocketData recv)
        {
            this.ip = ip; this.port = port;
            init();
            this.recv += recv;
        }

        public void send(byte[] data)
        {
            client.Send(data);
        }
        private void init()
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ip, port);

            new Thread(new ThreadStart(recvData)).Start();
            new Thread(new ThreadStart(serverStatus)).Start();
        }

        private bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
        }

        private void serverStatus()
        {
            while (true)
            {
                if (IsSocketConnected(client) == false)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void recvData()
        {
            try
            {
                while (true)
                {
                    byte[] buff = new byte[8192];
                    int n = client.Receive(buff);
                    recv(buff);
                    //SocketEvents.recvData(buff);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("오류발생");
            }
        }

        
    }
}

