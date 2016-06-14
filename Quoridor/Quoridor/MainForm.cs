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
        // the position of the behemoth on the window
        int x;
        int y;

        int velX;
        int velY;

        // the picture displayed in 
        Boolean darkSkin;

        int currentDisplay;
        int startScreenSelected;

        Boolean twoPlayerGame;

        Thread tick;
        Thread movement;

        /// moved main into here because its what I saw in some videos
        static void Main(string[] args)
        {
            // designates the form as the main window for the application, application ends when it is closed
            Application.Run(new MainForm());
        }

        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            // just default some stuff
            x = 200;
            y = 200;
            velX = 5;
            velY = -2;
            darkSkin = false;
            currentDisplay = 1;
            startScreenSelected = 0;
            twoPlayerGame = false;

            tick = new Thread(gameTick);
            tick.Start();
            movement = new Thread(movementThread);
            movement.Start();

            // form will contain the game and manipulate it. Again, it has to do with how forms are structured. Kinda weird. 
            // Also, we are giving access to the mainForm to quoridorGame. Super weird.
            Quoridor quoridorGame = new Quoridor(this);
        }

        /// <summary>
        /// not sure exactly what this does either but its necessary
        /// </summary>
        /// <param name="sender"> leave be </param>
        /// <param name="e"> leave be </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        // this will hold all of our key press events
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
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
                    startScreenSelected = (startScreenSelected + 1) % 2;
                }
            }
            else if (e.KeyCode == Keys.Right) // RIGHT key
            {
                Console.WriteLine("RIGHT");
                if (currentDisplay == 1)
                {
                    startScreenSelected = (startScreenSelected + 1) % 2;
                }
            }
            else if (e.KeyCode == Keys.Enter) // Enter key
            {
                if (currentDisplay == 1)
                {
                    switch (startScreenSelected)
                    {
                        case 0 : twoPlayerGame = true;
                            break;
                        case 1 : twoPlayerGame = false;
                            break;
                    }
                    // move on to action screen
                    currentDisplay++;
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

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // g is our servant whom we command to draw. It only operates within MainForm_Paint method.
            Graphics g = e.Graphics;

            // start screen
            if (currentDisplay == 1)
            {
                // currently hovering over two player mode
                if (startScreenSelected == 0)
                {
                    // we are asking our servant Mr. G for a golden rectangle at the two coordinates with a certain width and height
                    g.FillRectangle(Brushes.Gold, this.Width / 3, this.Height * (2f / 3f), 190f, 40f);
                }

                // currently hovering over four player mode
                else if (startScreenSelected == 1)
                {
                    g.FillRectangle(Brushes.Gold, this.Width * (2f / 3f), this.Height * (2f / 3f), 190f, 40f);
                }

                // ask Mr. G to draw some text for us. Because we make the request after the rectangles are drawn above, they will become the top layer
                g.DrawString("Quoridor", SystemFonts.MenuFont, Brushes.Black, this.Width / 2 - 100, this.Height / 3);
                g.DrawString("Two Players", SystemFonts.MenuFont, Brushes.Black, this.Width / 3f, this.Height * (2f / 3f));
                g.DrawString("Four Players", SystemFonts.MenuFont, Brushes.Black, this.Width * (2f / 3f), this.Height * (2f / 3f));
            }

            // game screen -- game has been started, all the action happens here
            else if (currentDisplay == 2)
            {
                // darkSkin enabled?
                switch (darkSkin)
                {
                    // draw the regular skin
                    case false:
                        g.DrawImage(Properties.Resources.Behemoth, x, y, 100, 100);
                        break;
                    // draw the "darkskin"
                    case true:
                        g.DrawImage(Properties.Resources.BehemothDark, x, y, 100, 100);
                        break;
                }
                switch (twoPlayerGame)
                {
                    case true:
                        g.DrawString("Two Player Game", SystemFonts.DefaultFont, Brushes.Black, 100, 100);
                        break;
                    case false:
                        g.DrawString("Four Player Game", SystemFonts.DefaultFont, Brushes.Black, 100, 100);
                        break;
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
        /// Boasting my animating talent :P
        /// </summary>
        private void movementThread()
        {
            while(true)
            {
                if (currentDisplay == 2)
                {
                    x = x + velX;
                    if (x < 100 || x > 1000)
                    {
                        velX = velX * -1;
                    }
                    y = y + velY;
                    if (y < 100 || y > 500)
                    {
                        velY = velY * -1;
                    }
                }
                Thread.Sleep(16);
            }
        }
    }
}
