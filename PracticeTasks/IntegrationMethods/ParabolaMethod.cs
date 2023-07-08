using System.Diagnostics;

namespace IntegrationMethods;

public class ParabolaMethod :
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
        var sum1 = 0d;
        var sum2 = 0d;

        var stopWatch = new Stopwatch();
        stopWatch.Start();
        
        for (var k = 1; k <= n; k++)
        {
            var xk = lowerBound + k * width;
            if (k < n) sum1 += function(xk);
            var xk1 = lowerBound + (k - 1) * width;
            sum2 += function((xk1 + xk) / 2d);
        }
        
        stopWatch.Stop();
        _time = stopWatch.ElapsedTicks;
        
        return width / 3d * (1d / 2d * function(lowerBound) + sum1 + 2 * sum2 + 1d / 2d * function(upperBound));
    }

    public string MethodName => "ParabolaMethod";
    
    public int IterationsCount => _iterationsCount;

    public long Time => _time;
}