using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotWastedTestAutomation.PageObjects
{
    internal class ServicePickerPage : BasePage
    {
        private IEnumerable<IWebElement> ServicesToChoose => FindElements(By.CssSelector("div[class=service-picker__select] ul li div[class=service-picker__select__item__content]"));
        internal IWebElement PageLocator => FindElement(By.CssSelector("div[class=service-picker]"));

        internal IWebElement FrequencyDetails => FindElement(By.CssSelector("ul[class=service-picker__details__frequencies] li div"));
        public ServicePickerPage(IWebDriver driver) : base(driver)
        {
        }

        internal void ChooseService(string service)
        {
            ServicesToChoose.First(ser => ser.Text.Contains(service)).Click();
        }

        internal string GetFrequency()
        {
            return FrequencyDetails.FindElement(By.CssSelector("h4")).Text;
        }

        internal string GetCharge()
        {
            return FrequencyDetails.FindElement(By.CssSelector("p")).Text;
        }
    }
}
