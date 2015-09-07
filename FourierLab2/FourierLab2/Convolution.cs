using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab2
{
    class Convolution 
    {
        public static List<Complex> Convolute(List<Complex> X, List<Complex> Y)
        {
            return Enumerable.Range(0, X.Count).Select(n => Z(n, X, Y)).ToList();
        }

        private static Complex Z(int k, List<Complex> X, List<Complex> Y)
        {
            Complex sum = 0;
            for (int i = 0; i < X.Count; i++)
            {
                int index = k - i;
                if(index < 0)
                    index += X.Count;
                sum += X[i] * Y[index]; 
            }
            return sum / X.Count;
        }

        public static List<Complex> ConvoluteDFT(List<Complex> X, List<Complex> Y)
        {
            var Cx = FourierLab1.DFT.Direct(X);
            var Cy = FourierLab1.DFT.Direct(Y);
            return FourierLab1.DFT.Inverse(Enumerable.Range(0 , X.Count).Select(n => Cx[n] * Cy[n]).ToList());
        }
    }
}
