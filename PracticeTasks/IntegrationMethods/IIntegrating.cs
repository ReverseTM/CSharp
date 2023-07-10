namespace IntegrationMethods;

public interface IIntegrating
{
    (double, int n, long) Сalculate(Func<double, double> function,
        double lowerBound,
        double upperBound,
        double precision);

    string MethodName
    {
        get;
    }
}