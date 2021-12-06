using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii._3_razdel
{
    class NeopKoeff
    {
        const double T = 1;
        public static double F(double x)
        {
            return 4 * T * x * x * x * x - 3 * T * T * x * x * x + 6 * T * x - 2 * T * T;
        }
        public static void MainNK()
        {
            double h = 0.1;
            List<double> x = new List<double>();
            List<double> yResT = new List<double>();
            List<double> Px = new List<double>();
            List<double> Qx = new List<double>();
            List<double> Fx = new List<double>();
            for (double i = 0; i < T; i += h)
            {
                x.Add(i);
                yResT.Add(T * i * i * (i - T));
                Px.Add(i * i);
                Qx.Add(i);
                Fx.Add(F(i));
            }
            int n = Px.Count;
            double[] yResM = new double[n];
            double[] E = new double[n];
            yResM[0] = 0;
            yResM[yResT.Count - 1] = 0;

            double[][] matrix = new double[n - 2][];
            double[] b = new double[n - 2];
            for (int i = 0; i < n - 2; i++)
            {
                matrix[i] = new double[n - 2];
                b[i] = Fx[i + 1];
            }
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < n - 2; j++)
                {
                    double DerivSec = (j + 1) * (j * Math.Pow(x[i + 1], j - 1) * (x[i] - T) + 
                        Math.Pow(x[i + 1], j)) + (j + 1) * Math.Pow(x[i], j);
                    double DerivFirst = Px[i + 1] * (j + 1) * Math.Pow(x[i + 1], j) * (x[i + 1] - T) +
                        Math.Pow(x[i + 1], j - 1);
                    double Third = Qx[i + 1] * Math.Pow(x[i + 1], j + 1) * (x[i + 1] - T);
                    matrix[i][j] = DerivSec + DerivFirst + Third;
                }
            }
            double[] resX = MethodGauss(matrix, b, n - 2);
            for (int i = 1; i < n - 1; i++)
            {
                double sum = 0;
                for (int j = 0; j < n - 2; j++)
                {
                    sum += resX[j] * Math.Pow(x[i], j + 1) * (x[i] - T);
                }
                yResM[i] = sum;
            }
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
        public static double[] MethodGauss(double[][] aNow, double[] b, int n)
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
                for (int j = 0; j < n; j++)
                {
                    aRes[i][j] /= mainEl;
                }
                b[i] /= mainEl;
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
        public static void Write(List<double> lst)
        {
            foreach (var item in lst)
            {
                Console.Write("{0:f3}"+ "\t", item);
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
