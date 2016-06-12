using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class Player
    {
        int walls; //Number of walls a player has left to use
        int playerNumber; //0: plr1, 1:plr2, 2:plr3, 3:plr4 (There can only be 2 or 4 players in a game)
        string name; //name of the player
    }
}
