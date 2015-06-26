namespace Katas.TennisDojo
{
    public class WatchSender : IWatcher
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }

    public class AppleWatchSender : IWatcher
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }
}
