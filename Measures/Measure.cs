namespace Measures;

public abstract class Measure<T>
{
    private float _amount;

    private Dictionary<T, int> _conversionFactors;

    public Measure(float amount, T type)
    {
        _conversionFactors = GetConversionFactors();
        _amount = ToBaseUnit(amount, type);
    }

    public bool Equals(Measure<T> other)
    {
        return _amount == other._amount;
    }

    public override bool Equals(object? other)
    {
        if (other is not Measure<T> otherVolume)
        {
            return false;
        }

        return Equals(otherVolume);
    }

    public Measure<T> Add(Measure<T> other)
    {
        return Create(_amount + other._amount);
    }

    private float ToBaseUnit(float amount, T type)
    {
        return amount * _conversionFactors[type];
    }

    protected abstract Dictionary<T, int> GetConversionFactors();

    protected abstract Measure<T> Create(float amount);
}