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
            var dict = new SortedDictionary<double,double>();
            for(var i =0;i<_elementsNumber;++i)
                dict.Add(u[i],w[i]);
            for (var i = 0; i < _elementsNumber; ++i)
            {
                _u[i] = dict.ElementAt(i).Key;
                _w[i] = dict.ElementAt(i).Value;
            }

            _k = k;
            _kernel = KernelFactory.Create(kernelType);
        }

        private double V1(double x)
        {
            var result = 0.0;
            for (var j = 0; j < _elementsNumber; ++j)
            {
                var s1 = 0.0;
                var s2 = 0.0;
                foreach (var element in _u)
                {
                    s1 += 1 / _k * _kernel.Calculate((element - x) / _k);
                    s2 += 1 / _k * _kernel.Calculate((element - _u[j]) / _k);
                }

                if (s2 != 0.0) result += 1 / _k * _kernel.Calculate((_u[j] - x) / _k) * s1 / s2;
            }

            return result / _elementsNumber;
        }

        private double V2(double x)
        {
            var result = 0.0;
            for (var j = 0; j < _elementsNumber; ++j)
            {
                var s1 = 0.0;
                var s2 = 0.0;
                foreach (var element in _u)
                {
                    s1 += 1 / _k * _w[j] * _kernel.Calculate((element - x) / _k);
                    s2 += 1 / _k * _w[j] * _kernel.Calculate((element - _u[j]) / _k);
                }

                if (s2 != 0.0) result += 1 / _k * _w[j] * _kernel.Calculate((_u[j] - x) / _k) * s1 / s2;
            }

            return result / _elementsNumber;
        }

        private double S1(double x)
        {
            var result = 0.0;
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / _k * _kernel.Calculate((_u[i] - x) / _k);
            return result / _elementsNumber;
        }

        private double S2(double x)
        {
            var result = 0.0;
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / _k * _w[i] * _kernel.Calculate((_u[i] - x) / _k);
            return result / _elementsNumber;
        }

        public double Fu(double x)
        {
            var v1 = V1(x);
            if (v1 == 0.0) return 0.0;
            return V2(x) / v1;
        }

        public double Fb(double x)
        {
            var s1 = S1(x);
            if (s1 == 0.0) return 0.0;
            return S2(x) / s1;
        }
    }
}