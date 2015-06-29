namespace Katas.TennisDojo
{
    public class Player
    {
        public string Name { get; set; }
        public ISportsWatch Watch { get; set; }
        public void SendScoreToWatch(string score)
        {
            if(Watch != null)
                Watch.Send(score, Name);
        }
    }
}
