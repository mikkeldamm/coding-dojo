using System.Collections.Generic;

namespace Katas.TennisDojo
{
    public class Team
    {
        public Team(Player p1, Player p2)
        {
            Players = new List<Player>();
            Players.AddRange(new List<Player> {p1, p2});
            
        }

        public int TeamPoints { get; set; }
        public List<Player> Players{ get; set; }

        public string Score { get; set; }

        public void SendScoreToWatch()
        {
            foreach (var player in Players)
            {
                player.SendScoreToWatch(Score);
            }
        }

        public void SetScore(string score)
        {
            Score = score;
            SendScoreToWatch();
        }
    }
}