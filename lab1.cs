/*****************************************
*     Rumuantsev Arseniy                 * 
*     PI - 221                           *
*     Lab 1                              *
*****************************************/

using System;

namespace ConsoleApp
{
    class Lab1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 задание: ");
            Console.WriteLine("Введите действительное число: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите степень: ");
            int degree = Convert.ToInt32(Console.ReadLine());
            int res1 = n;
            for (int degreeIndex = 1; degreeIndex < degree; ++degreeIndex)
            {
                res1 = res1 * n;
            }
            Console.WriteLine("Результат: " + res1);


            Console.WriteLine("2 задание: ");
            Console.WriteLine("Введите число: ");
            string inputString = Console.ReadLine();
            string firstChar = inputString[0].ToString();
            string secondChar = inputString[1].ToString();
            string restOfString = inputString.Substring(2);

            Console.WriteLine("Converted number is: " + firstChar + restOfString + secondChar);
        }
    }
}
