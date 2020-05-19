using NotWastedTestAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace NotWastedTestAutomation.StepDefinitions
{
    [Binding]
    public sealed class NotWastedStepDefinitions
    {
        private readonly MainPage mainPage;
        private readonly ServicePickerPage _servicePickerPage;

        public NotWastedStepDefinitions(IWebDriver driver)
        {
            mainPage = new MainPage(driver);
            _servicePickerPage = new ServicePickerPage(driver);
        }

        [Given(@"I navigate to the website")]
        public void GivenINavigateToTheWebsite()
        {
            // Todo Move to appsettings.json
            mainPage.Navigate("https://notwastedtestweb.azurewebsites.net/");
        }

        [Given(@"I click the button Order Bins Now on the header on the Main Page")]
        public void GivenIClickTheButtonOnTheHeaderOnTheMainPage()
        {
            mainPage.ClickBtn();
        }

        [Then(@"I get the search address modal")]
        public void ThenIGetTheSearchAddressModal()
        {
            Assert.IsTrue(mainPage.IsAddressModalPresent());
        }

        [When(@"I add and select address : '(.*)' to the search modal")]
        public void WhenIAddAddressToTheSearchModal(string address)
        {
            mainPage.AddAndSelectAddressOnTheSearchModal(address);            
        }

        [Then(@"I am on the Service Picker Page")]
        public void ThenIAmOnTheServicePickerPage()
        {
            var pageLocator = _servicePickerPage.PageLocator;
            Assert.IsTrue(_servicePickerPage.IsPageLoaded(pageLocator));
        }

        [When(@"I choose the service : ""(.*)""")]
        public void WhenIChooseTheService(string service)
        {
            _servicePickerPage.ChooseService(service);
        }

        [Then(@"I get frequency : ""(.*)"" with charge : ""(.*)""")]
        public void ThenIGetFrequencyWithCharge(string frequency, string charge)
        {
            Assert.AreEqual(frequency,_servicePickerPage.GetFrequency());
            Assert.AreEqual(charge, _servicePickerPage.GetCharge());
        }
    }
}
