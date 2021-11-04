using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Program
    {
        static void Main()
        {
            //ReshenieSlau();
            //MethodLagranga();
            Newton();

            Console.ReadLine();
        } 
        public static void ReshenieSlau()
        {
            double s = 0;
            Console.WriteLine("Введите размерность системы");
            int n = int.Parse(Console.ReadLine());
            double[] x = new double[n];
            double[] b = new double[n];
            double[,] a = new double[n, n];
            for (int i = 0; i < n; i++)
                x[i] = 0;
            Console.WriteLine("Введите  коэффициенты системы");
            string line;
            string[] vs;
            for (int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                vs = line.Split(' ');
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = double.Parse(vs[j]);
                }
            }
            Console.WriteLine("Введите свободные коэффициенты");
            line = Console.ReadLine();
            vs = line.Split(' ');
            for (int i = 0; i < n; i++)
                b[i] = double.Parse(vs[i]);

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + a[k, j] * x[j];
                x[k] = (b[k] - s) / a[k, k];
            }
            Console.WriteLine("Система имеет следующие корни");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine("А[" + i + "]= " + x[i]);
            }
            Console.ReadLine();
        }
        public static void MethodLagranga()
        {
            double xInput = double.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] vs = s.Split(' ');

            List<double> arrX = new List<double>();
            List<double> arrF = new List<double>();

            foreach (var item in vs)
            {
                arrX.Add(double.Parse(item));
            }
            s = Console.ReadLine();
            vs = s.Split(' ');

            foreach (var item in vs)
            {
                arrF.Add(double.Parse(item));
            }

            double ans = 0;
            double ch = 1;
            double zn = 1;
            double temp;
            for (int k = 0; k < arrX.Count; k++)
            {
                for (int j = 0; j < arrX.Count; j++)
                {
                    if (k != j)
                    {
                        ch *= xInput - arrX[j];
                        zn *= arrX[k] - arrX[j];
                    }
                }
                temp = arrF[k] * (ch / zn);
                ch = 1;
                zn = 1;
                ans += temp;
            }

            Console.WriteLine(ans);
            
        }

       
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
        public static void Newton()
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

        public static void Splayni()
        {

        }

    }
}
