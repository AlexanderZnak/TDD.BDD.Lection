using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TDD.Demo.TDD.SeleniumTests;
using TechTalk.SpecFlow;

namespace BDD.Demo;

[Binding]
public class LoginSteps
{
    private HomePage _homePage;

    [Given(@"I go to website demoblaze\.com")]
    public void GivenIGoToWebsiteDemoblazeCom()
    {
        var webDriver = new ChromeDriver();
        webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        webDriver.Manage().Window.Maximize();

        _homePage = new HomePage(webDriver);
        _homePage.Open("https://www.demoblaze.com/");
    }

    [When(@"I click button Login")]
    public void WhenIClickButtonLogin()
    {
        _homePage.ClickLoginIcon();
    }

    [When(@"I fill in form")]
    public void WhenIFillInForm()
    {
        _homePage.FillUsernameInput("123");
        _homePage.FillPasswordInput("123");
    }

    [When(@"I submit form")]
    public void WhenISubmitForm()
    {
        _homePage.SubmitLogin();
    }

    [Then(@"User should be logged in")]
    public void ThenUserShouldBeLoggedIn()
    {
        Assert.Multiple(() =>
        {
            Assert.IsTrue(_homePage.IsLogoutIconAppeared());
            Assert.That(_homePage.GetWelcomeUserIconText(), Is.EqualTo("Welcome 123"));
        });
    }

    [Then(@"Quite browser")]
    public void ThenQuiteBrowser()
    {
        _homePage.CloseBrowser();
    }
}