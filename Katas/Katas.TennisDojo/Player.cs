using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.TennisDojo
{
    public class Player
    {
        public string Name { get; private set; }
        public bool GotAWatch { get; private set; }

        

        public Player(string _name, bool _gotAWatch)
        {
            Name = _name;
            GotAWatch = _gotAWatch;
        }
    }

    public class Team
    {
        public string Result { get; private set; }
        public int Point { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Team(string player1Name,bool player1GotAWatch, string player2Name, bool player2GotAWatch)
        {
            Point = 0;
            Result = "";
            Player1 = new Player(player1Name);
            Player2 = new Player(player2Name);
        }

        public Team(string player1Name)
        {
            Point = 0;
            Result = "";
            Player1 = new Player(player1Name);
        }
    }
}
