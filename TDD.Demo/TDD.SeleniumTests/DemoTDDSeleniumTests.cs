using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TDD.Demo.TDD.SeleniumTests;

public class DemoTDDSeleniumTests
{
    private IWebDriver _webDriver;

    [SetUp]
    public void SetupDriver()
    {
        _webDriver = new ChromeDriver();
        _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _webDriver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        _webDriver.Quit();
    }

    [Test]
    public void Test()
    {
        // REFACTORING
        var homePage = new HomePage(_webDriver);

        var userEmail = "123";
        var password = "123";

        homePage.Open("https://www.demoblaze.com/");
        homePage.ClickLoginIcon();
        homePage.FillUsernameInput(userEmail);
        homePage.FillPasswordInput(password);
        homePage.SubmitLogin();

        Assert.Multiple(() =>
        {
            Assert.IsTrue(homePage.IsLogoutIconAppeared());
            Assert.That(homePage.GetWelcomeUserIconText(), Is.EqualTo("Welcome 123"));
        });
    }
}

public class HomePage
{
    private IWebDriver WebDriver { get; }

    public HomePage(IWebDriver webDriver)
    {
        WebDriver = webDriver;
    }

    private IWebElement LoginLabel => WebDriver.FindElement(By.CssSelector("#login2"));

    private IWebElement UsernameInput => WebDriver.FindElement(By.CssSelector("#loginusername"));

    private IWebElement PasswordInput => WebDriver.FindElement(By.CssSelector("#loginpassword"));

    private IWebElement SubmitButton => WebDriver.FindElement(By.CssSelector("[onclick='logIn()']"));

    private IWebElement LogoutButton => WebDriver.FindElement(By.CssSelector("[onclick='logOut()']"));

    private IWebElement WelcomeUserButton => WebDriver.FindElement(By.CssSelector("#nameofuser"));

    public void Open(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }

    public void ClickLoginIcon()
    {
        LoginLabel.Click();
    }

    public void FillUsernameInput(string user)
    {
        UsernameInput.SendKeys(user);
    }

    public void FillPasswordInput(string password)
    {
        PasswordInput.SendKeys(password);
    }

    public void SubmitLogin()
    {
        SubmitButton.Click();
    }

    public bool IsLogoutIconAppeared()
    {
        Thread.Sleep(TimeSpan.FromSeconds(3));
        return LogoutButton.Displayed;
    }

    public string GetWelcomeUserIconText()
    {
        Thread.Sleep(TimeSpan.FromSeconds(3));
        return WelcomeUserButton.Text;
    }

    public void CloseBrowser()
    {
        WebDriver.Quit();
    }
}