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
    public partial class PlayerName : Form
    {
        public PlayerName()
        {
            InitializeComponent();
        }

        string score = "";
        string name = "";

        public string userScore(string uscore) {
            return score = uscore;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            game user = new game();
            Form1 main = new Form1();

            name = textBox1.Text;

            if (name == "") {
                name = "Player";
            }

            storeScore(score, name);

            this.Dispose();
            main.Show();
            
        }

        public void storeScore(string score, string name) {
            try
            {


                string[] arr = File.ReadAllLines("../highscore.txt");
                int length = arr.Length;

                if (length < 10)
                {
                    StreamWriter sw = new StreamWriter("../highscore.txt", true);

                    using (sw)
                    {
                        sw.WriteLine("{0},{1}", name, score);
                    }
                }
                else
                {
                    StreamReader sr = new StreamReader("../highscore.txt");
                    string[] first = new string[10];

                    string[] final = new string[10];

                    int min = 0;

                    int l = 0;
                    int counter = 0;

                    using (sr)
                    {


                        while (sr.Peek() > -1)
                        {
                            first = sr.ReadLine().Split(',');
                            if (int.Parse(first[1]) < min)
                            {
                                l = counter;

                            }

                            final[counter] = first[0] + "," + first[1];
                            min = int.Parse(first[1]);
                            counter++;
                        }
                    }

                    int sc = int.Parse(final[l].Split(',')[1]);

                    if (sc < int.Parse(score))
                    {
                        final[l] = name + "," + score;

                        StreamWriter sw = new StreamWriter("../highscore.txt");

                        using (sw)
                        {
                            for (int i = 0; i < counter; i++)
                            {
                                sw.WriteLine(final[i]);
                            }

                        }
                    }



                }
            }
            catch (IOException e) {
                MessageBox.Show(e.Message);
            }

        }

     
    }
}
