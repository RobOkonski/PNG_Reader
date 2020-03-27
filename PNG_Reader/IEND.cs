using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    public class IEND
    {
        public byte[] iendSign = {73,69,78,68};
        public byte[] controlSum = new byte[8];

        public void ReadData(BinaryReader Pic)
        {
            controlSum = Pic.ReadBytes(8);
        }

        public void WriteData(BinaryWriter anonim)
        {
            anonim.Write(iendSign);
            anonim.Write(controlSum);
        }
    }
}
