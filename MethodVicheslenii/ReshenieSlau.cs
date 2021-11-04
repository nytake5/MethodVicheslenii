using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class ReshenieSlau
    {
        public static void ReshenieSlauM()
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
    }
}
