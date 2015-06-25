using System;
using System.Net;

namespace Katas.TennisDojo
{
    public class FakeApiPost
    {
        public void Send(dynamic postData)
        {
            FakeNoConnection();

            Console.WriteLine("--- Garmin: Send to: " + postData.player);
            Console.WriteLine("--- Garmin: Send complete \"The score is now: " + postData.score + "\"");
        }

        private void FakeNoConnection()
        {
            var randomGenerator = new Random();
            var randomNumber = randomGenerator.Next(0, 800);

            if (randomNumber < 2)
            {
                throw new HttpListenerException(408, "Request Timeout");
            }
        }
    }
}
