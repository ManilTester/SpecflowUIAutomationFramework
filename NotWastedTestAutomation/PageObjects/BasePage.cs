using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace NotWastedTestAutomation.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        public void Navigate(string url, string path)
        {
            var fullUrl = url.EndsWith("/")
                ? (url + path)
                : (url + "/" + path);
            Navigate(fullUrl);
        }

        public bool IsPageLoaded(By pageLocator)
        {
            try
            {
                return Driver.FindElement(pageLocator).Displayed;
            }
            catch (Exception)
            {
                Console.WriteLine($@"No page found with locator: {pageLocator}");
                throw;
            }
        }

        public bool IsPageLoaded(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {
                Console.WriteLine($@"No page found with element: {element}");
                throw;
            }
        }

        public IWebElement FindElement(By by)
        {
            return Driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Driver.FindElements(by);
        }
    }
}
