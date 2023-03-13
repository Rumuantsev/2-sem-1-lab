using Lab3;
using System;
using System.Data;
using System.Drawing;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер квадратной матрицы: ");
            int Size = int.Parse(Console.ReadLine());

            SquareMatrix Matrix1 = new SquareMatrix(Size);
            SquareMatrix Matrix2 = new SquareMatrix(Size);
            SquareMatrix ArrayResult = new SquareMatrix(Size);
            int IntResult = 0;
            Console.WriteLine("Первая матрица: "); Matrix1.PrintMatrix();
            Console.WriteLine("Вторая матрица: "); Matrix2.PrintMatrix();


            Console.WriteLine("Действия: \n\t1. Сложить\n\t2. Вычесть \n\t" + 
            "3. Пермножить\n\t4. Найти детерминант\n\t" +
            "5. Найти обратную матрицу\n");
            Console.Write("Введите желаемый пункт: ");
            int UserChoice = int.Parse(Console.ReadLine());

            switch (UserChoice)
            {
                case 1:
                    ArrayResult = Matrix1 + Matrix2;
                    Console.WriteLine("Результат сложения: ");
                    ArrayResult.PrintMatrix();
                    break;
                case 2:
                    IntResult = Matrix1 - Matrix2;
                    Console.WriteLine("Результат вычитания: " + IntResult);
                    break;
                case 3:
                    ArrayResult = Matrix1 * Matrix2;
                    Console.WriteLine("Результат умножения: ");
                    ArrayResult.PrintMatrix();
                    break;
                case 4:
                    IntResult = SquareMatrix.Determinant(Matrix1);
                    Console.WriteLine("Детерминант матрицы: " + IntResult);
                    break;
                case 5:
                    ArrayResult = SquareMatrix.Inverse(Matrix1);
                    Console.WriteLine("Обратная матрица: ");
                    ArrayResult.PrintMatrix();
                    break;
            }
        }
    }
}
