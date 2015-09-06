using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab1
{
    static class SequenceGen
    {
        public static List<Complex> Generate(int N, double discrete, Func<Complex, Complex> func)
        {
            return Enumerable.Range(0, N).Select(n => func(discrete * n)).ToList();
        }
    }
}
