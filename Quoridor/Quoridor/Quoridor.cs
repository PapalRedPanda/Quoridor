using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    /// <summary>
    /// runs the game and contains all game info. MainForm will pull info from here to display to player
    /// </summary>
    class Quoridor
    {
        Board gameBoard;
        Player[] players;
        MainForm mainForm;

        //Constructor
        public Quoridor(MainForm hackTheMainframe)
        {
            gameBoard = new Board();
            mainForm = hackTheMainframe;
            //At this point, we need to get how many players are playing (2 or 4).
            //In my previous experience, I would just do this within the console (Console.ReadLine())
            //But it may have to be done differently now that we are doing GUI. After we get that information,
            //we can create the player objects with names and put them in the array "players".
        }
    }
}
