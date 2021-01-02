using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class PlayerBoard
    {
        private Cell[] PlayerRoute;
        public PlayerBoard()
        {
         PlayerRoute = new Cell[38];
            int x = 900;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell c = new Cell();
                    c.SetX(x);
                    PlayerRoute[i]= c;
                    x = x + 50;
                }
            }
        }
        public void PaintBoard(Graphics g)
        {
            for (int i = 0; i < 30; i++)   
                {
                    PlayerRoute[i].PaintCell(g);
                }
        }
        public Cell[] GetPlayerBoard()
        {
            return this.PlayerRoute;
        }
    }
    }

