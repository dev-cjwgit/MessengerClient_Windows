using PacketComponent;
using SocketComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.Socket
{
    public delegate void SendData(byte[] data);
    public class ServerService
    {
        public static SendData send;
        private readonly ServerConnect socket;
        public ServerService(string ip, int port)
        {
            socket = new ServerConnect(ip, port, RecvPacket);
            send += socket.send;
        }

        public void RecvPacket(byte[] data)
        {
            ReadPacket r = new ReadPacket(data);
            int byteslength = r.readInt(); // 총 bytes 길이
            if (!ThreadPool.QueueUserWorkItem(recvData, r))
            {
                Console.WriteLine("Error");
            }
        }
        private void recvData(object obj)
        {
            ReadPacket r = obj as ReadPacket;
            int opcode = r.readInt();
            switch (opcode)
            {
                case 255:
                    {
                        Console.WriteLine("Login");
                        break;
                    }
            }
        }
        public static void Send(byte[] data)
        {
            send(data);
        }
    }
}
