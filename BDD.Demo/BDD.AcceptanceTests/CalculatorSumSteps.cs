using NUnit.Framework;
using TDD.Demo.TDD.UnitTests;
using TechTalk.SpecFlow;

namespace BDD.Demo.BDD.AcceptanceTests;

[Binding]
public class CalculatorSumSteps
{
    private Calculator _calculator;
    
    [Given(@"I start calculator")]
    public void GivenIStartCalculator()
    {
        _calculator = new Calculator();
    }

    [Given(@"I have the first number (.*)")]
    public void GivenIHaveTheFirstNumber(int number)
    {
        _calculator.FirstNumber = number;
    }

    [Given(@"I have the second number (.*)")]
    public void GivenIHaveTheSecondNumber(int number)
    {
        _calculator.SecondNumber = number;
    }

    [When(@"I Want to sum this numbers")]
    public void WhenIWantToSumThisNumbers()
    {
        _calculator.Sum();
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(int expectedResult)
    {
        Assert.AreEqual(expectedResult, _calculator.Result);
    }
}