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
    }
}
