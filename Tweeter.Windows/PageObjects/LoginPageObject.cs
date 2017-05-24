using System.ComponentModel.Composition;
using Tweeter.Common;
using Tweeter.Common.PageObjects;

namespace Tweeter.Windows.PageObjects
{
    [Export(typeof(ILoginPageObject))]
    public class LoginPageObject : ILoginPageObject
    {
        private readonly WindowsAppSession _session;

        [ImportingConstructor]
        public LoginPageObject(IAppSession session)
        {
            _session = session as WindowsAppSession;
        }

        public void Login(string userName, string password)
        {
            // Nothing to do. User in Windows application should be logged after start.
        }
    }
}
