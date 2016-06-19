﻿using System;
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
    /// T - Yeah, we would just ignore the "south" fields on the spaces in the bottom row and the "east" fields in the spaces in the far right collumn. 
    ///     We would just have to make sure that those fields never become true (or always stay true. Basically make sure they don't change). 
    ///     In fact, that might not be hard to do.
    ///   
    /// B - We may not need a whole 1x81 playerPos array, it may be better to just have two values stored and constantly changed. One for player 1 and 1 for player 2.
    /// </summary>
    class Board
    {
        int[] playerPos;

        // number of positions in each wall array 
        const int wallPosNum = 72;

        /// <summary>
        /// initializes the board
        /// </summary>
        Space[,] board = new Space[9, 9]; //This is more what I was thinking, what do you think?

        public Board( bool twoPlayerGame )
        {
            //Create all the spaces in the board
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    bool farRight = j == 8 ? true : false;
                    bool farBottom = i == 8 ? true : false;
                    board[i, j] = new Space(farRight, farBottom);
                }
            }
        }

        //Just like the Quoridor wikipedia article, each wall placed is given a square (row and column) and an orientation (h/v)
        //the row/col is determined by the space to the top-left of the wall being placed
        //        >[]|[] >[][]    the arrow is pointing to the space that corresponds to that wall (left one is vertical, right one is horizontal)
        //         []|[]  ----
        //                [][] 
        public void placeWall(bool horizontal, int row, int col)
        {
            if (row < 8 && col < 8)
            {
                board[row, col].AddWall(horizontal);
                if (horizontal)
                {
                    board[row, col + 1].AddWall(horizontal);
                }
                else
                {
                    board[row + 1, col].AddWall(horizontal);
                }
            }
        }
        // get wall arrays methods

        // set wall arrays methods
    }
}
