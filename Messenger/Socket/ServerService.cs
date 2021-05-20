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
    public delegate void SendForm(int opcode, ReadPacket r);
    public class ServerService
    {
        public static SendData send;
        public static SendForm sendLoginFrm;
        public static SendForm sendMainFrm;

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
            int opcode = r.readShort();
            switch (opcode)
            {
                case 255:  // id login
                case 256:  // email login
                    {
                        sendLoginFrm(opcode, r);
                        break;
                    }

            }
        }
    }
}
