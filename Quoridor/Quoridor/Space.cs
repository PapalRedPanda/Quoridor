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
        bool southWall = false;
        string name; //ex: e4 (it's the space's notation)
    }
}
