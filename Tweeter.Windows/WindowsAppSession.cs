using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using Tweeter.Common;

namespace Tweeter.Windows
{
    public class WindowsAppSession : IAppSession
    {
        private readonly WindowsDriver<WindowsElement> _current;

        public WindowsAppSession(WindowsDriver<WindowsElement> session)
        {
            _current = session;
        }

        public WindowsDriver<WindowsElement> Current
        {
            get { return _current; }
        }
    }
}
