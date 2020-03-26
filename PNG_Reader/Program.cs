using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace PNG_Reader
{
    class Program
    {
        public static void Main(string[] args)
        {
            PNG_signs signs = new PNG_signs();
            IHDR ihdr = new IHDR();
            Queue<SignInfo> existingSigns = new Queue<SignInfo>();


            string fileName = "data\\car-967387_640.png";
            string fileDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string filePath = Path.Combine(fileDir, fileName);
            
            int chunk;

            BinaryReader test = new BinaryReader(File.OpenRead(filePath));

            if (!(signs.IsPNG(test))) Console.WriteLine("Obraz nie PNG");

            signs.ExploreFile(test, existingSigns);

            /*while(existingSigns.Count != 0)
            {
                existingSigns.Dequeue().Display();
            }*/

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

            BinaryReader Pic = new BinaryReader(File.OpenRead(filePath));

            if (!(signs.IsPNG(Pic))) Console.WriteLine("Obraz nie PNG");

            while(existingSigns.Count != 0)
            {
                SignInfo s = existingSigns.Dequeue();
                chunk = signs.FindSign(Pic, s.hexSign);

                if (chunk == 1)
                {
                    Console.WriteLine("\n[{0}], length: {1}\n", s.Sign, s.byteLength);

                    if (s.Sign == "IHDR")
                    {
                        ihdr.ReadData(Pic);
                        ihdr.DisplayData();
                    }
                    else if (s.Sign == "PLTE") Console.WriteLine("Color quantity: {0}",s.byteLength/3);
                    else
                    {
                        Console.WriteLine(BitConverter.ToString(Pic.ReadBytes(s.byteLength)));
                    }
                }

            }

            Console.WriteLine("[IEND]");
        }
    }
}
