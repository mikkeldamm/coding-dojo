namespace Katas.TennisDojo
{
    public class TennisScoreBoard
    {
        private Team Team1;
        private Team Team2;

        public string P1res = "";
        public string P2res = "";

        private string playerWithGarminWatch = null;

        public TennisScoreBoard(string player1Name, string player2Name, string player3Name, string player4Name)
        {
            Team1 = new Team(player1Name, player2Name);
            Team2 = new Team(player3Name, player4Name);
        }

        public TennisScoreBoard(string player1Name, string player2Name)
        {
            Team1 = new Team(player1Name);
            Team2 = new Team(player2Name);
        }

        public string GetPoints(int PlayerPoints)
        {
            switch (PlayerPoints)
            {
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";

                default:
                    return "Love";
            }
        }

        public string GetScore()
        {
            string score = "";

            if (Team1.Point == Team2.Point && Team1.Point < 3)
            {
                score = GetPoints(Team1.Point) + "-All";
            }

            if (Team1.Point == Team2.Point && Team1.Point > 2)
                score = "Deuce";

            if (Team1.Point > 0 && Team2.Point == 0)
            {
                P1res = GetPoints(Team1.Point);

                P2res = "Love";
                score = P1res + "-" + P2res;
            }

            if (Team2.Point > 0 && Team1.Point == 0)
            {
                P2res = GetPoints(Team2.Point);

                P1res = "Love";
                score = P1res + "-" + P2res;
            }

            if (Team1.Point > Team2.Point && Team1.Point < 4)
            {
                P1res = GetPoints(Team1.Point);
                P2res = GetPoints(Team2.Point);

                score = P1res + "-" + P2res;
            }

            if (Team2.Point > Team1.Point && Team2.Point < 4)
            {
                P1res = GetPoints(Team1.Point);
                P2res = GetPoints(Team2.Point);

                score = P1res + "-" + P2res;
            }

            if (Team1.Point > Team2.Point && Team2.Point >= 3)
            {
                score = "Advantage Team1";
            }

            if (Team2.Point > Team1.Point && Team1.Point >= 3)
            {
                score = "Advantage Team2";
            }

            if (Team1.Point >= 4 && Team2.Point >= 0 && (Team1.Point - Team2.Point) >= 2)
            {
                score = "Win for Team1";
            }

            if (Team2.Point >= 4 && Team1.Point >= 0 && (Team2.Point - Team1.Point) >= 2)
            {
                score = "Win for Team2";
            }

            SendScoreToTeam(playerWithGarminWatch);

            return score;
        }

        public void SendScoreToTeam(Team team)
        {
            
            sendToWatch(team.Player1, team.Result);
            sendToWatch(team.Player2, team.Result);

        }

        private void sendToWatch(Player player, string score )
        {
            if (player != null)
            {
                var sender = new GarminWatchSender();
                sender.Send(score, player.Name);
            }
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        public void P1Score()
        {
            P1point++;
        }

        public void P2Score()
        {
            P2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

        public void SetPlayerThatHasGarminWatch(string player)
        {
            playerWithGarminWatch = player;
        }
    }
}
