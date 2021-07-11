
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
        private bool status = true;
        
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
        public void Close()
        {
            status = false;
            client.Close();
        }
        private bool IsSocketConnected(Socket s)
        {
            try
            {
                return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
            }catch(Exception ex)
            {
                return false;
            }
        }

        private void serverStatus()
        {
            while (true)
            {
                if (IsSocketConnected(client) == false)
                {
                    Close();
                    Environment.Exit(0);
                }
            }
        }

        private void recvData()
        {
            try
            {
                while (status)
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

