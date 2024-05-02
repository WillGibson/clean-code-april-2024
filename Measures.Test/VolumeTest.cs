namespace Measures.Test;

public class VolumeTests
{
    [Test]
    public void CanCheckInequalityOfDifferentMeasureTypes()
    {
        Assert.IsFalse(new Volume(1, Volume.Type.Teaspoon).Equals("a string is not a volume"));
        Assert.IsFalse(new Volume(1, Volume.Type.Teaspoon).Equals(new Volume(1, Volume.Type.Tablespoon)));
        Assert.IsFalse(new Volume(1, Volume.Type.Gallon).Equals(new Volume(1, Volume.Type.Ounce)));
        Assert.IsFalse(new Volume(1, Volume.Type.Teaspoon).Equals(new Distance(1, Distance.Type.Inch)));
    }

    [Test]
    [TestCase(1, Volume.Type.Teaspoon, 1, Volume.Type.Teaspoon, true)]
    [TestCase(1, Volume.Type.Teaspoon, 2, Volume.Type.Teaspoon, false)]
    [TestCase(0.5f, Volume.Type.Pint, 1, Volume.Type.Cup, true)]
    public void CanCheckEquality(float amount, Volume.Type type, float other_amount, Volume.Type other_type, bool isEqual)
    {
        Assert.That(new Volume(amount, type).Equals(new Volume(other_amount, other_type)) == isEqual);
    }

    [Test]
    [TestCase(1, Volume.Type.Tablespoon, 3, Volume.Type.Teaspoon, true)]
    [TestCase(1, Volume.Type.Ounce,2, Volume.Type.Tablespoon, true)]
    [TestCase(1, Volume.Type.Cup,8, Volume.Type.Ounce, true)]
    [TestCase(1, Volume.Type.Pint,2, Volume.Type.Cup, true)]
    [TestCase(1, Volume.Type.Quart,2, Volume.Type.Pint, true)]
    [TestCase(1, Volume.Type.Gallon,4, Volume.Type.Quart, true)]
    [TestCase(1, Volume.Type.Quart,4, Volume.Type.Cup, true)]
    public void CanCheckEqualityAcrossTypes(int amount, Volume.Type type, int other_amount, Volume.Type other_type, bool isEqual)
    {
        Assert.AreEqual(new Volume(amount, type).Equals(new Volume(other_amount, other_type)), isEqual);
    }
    
    [Test]
    [TestCase(1, Volume.Type.Teaspoon,4, Volume.Type.Teaspoon, 5, Volume.Type.Teaspoon)]
    [TestCase(5, Volume.Type.Cup, 8, Volume.Type.Ounce, 288, Volume.Type.Teaspoon)]
    [TestCase(0.7f, Volume.Type.Gallon, 1.3f, Volume.Type.Tablespoon, 541.5f, Volume.Type.Teaspoon)]
    [TestCase(0.1f, Volume.Type.Teaspoon,0.06f, Volume.Type.Teaspoon, 0.16f, Volume.Type.Teaspoon)]
    [TestCase(0.3f, Volume.Type.Teaspoon,0.16f, Volume.Type.Teaspoon, 0.46f, Volume.Type.Teaspoon)]
    public void CanAddVolume(float amount, Volume.Type type, float other_amount, Volume.Type other_type,float expectedAmount, Volume.Type expectedType)
    {
        Assert.AreEqual(new Volume(amount, type).Add(new Volume(other_amount,other_type)), new Volume(expectedAmount,expectedType));
    }
}
