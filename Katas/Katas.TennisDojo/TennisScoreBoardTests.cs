using Moq;
using Shouldly;
using Xunit;

namespace Katas.TennisDojo
{
    public class TennisScoreBoardTests
    {
        private readonly TennisScoreBoard _scoreBoard;

        public TennisScoreBoardTests()
        {
            var garminWatcher = new Mock<IWatcher>();
            var appleWatch = new Mock<IWatcher>();
            var player1 = new Player { Name = "player 1", Watch = garminWatcher.Object };
            var player2 = new Player { Name = "player 2", Watch = appleWatch.Object };
            var player3 = new Player {Name = "player 3"};
            var player4 = new Player { Name = "player 4", Watch = garminWatcher.Object };
            

            var team1 = new Team(player1, player2);
            var team2 = new Team(player3, player4);
            _scoreBoard = new TennisScoreBoard(team1, team2, garminWatcher.Object);
        }

        [Theory]
        [InlineData(0, 0, "Love-All")]
        [InlineData(1, 1, "Fifteen-All")]
        [InlineData(2, 2, "Thirty-All")]
        [InlineData(3, 3, "Deuce")]
        public void GetScore_IfBothPointsAreEqual(int score1, int score2, string expected)
        {
            _scoreBoard.SetP1Score(score1);
            _scoreBoard.SetP2Score(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, "Fifteen-Love")]
        [InlineData(2, "Thirty-Love")]
        [InlineData(3, "Forty-Love")]
        public void GetScore_Player1GetScore(int score1, string expected)
        {
            _scoreBoard.SetP1Score(score1);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(1, "Love-Fifteen")]
        [InlineData(2, "Love-Thirty")]
        [InlineData(3, "Love-Forty")]
        public void GetScore_Player2GetScore(int score1, string expected)
        {
            _scoreBoard.SetP2Score(score1);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(2, 1, "Thirty-Fifteen")]
        [InlineData(3, 1, "Forty-Fifteen")]
        [InlineData(3, 2, "Forty-Thirty")]
        public void GetScore_Player1MorePointsThanPlayer2(int score1, int score2, string expected)
        {
            _scoreBoard.SetP1Score(score1);
            _scoreBoard.SetP2Score(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }
        [Theory]
        [InlineData(1, 2, "Fifteen-Thirty")]
        [InlineData(1, 3, "Fifteen-Forty")]
        [InlineData(2, 3, "Thirty-Forty")]
        public void GetScore_Player2MorePointsThanPlayer1(int score1, int score2, string expected)
        {
            _scoreBoard.SetP1Score(score1);
            _scoreBoard.SetP2Score(score2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Theory]
        [InlineData(4, 3, "Advantage player1")]
        [InlineData(5, 4, "Advantage player1")]
        [InlineData(6, 5, "Advantage player1")]
        [InlineData(11, 10, "Advantage player1")]
        [InlineData(3, 4, "Advantage player2")]
        [InlineData(4, 5, "Advantage player2")]
        [InlineData(5, 6, "Advantage player2")]
        [InlineData(10, 11, "Advantage player2")]
        [InlineData(4, 2, "Win for player1")]
        [InlineData(5, 3, "Win for player1")]
        [InlineData(11, 9, "Win for player1")]
        [InlineData(2, 4, "Win for player2")]
        [InlineData(3, 5, "Win for player2")]
        [InlineData(9, 11, "Win for player2")]
        public void FinalGamePlay(int player1, int player2, string expected)
        {
            _scoreBoard.SetP1Score(player1);
            _scoreBoard.SetP2Score(player2);
            _scoreBoard.GetScore().ShouldBe(expected);
        }

        [Fact]
        public void RealisticGamePlayers()
        {
            _scoreBoard.WonPoint("player1");
            _scoreBoard.WonPoint("player1");
            _scoreBoard.WonPoint("player2");
            _scoreBoard.WonPoint("player2");
            _scoreBoard.WonPoint("player1");
            _scoreBoard.WonPoint("player2");
            _scoreBoard.WonPoint("player1");
            _scoreBoard.WonPoint("player2");
            _scoreBoard.WonPoint("player1");
            _scoreBoard.WonPoint("player2");
            _scoreBoard.GetScore().ShouldBe("Deuce");
        }
    }
}
