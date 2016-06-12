using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quoridor
{
    public partial class MainForm : Form
    {

        int x;
        int y;
        Boolean darkSkin;

        /// moved main into here because its what I saw in some videos
        static void Main(string[] args)
        {
            // designates the form as the main window for the application, application ends when it is closed
            Application.Run(new MainForm());
            
            // form will contain the game and manipulate it. Again, it has to do with how forms are structured. Kinda weird.
            Quoridor quoridorGame = new Quoridor();
        }
        
        public MainForm()
        {
            InitializeComponent();
            x = 200;
            y = 200;
            darkSkin = false;
        }

        /// <summary>
        /// not sure exactly what this does either but its necessary
        /// </summary>
        /// <param name="sender"> leave be </param>
        /// <param name="e"> leave be </param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        /// this is where the meat of the graphics will actually go. We will designate what stuff we want on the screen here and upodate it with invalidate() command.
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // this is how we will draw all of our stuff > g.DrawImage(Properties.Resources.ResourceName, int xPos, int yPos, height, width);
            // to add a resource, go to Project > Quoridor Properties > Resources > Add Resource Drop Down > Add Existing File
            if (darkSkin)
            {
                g.DrawImage(Properties.Resources.BehemothDark, x, y, 200, 200);
            }
            else
            {
                g.DrawImage(Properties.Resources.Behemoth, x, y, 100, 100);
            }
            // canvas is the window that it is being drawn on. Only needed for .Width and .Height -> makes drawing stuff easy
        }

        // this will hold all of our key press events
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) // UP key
            {
                Console.WriteLine("UP");
                y = y - 100;
            }
            else if (e.KeyCode == Keys.Down) // DOWN key
            {
                Console.WriteLine("DOWN");
                y = y + 100;
            }
            else if (e.KeyCode == Keys.Left) // LEFT key
            {
                Console.WriteLine("LEFT");
                x = x - 100;
            }
            else if (e.KeyCode == Keys.Right) // RIGHT key
            {
                Console.WriteLine("RIGHT");
                x = x + 100;
            }
            else if (e.KeyCode == Keys.Enter) // Enter key
            {
                darkSkin = !darkSkin;
            }
            else if (e.KeyCode == Keys.Shift) // SHIFT key
            {

            }
            canvas.Invalidate(); // redraws the screen
        }
    }
}
