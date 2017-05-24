using OpenQA.Selenium.Support.UI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Web.PageObjects
{
    [Export(typeof(ILoginPageObject))]
    public class LoginPageObject : ILoginPageObject
    {
        private readonly WebAppSession _session;

        [ImportingConstructor]
        public LoginPageObject(IAppSession session)
        {
            _session = session as WebAppSession;
        }

        public void Login(string userName, string password)
        {
            var emailInput = _session.Current.FindElementById("signin-email");
            var passwordInput = _session.Current.FindElementById("signin-password");
            var loginButton = _session.Current.FindElementByCssSelector("submit");

            emailInput.SendKeys(userName);
            passwordInput.SendKeys(password);

            loginButton.Click();

            var wait = new WebDriverWait(_session.Current, TimeSpan.FromSeconds(5));
            wait.Until(p => p.FindElements(OpenQA.Selenium.By.CssSelector("session")).Any());
        }
    }
}
