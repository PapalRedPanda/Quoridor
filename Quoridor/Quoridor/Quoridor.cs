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
        const int TILEWIDTH = 110; // also change in main form
        const int TILEHEIGHT = 70; // also change in main form

        //Constructor
        public Quoridor(MainForm hackTheMainframe)
        {
            mainForm = hackTheMainframe;
        }

        public Board GameBoard
        {
            get{ return gameBoard; }
        }

        public bool TwoPlayerGame
        {
            get { return twoPlayerGame; }
            set //used once per game to set up the players and create the board
            {
                twoPlayerGame = value;
                switch (twoPlayerGame)
                {
                    case true:
                        players = new Player[2];
                        for (int i = 0; i < 2; i++)
                        {
                            players[i] = new Player("Player " + i, i + 1, twoPlayerGame);
                        }
                        break;
                    case false:
                        players = new Player[4];
                        for (int i = 0; i < 4; i++)
                        {
                            players[i] = new Player("Player ", i + 1, twoPlayerGame);
                        }
                        break;
                }
                gameBoard = new Board(twoPlayerGame);
                // set locations of tiles
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        gameBoard[i, j].Location = new System.Drawing.Point(110 + (i * TILEWIDTH), 25 + j * TILEHEIGHT);
                    }
                }
                currentPlayer = players[0];
            }
        }
    }
}
