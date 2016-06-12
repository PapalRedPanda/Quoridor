using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    /// <summary>
    /// class will contain board data. Data includes pawn and wall placement.
    /// 
    /// B - I have an idea to store the board as three different types of 1D arrays.
    ///     1. The first array would be a 9x9 array to store player positions. We could easily flatten it into a 1x81
    ///     2. The second array would be an 8x9 array to store one category of walls.
    ///         > if possible player positions are [] and wall positions are <> then each row will look like []<>[]<>[]<>[]<>[]<>[]<>[]<>[]<>[]
    ///         The array would store all the possible values of <>
    ///     3. The third array would be a 9x8 array to store the other category of walls.
    ///         > each column looks like
    ///         []
    ///         <>
    ///         []
    ///         ...
    ///         The third array would conatins all the <> in columns.
    ///         
    ///     The reason for seperating the walls into two arrays is it would be easy to seperate them into player moves horizantally (wall category 1) or player moves vertically (wall category 2)
    ///     
    /// </summary>
    class Board
    {
        int[] playerPos;
        int[] rowWallPos;
        int[] colWallPos;

        public Board()
        {

        }
    }
}
