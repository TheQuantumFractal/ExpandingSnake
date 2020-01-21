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
    class food
    {
        public static  float x;
        public static float y;
        static public Rectangle foodbox;
        anti ant = new anti();
        public food(Random gen, float UniverseRadius, Size ClientSize)
        {
            generate(gen, UniverseRadius, ClientSize);
        }
        public void generate(Random gen, float UniverseRadius, Size ClientSize)
        {
            float angle = (float)(gen.NextDouble() * Math.PI * 2);
            float radius = (float)(Math.Sqrt(gen.NextDouble()) * UniverseRadius);
            x = (float)(ClientSize.Width / 2 + (radius-5) * Math.Cos(angle));
            y = (float)(ClientSize.Height / 2 + (radius-5) * Math.Sin(angle));
            foodbox = new Rectangle((int)x, (int)y, 10, 10);
        }
        public void Draw(Graphics gfx)
        {
            gfx.FillEllipse(Brushes.Blue, x, y, 10, 10);
        }

    
    }
}
