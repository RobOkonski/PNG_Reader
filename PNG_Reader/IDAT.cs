using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class IDAT
    {
        public byte[] idatSign = { 73, 68, 65, 84 };
        public byte[] idat;
        public byte[] idatControlSum = new byte[4];
        public string idatData = "";

        public IDAT(int byteLength)
        {
            idat = new byte[ byteLength ];
        }

        public void ReadData(BinaryReader Pic, int byteLength)
        {
            idat = Pic.ReadBytes(byteLength);
            idatControlSum = Pic.ReadBytes(4);
            idatData = BitConverter.ToString(idat);
        }

        public void DisplayData()
        {
            Console.WriteLine(idatData);
        }
        public void WriteData(BinaryWriter anonim)
        {
            anonim.Write(idatSign);
            anonim.Write(idat);
            anonim.Write(idatControlSum);
        }
    }
}
