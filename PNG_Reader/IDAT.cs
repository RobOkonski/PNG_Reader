using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class IDAT
    {
        public byte[] idat;
        public byte[] idatControlSum = new byte[8];
        public string idatData = "";

        public IDAT(int byteLength)
        {
            idat = new byte[ byteLength ];
        }

        public void ReadData(BinaryReader Pic, int byteLength)
        {
            idat = Pic.ReadBytes(byteLength);
            idatControlSum = Pic.ReadBytes(8);
            idatData = BitConverter.ToString(idat);
        }

        public void DisplayData()
        {
            Console.WriteLine(idatData);
        }
    }
}
