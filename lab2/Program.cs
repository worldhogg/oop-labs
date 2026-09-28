using System;

namespace Lab2
{
    class Program
    {
        private static void Calculate(int n, double a, double b, int k)
        {
            for (double x = a; x <= b + 0.000001; x += ((b - a) / k))
            {
                double SN = 0;
                for (int i = 0; i <= n; i++)
                {
                    SN += Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / (2 * i + 1);
                }

                double SE = 0;
                int count = 0;
                double currentItem;
                do
                {
                    currentItem = Math.Pow(-1, count) * Math.Pow(x, 2 * count + 1) / (2 * count + 1);
                    if (Math.Abs(currentItem) >= 0.0001)
                    {
                        SE += currentItem;
                    }
                    count++;
                }
                while (Math.Abs(currentItem) >= 0.0001);

                double Y = Math.Atan(x);

                Console.WriteLine($"X={x:F2}  SN={SN:F5}  SE={SE:F5}  Y={Y:F5}");
            }
        }

        static void Main()
        {
            Console.WriteLine("Вычисление функции arctg(x)");
            Calculate(40, 0.1, 1.0, 9);
        }
    }
}