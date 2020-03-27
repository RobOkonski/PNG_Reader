using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class IHDR
    {
        public int width { set; get; }
        public int height { set; get; }
        public int bitDepth { set; get; }
        public int colorType { set; get; }
        public int compresionMethod { set; get; }
        public int filterMethod { set; get; }
        public int interlanceMethod { set; get; }

        public byte[] ihdrSign = { 73, 72, 68, 82 };
        public byte[] byteWidth = new byte[4];
        public byte[] byteHeight = new byte[4];
        public byte[] byteBitDepth = new byte[1];
        public byte[] byteColorType = new byte[1];
        public byte[] byteCompresionMethod = new byte[1];
        public byte[] byteFilterMethod = new byte[1];
        public byte[] byteInterlanceMethod = new byte[1];
        public byte[] ihdrControlSum = new byte[8];

        public void DisplayData()
        {
            Console.WriteLine(" - width: " + width);
            Console.WriteLine(" - height: " + height);
            Console.WriteLine(" - bitDepth: " + bitDepth);
            Console.WriteLine(" - colorType: " + colorType);
            Console.WriteLine(" - compresionMethod: "+ compresionMethod);
            Console.WriteLine(" - filterMethod: " + filterMethod);
            Console.WriteLine(" - interlanceMethod: " + interlanceMethod);
        }

        public void ReadData(BinaryReader Pic)
        {
            byteWidth = Pic.ReadBytes(4);
            byteHeight = Pic.ReadBytes(4);
            byteBitDepth = Pic.ReadBytes(1);
            byteColorType = Pic.ReadBytes(1);
            byteCompresionMethod = Pic.ReadBytes(1);
            byteFilterMethod = Pic.ReadBytes(1);
            byteInterlanceMethod = Pic.ReadBytes(1);
            ihdrControlSum = Pic.ReadBytes(8);
            width = Int32.Parse(BitConverter.ToString(byteWidth).Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
            height = Int32.Parse(BitConverter.ToString(byteHeight).Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
            bitDepth = Int32.Parse(BitConverter.ToString(byteBitDepth), System.Globalization.NumberStyles.HexNumber);
            colorType = Int32.Parse(BitConverter.ToString(byteColorType), System.Globalization.NumberStyles.HexNumber);
            compresionMethod = Int32.Parse(BitConverter.ToString(byteCompresionMethod), System.Globalization.NumberStyles.HexNumber);
            filterMethod = Int32.Parse(BitConverter.ToString(byteFilterMethod), System.Globalization.NumberStyles.HexNumber);
            interlanceMethod = Int32.Parse(BitConverter.ToString(byteInterlanceMethod), System.Globalization.NumberStyles.HexNumber);
        }
        public void WriteData(BinaryWriter anonim)
        {
            anonim.Write(ihdrSign);
            anonim.Write(byteWidth);
            anonim.Write(byteHeight);
            anonim.Write(byteBitDepth);
            anonim.Write(byteColorType);
            anonim.Write(byteCompresionMethod);
            anonim.Write(byteFilterMethod);
            anonim.Write(byteInterlanceMethod);
            anonim.Write(ihdrControlSum);
        }
    }
}
