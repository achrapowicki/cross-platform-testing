using System.ComponentModel.Composition;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Web.PageObjects
{
    [Export(typeof(INavigationBar))]
    public class NavigationBar : INavigationBar
    {
        private readonly WebAppSession _session;

        [ImportingConstructor]
        public NavigationBar(IAppSession session)
        {
            _session = session as WebAppSession;
        }

        public void GoToNewTweet()
        {
            _session.Current.Navigate().GoToUrl("http://twitter.com");
        }
    }
}
