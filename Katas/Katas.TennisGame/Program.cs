using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Katas.TennisDojo;

namespace Katas.TennisGame
{
    class Program
    {
        private static TennisScoreBoard _tennisScoreBoardGame1;
        private static TennisScoreBoard _tennisScoreBoardGame2;

        private static Team _team1;
        private static Team _team2;
        private static Player _player1;
        private static Player _player2;
        private static Player _player3;
        private static Player _player4;

        //private static string _game1Player1;
        //private static string _game1Player2;
        //private static string _game2Player1;
        //private static string _game2Player2;

        static void Main(string[] args)
        {
            // Tennis Game 1
            _player1 = new Player{Name = "player1", Watch = new AppleWatchSender()};
            _player2 = new Player{Name = "player2", Watch = new AppleWatchSender()};
            _player3 = new Player { Name = "player3", Watch = new AppleWatchSender() };
            _player4 = new Player { Name = "player4", Watch = new AppleWatchSender() };
            _team1 = new Team(_player1,_player2);
            _team2 = new Team(_player3, _player4);
            _tennisScoreBoardGame1 = new TennisScoreBoard(_team1, _team2);

            // Tennis Game 1

            _tennisScoreBoardGame2 = new TennisScoreBoard(_team2, _team1);

            // Start games
            Task.Run(() =>
            {
                var task1 = startGame1();
                var task2 = startGame2();

                Task.WaitAll(task1, task2);
            });

            Console.ReadLine();
        }

        private static async Task startGame1()
        {
            var wonPoints = new[] { _player1.Name, _player1.Name, _player3.Name, _player4.Name, _player2.Name, _player1.Name };

            Console.WriteLine("Game1: ----- start ----");

            await PlayGame(_tennisScoreBoardGame1, wonPoints, "Game1");
        }

        private static async Task startGame2()
        {
            var wonPoints = new[] { _player2.Name, _player1.Name, _player3.Name, _player4.Name, _player2.Name, _player1.Name, _player1.Name, _player1.Name, _player1.Name, _player1.Name, _player1.Name, _player2.Name, _player3.Name, _player4.Name};

            Console.WriteLine("Game2: ----- start ----");

            await PlayGame(_tennisScoreBoardGame2, wonPoints, "Game2");
        }

        private static async Task PlayGame(TennisScoreBoard board, IEnumerable<string> wonPoints, string gameName)
        {
            board.GetScore().WriteLine(gameName + ": {0}");

            foreach (var pointWinner in wonPoints)
            {
                var player = pointWinner;

                await Task.Run(() =>
                {
                    var rdn = new Random();
                    Task.Delay((rdn.Next(1, 6)*1000)).Wait();

                    board.WonPoint(player);
                    board.GetScore().WriteLine(gameName + ": {0}");
                });
            }
        }
    }

    public static class ConsoleExtensions
    {
        public static void WriteLine(this string str, string format = null)
        {
            var line = str;
            if (format != null)
            {
                line = string.Format(format, str);
            }

            Console.WriteLine(line);
        }
    }
}
