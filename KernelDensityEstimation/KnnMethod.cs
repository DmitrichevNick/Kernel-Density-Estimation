using System;
using System.Collections.Generic;
using System.Linq;

namespace KernelDensityEstimation
{
    // ReSharper disable once InconsistentNaming
    public class KnnMethod
    {
        private readonly int _elementsNumber;
        private readonly int _k;
        private readonly IKernel _kernel;
        private readonly double[] _u;
        private readonly double[] _w;

        public KnnMethod(int kernelType, double[] u, double[] w, int k)
        {
            _u = new double[_elementsNumber];
            _w = new double[_elementsNumber];
            _elementsNumber = u.Length;
            var list = new List<Tuple<double, double>>();
            for (var i = 0; i < _elementsNumber; ++i)
                list.Add(new Tuple<double, double>(u[i], w[i]));
            list = (from element in list orderby element.Item1 select element).ToList();
            _u = list.Select(item => item.Item1).ToArray();
            _w = list.Select(item => item.Item2).ToArray();

            _k = k;
            _kernel = KernelFactory.Create(kernelType);
        }

        private double FindH(double x)
        {
            var uu = (_u.Clone() as double[]).ToList();
            uu.Add(x);
            uu.Sort();
            var index = uu.IndexOf(x);
            var pos = 0;

            if (index > 0 && index < _elementsNumber)
                pos = Math.Abs(uu.ElementAt(index - 1) - x) < Math.Abs(uu.ElementAt(index + 1) - x) ? index - 1 : index;
            else if (index == 00)
                pos = 0;
            else if (index == _elementsNumber)
                pos = _elementsNumber - 1;

            if (pos >= _k / 2 && pos < _elementsNumber - _k / 2)
                return _u[pos + _k / 2] - _u[pos - _k / 2];
            if (pos < _k / 2)
                return _u[pos + _k / 2] - _u[0];
            if (pos >= _elementsNumber - _k / 2)
                return _u[_elementsNumber - 1] - _u[pos - _k / 2];

            return 0;
        }

       
        private double S1(double x)
        {
            var result = 0.0;
            var h = FindH(x);
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / h * _kernel.Calculate((_u[i] - x) / h);
            return result / _elementsNumber;
        }

        private double S2(double x)
        {
            var result = 0.0;
            var h = FindH(x);
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / h * _w[i] * _kernel.Calculate((_u[i] - x) / h);
            return result / _elementsNumber;
        }

        public double F(double x)
        {
            var s1 = S1(x);
            if (s1 == 0.0) return 0.0;
            return S2(x) / s1;
        }
    }
}