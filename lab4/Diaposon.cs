using System;
using System.Collections.Specialized;
using System.Numerics;
namespace Lab4
{
    class Diaposon
    {
        private double x;
        private double y;
        private static int count = 0;
        public Diaposon()
        {
            x = 0.0;
            y = 0.0;
            count ++;
        }
        public Diaposon(double x, double y)
        {

            if (x > y)
            {
                this.x = y;
                this.y = x;
            }
            else{
                this.x = x;
                this.y = y;
            }
            count++;
        }
        public double X
        {
            get{return x;}
            set
            {
                if (value > y)
                {
                    throw new ArgumentException("Начало диапозона не должно быть дальше конца!");
                }
                x = value;
            }
        }
        public double Y
        {
            get{return y;}
            set
            {
                if (value < x)
                {
                    throw new ArgumentException("Конец диапозона не должен быть раньше начала!");
                }
                y = value;
            }
        }
        public void print()
        {
            Console.WriteLine($"Диапозон [{x},{y}]");
        }
        public static int getCount()
        {
            return count;
        }
        public bool checkDiaposon(double target)
        {
            if (target <= y && target >= x)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool checkDiaposon(Diaposon d, double target)
        {
            return d.X <= target && d.Y >= target;
        }
        public static Diaposon operator ++(Diaposon d)
        {
            return new Diaposon(d.X + 1, d.Y + 1);
        }
        public static double operator !(Diaposon d)
        {
            return d.Y - d.X;
        }
        public static Diaposon operator +(Diaposon d, int k)
        {
            return new Diaposon(d.X + k, d.Y + k);
        }
        public static Diaposon operator +(int k,Diaposon d)
        {
            return new Diaposon(d.X + k, d.Y + k);
        }
        public static bool operator < (Diaposon d, int k)
        {
            return k >= d.X && k <= d.Y;
        }
        public static bool operator > (Diaposon d, int k)
        {
            return !(k >= d.X && k <= d.Y);
        }
        public static explicit operator int(Diaposon d)
        {
            return (int)d.X;
        }
        public static implicit operator double(Diaposon d)
        {
            return d.Y;
        }
    }
}