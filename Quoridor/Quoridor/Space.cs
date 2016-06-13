using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    /// <summary>
    ///  B - not sure what you mean by space
    ///  T- A space is one square on the board. The board can be an array of spaces
    /// </summary>
    class Space
    {
        int occupied = 0; //0 if unoccupied, 1 if player 1, 2 if player 2, 3 if player 3, 4 if player 4
        bool eastWall = false;
        bool southWall = false; // what if the space has no south or east wall? just set it as true maybe?
        bool southmostSpace;
        bool eastmostSpace;
        string name; //ex: e4 (it's the space's notation)

        public Space(bool east = false, bool south = false)
        {
            eastmostSpace = east;
            southmostSpace = south;
        }

        //Only adds a wall if it can (it won't add a wall south of a space on the bottom row)
        //southPosition: True: add south wall; False: add east wall
        public void AddWall(bool southPosition)
        {
            if (southWall && !southmostSpace)
            {
                southWall = true;
            }
            else if (!southWall && !eastmostSpace)
            {
                eastWall = true;
            }
        }
    }
}
