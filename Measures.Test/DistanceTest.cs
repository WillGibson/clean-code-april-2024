namespace Measures.Test;

public class DistanceTests
{
    [Test]
    public void CanCheckInequalityOfDifferentMeasureTypes()
    {
        Assert.IsFalse(new Distance(1, Distance.Type.Inch).Equals("a string is not a volume"));
        Assert.IsFalse(new Distance(1, Distance.Type.Inch).Equals(new Distance(1, Distance.Type.Mile)));
        Assert.IsFalse(new Distance(1, Distance.Type.Furlong).Equals(new Distance(1, Distance.Type.Foot)));
        Assert.IsFalse(new Distance(1, Distance.Type.Inch).Equals(new Volume(1, Volume.Type.Teaspoon)));
    }

    [Test]
    [TestCase(1, Distance.Type.Inch, 1, Distance.Type.Inch, true)]
    [TestCase(1, Distance.Type.Inch, 2, Distance.Type.Inch, false)]
    [TestCase(0.5f, Distance.Type.Furlong, 110, Distance.Type.Yard, true)]
    public void CanCheckEquality(float amount, Distance.Type type, float other_amount, Distance.Type other_type, bool isEqual)
    {
        Assert.That(new Distance(amount, type).Equals(new Distance(other_amount, other_type)) == isEqual);
    }
    
    [Test]
    [TestCase(1, Distance.Type.Foot, 12, Distance.Type.Inch, true)]
    [TestCase(1, Distance.Type.Yard,3, Distance.Type.Foot, true)]
    [TestCase(1, Distance.Type.Furlong,220, Distance.Type.Yard, true)]
    [TestCase(1, Distance.Type.Mile,8, Distance.Type.Furlong, true)]
    public void CanCheckEqualityAcrossTypes(int amount, Distance.Type type, int other_amount, Distance.Type other_type, bool isEqual)
    {
        Assert.AreEqual(new Distance(amount, type).Equals(new Distance(other_amount, other_type)), isEqual);
    }
    
    [Test]
    [TestCase(1, Distance.Type.Inch,4, Distance.Type.Inch, 5, Distance.Type.Inch)]
    [TestCase(5, Distance.Type.Foot, 8, Distance.Type.Yard, 348, Distance.Type.Inch)]
    [TestCase(0.7f, Distance.Type.Mile, 1.3f, Distance.Type.Furlong, 54648, Distance.Type.Inch)]
    [TestCase(0.1f, Distance.Type.Inch,0.06f, Distance.Type.Inch, 0.16f, Distance.Type.Inch)]
    [TestCase(0.3f, Distance.Type.Inch,0.16f, Distance.Type.Inch, 0.46f, Distance.Type.Inch)]
    public void CanAddDistance(float amount, Distance.Type type, float other_amount, Distance.Type other_type,float expectedAmount, Distance.Type expectedType)
    {
        Assert.AreEqual(new Distance(amount, type).Add(new Distance(other_amount,other_type)), new Distance(expectedAmount,expectedType));
    }
}
