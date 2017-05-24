namespace Tweeter.Common
{
    public interface IRunner
    {
        IAppSession Run();
        void Close();
    }
}
