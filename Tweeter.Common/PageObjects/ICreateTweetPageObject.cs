namespace Tweeter.Common.PageObjects
{
    public interface ICreateTweetPageObject
    {
        void PutMessage(string message);
        void Publish();
        bool CanPublish();
    }
}
