using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Threading;
using Tweeter.Common.PageObjects;

namespace Tweeter.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class PublishTweetTests : TweeterTestBase
    {
        public PublishTweetTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            ClassInitialize();
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            TestInitialize();
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            TestCleanup();
        }

        #endregion

        [TestMethod]
        public void PublishTweet_TweetLessThan140Signs_Published()
        {
            var message = string.Format("Message:{0}", DateTime.Now.ToLongTimeString());

            var _navigationBar = MefContainer.Container.GetExport<INavigationBar>().Value;
            _navigationBar.GoToNewTweet();

            var _messagesPageObject = MefContainer.Container.GetExport<ICreateTweetPageObject>().Value;
            _messagesPageObject.PutMessage(message);

            _messagesPageObject.Publish();

            var _homePageObject = MefContainer.Container.GetExport<ITweetsStreamPageObject>().Value;
            var lastMessage = _homePageObject.GetLastTweet();

            Assert.AreEqual<string>(message, lastMessage);
        }

        [TestMethod]
        public void PublishTweet_TweetMoreThan140Signs_CannotPublish()
        {
            var message = new StringBuilder();
            while (message.Length <= 140)
            {
                message.Append(message.Length);
            }

            var _navigationBar = MefContainer.Container.GetExport<INavigationBar>().Value;
            _navigationBar.GoToNewTweet();

            var _messagesPageObject = MefContainer.Container.GetExport<ICreateTweetPageObject>().Value;
            _messagesPageObject.PutMessage(message.ToString());

            var result = _messagesPageObject.CanPublish();

            Assert.IsFalse(result);
        }
    }
}
