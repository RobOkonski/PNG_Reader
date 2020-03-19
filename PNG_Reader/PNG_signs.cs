using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    class PNG_signs
    {
        public string PNG_sign = "89-50-4E-47-0D-0A-1A-0A";
        public string IHDR_sign = "49-48-44-52";
        public string PLTE_sign = "50-4C-54-45";
        public string IDAT_sign = "49-44-41-54";
        public string IEND_sign = "49-45-4E-44";

        public bool IsPNG(BinaryReader Pic)
        {
            if (BitConverter.ToString(Pic.ReadBytes(8)) == PNG_sign)
            {
                Console.WriteLine("Obraz PNG");
                return true;
            }
            else
            {
                return false;
            }
        }

        public int FindSign(BinaryReader Pic)
        {
            //Console.WriteLine("Jestem");
            byte[] buff = new byte[4];
            buff = Pic.ReadBytes(4);

            while (!(BitConverter.ToString(buff) == IEND_sign))
            {
               //Console.WriteLine("Szukam");
                buff[0] = buff[1];
                buff[1] = buff[2];
                buff[2] = buff[3];
                buff[3] = Pic.ReadByte();
                if (BitConverter.ToString(buff) == IHDR_sign) return 1;
                if (BitConverter.ToString(buff) == PLTE_sign) return 2;
                if (BitConverter.ToString(buff) == IDAT_sign) return 3;

            }

            return 0;
        }
    }
}
