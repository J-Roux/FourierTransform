using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FourierLab3
{
    class FWT
    {

        private int N;

        public FWT(int N)
        {
            this.N = N;
        }

        public List<double> Transform(List<double> x)
        {
            if (x.Count == 1)
                return x.Select(n => n /N).ToList();
            var b = new List<double>();
            var c = new List<double>();
            for (int i = 0; i < x.Count / 2; i++)
            {
                b.Add(x[i] + x[i + x.Count / 2]);
                c.Add((x[i] - x[i + x.Count / 2]));
            }
            var result = Transform(b);
            result.AddRange(Transform(c));
            return result;
        }

        public static List<double> Sort(List<double> x, int N)
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
