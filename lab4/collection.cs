using System;
namespace Lab4
    {
    class DiaposonArray
    {
    static double ReadFromKeyboard(string text)
{
    while (true)                        
    {
        Console.WriteLine(text);
        if (double.TryParse(Console.ReadLine(), out double res))
        {
            return res;                
        }
        Console.WriteLine("Неверный ввод");   
    }
}
        private Diaposon[]arr;
        private static int count = 0;
        public DiaposonArray()
        {
            arr = new Diaposon[0];
            count++;
        }
        public DiaposonArray(int size)
        {
            arr = new Diaposon[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                double a = rand.Next(-50,50);
                double b = rand.Next(-50, 50);
                arr[i] = new Diaposon(a,b);

            }
            count++;
        }
        public DiaposonArray(int size, bool keyboard)
        {
            arr = new Diaposon[size];
            for (int i = 0; i < size; i++)
            {
                double a = ReadFromKeyboard("Введите левую границу диапозона");
                double b = ReadFromKeyboard("Введите правую границу диапозона");
                arr[i] = new Diaposon(a,b);
            }
            count ++;
        }
        public void Print()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                    return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i}: ");
                arr[i].print();        // вызываем print() каждого Diaposon
        }
    }
    public Diaposon this[int index]
{
    get
    {
        if (index < 0 || index >= arr.Length)
            throw new ArgumentException("Индекс вне диапазона массива");
        return arr[index];
    }
    set
    {
        if (index < 0 || index >= arr.Length)
            throw new ArgumentException("Индекс вне диапазона массива");
        arr[index] = value;
    }
}
    public static int GetCount() { return count; }
    
    }
    }