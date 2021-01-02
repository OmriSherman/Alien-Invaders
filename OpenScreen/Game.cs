using System;
//using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unit4.CollectionsLib;
using System.Media;

namespace OpenScreen
{
    public partial class Game : Form
    {
        Graphics g;
        Board game = new Board();
        PlayerSapceship s = new PlayerSapceship();
        List<Shoot> ls = new List<Shoot>();
        Node<Shoot> pos;
        SoundPlayer PlayerShoot1 = new SoundPlayer("PlayerShoot1.wav");
        int countTick = 0;//מסממל תזוזת חללית
        bool sw = true;//החלליות צריכות ללכת ימינה
        int HitCounter = 0;
        



        public Game(int t)
        {
            InitializeComponent();
            if (t > 0)
                this.timer1.Interval = 200;
            
        }
        private void Game_Load(object sender, EventArgs e,int t)
        {
            game = new Board();
            if (t == 1)
            {
                timer1.Interval -= 200;
                timer1.Start();
            }
            else
                timer1.Start();
        }
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            s.PaintPlayer(g);
            game.PaintBoard(g);
            pos = ls.GetFirst();
            while (pos != null)
            {
                Shoot s1 = new Shoot();
                s1 = pos.GetInfo();
                s1.PaintShoot(g);
                pos = pos.GetNext();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            g = CreateGraphics();
            if (sw == true)
            {
                if (countTick < 19)
                {
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            game.GetBoard()[i, j].SetX(game.GetBoard()[i, j].GetX() + 40);
                        }
                    countTick++;
                }
                else
                {
                    sw = false;
                    countTick = 0;
                    for (int i1 = 0; i1 < 4; i1++)
                        for (int j1 = 0; j1 < 8; j1++)
                            game.GetBoard()[i1, j1].SetY(game.GetBoard()[i1, j1].GetY() + 45);
                }
            }
            if (sw == false)
            {
                if (countTick < 19)
                {
                    for (int i1 = 0; i1 < 4; i1++)
                        for (int j1 = 0; j1 < 8; j1++)
                            game.GetBoard()[i1, j1].SetX(game.GetBoard()[i1, j1].GetX() - 40);
                    countTick++;
                }
                else
                {
                    sw = true;
                    countTick = 0;
                    for (int i1 = 0; i1 < 4; i1++)
                        for (int j1 = 0; j1 < 8; j1++)
                            game.GetBoard()[i1, j1].SetY(game.GetBoard()[i1, j1].GetY() + 45);
                }
            }
            game.PaintBoard(g);
            Refresh();
            int x = game.GetBoard()[3, 0].GetX();
            int x1 = game.GetBoard()[3, 7].GetX() + 120;
            int y = game.GetBoard()[0, 0].GetY();
            int y1 = game.GetBoard()[3, 7].GetY() + 120;
            if (s.GetX() >= x && s.GetX() <= x1 && s.GetY() >= y && s.GetY() <= y1)
            {
                s.SetStatus(0);
            }

            int mone = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.GetBoard()[i, j].GetStatus() == 0)
                    {
                        mone++;
                    }
                    if (mone == 32)
                    {
                        this.Close();
                        LvlUp a = new LvlUp();
                        a.Show();
                    }
                }
            }
            CheckLose();
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (s.x > 30 && s.x < 1751)
            {
                if (e.KeyCode == Keys.Right)
                {
                    s.x += 50;
                }
                if (e.KeyCode == Keys.Left)
                {
                    s.x -= 50;
                }
                if (e.KeyCode == Keys.Space)
                {
                    PlayerShoot1.Play();
                    Shoot shoot = new Shoot();
                    shoot.SetX(s.GetX() + 85);
                    shoot.SetY(s.GetY());
                    ls.Insert(null, shoot);
                    //Point w = new Point(s.x+60, s.y);
                    //pictureBox1.Location=w;
                    //pictureBox1.Show();
                    timer2.Start();
                }
            }
            if (s.x < 30)
            {
                if (e.KeyCode == Keys.Right)
                {
                    s.x += 50;
                }
            }
            if (s.x > 1751)
            {
                if (e.KeyCode == Keys.Left)
                {
                    s.x -= 50;
                }
            }
            int mone = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (game.GetBoard()[i, j].GetStatus() == 0)
                    {
                        mone++;
                        //this.timer1.Interval = this.timer1.Interval - 1;
                    }
                    if (mone == 32)
                    {
                        this.Close();
                        LvlUp a = new LvlUp();
                        a.Show();
                    }
                }
            }
            Invalidate();
            PlayerShoot1.Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("האם ברצונך לצאת מהמשחק?", "יציאה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Game a = new Game(0);
            a.Show();
        }
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions a = new Instructions();
            a.Show();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {//שעון עבור היריות
            g = CreateGraphics();
            pos = ls.GetFirst();
            while (pos != null)
            {
                Shoot s1 = new Shoot();
                s1 = pos.GetInfo();
                //לבדוק שלא פגענו בחללית
                //לבדוק שלא הגענו לתקרה
                s1.SetY(s1.GetY() - 20);
                if (s1.GetY() < 20)
                    ls.Remove(pos);

                else
                {
                    int x = game.GetBoard()[3, 0].GetX();//נקודה שמאלית ביותר של השורה האחרונה
                    int x1 = game.GetBoard()[3, 7].GetX() + 120;
                    int y = game.GetBoard()[0, 0].GetY();
                    int y1 = game.GetBoard()[3, 7].GetY() + 120;
                    if (s1.GetX() >= x && s1.GetX() <= x1 && s1.GetY() >= y && s1.GetY() <= y1)//הכדור נמצא בתחומי המטריצה
                    {
                        int i = (s1.GetY() - y) / 120;
                        int j = (s1.GetX() - x) / 120;
                        if (i >= 0 && i < 4 && j >= 0 && j < 8)
                        {
                            if (game.GetBoard()[i, j].GetStatus() == 1)//יש חללית
                            {

                                s1.PaintShoot(g);
                                game.GetBoard()[i, j].SetStatus(0);//פוצצנו את החללית
                                ls.Remove(pos);
                                HitCounter++;

                            }
                        }
                    }
                }
                pos = pos.GetNext();


            }
            label2.Text = "חלליות חוסלו:" + HitCounter + "/32";


        }
        public void CheckLose()
        {
            bool check=false;

            //while (check == false)
            //{
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (game.GetBoard()[i, j].GetStatus() == 1)//אם יש חללית
                        {
                            int y1 = game.GetBoard()[i, j].GetY();
                            if (y1 + 120 >= 850)
                                check = true;
                        }
                    }
                }
            //}
            if (check == true)
            {
                    
                LoseScreen a = new LoseScreen();
                a.Show();
                this.Close();
            }

        }
    }
}

    

