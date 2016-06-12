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
            g.DrawImage(Properties.Resources.Behemoth, canvas.Width / 3, canvas.Height / 3, 100, 100);
            // canvas is the window that it is being drawn on. Only needed for .Width and .Height -> makes drawing stuff easy
        }

        /// <summary>
        /// processes key presses
        /// </summary>
        /// <param name="sender"> leave be </param>
        /// <param name="e"> leave be </param>
        private void MainForm_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }
    }
}
