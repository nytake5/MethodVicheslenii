using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Newton
    {
        //метод для вычисления отдельного значения 
        static double OtdelnVicheslenia(double value, double[] x, double[,] a, int n)
        {
            double sum = a[0, 0];
            for (int i = 1; i < n; i++)
            {
                double pro = 1;
                for (int j = 0; j < i; j++)
                {
                    pro = pro * (value - x[j]);
                }
                sum = sum + pro * a[0, i];
            }
            return sum;
        }
        public static void NewtonM()
        {
            Console.WriteLine("Введите размерность системы:");
            int n = int.Parse(Console.ReadLine());
            double[,] a = new double[n, n];
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
                x[i] = 0;
            for (int i = 0; i < n; i++)
            {
                x[i] = i;
            }
            for (int i = 0; i < n; i++)
            {
                a[i, 0] = Math.Pow(x[i], 3);
            }
            //вычисление таблицы разделенных разностей
            for (int i = 1; i < n; i++)
            {

                for (int j = 0; j < n - i; j++)
                {

                    a[j, i] = (a[j, i - 1] - a[j + 1, i - 1]) / (x[j] - x[i + j]);

                }
            }
            //отображение таблицы разделенных разностей
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0}-ого\t", i + 1);
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {

                    Console.Write(Math.Round(a[i, j], 4) + "\t");

                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите точку: ");
            double value = double.Parse(Console.ReadLine());
            double sum = a[0, 0];
            Console.WriteLine("Значение: " + OtdelnVicheslenia(value, x, a, n));
            Console.ReadLine();
        }
    }
}
