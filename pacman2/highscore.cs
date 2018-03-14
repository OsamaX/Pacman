using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pacman2
{
    public partial class highscore : Form
    {
        public highscore()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void highscore_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("../highscore.txt");
                Label[] names = { name1, name2, name3, name4, name5, name6, name7, name8, name9, name10 };
                Label[] scores = { score1, score2, score3, score4, score5, score6, score7, score8, score9, score10 };

                int counter = 0;
                using (sr)
                {
                    while (sr.Peek() > -1)
                    {
                        string[] arr = sr.ReadLine().Split(',');
                        names[counter].Text = arr[0];
                        scores[counter].Text = arr[1];
                        counter++;
                    }
                }
            }
            catch (IOException o) {
                MessageBox.Show(o.Message);
            }
        }
    }
}
