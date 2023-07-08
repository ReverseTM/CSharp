namespace IntegrationMethods;

public interface IIntegrating
{
    double Сalculate(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int precision);

    string MethodName
    {
        get;
    }
    
}