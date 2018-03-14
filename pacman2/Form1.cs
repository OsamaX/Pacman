using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void start_Click(object sender, EventArgs e)
        {
            this.Hide();
            game pacman = new game();
            pacman.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 settings = new Form2();
            settings.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            highscore high_score = new highscore();
            high_score.Show();
        }

    }
}
