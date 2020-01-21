using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class anti
    {
        public List<antipiece> pieces= new List<antipiece>();
        public static float x;
        public static float y;
        Snake snake = new Snake();
        public void generate(Random gen, float UniverseRadius, Size ClientSize)
        {
            do
            {
                float angle = (float)(gen.NextDouble() * Math.PI * 2);
                float radius = (float)(Math.Sqrt(gen.NextDouble()) * UniverseRadius);
                x = (float)(ClientSize.Width / 2 + radius * Math.Cos(angle));
                y = (float)(ClientSize.Height / 2 + radius * Math.Sin(angle));
            } while ((((x <= food.x - 10 || x >= food.x + 20) && (y <= food.y - 10 || y >= food.y + 20)) /* && ((x <= snake.pieces[0]._location.X - 10 || x >= snake.pieces[0]._location.X + 20) && (y <= snake.pieces[0]._location.Y - 10 || y >= snake.pieces[0]._location.Y + 20)) */));
            pieces.Add(new antipiece(new Point((int)x, (int)y), new Size(10, 10), Color.Red));
        }
        public void Draw(Graphics gfx)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Draw(gfx);
            }
        }
    }
}
