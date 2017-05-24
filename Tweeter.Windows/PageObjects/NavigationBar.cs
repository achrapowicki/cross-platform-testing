using System.ComponentModel.Composition;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Windows.PageObjects
{
    [Export(typeof(INavigationBar))]
    public class NavigationBar : INavigationBar
    {
        private readonly WindowsAppSession _session;

        [ImportingConstructor]
        public NavigationBar(IAppSession session)
        {
            _session = session as WindowsAppSession;
        }

        public void GoToNewTweet()
        {
            var homeButton = _session.Current.FindElementByAccessibilityId("Home");
            homeButton.Click();

            var newTweetButton = _session.Current.FindElementByAccessibilityId("NewTweetBtn");
            newTweetButton.Click();
        }
    }
}
