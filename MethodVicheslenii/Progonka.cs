using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Progonka
    {
        const int N = 4;
        public static void ProgonkaM()
        {
            double[,] A = { 
                {2, 1, 0, 0 },
                {1, 10, -5, 0 },
                {0, 1, -5, 2 },
                {0, 0, 1, 4 } };
            double[] d = new double[] { -5, -18, -40, -27 };
            double[] ans = MethodProgonki(A, d);
            foreach (var item in ans)
            {
                Console.Write(item.ToString() + " ");
            }
        }

        public static double[] MethodProgonki(double[,] A, double[] d)
        {
            double[] a = new double[N];// массив под главной
            for (int i = 1; i < N; i++)
            {
                a[i] = A[i, i - 1];
            }
            double[] c = new double[N];//главная
            for (int i = 0; i < N ; i++)
            {
                c[i] = A[i, i];
            }
            double[] b = new double[N];//над главной
            for (int i = 0; i < N - 1; i++)
            {
                b[i] = A[i, i + 1];
            }
            double[] res = new double[N];
            double m;
            //прямой ход
            for (int i = 1; i < N; i++)
            {
                m = a[i] / c[i - 1];
                c[i] = c[i] - m * b[i - 1];
                d[i] = d[i] - m * d[i - 1];
            }
            //обратный ход
            res[N - 1] = d[N - 1] / c[N - 1];
            for (int i = N - 2; i >= 0; i--)
            {
                res[i] = (d[i] - b[i] * res[i + 1]) / c[i];
            }

            return res;
        }
    }
}
