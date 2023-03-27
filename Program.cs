using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Sem_2_Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите директорию с файлами для редактирования: "); 
            string directory = Console.ReadLine();
            if (string.IsNullOrEmpty(directory))
            {
                directory = @"C:\Users\ars13\OneDrive\Рабочий стол\Новая папка";
            }

            var dictionary = DictionaryOfErrors.GetDictionary();

            foreach (string file in Directory.GetFiles(directory))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string text = reader.ReadToEnd();

                    foreach (var item in dictionary)
                    {
                        foreach (string incorrectWord in item.Value)
                        {
                            text = text.Replace(incorrectWord, item.Key);
                        }
                    }

                    text = Regex.Replace(text, @"\(0(\d{2})\)\s*(\d{3})-(\d{2})-(\d{2})", "+380 $1 $2 $3 $4");
                    reader.Close();

                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        writer.Write(text);

                        writer.Close();
                    }
                }

                Console.WriteLine($"Файлы отредактированы");
            }

            Console.ReadKey();
        }
    }
}
