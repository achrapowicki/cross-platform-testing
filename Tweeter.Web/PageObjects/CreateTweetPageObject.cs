using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Web.PageObjects
{
    [Export(typeof(ICreateTweetPageObject))]
    public class CreateTweetPageObject : ICreateTweetPageObject
    {
        private readonly WebAppSession _session;

        [ImportingConstructor]
        public CreateTweetPageObject(IAppSession session)
        {
            _session = session as WebAppSession;
        }

        public void PutMessage(string message)
        {
            var textBox = _session.Current.FindElementById("tweet-box-home-timeline");
            textBox.Clear();
            textBox.SendKeys(message);
        }

        public void Publish()
        {
            WebDriverWait wait = new WebDriverWait(_session.Current, TimeSpan.FromSeconds(5));
            var publishButton = wait.Until(ExpectedConditions.ElementToBeClickable(OpenQA.Selenium.By.ClassName("tweet-action")));
            publishButton.SendKeys(Keys.Return);

            wait = new WebDriverWait(_session.Current, TimeSpan.FromSeconds(5));
            wait.Until(p => string.Equals(_session.Current.FindElementById("tweet-box-home-timeline").Text, "Co się dzieje?", StringComparison.InvariantCultureIgnoreCase));
        }

        public bool CanPublish()
        {
            var publishButton = _session.Current.FindElementByClassName("tweet-action");

            return publishButton.Enabled;
        }
    }
}
