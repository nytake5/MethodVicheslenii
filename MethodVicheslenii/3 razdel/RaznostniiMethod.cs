using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodVicheslenii;

namespace MethodVicheslenii._3_razdel
{
    public class RaznostniiMethod
    {
        const double T = 2;
        public static double F(double x)
        {
            return 4 * T * x * x * x * x - 3 * T * T * x * x * x + 6 * T * x - 2 * T * T;
        }
        public static void MainRz()
        {
            #region подготовка данных для разностного метода
            double h = 0.25;
            List<double> x = new List<double>();
            List<double> yResT = new List<double>();
            List<double> Px = new List<double>();
            List<double> Qx = new List<double>();
            List<double> Fx = new List<double>();
            for (double i = 0; i < T; i+=h)
            {
                x.Add(i);
                yResT.Add(T*i*i*(i - T));
                Px.Add(i*i);
                Qx.Add(i);
                Fx.Add(F(i));
            }
            double[] yResM = new double[yResT.Count];
            double[] E = new double[yResT.Count];
            yResM[0] = 0;
            yResM[yResT.Count - 1] = 0;
            int n = Px.Count - 2;
            #endregion
            #region подготовка массивов для прогонки
            double[] a = new double[n];
            double[] b = new double[n];
            double[] c = new double[n];
            double[] d = new double[n];
            a[0] = 0;
            c[n - 1] = 0;
            for (int i = 1; i < n; i++)// массив под главной
            {
                a[i] = 1 / (h * h) - Px[i + 1] / (2 * h);
            }
            for (int i = 0; i < n; i++)//главная
            {
                b[i] = 2 / (h * h) - Qx[i + 1];
                d[i] = Fx[i + 1];
            }
            for (int i = 0; i < n - 1; i++)//над главной
            {
                c[i] = 1 / (h * h) + Px[i + 1] / (2 * h);
            }
            #endregion
            double[] res = LocalProgonka(a, b, c, d, n);
            for (int i = 1; i < n + 1; i++)
            {
                yResM[i] = res[i - 1];
            }
            for (int i = 0; i < n + 2; i++)
            {
                E[i] = (yResM[i] - yResT[i]);
            }
            #region вывод матрицы
            Console.WriteLine("Разностный метод:");
            Console.Write("x: ");
            Write(x);
            Console.Write("Ymet: ");
            Write(yResM);
            Console.Write("Ytoch: ");
            Write(yResT);
            Console.Write("e: ");
            Write(E);
            #endregion
        }
        public static double[] LocalProgonka(double[] a, double[] b, double[] c, double[] d, int n)
        {
            double m;
            double[] res = new double[n];
            for (int i = 1; i < n; i++)
            {
                m = a[i] / c[i - 1];
                c[i] = c[i] - m * b[i - 1];
                d[i] = d[i] - m * d[i - 1];
            }
            //обратный ход
            res[n - 1] = d[n - 1] / c[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                res[i] = (d[i] - b[i] * res[i + 1]) / c[i];
            }

            return res;
        }
        public static void Write(List<double> lst)
        {
            foreach (var item in lst)
            {
                Console.Write("{0:f3} ", item);
            }
            Console.WriteLine();
        }
        public static void Write(double[] mas)
        {
            foreach (var item in mas)
            {
                Console.Write("{0:f3} ", item);
            }
            Console.WriteLine();
        }
    }
}
