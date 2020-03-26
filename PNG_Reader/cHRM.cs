using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class cHRM
    {
        string[] names = { "whitePointX", "whitePointY", "redX", "redY", "greenX", "greenY", "blueX", "blueY" };
        double[] chrm = new double[8];

        public void ReadData(BinaryReader Pic)
        {
            for (int i = 0; i < 8; i++) chrm[i] = ((double)Int32.Parse(BitConverter.ToString(Pic.ReadBytes(4)).Replace("-", ""), System.Globalization.NumberStyles.HexNumber))/100000;
        }

        public void DisplayData()
        {
            for (int i = 0; i < 8; i++) Console.WriteLine(" - {0}: {1}", names[i], chrm[i]);
        }
    }
}
