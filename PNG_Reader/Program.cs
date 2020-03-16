using System;
using System.IO;

namespace PNG_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "car-967387_1280.png";
            string fileDir = "C:\\Users\\Student241540\\source\\repos\\PNG_Reader\\PNG_Reader\\data";
            string buf = "";
            string filePath = Path.Combine(fileDir, fileName);

            if(File.Exists(filePath))
            {
                buf = File.ReadAllText(filePath);
                Console.WriteLine("Odczytano");
            }

            Console.WriteLine(buf);
            Console.WriteLine("Wypisano");
        }
    }
}
