using System.ComponentModel.Composition;
using Tweeter.Common;

namespace Tweeter.Tests
{
    public abstract class TweeterTestBase
    {
        [Import]
        private IRunner _runner;

        protected IAppSession _session;

        public TweeterTestBase()
        {
            
        }

        protected static void ClassInitialize()
        {

        }

        protected static void ClassCleanup()
        {

        }

        protected void TestInitialize()
        {
            MefContainer.Container.ComposeParts(this);

            _session = _runner.Run();
            
            MefContainer.Container.ComposeExportedValue<IAppSession>(_session);
        }

        protected void TestCleanup()
        {
            _runner.Close();

            MefContainer.Dispose();
        }
    }
}
