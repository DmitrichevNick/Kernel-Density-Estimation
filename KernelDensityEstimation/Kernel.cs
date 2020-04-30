using System;

namespace KernelDensityEstimation
{
    public static class KernelFactory
    {
        public static IKernel Create(int type)
        {
            switch (type)
            {
                case 0:
                    return new K0();
                case 1:
                    return new K1();
                case 2:
                    return new K2();
                case 3:
                    return new K3();
                case 4:
                    return new K4();
                case 5:
                    return new K5();
                case 6:
                    return new K6();
                default:
                    throw new ArgumentException("Wrong type of kernel.");
            }
        }
    }

    public interface IKernel
    {
        double Calculate(double x);
    }

    public static class Indicator
    {
        public static int ValueLess1(double x)
        {
            return Math.Abs(x) <= 1 ? 1 : 0;
        }
    }

    public class K0 : IKernel
    {
        public double Calculate(double x)
        {
            return 0.75 * (1 - Math.Pow(x, 2)) * Indicator.ValueLess1(x);
        }
    }

    public class K1 : IKernel
    {
        public double Calculate(double x)
        {
            return 0.9375 * Math.Pow(1 - Math.Pow(x, 2), 2) * Indicator.ValueLess1(x);
        }
    }

    public class K2 : IKernel
    {
        public double Calculate(double x)
        {
            return 0.5 * Indicator.ValueLess1(x);
        }
    }

    public class K3 : IKernel
    {
        public double Calculate(double x)
        {
            return (1 - Math.Abs(x)) * Indicator.ValueLess1(x);
        }
    }

    public class K4 : IKernel
    {
        public double Calculate(double x)
        {
            return Math.PI / 4 * Math.Cos(Math.PI * x / 2) * Indicator.ValueLess1(x);
        }
    }

    public class K5 : IKernel
    {
        public double Calculate(double x)
        {
            return 0.5 * Math.Exp(-Math.Abs(x)) * Indicator.ValueLess1(x);
        }
    }

    public class K6 : IKernel
    {
        public double Calculate(double x)
        {
            return 1 / Math.Sqrt(2 * Math.PI) * Math.Exp(-Math.Pow(x, 2) / 2) * Indicator.ValueLess1(x);
        }
    }
}