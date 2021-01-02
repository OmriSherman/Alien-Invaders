using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenScreen
{
    public partial class LvlUp : Form
    {
        public int t = 0;
        public LvlUp()
        {
            InitializeComponent();
        }

        private void LvlUp_Load(object sender, EventArgs e)
        {

        }
       
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Game a = new Game(0);
            a.Show();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Game a = new Game(1);
            a.Show();
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

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instructions a = new Instructions();
            a.Show();
        }


        

       

       
    }
}
