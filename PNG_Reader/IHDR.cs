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

        public void DisplayData()
        {
            Console.WriteLine("IHDR data:");
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
            width = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(4)).Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
            height = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(4)).Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
            bitDepth = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(1)), System.Globalization.NumberStyles.HexNumber);
            colorType = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(1)), System.Globalization.NumberStyles.HexNumber);
            compresionMethod = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(1)), System.Globalization.NumberStyles.HexNumber);
            filterMethod = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(1)), System.Globalization.NumberStyles.HexNumber);
            interlanceMethod = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(1)), System.Globalization.NumberStyles.HexNumber);
        }
    }
}
