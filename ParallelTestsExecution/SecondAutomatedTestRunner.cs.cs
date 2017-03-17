using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace ParallelTestsExecution
{
    [TestFixture]
    [Parallelizable]
    public class SecondAutomatedTestRunner
    {
        private static String STAGING_URL = "https://staging.university4industry.com";
        private RemoteWebDriver remoteFirefox;

        [SetUp]
        public void Init()
        {
            DesiredCapabilities remoteFirefoxCapability = DesiredCapabilities.Firefox();
            remoteFirefoxCapability.SetCapability("version", "");
            remoteFirefoxCapability.SetCapability("platform", "Linux");
            remoteFirefox = new RemoteWebDriver(new Uri("http://192.168.99.100:32776/wd/hub"), remoteFirefoxCapability);
            remoteFirefox.Navigate().GoToUrl(STAGING_URL);
        }

        [Test]
        public void UrLHasDiscoverWordAfterPressOnDiscoverButton()
        {
            By discoverButton = By.XPath("//button//*[text()='Discover']");
            remoteFirefox.FindElement(discoverButton).Click();
            Assert.AreEqual(STAGING_URL + "/discover", remoteFirefox.Url);
        }

        [Test]
        public void UrLHasDiscussWordAfterPressOnDiscussButton()
        {
            By discussButton = By.XPath("//button//*[text()='Discuss']");
            remoteFirefox.FindElement(discussButton).Click();
            Assert.AreEqual(STAGING_URL + "/?dialog=login", remoteFirefox.Url);
        }

        [TearDown]
        public void Cleanup()
        {
            remoteFirefox.Quit();
        }
    }
}
