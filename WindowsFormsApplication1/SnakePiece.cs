using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
        public class SnakePiece
        {
            public enum Direction
            {
                None,
                Up,
                Down,
                Left,
                Right
            }


            public Point _location;
            public Size _size;
            public Color _color;
            public Direction _direction;
            public Rectangle rect;

            public Direction Direct
            {
                get
                {
                    return _direction;
                }
                set
                {
                    _direction = value;
                }
            }



            #region Other Constructors
            public SnakePiece()
                : this(0, 0, 1, 1, Color.White, Direction.None)
            { }

            public SnakePiece(int x, int y, int width, int height, Color color, Direction direction)
                : this(new Point(x, y), new Size(width, height), color, direction)
            { }

            public SnakePiece(int x, int y, int size, Color color, Direction direction)
                : this(new Point(x, y), new Size(size, size), color, direction)
            { }
            #endregion
            public SnakePiece(Point location, Size size, Color color, Direction direction)
            {
                _location = location;
                _size = size;
                _color = color;
                _direction = direction;
            }

            public void Move(Size clientSize)
            {
                if (_direction == Direction.Right)
                {
                    _location.X += _size.Width;
                }
                if (_direction == Direction.Up)
                {
                    _location.Y -= _size.Height;
                }
                if (_direction == Direction.Left)
                {
                    _location.X -= _size.Width;
                }
                if (_direction == Direction.Down)
                {
                _location.Y += _size.Height;
                }


            }


            public void Draw(Graphics gfx)
            {
                rect = new Rectangle(_location, _size);
                gfx.FillRectangle(new SolidBrush(_color), new Rectangle(_location, _size));
            }

        }
}
