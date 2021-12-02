using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii._3_razdel
{
    class Eiler
    {
        const int n = 10;
        const double v = 15;
        
        public static void MainEiler()
        {
            EilerOneM();
            Console.WriteLine();
            EilerTwoM();
            Console.WriteLine();
            PrediktKorrektM();
        }
        public static void EilerOneM()
        {
            #region блок объявления начальных параметров
            double h = 0.01;
            double[] x = new double[n];
            double[] yResM = new double[n];
            double[] yResT = new double[n];
            double[] E = new double[n];
            yResM[0] = (v + h) * h * h;
            double x0 = 0;
            for (int i = 0; i < n; i++)
            {
                x0 += h;
                x[i] = x0;
                yResT[i] = x0 * x0 * (x0 + v);
            }
            #endregion
            for (int i = 1; i < n; i++)
            {
                yResM[i] = yResM[i - 1] + h * Der(x[i - 1], yResM[i - 1]);
            }
            for (int i = 0; i < n; i++)
            {
                E[i] = Math.Abs(yResM[i] - yResT[i]);
            }
            #region вывод матрицы
            Console.WriteLine("метод Эйлера:");
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
        public static void EilerTwoM()
        {
            #region блок объявления начальных параметров
            double h = 0.01;
            double[] x = new double[n];
            double[] yResM = new double[n];
            double[] yResT = new double[n];
            double[] E = new double[n];
            yResM[0] = (v + h) * h * h;
            double x0 = 0;
            for (int i = 0; i < n; i++)
            {
                x0 += h;
                x[i] = x0;
                yResT[i] = x0 * x0 * (x0 + v);
            }
            #endregion
            for (int i = 1; i < n; i++)
            {
                yResM[i] = yResM[i - 1] + h * Der(x[i - 1] + h/2, yResM[i - 1]);
            }
            for (int i = 0; i < n; i++)
            {
                E[i] = Math.Abs(yResM[i] - yResT[i]);
            }
            #region вывод матрицы
            Console.WriteLine("Усовершенствованный метод Эйлера:");
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
        public static void PrediktKorrektM()
        {
            #region блок объявления начальных параметров
            double h = 0.01;
            double[] x = new double[n];
            double[] yResM = new double[n];
            double[] yResT = new double[n];
            double[] E = new double[n];
            yResM[0] = (v + h) * h * h;
            double x0 = 0;
            for (int i = 0; i < n; i++)
            {
                x0 += h;
                x[i] = x0;
                yResT[i] = x0 * x0 * (x0 + v);
            }
            #endregion
            for (int i = 1; i < n; i++)
            {
                yResM[i] = yResM[i - 1] + h * Der(x[i - 1], yResM[i - 1]);
                yResM[i] = yResM[i - 1] + (h/2) * Der(x[i - 1], yResM[i - 1]+ yResM[i]);
            }
            for (int i = 0; i < n; i++)
            {
                E[i] = Math.Abs(yResM[i] - yResT[i]);
            }
            #region вывод матрицы
            Console.WriteLine("метод Предиктора-Корректора:");
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

        public static double Der(double x, double y)
        {
            return 2 * v * x + v * x * x - y;
        }
        public static void Write(double[] mas)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0:f3} ", mas[i]);
            }
            Console.WriteLine();
        }
    }
}
