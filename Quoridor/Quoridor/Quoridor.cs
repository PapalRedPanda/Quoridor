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
        bool twoPlayerGame;
        Player currentPlayer;

        //Constructor
        public Quoridor(MainForm hackTheMainframe)
        {
            mainForm = hackTheMainframe;
            //At this point, we need to get how many players are playing (2 or 4).
            //In my previous experience, I would just do this within the console (Console.ReadLine())
            //But it may have to be done differently now that we are doing GUI. After we get that information,
            //we can create the player objects with names and put them in the array "players".
        }

        public bool TwoPlayerGame
        {
            get { return twoPlayerGame; }
            set
            {
                twoPlayerGame = value;
                switch (twoPlayerGame)
                {
                    case true:
                        players = new Player[2];
                        for (int i = 0; i < 2; i++)
                        {
                            players[i] = new Player("Player " + i, i + 1, twoPlayerGame);
                            //players[i].Walls = 10;  This is done automatically in the Player Constructor
                        }
                        break;
                    case false:
                        players = new Player[4];
                        for (int i = 0; i < 4; i++)
                        {
                            players[i] = new Player("Player ", i + 1, twoPlayerGame);
                            //players[i].Walls = 10; This is done automatically in the Player Constructor
                        }
                        break;
                }
                gameBoard = new Board(twoPlayerGame);
                currentPlayer = players[0];
            }
        }
    }
}
