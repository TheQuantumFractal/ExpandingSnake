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
    public class antipiece
    {

        public Rectangle aunti;
        public Point _location;
        public Size _size;
        public Color _color;
        public antipiece(Point location, Size size, Color color)
        {
            _location = location;
            _size = size;
            _color = color;
        }
        public void Draw(Graphics gfx)
        {
            aunti = new Rectangle(_location, _size);
            gfx.FillEllipse(new SolidBrush(_color), new Rectangle(_location, _size));
        }
    }
}
