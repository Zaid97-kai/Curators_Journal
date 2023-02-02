using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedUITests;

public class AutomatedUiTest : IDisposable
{
    private readonly IWebDriver _driver;
    public AutomatedUiTest()
    {
        _driver = new ChromeDriver();
    }

    [Fact]
    public void Create_WhenExecuted_ReturnsCreateView()
    {
        _driver.Navigate()
            .GoToUrl("https://localhost:7017/");

        Assert.Equal("Main page", _driver.Title);
        Assert.Contains("Please provide a new employee data", _driver.PageSource);
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}