using NUnit.Framework;

namespace ConsoleApp1;

public class NUnitTestItem1
{
    private Class1 aga;
    [SetUp]
    public void Setup()
    {
        aga = new Class1();
    }

    [Test]
    public void SimplePlus()
    {
        double result = aga.Calculate("15 + 15");
        Assert.AreEqual(30, result);
    }
    [Test]
    public void SimpleMinus()
    {
        double result = aga.Calculate("25 - 15");
        Assert.AreEqual(10, result);
    }
    [Test]
    public void SimpleUmnozhenie()
    {
        double result = aga.Calculate("4 * 3");
        Assert.AreEqual(12, result);
    }
    [Test]
    public void SimpleDelenie()
    {
        double result = aga.Calculate("40 / 8");
        Assert.AreEqual(5, result);
    }
    [Test]
    public void HardPlus()
    {
        double result = aga.Calculate("187249871 + 137485");
        Assert.AreEqual(187387356, result);
    }
    [Test]
    public void HardMinus()
    {
        double result = aga.Calculate("1234567 - 765432");
        Assert.AreEqual(469135, result);
    }
    [Test]
    public void HardUmnozhenie()
    {
        double result = aga.Calculate("876543 * 478");
        Assert.AreEqual(418987554, result,1);
    }
    [Test]
    public void HardDelenie()
    {
        double result = aga.Calculate("123456789 / 1876");
        Assert.AreEqual(65808.52, result);
    }
    [Test]
    public void Stepen()
    {
        double result = aga.Calculate("2^20");
        Assert.AreEqual(1048576, result);
    }
    [Test]
    public void HardPrimerWithSkobkas()
    {
        double result = aga.Calculate("(234+65*34)/(23*32)");
        Assert.AreEqual(3.32, result,0.01);
    }
    [Test]
    public void simplePrimerWithSkobkas()
    {
        double result = aga.Calculate("(23-13)*(2+2)");
        Assert.AreEqual(40, result);
    }
    [Test]
    public void ProverkaNaCharSimbols()
    {
        Assert.Throws<FormatException>(() => aga.Calculate("15 + 153#"));
        
    }
    [Test]
    public void VOID()
    {
        Assert.Throws<FormatException>(() => aga.Calculate(""));
    }
    [Test]
    public void DontVernieDannyeInInput()
    {
        Assert.Throws<FormatException>(() => aga.Calculate("FDSF"));
    }
}
