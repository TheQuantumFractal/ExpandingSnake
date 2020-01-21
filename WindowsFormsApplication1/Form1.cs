using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Random rand;
        Bitmap map;
        Graphics gfx;
        public static float olduni = 1;
        Snake Player;
        food Food;
        anti antinu;
        Color colour = Color.ForestGreen;
        public static float universe_size = 55;
        private void Form1_Load(object sender, EventArgs e)
        {
            Player = new Snake();
            Player.pieces.Add(new SnakePiece(new Point(ClientSize.Width / 2 - 4, ClientSize.Height / 2 - 4), new Size(8, 8), colour, SnakePiece.Direction.None));
            rand = new Random();
            antinu = new anti();
            map = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(map);
            Food = new food(rand, universe_size, ClientSize);
        }
        int minuni = 55;
        int maxuni = 700;
        int x = 1;
        Brush brush = Brushes.Gold;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //erase, move, draw
            gfx.Clear(BackColor);
            if (universe_size <= minuni && universe_size < olduni)
            {
                x = 1;
                universe_size = minuni;
                olduni = 0;
            }
            if (universe_size >= maxuni && universe_size > olduni)
            {
                x = -1;
            }
            else if (universe_size / 2 > 300)
            {
                brush = Brushes.Black;
            }
            else if (universe_size / 2 > 200)
            {
                brush = Brushes.DarkGray;
            }
            else if (universe_size / 2 > 150)
            {
                brush = Brushes.LightYellow;
            }
            else if (universe_size / 2 > 100)
            {
                brush = Brushes.Yellow;
            }
            else if (universe_size / 2 > 25)
            {
                brush = Brushes.Gold;
            }
            if (universe_size > 0)
            {
                olduni = universe_size;
            }
            if (x == 1)
            {
                universe_size = (float)Math.Pow(universe_size + 2, Math.Sqrt(1.00011));
            }
            else
            {
                universe_size = (float)Math.Pow(universe_size - 2, Math.Sqrt(1 / 1.00011));
            }
            if (Player.pieces[0].rect.IntersectsWith(food.foodbox))
            {
                Score.Text = Convert.ToString(Convert.ToInt32(Score.Text)+10);
                Food.generate(rand, universe_size / 2, ClientSize);
                if (Player.pieces.Last()._direction == SnakePiece.Direction.Left)
                {
                    Player.pieces.Add(new SnakePiece(new Point(Player.pieces.Last()._location.X + 8, Player.pieces.Last()._location.Y), Player.pieces.Last()._size, Player.pieces.Last()._color, Player.pieces[Player.pieces.Count - 1].Direct));
                }
                if (Player.pieces.Last()._direction == SnakePiece.Direction.Right)
                {
                    Player.pieces.Add(new SnakePiece(new Point(Player.pieces.Last()._location.X - 8, Player.pieces.Last()._location.Y), Player.pieces.Last()._size, Player.pieces.Last()._color, Player.pieces[Player.pieces.Count - 1].Direct));
                }
                if (Player.pieces.Last()._direction == SnakePiece.Direction.Up)
                {
                    Player.pieces.Add(new SnakePiece(new Point(Player.pieces.Last()._location.X, Player.pieces.Last()._location.Y + 8), Player.pieces.Last()._size, Player.pieces.Last()._color, Player.pieces[Player.pieces.Count - 1].Direct));
                }
                if (Player.pieces.Last()._direction == SnakePiece.Direction.Down)
                {
                    Player.pieces.Add(new SnakePiece(new Point(Player.pieces.Last()._location.X, Player.pieces.Last()._location.Y - 8), Player.pieces.Last()._size, Player.pieces.Last()._color, Player.pieces[Player.pieces.Count - 1].Direct));
                }
                minuni += 7;
                maxuni += 3;
                universe_size = olduni;
                if (rand.Next(10, 12) == 10)
                {
                    antinu.generate(rand, universe_size / 2, ClientSize);
                }
            }
            gfx.FillEllipse(brush, (ClientSize.Width / 2 - universe_size / 2), (ClientSize.Height / 2 - universe_size / 2), universe_size, universe_size);
            for (int i = 1; i < Player.pieces.Count; i++)
            {
                if (Player.pieces[0].rect.IntersectsWith(Player.pieces[i].rect))
                {
                    antinu.pieces.Clear();
                    Player.pieces[0]._location = new Point(ClientSize.Width / 2 - Player.pieces[0]._size.Height / 2, ClientSize.Height / 2 - Player.pieces[0]._size.Width / 2);
                    Player.pieces.RemoveRange(1, Player.pieces.Count - 1);
                    Player.pieces[0].Direct = SnakePiece.Direction.None;
                    x = 1;
                    universe_size = minuni;
                    olduni = 0;
                    Food.generate(rand, universe_size / 2, ClientSize);
                    maxuni = 700;
                    minuni = 55;
                    Score.Text = "0";
                }
            }
            Player.Move(ClientSize);
            Player.ChangeDirection();
            if (Math.Sqrt(Math.Pow(Player.pieces[0]._location.X - (ClientSize.Width / 2), 2) + Math.Pow(Player.pieces[0]._location.Y - (ClientSize.Height / 2), 2)) > universe_size / 2 && universe_size > 55)
            {
                antinu.pieces.Clear();
                Player.pieces[0]._location = new Point(ClientSize.Width / 2 - Player.pieces[0]._size.Height / 2, ClientSize.Height / 2 - Player.pieces[0]._size.Width / 2);
                Player.pieces.RemoveRange(1, Player.pieces.Count - 1);
                Player.pieces[0].Direct = SnakePiece.Direction.None;
                x = 1;
                universe_size = minuni;
                olduni = 0;
                Food.generate(rand, universe_size / 2, ClientSize);
                maxuni = 700;
                minuni = 55;
                Score.Text = "0";
            }
            if (Math.Sqrt(Math.Pow(food.x - (ClientSize.Width / 2), 2) + Math.Pow(food.y - (ClientSize.Height / 2), 2)) > universe_size / 2 && universe_size > 15 && universe_size < olduni)
            {
                Food.generate(rand, minuni, ClientSize);
            }
            for (int i = 0; i < antinu.pieces.Count; i++)
            {
                if (Math.Sqrt(Math.Pow(antinu.pieces[i]._location.X - (ClientSize.Width / 2), 2) + Math.Pow(antinu.pieces[i]._location.Y - (ClientSize.Height / 2), 2)) > universe_size / 2 && universe_size > 15 && universe_size < olduni)
                {
                    antinu.pieces.RemoveAt(i);
                    if (rand.Next(0, 2) == 1)
                    {
                        antinu.generate(rand, universe_size / 2, ClientSize);
                    }
                }
            }

            for (int i = 0; i < antinu.pieces.Count; i++)
            {
                if (antinu.pieces[i].aunti.IntersectsWith(Player.pieces[0].rect))
                {
                    if (Player.pieces.Count > 1)
                    {
                        Score.Text = Convert.ToString(Convert.ToInt32(Score.Text) - 10);
                        antinu.pieces.RemoveAt(i);
                        Player.pieces.RemoveAt(Player.pieces.Count - 1);
                        minuni -= 7;
                        maxuni -= 3;

                    }
                    else
                    {
                        antinu.pieces.Clear();
                        Player.pieces[0]._location = new Point(ClientSize.Width / 2 - Player.pieces[0]._size.Height / 2, ClientSize.Height / 2 - Player.pieces[0]._size.Width / 2);
                        Player.pieces.RemoveRange(1, Player.pieces.Count - 1);
                        Player.pieces[0].Direct = SnakePiece.Direction.None;
                        x = 1;
                        universe_size = minuni;
                        olduni = 0;
                        Food.generate(rand, universe_size / 2, ClientSize);
                        maxuni = 700;
                        minuni = 55;
                        Score.Text = "0";
                    }
                }
            }
                antinu.Draw(gfx);
            Player.Draw(gfx);
            Food.Draw(gfx);
            bitBox.Image = map;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && Player.pieces[0].Direct != SnakePiece.Direction.Left)
            {
                Player.pieces[0].Direct = SnakePiece.Direction.Right;
            }
            else if (e.KeyCode == Keys.Left && Player.pieces[0].Direct != SnakePiece.Direction.Right)
            {
                Player.pieces[0].Direct = SnakePiece.Direction.Left;
            }
            else if (e.KeyCode == Keys.Up && Player.pieces[0].Direct != SnakePiece.Direction.Down)
            {
                Player.pieces[0].Direct = SnakePiece.Direction.Up;
            }
            else if (e.KeyCode == Keys.Down && Player.pieces[0].Direct != SnakePiece.Direction.Up)
            {
                Player.pieces[0].Direct = SnakePiece.Direction.Down;
            }
            if(e.KeyCode == Keys.Escape)
            {
                timer1.Stop();
            }
            if(e.KeyCode == Keys.Enter)
            {
                timer1.Start();
            }
        }

        private void bitBox_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
