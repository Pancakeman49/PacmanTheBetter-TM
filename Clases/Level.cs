using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_FOR_REAL_THIS_TIME.Clases
{
    class Level : PictureBox
    {
        public Level()
        {
            InitilizeLevel();
        }
        private void InitilizeLevel()
        {
            this.BackColor = Color.Black;
            this.Size = new Size(400, 400);
            this.Location = new Point(100, 100);
            this.Name = "level";
        }
    }
}
