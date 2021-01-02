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
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void Instructions_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(960, 600);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
