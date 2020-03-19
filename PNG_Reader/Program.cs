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


            string fileName = "data\\multipla.png";
            string fileDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string filePath = Path.Combine(fileDir, fileName);
            
            int chunk;

            BinaryReader test = new BinaryReader(File.OpenRead(filePath));

            if (!(signs.IsPNG(test))) Console.WriteLine("Obraz nie PNG");

            signs.ExploreFile(test, existingSigns);

            while(existingSigns.Count != 0)
            {
                existingSigns.Dequeue().Display();
            }

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

            do{
                chunk = signs.FindSign(Pic);

                if (chunk == 1)
                {
                    ihdr.ReadData(Pic);
                    ihdr.DisplayData();
                }
                else if(chunk==2)
                {
                    Console.WriteLine("[PLTE]");
                }
                else if(chunk==3)
                {
                    Console.WriteLine("[IDAT]");
                }

            } while (!(chunk==0));

            Console.WriteLine("Koniec");
        }
    }
}
