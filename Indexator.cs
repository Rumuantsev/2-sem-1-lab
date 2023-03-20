using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal static class Indexator
    {
        public static void Indexation(string Path)
        {
            List<string> Extensions = new List<string>();
            Console.WriteLine("Вводите расширения файлов для индексации. Для остановки введите #");
            while (!Extensions.Contains("#"))
            {
                Extensions.Add(Console.ReadLine());
            }
            Extensions.Remove("#");

            Console.Write("\nВведите имя файла c расширением, в который нужно записать индексацию: ");
            string RecordFileName = Path + @"\" + Console.ReadLine();
            FileStream IndexatedFile = new FileStream(RecordFileName, FileMode.OpenOrCreate);
            using (StreamWriter Writer = new StreamWriter(IndexatedFile))
                foreach (string Extension in Extensions)
                {
                    var SearchFiles = Directory.EnumerateFiles(Path, "*." + Extension,
                        SearchOption.AllDirectories);
                    Writer.WriteLine(Extension + ":\n");
                    foreach (string File in SearchFiles)
                    {
                        string FileName = File.Substring(Path.Length);
                        Writer.WriteLine(FileName);
                    }
                }
            IndexatedFile.Close();
        }
    }
}
