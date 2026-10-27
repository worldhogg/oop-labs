using System;

namespace Lab4
{
    class Program
    {
        static Diaposon FindMax(DiaposonArray collection, int size)
        {
            Diaposon max = collection[0];
            for (int i = 1; i < size; i++)
            {
                if (!collection[i] > !max)
                    max = collection[i];
            }
            return max;
        }

        static void Main()
        {
            Diaposon d1 = new Diaposon(2, 8);
            Diaposon d2 = new Diaposon(10, 20);
            Console.WriteLine("Исходные диапазоны:");
            d1.print();
            d2.print();
            Console.WriteLine();

            Console.WriteLine("Оператор ++ :");
            d1++;
            d1.print();
            Console.WriteLine();

            Console.WriteLine("Оператор ! (длина диапазона):");
            double len = !d2;
            Console.WriteLine($"Длина d2 = {len}");
            Console.WriteLine();

            Console.WriteLine("Оператор + с числом (обе стороны):");
            Diaposon d3 = d2 + 5;
            Diaposon d4 = 5 + d2;
            d3.print();
            d4.print();
            Console.WriteLine();

            Console.WriteLine("Операторы < и > (проверка числа 12 для d2):");
            Console.WriteLine($"12 < d2: {d2 < 12}");
            Console.WriteLine($"12 > d2: {d2 > 12}");
            Console.WriteLine();

            Console.WriteLine("Явное приведение (int):");
            int xPart = (int)d2;
            Console.WriteLine($"(int)d2 = {xPart}");
            Console.WriteLine();

            Console.WriteLine("Неявное приведение (double):");
            double yCoord = d2;
            Console.WriteLine($"double от d2 = {yCoord}");
            Console.WriteLine();

            Console.WriteLine($"Всего создано диапазонов: {Diaposon.getCount()}");
            Console.WriteLine();

            Console.WriteLine("===== ЧАСТЬ 3: КОЛЛЕКЦИЯ =====");
            Console.WriteLine();

            Console.WriteLine("Пустая коллекция:");
            DiaposonArray emptyColl = new DiaposonArray();
            emptyColl.Print();
            Console.WriteLine();

            int size = 5;
            Console.WriteLine($"Случайная коллекция ({size} элементов):");
            DiaposonArray randomColl = new DiaposonArray(size);
            randomColl.Print();
            Console.WriteLine();

            Console.WriteLine("Коллекция с клавиатуры (2 элемента):");
            DiaposonArray keyboardColl = new DiaposonArray(2, true);
            keyboardColl.Print();
            Console.WriteLine();

            Console.WriteLine("Доступ к элементу через индексатор (индекс 0):");
            Console.Write("Элемент [0]: ");
            randomColl[0].print();
            Console.WriteLine();

            Console.WriteLine("Поиск диапазона с максимальной длиной:");
            Diaposon max = FindMax(randomColl, size);
            Console.Write("Максимальный: ");
            max.print();
            Console.WriteLine();

            Console.WriteLine("Попытка обратиться за границы массива (индекс 100):");
            try
            {
                Diaposon bad = randomColl[100];
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Поймано исключение: {ex.Message}");
            }
            Console.WriteLine();

            Console.WriteLine($"Всего создано коллекций: {DiaposonArray.GetCount()}");
        }
    }
}