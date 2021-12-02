using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class SimpleIteration
    {
        static int n = 5;
        static int num = 15;
        public static void SimpleIterationM()
        {
            double[,] a = new double[n,n];//
            double[] matr = new double[n];//
            double[] b = new double[n];// получается умножением строк A на вектор столбец (v, v+1,...)

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        a[i,j] = num;
                        matr[i] = num;
                    }
                    else
                    {
                        a[i,j] = num * 0.01;
                    }
                }
                num++;
            }
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += a[i,j] * matr[j];
                }
                b[i] = sum;
            }
            Write(a);
            Write(b);
            Write(SimpleIterationMethod(a, b));
        }

        public static double[] SimpleIterationMethod(double[,] A, double[] b)
        {
            int I = 50;
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                x[i] = 0;
            }
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = A[i, i];
            }
            double[,] R = new double[n,n]; 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        R[i,j] = 0;
                    }
                    else
                    {
                        R[i, j] = A[i, j];
                    }
                }
                
            }
            //скалярное произведение матрицы R на вектор d 
            for (int k = 0; k < I; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        x[i] += R[i, j] * d[j]; 
                    }
                    x[i] = b[i] - x[i];
                    x[i] /= d[i];
                }
            }
            return x;
        }

        public static void Write(double[,] mas)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void Write(double[] mas)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(mas[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
