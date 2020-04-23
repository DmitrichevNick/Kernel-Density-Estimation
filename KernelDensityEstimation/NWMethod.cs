namespace KernelDensityEstimation
{
    // ReSharper disable once InconsistentNaming
    public class NWMethod
    {
        private readonly int _elementsNumber;
        private readonly double _h;
        private readonly IKernel _kernel;
        private readonly double[] _u;
        private readonly double[] _w;

        public NWMethod(int kernelType, double[] u, double[] w, double h)
        {
            _elementsNumber = u.Length;
            _u = u;
            _w = w;
            _h = h;
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
                    s1 += 1 / _h * _kernel.Calculate((element - x) / _h);
                    s2 += 1 / _h * _kernel.Calculate((element - _u[j]) / _h);
                }

                if (s2 != 0.0) result += 1 / _h * _kernel.Calculate((_u[j] - x) / _h) * s1 / s2;
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
                    s1 += 1 / _h * _w[j] * _kernel.Calculate((element - x) / _h);
                    s2 += 1 / _h * _w[j] * _kernel.Calculate((element - _u[j]) / _h);
                }

                if (s2 != 0.0) result += 1 / _h * _w[j] * _kernel.Calculate((_u[j] - x) / _h) * s1 / s2;
            }

            return result / _elementsNumber;
        }

        private double S1(double x)
        {
            var result = 0.0;
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / _h * _kernel.Calculate((_u[i] - x) / _h);
            return result / _elementsNumber;
        }

        private double S2(double x)
        {
            var result = 0.0;
            for (var i = 0; i < _elementsNumber; ++i) result += 1 / _h * _w[i] * _kernel.Calculate((_u[i] - x) / _h);
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