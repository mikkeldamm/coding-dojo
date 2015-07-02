namespace Katas.TennisDojo
{
    public class TennisScoreBoard
    {
        public int PlayerA = 0;
        public int PlayerB = 0;

        //public string P1Res = "";
        //public string P2Res = "";

        private readonly Team _team1;
        private readonly Team _team2;

        private string _playerWithWatch;
        //private string _score;

        public TennisScoreBoard(Team team1, Team team2)
        {
            _team1 = team1;
            _team2 = team2;
        }

        public string GetScore()
        {
            var score = _team1.StringScore + "-" + _team2.StringScore;
            if (GetEvenScore() != string.Empty) score = GetEvenScore();

            if (ScoreIsDeuce() != string.Empty) score = ScoreIsDeuce();

            if(Team1Advantage() != string.Empty) score = Team1Advantage();

            if(Team2Advantage() != string.Empty) score = Team2Advantage();

            if(Team1Wins()!= string.Empty) score = Team1Wins();

            if(Team2Wins() != string.Empty) score = Team2Wins();

            _team1.MatchScore = score;
            _team2.MatchScore = score;

            return score;
        }

        private string ScoreIsDeuce()
        {
            if (_team1.TeamPoints == _team2.TeamPoints && _team1.TeamPoints > 2)
            {
                return "Deuce";
            }
            return string.Empty;
        }

        private string Team2Wins()
        {
            if (_team2.TeamPoints >= 4 && _team1.TeamPoints >= 0 && (_team2.TeamPoints - _team1.TeamPoints) >= 2)
            {
                return "Win for Team 2";
            }
            return string.Empty;
        }

        private string Team1Wins()
        {
            if (_team1.TeamPoints >= 4 && _team2.TeamPoints >= 0 && (_team1.TeamPoints - _team2.TeamPoints) >= 2)
            {
                return "Win for Team 1";
            }
            return string.Empty;
        }

        private string Team2Advantage()
        {
            if (_team2.TeamPoints > _team1.TeamPoints && _team1.TeamPoints >= 3)
            {
                return "Advantage Team 2";
            }
            return string.Empty;
        }

        private string Team1Advantage()
        {
            if (_team1.TeamPoints > _team2.TeamPoints && _team2.TeamPoints >= 3)
            {
                return "Advantage Team 1";
            }
            return string.Empty;
        }

        private string GetEvenScore()
        {
            if (_team1.TeamPoints != _team2.TeamPoints || _team1.TeamPoints >= 3) return string.Empty;
            if (_team1.TeamPoints == 0)
                return "Love-All";
            if (_team1.TeamPoints == 1)
                return "Fifteen-All";
            return _team1.TeamPoints == 2 ? "Thirty-All" : string.Empty;
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

        public void WonPoint(Team team)
        {
            team.TeamPoints++;
        }
    }
}
