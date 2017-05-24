using System.ComponentModel.Composition;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Windows.PageObjects
{
    [Export(typeof(ICreateTweetPageObject))]
    public class CreateTweetPageObject : ICreateTweetPageObject
    {
        private readonly WindowsAppSession _session;

        [ImportingConstructor]
        public CreateTweetPageObject(IAppSession session)
        {
            _session = session as WindowsAppSession;
        }

        public void PutMessage(string message)
        {
            var textBox = _session.Current.FindElementByAccessibilityId("TextInputBox");
            textBox.SendKeys(message);
        }

        public void Publish()
        {
            var publishButton = _session.Current.FindElementByAccessibilityId("DesktopTweetBtn");
            publishButton.Click();
        }

        public bool CanPublish()
        {
            var publishButton = _session.Current.FindElementByAccessibilityId("DesktopTweetBtn");
            return publishButton.Enabled;
        }
    }
}
