using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Program
    {
        public static double[,] CountInterPolynom(List<double> arrX, List<double> arrF, double e)
        {
            int N = (int)(arrX.Count / e);
            double[,] mass = new double[2, N];   
            mass[0, 0] = arrX[0];
            List<double> tempMas = new List<double>();
            for (int i = 1; i < N; i++)
            {
                mass[0, i] += e;
            }
            for (int i = 0; i < arrX.Count; i++)
            {
                double tempF = 1;
                double tempX = arrX[i] + e;
                for (int j = 0; j < arrX.Count - 1; j++)
                {
                    if (i != j)
                    {
                        tempF *= (tempX - arrX[j]);
                    }
                }
                double tempF2 = arrF[i];
                for (int j = 0; j < arrX.Count; j++)
                {
                    if (i != j)
                    {
                        tempF2 *= (arrX[i] - arrX[j]);
                    }
                }
                for (int j = 0; j < N; j++)
                {
                    if (mass[0, j] == tempX)
                    {
                        mass[1, j] = tempF * tempF2;
                    }
                }
            }
            return mass;
        }
        static void Main()
        {

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
            double e = double.Parse(Console.ReadLine());
            double[,] mass = CountInterPolynom(arrX, arrF, e);
            for (int i = 0; i < mass.GetLength(1); i++)
            {
                Console.Write(mass[0, i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            for (int i = 0; i < mass.GetLength(1); i++)
            {
                Console.Write(mass[1, i]);
                Console.Write(" ");
            }
            Console.ReadLine();
        }
        /* static void Main(string[] args)
         {
             double s = 0;
             string sline;
             string[] vs;
             Console.WriteLine("Введите размерность системы");
             int n = int.Parse(Console.ReadLine());
             double[,] a = new double[n, n];
             double[] b = new double[n];
             double[] x = new double[n];
             for (int i = 0; i < n; i++)
                 x[i] = 0;
             Console.WriteLine("Введите построчно коэффициенты системы");
             for (int i = 0; i < n; i++)
             { 
                 sline = Console.ReadLine();
                 vs = sline.Split(' ');
                 for (int j = 0; j < n; j++)
                 {
                     a[i, j] = double.Parse(vs[j]);
                 }

             }
             Console.WriteLine("Введите свободные коэффициенты");
             sline = Console.ReadLine();
             vs = sline.Split(' ');
             for (int i = 0; i < n; i++)
             {
                 b[i] = double.Parse(vs[i]);
             }

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
         }*/
    }
}
