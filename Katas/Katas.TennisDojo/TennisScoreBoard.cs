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
            if (GetEvenScore() != string.Empty) return GetEvenScore();

            if(ScoreIsDeuce() != string.Empty)return GetEvenScore();

            if(Team1ScoreIsLove() != string.Empty) return Team1ScoreIsLove();

            if(Team2ScoreIsLove() != string.Empty) return Team2ScoreIsLove();

            if(Team1IsAhead() != string.Empty) return Team1IsAhead();

            score = Team2IsAhead();

            score = Team1Advantage();

            score = Team2Advantage();

            score = Team1Wins();

            score = Team2Wins();

            _team1.SetScore(score);
            _team2.SetScore(score);

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

        private string Team2IsAhead()
        {
            var team2Res = string.Empty;
            var team1Res = string.Empty;

            if (_team2.TeamPoints > _team1.TeamPoints && _team2.TeamPoints < 4)
            {
                if (_team2.TeamPoints == 2)
                    team2Res = "Thirty";
                if (_team2.TeamPoints == 3)
                    team2Res = "Forty";
                if (_team1.TeamPoints == 1)
                    team1Res = "Fifteen";
                if (_team1.TeamPoints == 2)
                    team1Res = "Thirty";

                return team1Res + "-" + team2Res;
            }

            return string.Empty;
        }

        private string Team1IsAhead()
        {
            var team2Res = string.Empty;
            var team1Res = string.Empty;

            if (_team1.TeamPoints > _team2.TeamPoints && _team1.TeamPoints < 4)
            {
                if (_team1.TeamPoints == 2)
                    team1Res = "Thirty";
                if (_team1.TeamPoints == 3)
                    team1Res = "Forty";
                if (_team2.TeamPoints == 1)
                    team2Res = "Fifteen";
                if (_team2.TeamPoints == 2)
                    team2Res = "Thirty";

                return team1Res + "-" + team2Res;
            }

            return string.Empty;
        }

        private string Team1ScoreIsLove()
        {
            if (_team1.TeamPoints == 0 && _team2.TeamPoints > 0)
            {
                if (_team2.TeamPoints == 1)
                    return  "Love-Fifteen";
                if (_team2.TeamPoints == 2)
                    return "Love-Thirty";
                if (_team2.TeamPoints == 3)
                    return "Love-Forty";
            }
            return string.Empty;
        }

        private string Team2ScoreIsLove()
        {
            if (_team2.TeamPoints == 0 && _team1.TeamPoints > 0)
            {
                if (_team1.TeamPoints == 1)
                    return "Fifteen-Love";
                if (_team1.TeamPoints == 2)
                    return "Thirty-Love";
                if (_team1.TeamPoints == 3)
                    return  "Forty-Love";
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
