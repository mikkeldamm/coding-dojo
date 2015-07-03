using Moq;
using Shouldly;
using Xunit;

namespace Katas.TennisDojo
{
    public class TennisScoreBoardTests
    {
        private readonly TennisScoreBoard _scoreBoard;
        private Team _team1;
        private Team _team2;

        public TennisScoreBoardTests()
        {
            var garminWatcher = new Mock<ISportsWatch>();
            var appleWatch = new Mock<ISportsWatch>();
            var player1 = new Player { Name = "player 1", Watch = garminWatcher.Object };
            var player2 = new Player { Name = "player 2", Watch = appleWatch.Object };
            var player3 = new Player {Name = "player 3"};
            var player4 = new Player { Name = "player 4", Watch = garminWatcher.Object };
            

            _team1 = new Team(player1, player2);
            _team2 = new Team(player3, player4);
            _scoreBoard = new TennisScoreBoard(_team1, _team2);
        }

        [Theory]
        [InlineData(0, 0, "Love-All")]
        [InlineData(1, 1, "Fifteen-All")]
        [InlineData(2, 2, "Thirty-All")]
        [InlineData(3, 3, "Deuce")]
        public void GetScore_IfBothPointsAreEqual(int score1, int score2, string expected)
        {
            _team1.WonPoint(score1);
            _team2.WonPoint(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, "Fifteen-Love")]
        [InlineData(2, "Thirty-Love")]
        [InlineData(3, "Forty-Love")]
        public void GetScore_Player1GetScore(int score1, string expected)
        {
            _team1.WonPoint(score1);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, "Love-Fifteen")]
        [InlineData(2, "Love-Thirty")]
        [InlineData(3, "Love-Forty")]
        public void GetScore_Player2GetScore(int score1, string expected)
        {
            _team2.WonPoint(score1);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(2, 1, "Thirty-Fifteen")]
        [InlineData(3, 1, "Forty-Fifteen")]
        [InlineData(3, 2, "Forty-Thirty")]
        public void GetScore_Player1MorePointsThanPlayer2(int score1, int score2, string expected)
        {
            _team1.WonPoint(score1);
            _team2.WonPoint(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }
        [Theory]
        [InlineData(1, 2, "Fifteen-Thirty")]
        [InlineData(1, 3, "Fifteen-Forty")]
        [InlineData(2, 3, "Thirty-Forty")]
        public void GetScore_Player2MorePointsThanPlayer1(int score1, int score2, string expected)
        {
            _team1.WonPoint(score1);
            _team2.WonPoint(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(4, 3, "Advantage Team 1")]
        [InlineData(5, 4, "Advantage Team 1")]
        [InlineData(6, 5, "Advantage Team 1")]
        [InlineData(11, 10, "Advantage Team 1")]
        [InlineData(3, 4, "Advantage Team 2")]
        [InlineData(4, 5, "Advantage Team 2")]
        [InlineData(5, 6, "Advantage Team 2")]
        [InlineData(10, 11, "Advantage Team 2")]
        [InlineData(4, 2, "Win for Team 1")]
        [InlineData(5, 3, "Win for Team 1")]
        [InlineData(11, 9, "Win for Team 1")]
        [InlineData(2, 4, "Win for Team 2")]
        [InlineData(3, 5, "Win for Team 2")]
        [InlineData(9, 11, "Win for Team 2")]
        public void FinalGamePlay(int team1, int team2, string expected)
        {
            _team1.WonPoint(team1);
            _team2.WonPoint(team2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Fact]
        public void RealisticGamePlayers()
        {
            _team1.WonPoint(1);
            _team1.WonPoint(1);
            _team2.WonPoint(1);
            _team2.WonPoint(1);
            _team1.WonPoint(1);
            _team2.WonPoint(1);
            _team1.WonPoint(1);
            _team2.WonPoint(1);
            _team1.WonPoint(1);
            _team2.WonPoint(1);
            _scoreBoard.GetScore().ShouldBe("Deuce");
        }
    }
}
