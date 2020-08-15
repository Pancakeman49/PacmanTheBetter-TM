using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_FOR_REAL_THIS_TIME.Clases
{
    class Enemy : PictureBox
    {
        public int Step { get; set; } = 2;
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;

        public Enemy()
        {
            InitilizeEnemy();
        }
        private void InitilizeEnemy()
        {
            this.BackColor = Color.Red;
            this.Size = new Size(40, 40);
            this.Tag = "ghost";
        }
    }
}
