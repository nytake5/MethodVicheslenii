using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodVicheslenii
{
    class Lagrang
    {
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
    }
}
