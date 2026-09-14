using System;
namespace Lab1
{
    class Program
    {
        static int ReadInt(string prompt)
        {
            int res;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out res))
                {
                    return res;
                }
                Console.WriteLine("Введено не число");
            }
        }

        static double ReadDouble(string prompt)
        {
            double res;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out res))
                {
                    return res;
                }
                Console.WriteLine("Введено не число");
            }
        }

        static int ReadIntNotZero(string prompt)
        {
            while (true)
            {
                int res = ReadInt(prompt);
                if (res != 0)
                {
                    return res;
                }
                Console.WriteLine("На ноль делить нельзя!");
            }
        }

        static void RunFirst()
        {
            Console.WriteLine("Первый пример");
            int n = ReadInt("Введите число n: ");
            int m = ReadIntNotZero("Введите число m: ");
            int k = n / m++;
            Console.WriteLine("n/m++ = {0}, m = {1}, n = {2}", k, m, n);
        }

        static void RunSecond()
        {
            Console.WriteLine("Второй пример");
            int n = ReadInt("Введите число n: ");
            int m = ReadInt("Введите число m: ");
            bool isLess = m++ < --n;
            Console.WriteLine("m++ < --n = {0}, m = {1}, n = {2}", isLess, m, n);
        }

        static void RunThird()
        {
            Console.WriteLine("Третий пример");
            int n = ReadIntNotZero("Введите число n: ");
            int m = ReadIntNotZero("Введите число m: ");
            int leftPart = m / n;
            bool isLess = leftPart++ < (n / m);
            Console.WriteLine("(m / n)++ < (n / m) = {0}, m = {1}, n = {2}", isLess, m, n);
        }

        static void RunFourth()
        {
            Console.WriteLine("Четвертый пример");
            double x = ReadDouble("Введите число x: ");
            double part1 = Math.Sqrt(Math.Abs(Math.Pow(x, 3) - 1));
            double part2 = 7 * Math.Cos(Math.Pow(Math.Pow(x, 4) + x, 1.0 / 3.0));
            double result = part1 - part2;
            Console.WriteLine("Результат выражения: {0}", result);
        }
        static void RunTask2()
        {   
            Console.WriteLine("Задача номер два ");
            double x = ReadDouble("Введи число x: ");
            double y = ReadDouble("Введи число y: ");
            bool inArea =  ((x * x + y * y <= 4) && (x <= 0)) || ((y <= -x + 2) && (y >= x - 2) && x >= 0);
            Console.WriteLine("Точка ({0}, {1}) принадлежит области: {2}", x, y, inArea);
        }
        static void RunTask3()
        {
            Console.WriteLine("Задача номер три ");
            double aDouble = 1000;
            double bDouble = 0.0001;
            float aFloat = 1000f;
            float bFloat = 0.0001f;

            double numeratorDouble = Math.Pow(aDouble + bDouble, 3) - Math.Pow(aDouble, 3);
            double denominatorDouble = Math.Pow(bDouble,3) + (3 * aDouble * Math.Pow(bDouble,2)) + (3 * Math.Pow(aDouble,2) * bDouble);
            double resultDouble = numeratorDouble / denominatorDouble;

            float numeratorFloat = (float)(Math.Pow(aFloat + bFloat, 3) - Math.Pow(aFloat, 3));
            float denominatorFloat = (float)(Math.Pow(bFloat, 3) + (3 * aFloat * Math.Pow(bFloat, 2)) + (3 * Math.Pow(aFloat, 2) * bFloat));
            float resultFloat = numeratorFloat / denominatorFloat;

            Console.WriteLine("Результат (double): {0}", resultDouble);
            Console.WriteLine("Результат (float): {0}", resultFloat);   
        }

        static void Main()
        {
            //RunFirst();
            //Console.WriteLine();
            RunSecond();
            //Console.WriteLine();
            //RunThird();
            //Console.WriteLine();
            //RunFourth();
            //Console.WriteLine();
            //RunTask2();
            //RunTask3();
        }
    }
}