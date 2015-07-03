using System.Collections.Generic;
using Shouldly;

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

        private string _matchScore;

        public string MatchScore
        {
            get
            {
                return _matchScore;
            }
            set
            {
                _matchScore = value;
                SendScoreToWatch();
            }
        }
        public string StringScore
        {
            get
            {
                switch (TeamPoints)
                {
                    case 0:
                        return "Love";
                    case 1:
                        return "Fifteen";
                    case 2:
                        return "Thirty";
                    case 3:
                        return "Forty";
                    default:
                        return string.Empty;
                }
            }
        }

        public void SendScoreToWatch()
        {
            foreach (var player in Players)
            {
                player.SendScoreToWatch(MatchScore);
            }
        }

        public void WonPoint(int point)
        {
            TeamPoints += point;
        }
    }
}