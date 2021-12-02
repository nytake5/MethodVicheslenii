using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Gauss
    {
        static int n = 5;
        static int num = 15;
       
        static double opredelitel = 1;
        public static void GaussM()
        {   
            double[][] a = new double[n][];//
            double[] matr = new double[n];//
            double[] b = new double[n];// получается умножением строк A на вектор столбец (v, v+1,...)

            for (int i = 0; i < n; i++)
            {
                a[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        a[i][j] = num;
                        matr[i] = num;
                    }
                    else
                    {
                        a[i][j] = num * 0.01;
                    }
                }
                num++;
            }
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += a[i][j] * matr[j];
                }
                b[i] = sum;
            }

            Write(a);
            Write(b);
            Write(MethodGauss(a, b, 1));
            ReverseMatrix(a);
        }

        public static void Write(double[][] mas)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(mas[i][j] + " ");
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
        public static double[] MethodGauss(double[][] aNow, double[] b, int f)
        {
            double[][] aRes = new double[n][];
            for (int i = 0; i < n; i++)// перекопируем значения, дабы не менять исходный массив
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
                    int index = FindMainInRows(aRes, i);
                    if (index == -1)
                    {
                        break;
                    }
                    Swap(aRes, i, index);//если элемент на главной диагонали
                    double tmp = b[i];// равен нулю, то тогла поменяем строку 
                    b[i] = b[index];//с этим элементом местами со строкой с максимальным
                    b[index] = tmp;// элементом в текущем столбце
                }
                double mainEl = aRes[i][i];
                opredelitel *= mainEl;
                for (int j = 0; j < n; j++)
                {
                    aRes[i][j] /= mainEl;
                }
                b[i] /= mainEl;
                NextInter(aRes, i, b);
            }
            if (f == 1)
            {
                opredelitel *= Math.Pow(-1, y);
                Console.WriteLine("Определитель = " + (opredelitel));
            }
            double[] x = new double[n];
            //обратный ход
            for (int i = n - 1;  i >= 0; i--)
            {
                x[i] = b[i];
                for (int j = i + 1; j < n; j++)
                {
                    x[i] -= x[j] * aRes[i][j];
                }
            }
            return x;
        }

        private static void NextInter(double[][] aRes, int i, double[] b)
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

        public static int FindMainInRows(double[][] aNow, int index)
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

        public static void ReverseMatrix(double[][] a)
        {
            double[][] aReverse = new double[n][];
            double[] b = new double[n];
            double[][] e = new double[n][];
            for (int i = 0; i < n; i++)
            {
                b[i] = 0;
                aReverse[i] = new double[n];
                e[i] = new double[n];
            }
            double[] helper = new double[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = 1;
                helper = MethodGauss(a, b, 0);
                for (int j = 0; j < n; j++)
                {
                    aReverse[j][i] = helper[j];
                }
                b[i] = 0;
            }
            Console.WriteLine("Проверка обратной матрицы ");
            double sum;
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += a[i][j] * aReverse[j][i];
                }
                e[i][k] = sum;
                if (k < 8)
                    k++;
                else
                    k = 0;
            }
            Write(e);
        }
    }
}
