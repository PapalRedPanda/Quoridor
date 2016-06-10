using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    /// <summary>
    /// runs the game
    /// </summary>
    class Quoridor
    {
        MainForm mainframe;

        public Quoridor()
        {
            mainframe = new MainForm();
            mainframe.ShowDialog();
        }
    }
}
