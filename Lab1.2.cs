/*****************************************
*     Rumuantsev Arseniy                 * 
*     PI - 221                           *
*     Lab 2                              *
*****************************************/

using System;

namespace Lab2
{
    class Document
    {
        public string Name;
        public string Author;
        public string Path;

        public virtual void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path);
        }
    }

    class Word : Document
    {
        string KeyWords;
        string Topic;

        public override void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path
            + ";\nКлючевые слова - " + KeyWords + ";\nТематика -" + Topic);
        }

        public Word(string Name, string Author, string Path, string KeyWords, string Topic)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.KeyWords = KeyWords;
            this.Topic = Topic;
        }
    }

    class PDF : Document
    {
        string Colors;
        string Resolution;

        public override void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path
            + ";\nЦвета - " + Colors + ";\nРазрешение изображения - " + Resolution);
        }

        public PDF(string Name, string Author, string Path, string Colors, string Resolution)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.Colors = Colors;
            this.Resolution = Resolution;
        }
    }

    class Excel : Document
    {
        int RowCount;
        int ColumnCount;

        public override void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path
            + ";\nЧисло строк -" + RowCount + ";\nЧисло столбцов - " + ColumnCount);
        }

        public Excel(string Name, string Author, string Path, int RowCount, int ColumnCount)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.RowCount = RowCount;
            this.ColumnCount = ColumnCount;
        }
    }

    class TXT : Document
    {
        int Size;
        string Font;

        public override void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path
              + ";\nРазмер файла -" + Size + ";\nШрифт - " + Font);
        }
        public TXT(string Name, string Author, string Path, int Size, string Font)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.Size = Size;
            this.Font = Font;
        }
    }

    class HTML : Document
    {
        string IDs;
        string Classes;

        public override void Info()
        {
            Console.WriteLine("Имя файла - " + Name + ";\nИмя автора - " + Author + ";\nПуть к файлу - " + Path
            + ";\nИдентификаторы - " + IDs + ";\nКлассы - " + Classes);
        }
        public HTML(string Name, string Author, string Path, string IDs, string Classes)
        {
            this.Name = Name;
            this.Author = Author;
            this.Path = Path;
            this.IDs = IDs;
            this.Classes = Classes;
        }
    }

    public class Singleton
    {
        string Type;

        public string Name;
        public string Author;
        public string Path;

        string KeyWords;
        string Topic;

        string Colors;
        string Resolution;

        int RowCount;
        int ColumnCount;

        int Size;
        string Fonts;

        string IDs;
        string Classes;

        public static Singleton Instance
        {
            get
            {
                if (instance == null) instance = new Singleton();
                return instance;
            }

        }

        private void Input(string Type)
        {
            Console.Write("\nВведите имя файла: ");
            Name = Console.ReadLine();
            Console.Write("Введите имя автора: ");
            Author = Console.ReadLine();
            Console.Write("Введите полный путь к файлу: ");
            Path = Console.ReadLine();
            switch (Type)
            {
                case "Word":
                    Console.Write("Введите ключевые слова файла: ");
                    KeyWords = Console.ReadLine();
                    Console.Write("Введите тему файла: ");
                    Topic = Console.ReadLine();
                    Word WordDoc = new Word(Name, Author, Path, KeyWords, Topic);
                    WordDoc.Info();
                    break;

                case "PDF":
                    Console.Write("Введите цвета: ");
                    Colors = Console.ReadLine();
                    Console.Write("Введите разрешение изображения: ");
                    Resolution = Console.ReadLine();
                    PDF PDFDoc = new PDF(Name, Author, Path, Colors, Resolution);
                    PDFDoc.Info();
                    break;

                case "Excel":
                    Console.Write("Введите количество строк: ");
                    RowCount = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    ColumnCount = Convert.ToInt32(Console.ReadLine());
                    Excel ExcelDoc = new Excel(Name, Author, Path, RowCount, ColumnCount);
                    ExcelDoc.Info();
                    break;

                case "TXT":
                    Console.Write("Введите размер файла: ");
                    Size = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите названия шрифтов, используемых в файле: ");
                    Fonts = Console.ReadLine();
                    TXT TXTDoc = new TXT(Name, Author, Path, Size, Fonts);
                    TXTDoc.Info();
                    break;

                case "HTML":
                    Console.Write("Введите названия идентификаторов, используемых в документе: ");
                    IDs = Console.ReadLine();
                    Console.Write("Введите названия классов, используемых в документе: ");
                    Classes = Console.ReadLine();
                    HTML HTMLDoc = new HTML(Name, Author, Path, IDs, Classes);
                    HTMLDoc.Info();
                    break;
            }
        }
        public void ChooseType()
        {
            Console.WriteLine("Выберите необходимый файл (Word/PDF/Excel/TXT/HTML): ");
            Type = Console.ReadLine();
            Input(Type);
        }
        private Singleton() { }
        private static Singleton instance;
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Singleton.Instance.ChooseType();
            }
        }
    }
}

