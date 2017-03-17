using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ParallelTestsExecution
{
    [TestFixture]
    [Parallelizable]

    public class FirstAutomatedTestRunner
    {
        private static String STAGING_URL = "https://staging.university4industry.com";
        private RemoteWebDriver remoteChrome;

        [SetUp]
        public void Init()
        {
            DesiredCapabilities remoteChromeCapability = DesiredCapabilities.Chrome();
            remoteChromeCapability.SetCapability("version", "");
            remoteChromeCapability.SetCapability("platform", "Linux");
            remoteChrome = new RemoteWebDriver(new Uri("http://192.168.99.100:32776/wd/hub"), remoteChromeCapability);

            remoteChrome.Manage().Window.Maximize();
            remoteChrome.Navigate().GoToUrl(STAGING_URL);
        }

        [Test]
        public void HartingPageIsDisplayedAfterNavigateOnHartingPage()
        {
            remoteChrome.Navigate().GoToUrl("https://staging.university4industry.com/harting");
            Assert.AreEqual(STAGING_URL + "/harting", remoteChrome.Url);
        }

        [Test]
        public void DialogRegisterIsDisplayedAfterNavigateOnRegisterPage()
        {
            remoteChrome.Navigate().GoToUrl("https://staging.university4industry.com/?dialog=register");
            Assert.AreEqual(STAGING_URL + "/?dialog=register", remoteChrome.Url);
        }

        [TearDown]
        public void Cleanup()
        {
            remoteChrome.Quit();
        }
    }
}
