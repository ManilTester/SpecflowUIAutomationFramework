using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NotWastedTestAutomation.PageObjects
{
    internal class MainPage : BasePage
    {

        private IWebElement OrderBinsNowHdrBtn => FindElement(By.CssSelector("button[class*=home__header]"));
        private IWebElement AddressModal => FindElement(By.CssSelector("div[class=search-address-modal__window]"));
        private IWebElement AddressModalAddressInput => FindElement(By.CssSelector("div[class=search-address] div[class=search-address__input] input"));

        private IEnumerable<IWebElement> AddressModalAddressList => FindElements(By.CssSelector("div[class=search-address__suggestion-list] ul li div"));

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        internal void ClickBtn()
        {
            OrderBinsNowHdrBtn.Click();
        }

        internal bool IsAddressModalPresent()
        {
            return AddressModal.Displayed;
        }

        internal void AddAndSelectAddressOnTheSearchModal(string address)
        {
            AddressModalAddressInput.SendKeys(address);
            Thread.Sleep(1000);
            AddressModalAddressList.First(add => add.Text == address).Click();                        
        }
    }
}
