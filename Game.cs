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
            EnemyBorderCollision();
            EnemyPacmanCollision();
        }
        private void AddPacman()
        {
            this.Controls.Add(pacman);
            pacman.Parent = lvl;
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
                    pacman.Direction = "right";
                    pacman.HorizontalVelocity = pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.Down:
                    pacman.Direction = "down";
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = pacman.Step;
                    break;
                case Keys.Left:
                    pacman.Direction = "left";
                    pacman.HorizontalVelocity = -pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.Up:
                    pacman.Direction = "up";
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = -pacman.Step;
                    break;
                case Keys.D:
                    pacman.Direction = "right";
                    pacman.HorizontalVelocity = pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.S:
                    pacman.Direction = "down";
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = pacman.Step;
                    break;
                case Keys.A:
                    pacman.Direction = "left";
                    pacman.HorizontalVelocity = -pacman.Step;
                    pacman.VerticalVelocity = 0;
                    break;
                case Keys.W:
                    pacman.Direction = "up";
                    pacman.HorizontalVelocity = 0;
                    pacman.VerticalVelocity = -pacman.Step;
                    break;
            }
            SetRandomEnemyDirection();
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
                enemy.SetDirection(rand.Next(1,5));
                enemies.Add(enemy);
                this.Controls.Add(enemy);
                enemy.Parent = lvl;
                enemy.BringToFront();
            }
        }
        private void EnemyBorderCollision()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.Top < lvl.Top) //From "up" to "down"
                {
                    enemy.SetDirection(2);
                }
                if (enemy.Top > lvl.Height - enemy.Height) //From "down" to "up"
                {
                    enemy.SetDirection(4);
                }
                if (enemy.Left < lvl.Left) //From "left" to "right"
                {
                    enemy.SetDirection(1);
                }
                if (enemy.Left > lvl.Width - enemy.Width) //From "right" to "left"
                {
                    enemy.SetDirection(3);
                }
            }
        }
        private void SetRandomEnemyDirection()
        {
            foreach (var enemy in enemies)
            {
                enemy.SetDirection(rand.Next(1,5));
            }
        }
        private void EnemyPacmanCollision()
        {
            foreach (var enemy in enemies)
            {
                if (pacman.Bounds.IntersectsWith(enemy.Bounds))
                {
                    GameOver();
                }
            }
        }
        private void GameOver()
        {
            this.Controls.Clear();
            Label label = new Label();
            label.Text = "GAME OVER";
            label.Font = new Font("Comic Sans MS", 24, FontStyle.Regular);
            label.Location = new Point(ClientRectangle.Width / 2, ClientRectangle.Height / 2);
            label.Size = new Size(300,50);
            this.Controls.Add(label);
            label.BringToFront();
        }
    }
}
