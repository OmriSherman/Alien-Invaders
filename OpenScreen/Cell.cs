using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class Cell
    {

        private int x;
        private int y;
        private int full;//האם יש חללית 

        public Cell()
        {
            this.x = 0;
            this.y = 0;
            this.full = 1;
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
        public int GetStatus()
        {
            return this.full;
        }
        public void SetStatus(int status)
        {
            this.full = status;
        }
        public void PaintCell(Graphics g)
        {
            //Pen pen1 = new Pen(Color.Green);
            //g.DrawRectangle(pen1, this.x, this.y, 120, 120);
            if (this.full == 1)
            {
                Point p = new Point(this.x, this.y);
                Image pic = Image.FromFile("alien3.gif");
                g.DrawImage(pic, p);
            }
        }
        public void PaintCell1(Graphics g)
        {
                Point p = new Point(this.x, this.y);
                Image pic = Image.FromFile("alien3.gif");
                g.DrawImage(pic, p);
        }
       
    }
}
