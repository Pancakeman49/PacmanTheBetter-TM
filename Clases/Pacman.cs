using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_FOR_REAL_THIS_TIME.Clases
{
    class Pacman : PictureBox
    {
        public int Step { get; set; } = 2;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;


        public Pacman()
        {
            InitializePacman();
        }
        private void InitializePacman()
        {
            this.BackColor = Color.Yellow;
            this.Size = new Size(60,60);
            this.Location = new Point(200,200);
            this.Name = "Pacman";
        }
    }
}
