using Microsoft.Win32;
using Pacman_FOR_REAL_THIS_TIME.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_FOR_REAL_THIS_TIME
{
    public partial class Game : Form
    {
        private Level lvl = new Level();
        private Pacman pacman = new Pacman();
        private Timer mainTimer = null;
        private List<Enemy> enemies = new List<Enemy>();
        private int initialEnemyCount = 4;
        private Random rand = new Random();
        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
            
        }
        private void InitializeGame()
        {
            //adding lvl to the game
            this.Controls.Add(lvl);

            //changing its size
            this.Size = new Size(600, 600);

            //adding pacman to game
            AddPacman();

            //adding key down event handler
            this.KeyDown += Gmae_KeyDown;

            //adding enemys
            AddEnemys();
        }
        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 20;
            mainTimer.Tick += MaintTimer_Tick;
            mainTimer.Start();
        }
        
        private void MaintTimer_Tick(object sender, EventArgs e)
        {
            MovePacman();
            PacmanBorderCollision();
            MoveEnemys();
        }
        private void AddPacman()
        {
            this.Controls.Add(pacman);
            pacman.BringToFront();
        }
        private void MoveEnemys()
        {
            foreach (var enemy in enemies)
            {
                enemy.Left += enemy.HorizontalVelocity;
                enemy.Top += enemy.VerticalVelocity;
            }
        }
        private void MovePacman()
        {
            pacman.Left += pacman.HorizontalVelocity;
            pacman.Top += pacman.VerticalVelocity;
        }
        private void Gmae_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    pacman.HorizontalVelocity = pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.Down:
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = pacman.Step;
                    break;
                case Keys.Left:
                    pacman.HorizontalVelocity = -pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.Up:
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = -pacman.Step;
                    break;
                case Keys.D:
                    pacman.HorizontalVelocity = pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.S:
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = pacman.Step;
                    break;
                case Keys.A:
                    pacman.HorizontalVelocity = -pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.W:
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = -pacman.Step;
                    break;


            }
        }
        
        private void PacmanBorderCollision()
        {
            if (pacman.Left > lvl.Left + lvl.Width)
            {
                pacman.Left = lvl.Left - pacman.Width;
            }
            if (pacman.Left + pacman.Width < lvl.Left)
            {
                pacman.Left = lvl.Left + lvl.Width;
            }
            if (pacman.Top> lvl.Top + lvl.Height)
            {
                pacman.Top = lvl.Top - pacman.Height;
            }
            if (pacman.Top + pacman.Height < lvl.Top)
            {
                pacman.Top = lvl.Top + lvl.Height;
            }
        }

        private void AddEnemys()
        {
            Enemy enemy;
            for (int i = 0; i < initialEnemyCount; i++)
            {
                enemy = new Enemy();
                enemy.Location = new Point(rand.Next(100,400), rand.Next(100,400));
                enemies.Add(enemy);
                this.Controls.Add(enemy);
                enemy.BringToFront();
            }
        }
    }
}
