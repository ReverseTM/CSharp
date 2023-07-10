using System.Diagnostics;

namespace IntegrationMethods;

public abstract class AIntegrating :
    IIntegrating
{
    protected Stopwatch _stopWatch;
    
    public (double, int, long) Сalculate(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        double precision)
    {
        if (function == null) throw new ArgumentNullException(nameof(function));
        
        if (lowerBound >= upperBound) throw new ArgumentException("Lower bound must be lower than upper bound");

        if (precision.CompareTo(0d) <= 0) throw new ArgumentException("Precision must be greater than 0", nameof(precision));

        var n = 1;
        var tuple = Method(function, lowerBound, upperBound, n);
        var previousResult = 0d;

        do
        {
            previousResult = tuple.Item1;
            n += 1;
            tuple = Method(function, lowerBound, upperBound, n);

        } while (Math.Abs(tuple.Item1 - previousResult).CompareTo(precision) > 0);

        return (tuple.Item1, n, tuple.Item2);
    }

    protected abstract (double, long) Method(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int n);

    public abstract string MethodName { get; }
}