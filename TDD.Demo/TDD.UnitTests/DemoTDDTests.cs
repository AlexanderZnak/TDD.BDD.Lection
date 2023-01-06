using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TDD.Demo.TDD.UnitTests;

public class DemoTDDTests
{
    [Test]
    public void SumValues_ValidData_ShouldReturnCorrectly()
    {
        // Refactoring
        var calculator = new Calculator();
        var result = calculator.Sum(2, 3);

        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void SumValues_NegativeValidData_ShouldReturnCorrectly()
    {
        // RED
        
        // GREEN
        
        // REFACTORING
        var calculator = new Calculator();
        var result = calculator.Sum(-2, 3);

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void DivisionValues_ValidData_ShouldReturnCorrectly()
    {
        var calculator = new Calculator();
        var result = calculator.Divide(3, 1);

        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void DivisionValues_DivisionOnNull_ShouldThrowError()
    {
        Assert.Catch<DivideByZeroException>(() =>
        {
            var calculator = new Calculator();
            calculator.Divide(3, 0);
        });
    }
}

public class Calculator
{
    public int Sum(int x, int y)
    {
        return x + y;
    }
    
    public void Sum()
    {
        Result = FirstNumber + SecondNumber;
    }

    public int Divide(int x, int y)
    {
        return x / y;
    }

    public int Result { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
}