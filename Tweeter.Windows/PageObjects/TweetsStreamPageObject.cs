using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Windows.PageObjects
{
    [Export(typeof(ITweetsStreamPageObject))]
    public class TweetsStreamPageObject : ITweetsStreamPageObject
    {
        private readonly WindowsAppSession _session;

        [ImportingConstructor]
        public TweetsStreamPageObject(IAppSession session)
        {
            _session = session as WindowsAppSession;

        }
        public string GetLastTweet()
        {
            var listView = _session.Current.FindElementByAccessibilityId("ListView");

            var wait = new WebDriverWait(_session.Current, TimeSpan.FromSeconds(5));
            wait.Until(p => p.FindElements(OpenQA.Selenium.By.ClassName("ListViewItem")).Any());

            var firstMessage = listView.FindElementsByClassName("ListViewItem").First();
            var messageContent = firstMessage.FindElementsByClassName("RichTextBlock");
            return messageContent.Last().Text.Trim();
        }
    }
}
