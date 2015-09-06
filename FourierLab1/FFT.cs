using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab1
{
    class FFT
    {
        public static List<Complex> DecimationInTime(List<Complex> x)
        {
            if (x.Count == 1)
            {
                return x;
            }
            var Wn = Complex.Exp(2 * Math.PI * Complex.ImaginaryOne / x.Count);
            Complex w = 1;
            var a1 = x.Where((n, i) => i % 2 == 0).ToList();
            var a2 = x.Where((n, i) => i % 2 != 0).ToList();
            var b1 = DecimationInTime(a1);
            var b2 = DecimationInTime(a2);
            var y = new List<Complex>(new Complex[x.Count]);
            for (int i = 0; i < x.Count / 2; i++)
            {
                y[i] = b1[i] + b2[i] * w;
                y[i + x.Count / 2] = b1[i] - b2[i] * w;
                w = w * Wn;
            }
            return y;
        }

        public static List<Complex> DecimationInFrequency(List<Complex> x)
        {
            var result = Compute(x);
            result.Reverse();
            return Sort(result, (int)Math.Log(result.Count, 2));
        }

        private static List<Complex> Compute(List<Complex> x)
        {
            if (x.Count == 1)
                return x;
            var Wn = Complex.Exp(2 * Math.PI * Complex.ImaginaryOne / x.Count);
            Complex w = 1;
            var b = new List<Complex>();
            var c = new List<Complex>();
            for (int i = 0; i < x.Count / 2; i++)
            {
                b.Add(x[i] + x[i + x.Count / 2]);
                c.Add((x[i] - x[i + x.Count / 2]) * w);
                w = w * Wn;
            }

            var result = Compute(b);
            result.AddRange(Compute(c));
            return result;
        }

        private static List<Complex> Sort(List<Complex> x, int N)
        {
            if (N == 1)
                return x;
            var b = x.Where((n, i) => i % 2 == 0).ToList();
            var c = x.Where((n, i) => i % 2 != 0).ToList();
            var result = Sort(b, --N);
            var result1 = Sort(c, N);
            result.AddRange(result1);
            return result;
        }

    }
}
