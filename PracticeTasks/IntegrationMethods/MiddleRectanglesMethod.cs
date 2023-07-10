using System.Diagnostics;

namespace IntegrationMethods;

public class MiddleRectanglesMethod :
    AIntegrating
{
    public MiddleRectanglesMethod()
    {
        _stopWatch = new Stopwatch();
    }
    
    // public double Сalculate(
    //     Func<double, double> function,
    //     double lowerBound,
    //     double upperBound,
    //     double precision)
    // {
    //     if (function == null) throw new ArgumentNullException(nameof(function));
    //     
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

        var sum = (function(lowerBound) + function(upperBound)) / 2d;
        
        _stopWatch.Start();
        
        for (var i = 1; i < n; i++)
        {
            var x = lowerBound + i * width;
            sum += function(x);
        }

        _stopWatch.Stop();
        
        
        return (sum * width, _stopWatch.ElapsedTicks);
    }

    public override string MethodName => "MiddleRectanglesMethod";
}