using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace NotWastedTestAutomation.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "TestResults"));
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            // GetDriver(Convert.ToBoolean(ConfigurationManager.AppSettings["headless"]));
            GetDriver(false);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                TakeScreenshot(scenarioContext);
            }

            _driver?.Dispose();
        }

        private void TakeScreenshot(ScenarioContext scenarioContext)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile(Path.Combine(Environment.CurrentDirectory, $"{scenarioContext.ScenarioInfo.Title}.png"),
                    ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public IWebDriver GetDriver(bool headless)
        {
            if (_driver == null)
            {
                switch ("Chrome")
                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        if (headless)
                        {
                            chromeOptions.AddArgument("--window-size=1920,1080");
                            chromeOptions.AddArgument("--start-maximized");
                            chromeOptions.AddArgument("--headless");
                        }

                        _driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
                        break;
                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }

            }

            return _driver;
        }
    }
}
