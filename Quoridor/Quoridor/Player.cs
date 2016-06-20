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

        //Properties
        //To access the Player fields, instead just use the capitalized versions of the fields as normal variables
        //I made it so only the walls can be changed because your name and player number isn't going to change mid-game
        public int Walls
        {
            get { return walls; }
            set { walls = value; }
        }
        public int PlayerNumber
        {
            get { return playerNumber; }
        }
        public string Name
        {
            get { return name; }
        }

        //Constructor
        //If the game has 2 players, twoPlayerGame = true, else if the game has 4 players, twoPlayerGame = false
        public Player(string playerName, int number, bool twoPlayerGame)
        {
            name = playerName;
            playerNumber = number;
            walls = twoPlayerGame ? 10 : 5; //Each player gets 10 walls in a 2-player game, 5 in a 4-player game
        }
    }
}
