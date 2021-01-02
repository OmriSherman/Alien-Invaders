using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class Try
    {
       public int x;
        public int y;
        public Try(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        public int GetX()
        {
            return this.x;
        }
        public int GetY()
        {
            return this.y;
        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public void PaintPlayer(Graphics g)
        {
            Point p = new Point(this.x, this.y);
            Image pic = Image.FromFile("Player1.gif");
            g.DrawImage(pic,p);
        }
    }    
}