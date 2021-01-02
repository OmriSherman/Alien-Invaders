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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(960, 600);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Instructions a = new Instructions();
            a.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("האם ברצונך לצאת מהמשחק?", "יציאה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Game a = new Game(0);
            a.Show();
        }
    }
}
