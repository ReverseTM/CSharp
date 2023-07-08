using System.Diagnostics;

namespace IntegrationMethods;

public class TrapezoidalMethod :
    IIntegrating
{
    private int _iterationsCount;
    private long _time;
    
    public double Сalculate(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        double precision)
    {
        if (function == null) throw new ArgumentNullException(nameof(function));
        
        var n = 1;
        var result = Method(function, lowerBound, upperBound, n);
        var previousResult = 0d;

        do
        {
            previousResult = result;
            n += 1;
            result = Method(function, lowerBound, upperBound, n);

        } while (Math.Abs(result - previousResult).CompareTo(precision) > 0);

        _iterationsCount = n;
        
        return result;
    }

    private double Method(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int n)
    {
        var width = (upperBound - lowerBound) / n;

        var sum = (function(lowerBound) + function(upperBound)) / 2d;

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        for (var i = 1; i < n; i++)
        {
            var x = lowerBound + i * width;
            sum += function(x);
        }
        
        stopWatch.Stop();
        _time = stopWatch.ElapsedTicks;
        
        return sum * width;
    }

    public string MethodName => "TrapezoidalMethod";
    
    public int IterationsCount => _iterationsCount;

    public long Time => _time;
}