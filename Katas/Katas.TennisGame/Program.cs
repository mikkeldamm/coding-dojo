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

        private static string _game1Player1;
        private static string _game1Player2;
        private static string _game2Player1;
        private static string _game2Player2;

        static void Main(string[] args)
        {
            // Tennis Game 1
            _game1Player1 = "player1";
            _game1Player2 = "player2";
            _tennisScoreBoardGame1 = new TennisScoreBoard(_game1Player1, _game1Player2, new WatchSender());
            _tennisScoreBoardGame1.SetPlayerThatHasGarminWatch(_game1Player1);

            // Tennis Game 1
            _game2Player1 = "player1";
            _game2Player2 = "player2";

            _tennisScoreBoardGame2 = new TennisScoreBoard(_game2Player1, _game2Player2, new WatchSender());
            _tennisScoreBoardGame2.SetPlayerThatHasGarminWatch(_game2Player2);

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
            var wonPoints = new[] { _game1Player1, _game1Player1, _game1Player2, _game1Player1, _game1Player2, _game1Player1 };

            Console.WriteLine("Game1: ----- start ----");

            await PlayGame(_tennisScoreBoardGame1, wonPoints, "Game1");
        }

        private static async Task startGame2()
        {
            var wonPoints = new[] { _game2Player2, _game2Player1, _game2Player2, _game2Player1, _game2Player2, _game2Player1, _game2Player2, _game2Player1, _game2Player1, _game2Player2, _game2Player2, _game2Player1, _game2Player2, _game2Player2 };

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
