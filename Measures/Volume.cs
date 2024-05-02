namespace Measures;

public class Volume : Measure<Volume.Type>
{
    public Volume(float amount, Type type) : base(amount, type) { }
    
    public enum Type
    {
        Teaspoon,
        Tablespoon,
        Ounce,
        Cup,
        Pint,
        Quart,
        Gallon
    }

    protected override Dictionary<Type, int> GetConversionFactors()
    {
        return new Dictionary<Type, int>()
        {
            { Type.Teaspoon, 1 },
            { Type.Tablespoon, 3 },
            { Type.Ounce, 6 },
            { Type.Cup, 48 },
            { Type.Pint, 96 },
            { Type.Quart, 192 },
            { Type.Gallon, 768 }
        };
    }

    protected override Measure<Type> Create(float amount)
    {
        return new Volume(amount, Type.Teaspoon);
    }
}