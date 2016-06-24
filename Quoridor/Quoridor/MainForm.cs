using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Quoridor
{
    public partial class MainForm : Form
    {
        // the picture displayed in 
        bool darkSkin; //Still needed?

        int currentDisplay;
        int tileSize;

        bool twoPlayerGame;

        Thread tick;
        Thread movement;
        Thread musicthread;

        System.Media.SoundPlayer gameMusic;

        Quoridor quoridorGame;

        Point cursorLocation;

        Board quoridorBoard;

        /// moved main into here because its what I saw in some videos
        static void Main(string[] args)
        {
            // designates the form as the main window for the application, application ends when it is closed
            Application.Run(new MainForm());
        }

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            // just default some stuff
            currentDisplay = 1;
            twoPlayerGame = true;

            tick = new Thread(gameTick);
            tick.Start();
            //movement.Start();
            musicthread = new Thread(playBackgroundMusic);

            gameMusic = new System.Media.SoundPlayer(Properties.Resources.Dungeon1);

            // form will contain the game and manipulate it. Again, it has to do with how forms are structured. Kinda weird. 
            // Also, we are giving access to the mainForm to quoridorGame. Super weird.
            quoridorGame = new Quoridor(this);
            quoridorBoard = quoridorGame.GameBoard;
        }

        /// <summary>
        /// not sure exactly what this does either but its necessary
        /// </summary>
        /// <param name="sender"> leave be </param>
        /// <param name="e"> leave be </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        const int TILESIZE = 63;

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // gets current mouse position
            cursorLocation = PointToClient(Cursor.Position);
            mousePositionHandler(cursorLocation.X, cursorLocation.Y);

            quoridorBoard = quoridorGame.GameBoard;

            // Another Idea for interacting with GUI is to have it be mouse controlled. When mouse hovers over a rectangle that is clickable, it will highlight in gold.
            // The issue here would be how we know we know which rectangles to check.
            // Could add another variable to space -> x and y locations. 
            // With constant sizes for player space and wall space, we could know exactly which player space or wall is being hovered over.

            // g is our servant whom we command to draw. It only operates within MainForm_Paint method.
            Graphics g = e.Graphics;

            // start screen
            if (currentDisplay == 1)
            {
                // currently hovering over two player mode
                if (twoPlayerGame)
                {
                    // we are asking our servant Mr. G for a golden rectangle at the two coordinates with a certain width and height
                    g.FillRectangle(Brushes.Gold, Width / 3, Height * (2f / 3f), 190f, 40f);
                }

                // currently hovering over four player mode
                else if (!twoPlayerGame)
                {
                    g.FillRectangle(Brushes.Gold, Width * (2f / 3f), Height * (2f / 3f), 190f, 40f);
                }

                // ask Mr. G to draw some text for us. Because we make the request after the rectangles are drawn above, they will become the top layer
                g.DrawString("Quoridor", SystemFonts.MenuFont, Brushes.Black, Width / 2 - 100, Height / 3);
                g.DrawString("Two Players", SystemFonts.MenuFont, Brushes.Black, Width / 3f, Height * (2f / 3f));
                g.DrawString("Four Players", SystemFonts.MenuFont, Brushes.Black, Width * (2f / 3f), Height * (2f / 3f));
            }
            // !!!! testing tile placement !!!!
            else if (currentDisplay == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        g.DrawRectangle(Pens.Black, quoridorBoard[i, j].Location.X, quoridorBoard[i, j].Location.Y, tileSize, tileSize);
                    }
                }
            }
        }

        /// <summary>
        /// Constantly keeps the graphics up to date. Was a huge pain to figure out so please enjoy :)
        /// </summary>
        private void gameTick()
        {
            while(true)
            {
                Invalidate();
                Thread.Sleep(16);
            }
        }

        /// <summary>
        /// Handles events dealing with current cursor placement
        /// Cursor always beats keystroke
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void mousePositionHandler(int x, int y)
        {
            // adds cursor functionality to start menu
            if (currentDisplay == 1)
            {
                if (x > Width / 3 && x < (Width / 3) + 190 && y > Height * (2f / 3f) && y < Height * (2f / 3f) + 40)
                {
                    twoPlayerGame = true;
                }
                if (x > Width * (2f / 3f) && x < (Width * (2f / 3f)) + 190 && y > Height * (2f / 3f) && y < Height * (2f / 3f) + 40)
                {
                    twoPlayerGame = false;
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) // UP key
            {
                Console.WriteLine("UP");
            }
            else if (e.KeyCode == Keys.Down) // DOWN key
            {
                Console.WriteLine("DOWN");
            }
            else if (e.KeyCode == Keys.Left) // LEFT key
            {
                Console.WriteLine("LEFT");
                if (currentDisplay == 1)
                {
                    twoPlayerGame = !twoPlayerGame;
                }
            }
            else if (e.KeyCode == Keys.Right) // RIGHT key
            {
                Console.WriteLine("RIGHT");
                if (currentDisplay == 1)
                {
                    twoPlayerGame = !twoPlayerGame;
                }
            }
            else if(e.KeyCode == Keys.W) //W key
            {
                Console.WriteLine("W");
                if(currentDisplay == 2)
                {
                    //if the current player has at least one wall left:
                    //maybe call a method that does:
                    //places a flashing wall at the top left of the board
                    //pressing 'r' rotates the wall
                    //you can use the arrow keys to move the flashing wall around
                    //as it moves, it turns red if the position is invalid, green in valid (if there is already a wall there)
                    //you aren't allowed to move the wall into a position that is off the board in any way
                    //pressing enter in a valid location places the wall there (we have to keep in mind placing rules
                    //with being no walls placed in such a way that completely blocks a player off from getting accross.)
                    //The current player subtracts one wall
                }
            }
            else if (e.KeyCode == Keys.Enter) // Enter key
            {
                if (currentDisplay == 1)
                {
                    quoridorGame.TwoPlayerGame = twoPlayerGame;
                    // move on to action screen
                    currentDisplay++;
                    //musicthread.Start();
                }
            }
            else if (e.KeyCode == Keys.Shift) // Shift key
            {
                if (currentDisplay == 2)
                {
                    darkSkin = !darkSkin;
                }
            }
            else if (e.KeyCode == Keys.Escape) // Escape Key
            {
                // pretty handy
                Application.Exit();
            }
            // redraws the screen. Tested the water of running a constant reInvalidation every n-milliseconds, 
            // but it caused a nasty flickering affect so I backed off. 
        }

        private void playBackgroundMusic()
        {
            gameMusic.PlayLooping();
        }
    }
}
