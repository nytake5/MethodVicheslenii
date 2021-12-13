using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii._4_razdel
{
    class FredGolm
    {
        const double V = 15;
        const int a = 0;
         const int b = 1;
        public static double F(double x)
        {
            return V * ((4.0 / 3) * x + 0.25 * x * x + 0.2 * x * x * x);
        }
        public static double FuncAx(double x, double t)
        {
            return x * t + x * x * t * t + Math.Pow(x, 3) * Math.Pow(t, 3);
        }
        public static void MainNK()
        {
            double h = 0.01;
            int n = 10;
            double[] x = new double[n];
            double[] yResT = new double[n];
            double[] Fx = new double[n];
            double opredelitel = 1;
            int temp = 0;
            for (double i = a; i <= b; i += h)
            {
                if (temp < n)
                {
                    x[temp]= i;
                    yResT[temp]= V * i;
                    Fx[temp]=F(i);
                    temp++;
                }
                else
                {
                    break;
                }
            }
            double[] YResM = new double[n];
            double[][] matrix = new double[n][];
            double[] d = new double[n];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[n];
                d[i] = Fx[i];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = h * FuncAx(x[i], x[j]);
                    if (i == j)
                    {
                        matrix[i][i] += 1;
                    }
                }
            }
            double[] yResM = MethodGauss(matrix, d, n, ref opredelitel);
            double[] E = new double[n];
            for (int i = 0; i < n; i++)
            {
                E[i] = Math.Abs(yResM[i] - yResT[i]);
            }
            #region вывод матрицы
            Console.WriteLine("Разностный метод:");
            Console.Write("x:\t");
            Write(x);
            Console.Write("Ymet:\t");
            Write(yResM);
            Console.Write("Ytoch:\t");
            Write(yResT);
            Console.Write("e:\t");
            Write(E);
            #endregion
        }
        public static void Write(List<double> lst)
        {
            foreach (var item in lst)
            {
                Console.Write("{0:f3}" + "\t", item);
            }
            Console.WriteLine();
        }
        public static void Write(double[] mas)
        {
            foreach (var item in mas)
            {
                Console.Write("{0:f3}" + "\t", item);
            }
            Console.WriteLine();
        }
        public static double[] MethodGauss(double[][] aNow, double[] b, int n, ref double opredelitel)
        {
            double[][] aRes = new double[n][];
            for (int i = 0; i < n; i++)
            {
                aRes[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    aRes[i][j] = aNow[i][j];
                }
            }
            int y = 0;
            for (int i = 0; i < n; i++)
            {
                if (aRes[i][i] == 0)
                {
                    y++;
                    int index = FindMainInRows(aRes, i, n);
                    if (index == -1)
                    {
                        break;
                    }
                    Swap(aRes, i, index);
                    double tmp = b[i];
                    b[i] = b[index];
                    b[index] = tmp;
                }
                double mainEl = aRes[i][i];
                opredelitel *= mainEl;
                for (int j = 0; j < n; j++)
                {
                    aRes[i][j] /= mainEl;
                }
                b[i] /= mainEl;
                opredelitel *= Math.Pow(-1, y);
                NextInter(aRes, i, b, n);
            }
            double[] x = new double[n];
            //обратный ход
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= x[j] * aRes[i][j];
                }
            }
            return x;
        }
        private static void NextInter(double[][] aRes, int i, double[] b, int n)
        {
            for (int l = i + 1; l < n; l++)
            {
                double d = aRes[l][i];
                for (int j = i; j < n; j++)
                {
                    aRes[l][j] = aRes[l][j] - aRes[i][j] * d;
                }
                b[l] = b[l] - b[i] * d;
            }
        }

        public static int FindMainInRows(double[][] aNow, int index, int n)
        {
            if (index + 1 < n)
            {
                int indexMax = index + 1;
                double maxElementAbs = Math.Abs(aNow[indexMax][index]);
                for (int j = index + 1; j < n; j++)
                {
                    if (Math.Abs(aNow[j][index]) > maxElementAbs)
                    {
                        maxElementAbs = Math.Abs(aNow[j][index]);
                        indexMax = j;
                    }
                }
                return indexMax;
            }
            else
                return -1;
        }

        public static void Swap(double[][] aNow, int i, int j)
        {
            double[] temp = aNow[i];
            aNow[i] = aNow[j];
            aNow[j] = temp;
        }
    }
}
