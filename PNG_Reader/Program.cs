﻿using System;
using System.Text;
using System.IO;

namespace PNG_Reader
{
    class Program
    {
        public static void Main(string[] args)
        {
            PNG_signs signs = new PNG_signs();

            string fileName = "data\\car-967387_640.png";
            string fileDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string filePath = Path.Combine(fileDir, fileName);

            BinaryReader Pic = new BinaryReader(File.OpenRead(filePath));

            //DO USUNIECIA - TESTOWE WCZYTANIE
            /*  
            string hex = ""''
            if (File.Exists(filePath))
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                hex = BitConverter.ToString(bytes);
            }

            Console.WriteLine(hex);
            Console.WriteLine("Wypisano");
            Console.WriteLine(filePath);
            */

            if(!(signs.IsPNG(Pic)))
            {
                Console.WriteLine("Obraz nie PNG");
            }

            byte[] buff = new byte[4];
            buff = Pic.ReadBytes(4);

            while(!(BitConverter.ToString(buff)==signs.IHDR_sign))
            {
                buff[0] = buff[1];
                buff[1] = buff[2];
                buff[2] = buff[3];
                buff[3] = Pic.ReadByte();
            }

            IHDR ihdr = new IHDR();

            ihdr.ReadData(Pic);
            ihdr.DisplayData();
        }
    }
}
