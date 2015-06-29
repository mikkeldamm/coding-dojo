namespace Katas.TennisDojo
{
    public class WatchSender : ISportsWatch
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }

    public class AppleWatchSender : ISportsWatch
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }
}
