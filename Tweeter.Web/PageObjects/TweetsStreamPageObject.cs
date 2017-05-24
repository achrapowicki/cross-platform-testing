using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Web.PageObjects
{
    [Export(typeof(ITweetsStreamPageObject))]
    public class TweetsStreamPageObject : ITweetsStreamPageObject
    {
        private readonly WebAppSession _session;

        [ImportingConstructor]
        public TweetsStreamPageObject(IAppSession session)
        {
            _session = session as WebAppSession;

        }
        public string GetLastTweet()
        {
            var wait = new WebDriverWait(_session.Current, TimeSpan.FromSeconds(5));
            wait.Until(p => p.FindElements(OpenQA.Selenium.By.ClassName(@"stream-item")).Any());
            
            var firstMessage = _session.Current.FindElements(OpenQA.Selenium.By.ClassName(@"tweet-text")).First();
            
            return firstMessage.Text.Trim();
        }
    }
}
