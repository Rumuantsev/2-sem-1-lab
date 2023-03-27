using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal static class FilesEditor
    {
        public static void InitiateEdit(string UserPath, string FileName)
        {
            Console.Write("Выберите действие: \n1. Изменить текст\n2. Откатить изменения\n");
            int Choice = int.Parse(Console.ReadLine());
            if (Choice != 1 && Choice != 2)
            {
                Console.WriteLine("Ошибка! Введите либо 1, либо 2");
            }

            FileStream File = new FileStream(UserPath, FileMode.OpenOrCreate);
            switch (Choice)
            {
                case 1:
                    FileReader(File, FileName);
                    Console.Clear();
                    Console.WriteLine("Введите новое содержание файла(нажмите # для выхода):");
                    
                    string Input = "";
                    Input = Console.ReadLine();
                    while (Input != "#") 
                    {
                        Input += "\n";
                        FileWriter(Input, UserPath, FileName);
                        Input = Console.ReadLine();
                    }
                    Console.Clear();
                    Console.WriteLine("Изменения добавлены");
                    Console.ReadKey();
                    break;
                case 2:
                    try
                    {
                        File.Close();
                        RestoreData(UserPath, FileName);
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine("Не было изменений");
                        Console.ReadKey();
                    }
                    break;
            }
            File.Close();
        }

        static TextClass TextFile = new TextClass();
        static Caretaker Caretaker = new Caretaker();

        private static void FileReader(FileStream File, string FileName)
        {
            string outString = "";
            var Reader = new StreamReader(File);

            while (!Reader.EndOfStream)
            {
                outString += Reader.ReadLine();
            }
            try
            {
                TextFile.Content.Add(FileName, outString);
                TextFile.FileName.Add(FileName);
            }
            catch (Exception)
            {
                TextFile.Content[FileName] = outString;
            }
            Reader.Close();
        }

        private static void FileWriter(string input, string UserPath, string FileName)
        {
            using (StreamWriter writer = new StreamWriter(UserPath, true))
            {
                writer.Write(input);
            }
        }

        private static void RestoreData(string UserPath, string FileName)
        {
            Caretaker.RestoreState(TextFile);
            using (StreamWriter Writer = new StreamWriter(UserPath, false))
            {
                Writer.Write(TextFile.Content[FileName]);
            }
        }
    }
}