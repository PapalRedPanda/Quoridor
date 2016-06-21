using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    /// <summary>
    /// A space is one square on the board. The board is an array of spaces.
    /// Each space has multiple characteristics as fields:
    /// The ability to be occupied by a player's pawn, the ability to have walls to the east and south of it, and each
    /// space can have the distinction of being on the bottommost row and/or the rightmost column of the board. Every space has 
    /// a corresponding name.
    /// 
    /// Methods:
    /// AddWall()
    /// </summary>
    class Space
    {
        int occupied; //0 if unoccupied, 1 if player 1, 2 if player 2, 3 if player 3, 4 if player 4
        bool eastWall = false;  //true if there is a wall in the interstice directly east of this space on the board
        bool southWall = false; //true if there is a wall in the interstice directly south of this space on the board
        bool southmostSpace; //true if this space is on the bottommost row on the board. If so, southWall will always be false
        bool eastmostSpace; //true if this space is on the rightmost column on the board. If so, eastWall will always be false
        string name; //ex: e4 (it's the space's notation)

        //Properties
        //Occupied needs to be changed outside of Space class to account for the movement of the players
        public int Occupied
        {
            get { return occupied; }
            set { occupied = value; }
        }
        //These properties don't need to be changed outside of this class (outside of the constructor and AddWall() )
        public bool EastWall
        {
            get { return eastWall; }
        }
        public bool SouthWall
        {
            get { return southWall; }
        }
        public bool SouthmostSpace
        {
            get { return southmostSpace; }
        }
        public bool EastmostSpace
        {
            get { return eastmostSpace; }
        }
        public string Name
        {
            get { return name; }
        }

        //A basic call to the constructor with no arguments will result in a space that isn't on the bottommost row or rightmost collumn
        //and the space will be unoccupied without walls to the south or east of it
        public Space(bool east = false, bool south = false, int occupied = 0)
        {
            eastmostSpace = east;
            southmostSpace = south;
            this.occupied = occupied;
        }

        //Only adds a wall if it can (it won't add a wall south of a space on the bottom row)
        //southPosition: True: add south wall; False: add east wall
        public void AddWall(bool southPosition)
        {
            if (southPosition && !southmostSpace)
            {
                southWall = true;
            }
            else if (!southPosition && !eastmostSpace)
            {
                eastWall = true;
            }
        }
    }
}
