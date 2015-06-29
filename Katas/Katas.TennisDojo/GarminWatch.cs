namespace Katas.TennisDojo
{
    public class GarminWatch : ISportsWatch
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }

    public class AppleWatch : ISportsWatch
    {
        public void Send(string score, string player)
        {
            var apiEndPoint = new FakeApiPost();
            apiEndPoint.Send(new { player, score });
        }
    }
}
