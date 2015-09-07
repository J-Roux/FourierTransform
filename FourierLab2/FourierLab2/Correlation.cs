using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab2
{
    class Correlation
    {
        public static List<Complex> CorrelateDFT(List<Complex> X, List<Complex> Y)
        {
            var Cx = FourierLab1.DFT.Direct(X).Select(n => Complex.Conjugate(n)).ToList();
            var Cy = FourierLab1.DFT.Direct(Y);
            return FourierLab1.DFT.Inverse(Enumerable.Range(0, X.Count).Select(n => Cx[n] * Cy[n]).ToList());
        }

        public static List<Complex> Correlate(List<Complex> X, List<Complex> Y)
        {
            return Enumerable.Range(0, X.Count).Select(n => Z(n, X, Y)).ToList();
        }

        private static Complex Z(int k, List<Complex> X, List<Complex> Y)
        {
            Complex sum = 0;
            for(int i = 0; i < X.Count; i++)
            {
                int index = i + k;
                if(index >= X.Count)
                    index -= X.Count;
                sum += X[i] * Y[index];
            }
            return sum / X.Count;
        }
    }
}
