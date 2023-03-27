using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Seeker
    {
        public static void KeywordFilesSeeker(string Path, string Keyword)
        {
            List<string> ReadyList = new List<string>();
            var TxtFiles = Directory.EnumerateFiles(Path, "*.txt", SearchOption.AllDirectories);

            foreach (string TxtFile in TxtFiles)
            {
                string FileName = TxtFile.Substring(Path.Length);
                if (File.ReadLines(Path + FileName).Any(line => line.Contains(Keyword)) || FileName.Contains(Keyword))
                {
                    ReadyList.Add(FileName);
                }
            }

            Console.WriteLine("Файлы, содержащие слово '" + Keyword + "': ");
            if (ReadyList.Count != 0)
            {
                for (int ElementIndex = 0; ElementIndex < ReadyList.Count; ++ElementIndex)
                {
                    Console.Write($"{ElementIndex + 1}. {ReadyList[ElementIndex]}\n");
                }
            }
            else
            {
                Console.WriteLine("Нет подходящих файлов");
            }
        }
    }
}

