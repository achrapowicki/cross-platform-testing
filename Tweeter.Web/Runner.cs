using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition;
using Tweeter.Common;

namespace Tweeter.Web
{
    [Export(typeof(IRunner))]
    public class Runner : IRunner
    {
        private InternetExplorerDriver _driver;

        public IAppSession Run()
        {
            var options = new InternetExplorerOptions();
            options.InitialBrowserUrl = "http://twitter.com";
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            
            _driver = new InternetExplorerDriver(options);
            
            WebDriverWait waitForLoaded = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            waitForLoaded.Until(ExpectedConditions.ElementIsVisible(OpenQA.Selenium.By.ClassName(@"stream-items")));

            return new WebAppSession(_driver);
        }

        public void Close()
        {
            _driver.Close();
        }
    }
}
