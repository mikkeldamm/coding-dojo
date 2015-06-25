namespace Katas.TennisDojo
{
    public class GarminWatchSender
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }
}
