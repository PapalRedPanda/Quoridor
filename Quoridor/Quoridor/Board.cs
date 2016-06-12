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
    ///     2. The second array would be an 8x9 (or 1x72) array to store one category of walls.
    ///         > if possible player positions are [] and wall positions are <> then each row will look like []<>[]<>[]<>[]<>[]<>[]<>[]<>[]<>[]
    ///         The array would store all the possible values of <>
    ///     3. The third array would be a 9x8 (or 1x72) array to store the other category of walls.
    ///         > each column looks like
    ///         []
    ///         <>
    ///         []
    ///         ...
    ///         The third array would conatins all the <> in columns.
    ///         
    ///     The reason for seperating the walls into two arrays is it would be easy to seperate them into player moves horizantally (wall category 1) or player moves vertically (wall category 2)
    ///     
    /// 
    /// T - Ok, I'm not sure I understand everything you said.
    ///     What I was thinking of initially is have the board be a 2D array of Spaces (the object). Spaces will have two boolean fields that relate to the 
    ///     right and bottom portions of the space. True would mean that a wall would occupy that space. When you place a wall, one field will turn from false to true
    ///     on two adjacent spaces
    ///     
    /// B - So from your idea I'm imaging the board looking like:
    ///     
    ///     [ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]
    ///      F   F   F   F   F   F   F   F   F
    ///     [ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]
    ///      F   F   F   F   F   F   F   F   F
    ///     ... 6 more times
    ///     [ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ]F[ ] - How would the last row and last column work?
    ///     
    ///     Where the F represents the true/false boolean with all booleans initialized to false.
    /// 
    ///   
    /// B - We may not need a whole 1x81 playerPos array, it may be better to just have two values stored and constantly changed. One for player 1 and 1 for player 2.
    /// </summary>
    class Board
    {
        int[] playerPos;
        int[] rowWallPos;
        int[] colWallPos;

        // number of positions in each wall array 
        const int wallPosNum = 72;

        /// <summary>
        /// initializes the board
        /// </summary>
        Space[,] board = new Space[9, 9]; //This is more what I was thinking, what do you think?

        public Board()
        {
            // intiialize all arrays to be full of 0s
            playerPos = new int[2];
            for (int i = 0; i < playerPos.Length; i++)
            {
                playerPos[i] = 0;
            }

            rowWallPos = new int[wallPosNum];
            for (int i = 0; i < rowWallPos.Length; i++)
            {
                rowWallPos[i] = 0;
            }

            colWallPos = new int[wallPosNum];
            for (int i = 0; i < colWallPos.Length; i++)
            {
                colWallPos[i] = 0;
        }
    }

        /// <summary>
        /// place a wall in the 
        /// </summary>
        /// <param name="wallType"> 0 for row wall, 1 for column wall </param>
        /// <param name="position"> position of wall </param>
        /// <returns> 0 for success and 1 for fail </returns>
        public int placeWall(int wallType, int position)
        {
            if (wallType == 0 && position < wallPosNum)
            {
                rowWallPos[position] = 1;
                return 0;
            }
            else if (wallType == 1 && position < wallPosNum)
            {
                colWallPos[position] = 1;
                return 0;
            }
            return 1;
        }

        // get wall arrays methods

        // set wall arrays methods
    }
}
