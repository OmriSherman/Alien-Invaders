using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenScreen
{
    class Board
    {
        private Cell[,] horde;
        public Board()
        {
            horde = new Cell[4, 8];
            int x = 100;
            int y = 50;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell c = new Cell();
                    c.SetX(x);
                    c.SetY(y);
                    horde[i, j] = c;
                    x = x + 120;
                }
                x = 100;
                y = y + 120;
            }
        }
        public void PaintBoard(Graphics g)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                {
                    horde[i, j].PaintCell(g);
                }
        }
        
        public Cell[,] GetBoard()
        {
            return this.horde;
        }

       
    }
}
