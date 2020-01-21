using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{

    public class Snake
    {

        public List<SnakePiece> pieces = new List<SnakePiece>();


        public void Draw(Graphics gfx)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Draw(gfx);
            }
        }

        public void Move(Size ClientSize)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                pieces[i].Move(ClientSize);
            }
        }

        public void ChangeDirection()
        {
            for (int i = pieces.Count - 1; i > 0; i--)
            {
                pieces[i].Direct = pieces[i - 1].Direct;
            }
        }



    }
}
