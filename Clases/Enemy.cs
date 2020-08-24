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
        public string Direction { get; set; } = null;

        private Timer animationTimer = null;
        private int frameCounter = 1;

        public Enemy()
        {
            InitilizeEnemy();
            InitializeAnimationTimer();
        }
        private void InitilizeEnemy()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(20, 20);
            this.Tag = "ghost";
        }
        /// <summary>
        /// Sets the direction of enemy
        /// 1-Right, 2-Down, 3-Left, 4-Up
        /// </summary>
        /// <param name="directionCode"></param>
        public void SetDirection(int directionCode)
        {
            switch (directionCode)
            {
                case 1: //right
                    Direction = "right";
                    HorizontalVelocity = Step;
                    VerticalVelocity = 0;
                    break;
                case 2: //down
                    Direction = "down";
                    HorizontalVelocity = 0;
                    VerticalVelocity = Step;
                    break;
                case 3: //left
                    Direction = "left";
                    HorizontalVelocity = -Step;
                    VerticalVelocity = 0;
                    break;
                case 4: //up
                    Direction = "up";
                    HorizontalVelocity = 0;
                    VerticalVelocity = -Step;
                    break;
            }
        }
        private void InitializeAnimationTimer()
        {
            animationTimer = new Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Animate();
        }
        private void Animate()
        {
            string imageName = "enemy_" + this.Direction + "_" + frameCounter.ToString();
            this.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            frameCounter++;
            if (frameCounter > 2)
            {
                frameCounter = 1;
            }
        }
    }
}
