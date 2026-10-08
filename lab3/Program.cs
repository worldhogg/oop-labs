using System;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;
namespace Lab3
{
    class Program
    {
        static void OpenMainMenu(string text = "Меню")
        {
            int[,] matrix = null; 
            int [][]jagged = null;
            string line = "";
            Console.WriteLine(text);
            int choice;
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine(@"1.Сформировать двумерный массив
2.Выполнить задание для двумерного массива
3.Сформировать рваный массив
4.Выполнить задание для рваного массива
5.Сформировать строку
6.Выполнить задание для строки
7.Вывести на печать результаты
8.Выход
                ");
                if(int.TryParse(Console.ReadLine(),out int res))
                {
                    choice = res;
                }
                else{
                    Console.WriteLine("Ошибка ввода. Введите еще раз");
                    continue;
                    }
                switch (choice)
                {
                    case 1:
                        matrix = OpenArrMenu();
                        Print(matrix);
                        break;
                    case 2:
                        matrix = FirstTask(matrix);
                        Print(matrix);
                        break; 
                    case 3:
                        jagged = OpenJarrMenu();
                        Print(jagged);
                        break;
                    case 4:
                        jagged = SecondTask(jagged);
                        Print(jagged);
                        break;
                    case 5:
                        line = OpenStringMenu();
                        Console.WriteLine($"Строка {line}");
                        break;
                    case 6:
                        if (ThirdTask(line,out string shortest))
                        {
                            Console.WriteLine($"Самый коротки идентификатор {shortest}");
                        }
                        else
                        {
                            Console.WriteLine("Идентификаторов не найдено");
                        }
                        break;
                    case 7:
                        Print(matrix);
                        Print(jagged);
                        break;
                    case 8:
                        keepRunning = false;
                        Console.WriteLine("Программа завершена. До свидания");
                        break;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;
                }
            }
            
        }
        static int [,] OpenArrMenu(string text = "Меню двумерных массивов")
        {
            int choice;
            while (true)
            {
                Console.WriteLine(text);
                Console.WriteLine(@"1.Ввести массив вручную
2.Ввести с помощью датчика случайных чисел
3.Выход");
                if(int.TryParse(Console.ReadLine(),out int res))
                {
                    choice = res;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите еще раз");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        return KeyboardArr();
                    case 2:
                        return RandomizeArr();
                    case 3:
                        Console.WriteLine("Выход из создания массива");
                        return null;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;

                }
            }
        }
    static int[][] OpenJarrMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Меню рваных массивов");
                Console.WriteLine(@"1.Создание рваного массива вручную
2.Создание рваного массива случайно
3.Выход из создания рваного массива");
                if (int.TryParse(Console.ReadLine(),out int res))
                {
                    choice = res;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите еще раз");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        return KeyboardJarr();
                    case 2:
                        return RandomizeJarr();
                    case 3:
                        return null;
                    default:
                        Console.WriteLine("Нет такой команды");
                        break;

                }
            }
        }
    static string OpenStringMenu()
        {
            int choice;
            while (true)
            {
                Console.WriteLine("Меню строк");
                Console.WriteLine(@"1.Создание строки вручную
2.Создание строки из заранее сформированного массива
3. Выход из меню строк");
                if (int.TryParse(Console.ReadLine(),out int res))
                {
                    choice = res;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода , попробуйте еще");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        return KeyboardString();
                    case 2:
                        return TestString();
                    case 3:
                        return "";
                    default:
                        Console.WriteLine("Ошибка нет такой команды");
                        break;
                }
            }
        }
    static  int ReadIntSafe(string promt)
        {
            int digit = 0;
            while (true)
            {
                Console.WriteLine(promt);
                try
                {
                digit = int.Parse(Console.ReadLine());
                break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено не число");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Слищком большое число");
                }
            }
            return digit;
        }
        static int ReadIntPositive(string promt)
        {
            int digit = 0;
            while (true)
            {
            digit = ReadIntSafe(promt);
            if (digit <= 0)
                {
                    Console.WriteLine("Введите положительное число больше нуля");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return digit;
        }
    static int [,] KeyboardArr()
        {
            int rows = ReadIntPositive("Введите количество строк");
            int colls = ReadIntPositive("Введите количество столбцов");
            int [,] matrix = new int [rows,colls];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colls; j++)
                {
                    matrix[i,j] = ReadIntSafe($"Введите элемент [{i},{j}]");
                }
            }
            Console.WriteLine($"Создана матрица {rows} на {colls}");
            Console.WriteLine();
            return matrix;
        }
    static int [,] RandomizeArr()
        {
            Random rand = new Random();
            int rows = ReadIntPositive("Введите количество строк");
            int colls = ReadIntPositive("Введите количество стобцов");
            int [,]matrix = new int[rows,colls];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0 ; j < colls; j++)
                {
                    matrix[i,j] = rand.Next(1,100);
                }
            }
            Console.WriteLine($"Создана матрица {rows} на {colls}");
            Console.WriteLine();
            return matrix;

        }
        static void Print(int[,]matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Двумерный массив пуст");
                return;
            }
            Console.WriteLine("Вывод массива");
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + "\t");
                }
                Console.WriteLine();
            }
            
        }
        static int[][] KeyboardJarr()
        {
            int rows = ReadIntPositive("Введите количество строк");
            int [][]matrix = new int [rows][];
            for (int i = 0; i < rows; i++)
            {
                int colls = ReadIntPositive($"Введите количество столбцов для строки {i}");
                matrix[i] = new int[colls];
                for (int j = 0; j < colls; j++)
                {
                    matrix[i][j] = ReadIntSafe($"Введите элемент [{i},{j}]");
                }
            }
            Console.WriteLine("Создан рваный массив");
            Console.WriteLine();
            return matrix;
        }
        static int[][] RandomizeJarr()
        {
            Random rand = new Random();
            int rows = ReadIntPositive("Введите количество строк");
            int [][]matrix = new int[rows][];
            for (int i = 0 ; i < rows; i++)
            {
                int colls = ReadIntPositive($"Введите количество столбцов для строки {i}");
                matrix[i] = new int[colls];
                for (int j = 0; j < colls; j++)
                {
                    matrix[i][j] = rand.Next(1,100);
                }
            }
            Console.WriteLine("Создан рваный массив");
            Console.WriteLine();
            return matrix;
            
        }
        static void Print(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Сначала создайте рваный массив");
                return;
            }
                Console.WriteLine("Вывод рваного массива");
                Console.WriteLine();
                for (int i = 0; i < matrix.Length; i++)
            {
                foreach(int x in matrix[i])
                {
                    Console.Write(x+"\t");
                }
                Console.WriteLine();
            }
        }
        static string KeyboardString()
        {
            Console.WriteLine("Введите строку");
            return Console.ReadLine();
        }
        static string TestString()
        {
            int index = ReadIntSafe("Введите индекс от 0 до 4");
            string[] tests = {
                "static void PrintUpper info12346: WriteLine info, 1234info.",
                "public class MyProgram int x_value = 10 count5 name.",
                "_temp data123 while if 99bad else sum result.",
                "a bb ccc dddd result_1 2start method Name.",
                "В лесу родилась елочка. Зимой была."
            };
            if (index < 0 || index >= tests.Length)
            {
                Console.WriteLine("Нет такой строки");
                return "";
            }
            return tests[index];
        }
        static int[,] FirstTask(int[,]matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Сначала создайте массив");
                return matrix;
            }
            int oldRows = matrix.GetLength(0);
            int oldColls = matrix.GetLength(1);
            int evenCount = 0;
            for (int i = 0; i < oldRows; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    evenCount++;
                }
            }
            int newRows = oldRows + evenCount;
            int[,] matrix2 = new int [newRows,oldColls];
            int newIndex = 0;
            for (int i = 0; i < oldRows; i++)
            {
                for (int j = 0; j < oldColls; j++)
                {
                    matrix2[newIndex,j] = matrix[i,j];//можно было сделать через Array.Copy(matrix,i * oldColls,matrix2,newIndex * oldColls,oldColls)
                }
                newIndex ++;
                if ((i + 1) % 2 == 0)
                {
                    for (int j = 0; j < oldColls; j++)
                    {
                        matrix2[newIndex,j] = 0;
                    }
                    newIndex++;
                }
            }
            return matrix2;


        }
        static int[][] SecondTask(int[][]matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                Console.WriteLine("Сначала создайте рваный массив");
                return matrix;
            }
            int newRows = matrix.Length + 1;              
            int[][] matrix2 = new int[newRows][];        

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix2[i] = matrix[i];      //поверхностное копирование              
            }

            int len = ReadIntPositive("Введите длину новой строки");  
            matrix2[matrix.Length] = new int[len];         
            return matrix2;
        }
        static bool IsIdentifier(string word)
        {
            return Regex.IsMatch(word, @"^[A-Za-z_][A-Za-z0-9_]*$");
        }

        static bool ThirdTask(string line, out string res)
        {
            res = ""; 
            
            if (string.IsNullOrEmpty(line))
            {
                return false;
            }
            else
            {
                char[] separators = { ' ', ',', ';', ':', '.', '!', '?', '=', '(', ')', '[', ']' };
                string[] words = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                string shortestId = null; 

                foreach (string word in words)
                {
                    if (IsIdentifier(word))
                    {
                        if (shortestId == null || word.Length < shortestId.Length)
                        {
                            shortestId = word; 
                        }
                    }
                }

                if (shortestId != null)
                {
                    res = shortestId; 
                    return true;      
                }
                
                return false; 
            }
        }
        static void Main()
        {
            OpenMainMenu();
        }
    }
}