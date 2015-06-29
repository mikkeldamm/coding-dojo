namespace Katas.TennisDojo
{
    public class TennisScoreBoard
    {
        public int PlayerA = 0;
        public int PlayerB = 0;

        public string P1Res = "";
        public string P2Res = "";

        private readonly Team _team1;
        private readonly Team _team2;

        private string _playerWithWatch;
        private string _score;

        public TennisScoreBoard(Team team1, Team team2)
        {
            _team1 = team1;
            _team2 = team2;
        }

        public string GetScore()
        {
            _score = GetEvenScore();

            if (PlayerA == PlayerB && PlayerA > 2)
                _score = "Deuce";

            if (OnePlayersScoreIsLove(PlayerA, PlayerB, false)) return _score;

            if (OnePlayersScoreIsLove(PlayerB, PlayerA, true)) return _score;

            if (PlayerA > PlayerB && PlayerA < 4)
            {
                if (PlayerA == 2)
                    P1Res = "Thirty";
                if (PlayerA == 3)
                    P1Res = "Forty";
                if (PlayerB == 1)
                    P2Res = "Fifteen";
                if (PlayerB == 2)
                    P2Res = "Thirty";

                _score = P1Res + "-" + P2Res;
            }

            if (PlayerB > PlayerA && PlayerB < 4)
            {
                if (PlayerB == 2)
                    P2Res = "Thirty";
                if (PlayerB == 3)
                    P2Res = "Forty";
                if (PlayerA == 1)
                    P1Res = "Fifteen";
                if (PlayerA == 2)
                    P1Res = "Thirty";

                _score = P1Res + "-" + P2Res;
            }

            if (PlayerA > PlayerB && PlayerB >= 3)
            {
                _score = "Advantage player1";
            }

            if (PlayerB > PlayerA && PlayerA >= 3)
            {
                _score = "Advantage player2";
            }

            if (PlayerA >= 4 && PlayerB >= 0 && (PlayerA - PlayerB) >= 2)
            {
                _score = "Win for player1";
            }

            if (PlayerB >= 4 && PlayerA >= 0 && (PlayerB - PlayerA) >= 2)
            {
                _score = "Win for player2";
            }

            _team1.SetScore(_score);
            _team2.SetScore(_score);

            return _score;
        }

        private bool OnePlayersScoreIsLove(int playerAPoint, int playerBPoint, bool reverse)
        {
            if (playerAPoint > 0 && playerBPoint == 0)
            {
                if (playerAPoint == 1)
                    P1Res = "Fifteen";
                if (playerAPoint == 2)
                    P1Res = "Thirty";
                if (playerAPoint == 3)
                    P1Res = "Forty";

                P2Res = "Love";
                _score = reverse ? P2Res + "-" + P1Res : P1Res + "-" + P2Res;
                return true;
            }
            return false;
        }

        private string GetEvenScore()
        {
            if (_team1.TeamScore == _team2.TeamScore && _team1.TeamScore < 3)
            {
                if (_team1.TeamScore == 0)
                    _score = "Love";
                if (_team1.TeamScore == 1)
                    _score = "Fifteen";
                if (_team1.TeamScore == 2)
                    _score = "Thirty";
                _score += "-All";
            }
            return _score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                WonPoint(_team1);
            }
        }

        public void SetP2Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                WonPoint(_team2);
            }
        }

        //public void P1Score()
        //{
        //    PlayerA++;
        //}

        //public void P2Score()
        //{
        //    PlayerB++;
        //}

        public void WonPoint(Team team)
        {
            team.TeamScore++;
        }
    }
}
