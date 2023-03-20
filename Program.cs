using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите полный путь к директории: ");
            string InputPath = @"C:\";
            InputPath = Console.ReadLine();
            int Choice = 0;
            while (Choice != 4)
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1. Редактировать файл\n2. Найти файлы по ключевому слову\n" +
                                  "3. Проиндексировать все файлы в рабочей папке в отдельный файл\n4.Закрыть консоль");
                string FileName;
                Choice = int.Parse(Console.ReadLine());
                if (Choice < 1 || Choice > 3)
                {
                    Console.WriteLine("Ошибка! Введите число от 1 до 3");
                }
                Console.Clear();
                switch (Choice)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Введите имя файла, который вы хотите отредактировать: ");
                        FileName = Console.ReadLine();
                        FilesEditor.InitiateEdit(InputPath + @"\" + FileName + ".txt", FileName);
                        Choice = 0;
                        break;
                    case 2:
                        Console.Write("Введите ключевые слова для поиска: ");
                        string InputKeyword = Console.ReadLine();
                        Console.Clear();
                        Seeker.KeywordFilesSeeker(InputPath, InputKeyword);
                        Console.ReadKey();
                        Choice = 0;
                        break;
                    case 3:
                        Indexator.Indexation(InputPath);
                        Choice = 0;
                        break;
                }
            }
            
        }
    }
}
