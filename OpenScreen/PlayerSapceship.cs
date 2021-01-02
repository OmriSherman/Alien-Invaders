using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class PlayerSapceship
    {
        public int x;
        public int y;
        public int PlayerFull;
        public PlayerSapceship()
        {
            this.x = 900;
            this.y = 850;
            this.PlayerFull = 1;
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
        public void SetStatus(int status)
        {
            this.PlayerFull = status;
        }
        public void PaintPlayer(Graphics g)
        {
            if (this.PlayerFull == 1)
            {
                Point p = new Point(this.x, this.y);
                Image pic = Image.FromFile("Player1.gif");
                g.DrawImage(pic, p);
            }
        }
        
    }    
}

