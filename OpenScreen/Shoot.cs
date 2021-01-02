using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class Shoot
    {
        private int x;
        private int y;
        public Shoot()
        {
            x = 0;
            y = 0;
        }

        public void SetX(int x)
        {
            this.x = x;
        }
        public int GetX()
        {
            return this.x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetY()
        {
            return this.y;
        }
        public void PaintShoot(Graphics g)
        {
            Point p = new Point(this.x - 40, this.y - 50 );
            Image pic = Image.FromFile("lazer.png");
            g.DrawImage(pic, p);
        }
    }
}
