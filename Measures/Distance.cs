namespace Measures;

public class Distance : Measure<Distance.Type>
{
    public Distance(float amount, Type type) : base(amount, type) { }

    public enum Type
    {
        Inch,
        Foot,
        Yard,
        Furlong,
        Mile
    }
    
    protected override Dictionary<Type, int> GetConversionFactors()
    {
        return new Dictionary<Type, int>()
        {
            { Type.Inch, 1 },
            { Type.Foot, 12 },
            { Type.Yard, 36 },
            { Type.Furlong, 7920 },
            { Type.Mile, 63360 }
        };
    }

    protected override Measure<Type> Create(float amount)
    {
        return new Distance(amount, Type.Inch);
    }
}