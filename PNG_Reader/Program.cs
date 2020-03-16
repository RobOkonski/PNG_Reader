﻿using System;
using System.Text;
using System.IO;

namespace PNG_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "car-967387_640.png";
            string fileDir = "C:\\Users\\Student241540\\source\\repos\\PNG_Reader\\PNG_Reader\\data";
            string buf = "";
            string filePath = Path.Combine(fileDir, fileName);

            ASCIIEncoding ascii = new ASCIIEncoding();

            if (File.Exists(filePath))
            {
                buf = File.ReadAllText(filePath);
                Console.WriteLine("Odczytano");
            }

            byte[] bytes = File.ReadAllBytes(filePath);
            string hex = BitConverter.ToString(bytes);

            Console.WriteLine(hex);
            Console.WriteLine("Wypisano");
        }
    }
}
