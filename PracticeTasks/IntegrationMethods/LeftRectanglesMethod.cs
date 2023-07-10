using System.Diagnostics;

namespace IntegrationMethods;

public class LeftRectanglesMethod :
    AIntegrating
{

    // public double Сalculate(
    //     Func<double, double>? function,
    //     double lowerBound,
    //     double upperBound,
    //     double precision)
    // {
    //     //проверить что ловер меньше баунд, и проверить что точность больше 0
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

    public LeftRectanglesMethod()
    {
        _stopWatch = new Stopwatch();
    }
    
    protected override (double, long) Method(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int n)
    {
        var width = (upperBound - lowerBound) / n;

        var sum = 0d;
        
        _stopWatch.Start();
        
        for (var i = 0; i < n; i++)
        {
            var x = lowerBound + i * width;
            sum += function(x);
        }
        
        _stopWatch.Stop();

        return (sum * width, _stopWatch.ElapsedTicks);
    }
    
    public override string MethodName => "LeftRectanglesMethod";
}