using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Tweeter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PublishTweetTests
    {
        private InternetExplorerDriver _driver;

        #region Additional test attributes
        

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            var options = new InternetExplorerOptions();
            options.InitialBrowserUrl = "http://twitter.com";
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            _driver = new InternetExplorerDriver(options);

            WebDriverWait waitForLoaded = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            waitForLoaded.Until(ExpectedConditions.ElementIsVisible(OpenQA.Selenium.By.ClassName(@"stream-items")));
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            _driver.Close();
        }

        #endregion

        [TestMethod]
        public void PublishTweet_TweetLessThan140Signs_Published()
        {
            var message = string.Format("Message:{0}", DateTime.Now.ToLongTimeString());

            _driver.Navigate().GoToUrl("http://twitter.com");

            var textBox = _driver.FindElementById("tweet-box-home-timeline");
            textBox.Clear();
            textBox.SendKeys(message);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(OpenQA.Selenium.By.ClassName("tweet-action")));
            element.SendKeys(Keys.Return);

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(p => string.Equals(_driver.FindElementById("tweet-box-home-timeline").Text, "Co się dzieje?", StringComparison.InvariantCultureIgnoreCase));

            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(p => p.FindElements(OpenQA.Selenium.By.ClassName(@"stream-item")).Any());

            var firstMessage = _driver.FindElements(OpenQA.Selenium.By.ClassName(@"tweet-text")).First();

            var publishedMessage = firstMessage.Text.Trim();

            Assert.AreEqual<string>(message, publishedMessage);
        }
    }
}
