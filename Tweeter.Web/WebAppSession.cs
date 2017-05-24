using OpenQA.Selenium.IE;
using System.Threading;
using Tweeter.Common;

namespace Tweeter.Web
{
    public class WebAppSession : IAppSession
    {
        private readonly InternetExplorerDriver _current;

        public WebAppSession(InternetExplorerDriver session)
        {
            _current = session;
        }

        public InternetExplorerDriver Current
        {
            get { return _current; }
        }
    }
}
