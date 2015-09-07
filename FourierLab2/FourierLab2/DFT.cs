using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab1
{
    public class DFT
    {

        protected static Complex  W(int N)
        {
            return Complex.Exp(-Complex.ImaginaryOne * 2 * Math.PI / N);
        }

        protected static Complex C(int k, List<Complex> x)
        {
            Complex sum = 0;
            for (int m = 0; m < x.Count; m++)
            {
                sum += x[m] * Complex.Pow(W(x.Count), k * m);
            }
            return sum /= x.Count;
        }

        public static List<Complex> Direct(List<Complex> x)
        {
            return Enumerable.Range(0, x.Count).Select(n =>C(n, x)).ToList();
        }

        protected static Complex X(int m, List<Complex> x)
        {
            Complex sum = 0;
            for (int k = 0; k < x.Count; k++)
            {
                sum += x[k] * Complex.Pow(W(x.Count), -k * m);
            }
            return sum ;
        }        

        public static List<Complex> Inverse(List<Complex> x)
        {
            return Enumerable.Range(0, x.Count).Select(n => X(n, x)).ToList();
        }

    }
}
