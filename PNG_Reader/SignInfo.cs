using System;
using System.Collections.Generic;
using System.Text;

namespace PNG_Reader
{
    class SignInfo
    {
        public string Sign { set; get; }
        public string hexSign { set; get; }
        public int byteLength = 0;

        public void Display()
        {
            Console.WriteLine("{0}, {1}, {2}", Sign, hexSign, byteLength);
        }
    }


}
