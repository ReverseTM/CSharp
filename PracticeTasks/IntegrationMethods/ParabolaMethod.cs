using System.Diagnostics;

namespace IntegrationMethods;

public class ParabolaMethod :
    AIntegrating
{
    public ParabolaMethod()
    {
        _stopWatch = new Stopwatch();
    }
    
    // public double Сalculate(
    //     Func<double, double> function,
    //     double lowerBound,
    //     double upperBound,
    //     double precision)
    // {
    //     var n = 1;
    //     var result = Method(function, lowerBound, upperBound, n);
    //     var previousResult = 0d;
    //
    //     do
    //     {
    //         previousResult = result;
    //         n += 1;
    //         result = Method(function, lowerBound, upperBound, n);
    //
    //     } while (Math.Abs(result - previousResult).CompareTo(precision) > 0);
    //
    //     _iterationsCount = n;
    //     
    //     return result;
    // }

    protected override (double, long) Method(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int n)
    {
        var width = (upperBound - lowerBound) / n;
        var sum1 = 0d;
        var sum2 = 0d;
        
        _stopWatch.Start();
        
        for (var k = 1; k <= n; k++)
        {
            var xk = lowerBound + k * width;
            if (k < n) sum1 += function(xk);
            var xk1 = lowerBound + (k - 1) * width;
            sum2 += function((xk1 + xk) / 2d);
        }
        
        _stopWatch.Stop();

        return (width / 3d * (1d / 2d * function(lowerBound) + sum1 + 2 * sum2 + 1d / 2d * function(upperBound)), _stopWatch.ElapsedTicks);
    }

    public override string MethodName => "ParabolaMethod";
}