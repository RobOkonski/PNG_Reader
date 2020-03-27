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


            string fileName = "data\\adaptive.png";
            string fileDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
            string filePath = Path.Combine(fileDir, fileName);
            string newPath = Path.Combine(fileDir, "data\\test");
            
            int chunk;

            BinaryReader test = new BinaryReader(File.OpenRead(filePath));
            BinaryWriter anonim = new BinaryWriter(File.OpenWrite(newPath));

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

            if (signs.IsPNG(Pic)) Console.WriteLine("Obraz PNG");
            signs.WriteData(anonim);

            while(existingSigns.Count != 0)
            {
                SignInfo s = existingSigns.Dequeue();
                chunk = signs.FindSign(Pic, s.hexSign);

                if (chunk == 1)
                {
                    Console.WriteLine("\n[{0}], byteLength: {1}\n", s.Sign, s.byteLength);

                    if (s.Sign == "IHDR")
                    {
                        ihdr.ReadData(Pic);
                        ihdr.DisplayData();
                        ihdr.WriteData(anonim);
                    }
                    else if (s.Sign == "PLTE")
                    {
                        PLTE plte = new PLTE(s.byteLength);
                        plte.ReadData(Pic, s.byteLength);
                        plte.DisplayData();
                        plte.WriteData(anonim);
                    }
                    else if (s.Sign == "gAMA")
                    {
                        int gama = Int32.Parse(BitConverter.ToString(Pic.ReadBytes(4)).Replace("-", ""), System.Globalization.NumberStyles.HexNumber);
                        Console.WriteLine(" - gama: {0}", (double)gama / 100000);
                    }
                    else if(s.Sign == "cHRM")
                    {
                        cHRM chrm = new cHRM();
                        chrm.ReadData(Pic);
                        chrm.DisplayData();
                    }
                    else if (s.Sign == "IDAT")
                    {
                        IDAT idat = new IDAT(s.byteLength);
                        idat.ReadData(Pic, s.byteLength);
                        idat.DisplayData();
                        idat.WriteData(anonim);
                    }
                    else
                    {
                        Console.WriteLine(BitConverter.ToString(Pic.ReadBytes(s.byteLength)));
                    }
                }

            }

            IEND iend = new IEND();
            iend.ReadData(Pic);
            iend.WriteData(anonim);

            Pic.Close();
            anonim.Close();

            Console.WriteLine("\n[IEND]\n");
        }
    }
}
