using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketComponent
{

    public class ReadPacket
    {
        private byte[] data;
        int pos;

        private byte[] copyByte(byte[] obj, int start, int size)
        {
            byte[] b = new byte[size];
            for (int i = 0; i < size; i++)
            {
                b[i] = obj[start + i];
            }
            return b;
        }
        public ReadPacket()
        {
            this.data = new byte[1024];
            pos = 0;

        }
        public ReadPacket(byte[] data)
        {
            int n = data.Length;
            this.data = new byte[n];
            this.data = copyByte(data, pos, n);
            pos = 0;
        }
        public byte[] readByte()
        {
            int size = readInt();
            byte[] temp = new byte[size];
            temp = copyByte(this.data, pos, size);
            pos += size;
            return temp;
        }
        public int readInt()
        {
            byte[] temp = new byte[4];
            temp = copyByte(this.data, pos, 4);
            pos += 4;
            return BitConverter.ToInt32(temp, 0);
        }

        public double readDouble()
        {
            byte[] temp = new byte[4];
            temp = copyByte(this.data, pos, 8);
            pos += 8;
            return BitConverter.ToDouble(temp, 0);
        }

        public string readString()
        {
            int size = readInt();
            byte[] temp = new byte[size];
            temp = copyByte(this.data, pos, size);
            pos += size;
            return Encoding.UTF8.GetString(temp);
        }
    }
}
