namespace Measures.Test;

public class UnitTest
{
    [Test]
    public void SetsDefaultRatioToBaseUnit()
    {
        Assert.AreEqual(new Unit().ratioToBaseUnit, 1);
    }
    
    [Test]
    public void SetsRatioToAnotherUnit()
    {
        Assert.AreEqual(new Unit().ratioToBaseUnit, 1);
    }
}