using Lab3;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ExceptionServices;

namespace Lab3
{
    class MatrixCalculator
    {
        private SquareMatrix Matrix1, Matrix2;

        public MatrixCalculator(int size)
        {
            Matrix1 = new SquareMatrix(size);
            Matrix2 = new SquareMatrix(size);
        }

        

        public void MainMenu()
        {
            bool MainExit = false;

            while (!MainExit)
            {
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Показать матрицы");
                Console.WriteLine("2. Действия с двумя матрицами");
                Console.WriteLine("3. Действия с одной матрицей");
                Console.WriteLine("0. Выйти");

                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Первая матрица: "); Matrix1.PrintMatrix();
                        Console.WriteLine("Вторая матрица: "); Matrix2.PrintMatrix();
                        break;
                    case "2":
                        TwoMatrixMenu(Matrix1, Matrix2);
                        break;
                    case "3":
                        Console.Write("Выберите матрицу: ");
                        string MatrixChoice = Console.ReadLine();
                        Console.WriteLine();
                        switch (MatrixChoice)
                        {
                            case "1": 
                                OneMatrixMenu(Matrix1);
                                break;
                            case "2":
                                OneMatrixMenu(Matrix2);
                                break;
                        }
                        break;
                    case "0":
                        MainExit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }
        public void TwoMatrixMenu(SquareMatrix FirstMatrix, SquareMatrix SecondMatrix)
        {
            SquareMatrix ArrayResult = new SquareMatrix(FirstMatrix.Size);
            int IntResult = 0;

            bool TwoMatrixMenuExit = false;

            while (!TwoMatrixMenuExit)
            {
                Console.WriteLine("Меню действий с двумя матрицами:");
                Console.WriteLine("1. Сложить");
                Console.WriteLine("2. От первой отнять вторую");
                Console.WriteLine("3. От второй отнять первую");
                Console.WriteLine("4. Перемножить");
                Console.WriteLine("0. Выйти в главное меню");

                Console.Write("Выберите действие: ");
                string TwoMatrixMenuChoice = Console.ReadLine();
                Console.WriteLine();

                switch (TwoMatrixMenuChoice)
                {
                    case "1":
                        ArrayResult = Matrix1 + Matrix2;
                        Console.WriteLine("Результат сложения: ");
                        ArrayResult.PrintMatrix();
                        break;
                    case "2":
                        IntResult = Matrix1 - Matrix2;
                        Console.WriteLine("Результат вычитания: " + IntResult);
                        break;
                    case "3":
                        IntResult = Matrix2 - Matrix1;
                        Console.WriteLine("Результат вычитания: " + IntResult);
                        break;
                    case "4":
                        ArrayResult = Matrix1 * Matrix2;
                        Console.WriteLine("Результат умножения: ");
                        ArrayResult.PrintMatrix();
                        break;
                    case "0":
                        TwoMatrixMenuExit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }
        public void OneMatrixMenu(SquareMatrix Matrix)
        {
            SquareMatrix ArrayResult = new SquareMatrix(Matrix.Size);
            int IntResult = 0;

            bool OneMatrixMenuExit = false;

            while (!OneMatrixMenuExit)
            {
                Console.WriteLine("Меню действий с одной матрицей:");
                Console.WriteLine("1. Найти детерминант");
                Console.WriteLine("2. Найти обратную матрицу");
                Console.WriteLine("3. Транспонировать");
                Console.WriteLine("4. Найти след матрицы");
                Console.WriteLine("5. Привести к диагональному виду");
                Console.WriteLine("0. Выйти в главное меню");

                Console.Write("Выберите действие: ");
                string OneMatrixMenuChoice = Console.ReadLine();
                Console.WriteLine();

                switch (OneMatrixMenuChoice)
                {
                    case "1":
                        IntResult = SquareMatrix.Determinant(Matrix);
                        Console.WriteLine("Детерминант матрицы: " + IntResult);
                        break;
                    case "2":
                        ArrayResult = SquareMatrix.Inverse(Matrix);
                        Console.WriteLine("Обратная матрица: ");
                        ArrayResult.PrintMatrix();
                        break;
                    case "3":
                        ArrayResult = Matrix.Transpose();
                        Console.WriteLine("Транспонированная матрица: ");
                        ArrayResult.PrintMatrix();
                        break;
                    case "4":
                        IntResult = Matrix.MatrixTrace();
                        Console.WriteLine("След матрицы: " + IntResult);
                        break;
                    case "5":
                        ArrayResult = DiagonalizationMatrix(Matrix);
                        Console.WriteLine("Матрица в диагональном виде: ");
                        ArrayResult.PrintMatrix();
                        break;
                    case "0":
                        OneMatrixMenuExit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }

        delegate SquareMatrix WorkWithMatrix(SquareMatrix Matrix);

        WorkWithMatrix DiagonalizationMatrix = DiagonalizeMatrix;

        static SquareMatrix DiagonalizeMatrix(SquareMatrix DiagonalMatrix) 
        {
            int MatrixSize = DiagonalMatrix.Size;

            for (int ColumnIndex = 0; ColumnIndex < DiagonalMatrix.Size; ++ColumnIndex)
            {
                for (int RowIndex = 0; RowIndex < DiagonalMatrix.Size; ++RowIndex)
                {
                    if (ColumnIndex != RowIndex)
                    {
                        DiagonalMatrix.Matrix[ColumnIndex, RowIndex] = 0;
                    }

                }
            }

            return DiagonalMatrix;
        }



    }
        class Program
        {
            static void Main()
            {
                

                Console.WriteLine("Введите размер квадратной матрицы: ");
                int Size = int.Parse(Console.ReadLine());
                MatrixCalculator calculator = new MatrixCalculator(Size);
                calculator.MainMenu();

                ////SquareMatrix Matrix1 = new SquareMatrix(Size);
                ////SquareMatrix Matrix2 = new SquareMatrix(Size);
                //SquareMatrix ArrayResult = new SquareMatrix(Size);
                //int IntResult = 0;
                //Console.WriteLine("Первая матрица: "); Matrix1.PrintMatrix();
                //Console.WriteLine("Вторая матрица: "); Matrix2.PrintMatrix();


                //Console.WriteLine("Действия: \n\t1. Сложить\n\t2. Вычесть \n\t" +
                //"3. Пермножить\n\t4. Найти детерминант\n\t" +
                //"5. Найти обратную матрицу\n");
                //Console.Write("Введите желаемый пункт: ");
                //int UserChoice = int.Parse(Console.ReadLine());

                //switch (UserChoice)
                //{
                //    case 1:
                //        ArrayResult = Matrix1 + Matrix2;
                //        Console.WriteLine("Результат сложения: ");
                //        ArrayResult.PrintMatrix();
                //        break;
                //    case 2:
                //        IntResult = Matrix1 - Matrix2;
                //        Console.WriteLine("Результат вычитания: " + IntResult);
                //        break;
                //    case 3:
                //        ArrayResult = Matrix1 * Matrix2;
                //        Console.WriteLine("Результат умножения: ");
                //        ArrayResult.PrintMatrix();
                //        break;
                //    case 4:
                //        IntResult = SquareMatrix.Determinant(Matrix1);
                //        Console.WriteLine("Детерминант матрицы: " + IntResult);
                //        break;
                //    case 5:
                //        ArrayResult = SquareMatrix.Inverse(Matrix1);
                //        Console.WriteLine("Обратная матрица: ");
                //        ArrayResult.PrintMatrix();
                //        break;
                //}
                Console.ReadKey();
            }
        }
    }
