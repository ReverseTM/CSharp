namespace IntegrationMethods;

public class ParabolaMethod :
    IIntegrating
{
    public double Сalculate(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        int precision)
    {
        throw new NotImplementedException();
    }

    public string MethodName => "ParabolaMethod";
}