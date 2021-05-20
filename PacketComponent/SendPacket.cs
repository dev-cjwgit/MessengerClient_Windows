using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketComponent
{
    public class SendPacket
    {
        private byte[] data;
        private int pos;

        public SendPacket()
        {
            pos = 0;
            data = new byte[1024];
        }

        public SendPacket(int maxsize)
        {
            pos = 0;
            data = new byte[maxsize];
        }

        public byte[] getPacket()
        {
            Byte[] temp = new Byte[pos];
            Buffer.BlockCopy(this.data, 0, temp, 0, pos);
            return temp;
        }

        public void writeByte(byte[] by, int size)
        {
            writeInt(size);
            for (int i = 0; i < size; i++, pos++)
            {
                this.data[pos] = by[i];
            }

        }

        public void writeShort(short SH)
        {
            byte[] bytes = BitConverter.GetBytes(SH);
            for (int i = 0; i < bytes.Length; i++, pos++)
            {
                this.data[pos] = bytes[i];
            }
        }

        public void writeInt(int INT)
        {
            byte[] bytes = BitConverter.GetBytes(INT);
            for (int i = 0; i < bytes.Length; i++, pos++)
            {
                this.data[pos] = bytes[i];
            }
        }

        public void writeDouble(double DOUBLE)
        {
            byte[] bytes = BitConverter.GetBytes(DOUBLE);
            for (int i = 0; i < bytes.Length; i++, pos++)
            {
                this.data[pos] = bytes[i];
            }
        }

        public void writeString(string STRING)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(STRING);
            writeInt(bytes.Length);
            for (int i = 0; i < bytes.Length; i++, pos++)
            {
                this.data[pos] = bytes[i];
            }
        }

    }
}
