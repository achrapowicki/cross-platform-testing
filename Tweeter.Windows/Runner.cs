using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.ComponentModel.Composition;
using Tweeter.Common;

namespace Tweeter.Windows
{
    [Export(typeof(IRunner))]
    public class Runner : IRunner
    {
        private WindowsAppSession _sesson;

        public IAppSession Run()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", @"9E2F88E3.Twitter_wgeqdkkx372wm!x554f661dyd360y462cy8743yf8a99b7d41dbx");
            appCapabilities.SetCapability("platformName", "Windows");
            appCapabilities.SetCapability("deviceName", "WindowsPC");

            _sesson = new WindowsAppSession(new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723/wd/hub"), appCapabilities));

            return _sesson;
        }

        public void Close()
        {
            if (_sesson != null)
            {
                _sesson.Current.CloseApp();
            }
        }
    }
}
