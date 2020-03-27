using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class PLTE
    {
        public byte[] plteSign = { 80, 76, 84, 69 };
        public byte[] plte;
        public byte[] plteControlSum = new byte[8];
        public int colorQuantity = 0;

        public PLTE(int byteLength)
        {
            plte = new byte[byteLength];
        }

        public void ReadData(BinaryReader Pic, int byteLength)
        {
            plte = Pic.ReadBytes(byteLength);
            plteControlSum = Pic.ReadBytes(8);
            colorQuantity = byteLength / 3;
        }

        public void DisplayData()
        {
            Console.WriteLine(" - colorQuantity: {0}", colorQuantity);
        }
        public void WriteData(BinaryWriter anonim)
        {
            anonim.Write(plteSign);
            anonim.Write(plte);
            anonim.Write(plteControlSum);
        }
    }
}
