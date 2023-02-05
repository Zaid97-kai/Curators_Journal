using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomatedUITests;

/// <summary>
/// Class AutomatedUiTest.
/// Implements the <see cref="System.IDisposable" />
/// </summary>
/// <seealso cref="System.IDisposable" />
public class AutomatedUiTest : IDisposable
{
    /// <summary>
    /// The driver
    /// </summary>
    private readonly IWebDriver _driver;

    /// <summary>
    /// Initializes a new instance of the <see cref="AutomatedUiTest"/> class.
    /// </summary>
    public AutomatedUiTest()
    {
        _driver = new ChromeDriver();
    }

    /// <summary>
    /// Defines the test method Create_WhenExecuted_ReturnsCreateView.
    /// </summary>
    [Fact]
    public void Create_WhenExecuted_ReturnsCreateView()
    {
        _driver.Navigate()
            .GoToUrl("https://localhost:7017/");

        Assert.Equal("Main page", _driver.Title);
        Assert.Contains("Please provide a new employee data", _driver.PageSource);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}