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
    public partial class game : Form
    {
        public game()
        {
            InitializeComponent();
        }
        
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        PlayerName uip = new PlayerName();
        
        PictureBox[] coins;
        PictureBox[] bounds;
        int points = 0;
        int plives = 3;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void game_KeyDown(object sender, KeyEventArgs e)
        {

                if (e.KeyCode == Keys.Up)
                {
                    pac.Location = new Point(pac.Location.X, pac.Location.Y - 18);
                    pac.Image = Image.FromFile("../assest/up.gif");
                }

                if (e.KeyCode == Keys.Down)
                {
                    pac.Location = new Point(pac.Location.X, pac.Location.Y + 18);
                    pac.Image = Image.FromFile("../assest/down.gif");
                }

                if (e.KeyCode == Keys.Right)
                {
                    pac.Location = new Point(pac.Location.X + 18, pac.Location.Y);
                    pac.Image = Image.FromFile("../assest/right.gif");
                }


                if (e.KeyCode == Keys.Left)
                {
                    pac.Location = new Point(pac.Location.X - 18, pac.Location.Y);
                    pac.Image = Image.FromFile("../assest/left.gif");
                }

            if (pac.Bounds.IntersectsWith(coin19.Bounds)) {
                coin19.Dispose();
            }

            for (int i = 0; i < coins.Length; i++) {
                if (coins[i] != null)
                {
                    if (pac.Bounds.IntersectsWith(coins[i].Bounds))
                    {
                        coins[i].Dispose();
                        coins[i] = null;
                        points++;
                    }
                }
            }

            score.Text = Convert.ToString(points);



            for (int i = 0; i < bounds.Length; i++)
            {
                if (pac.Bounds.IntersectsWith(bounds[i].Bounds) && e.KeyCode == Keys.Right)
                {
                    pac.Location = new Point(pac.Location.X - 18, pac.Location.Y);
                }
                else if (pac.Bounds.IntersectsWith(bounds[i].Bounds) && e.KeyCode == Keys.Left) {
                    pac.Location = new Point(pac.Location.X + 18, pac.Location.Y);
                }
                else if (pac.Bounds.IntersectsWith(bounds[i].Bounds) && e.KeyCode == Keys.Up)
                {
                    pac.Location = new Point(pac.Location.X, pac.Location.Y + 18);
                }
                else if (pac.Bounds.IntersectsWith(bounds[i].Bounds) && e.KeyCode == Keys.Down)
                {
                    pac.Location = new Point(pac.Location.X, pac.Location.Y - 18);
                }
            }
            
            
        }

        private void game_Load(object sender, EventArgs e)
        {
            player.SoundLocation = "../assest/sound.wav";
            player.Load();
            player.Play();
            timer1.Start();

            monster1Move1.Start();
            timer2.Start();

            coins = new PictureBox[] {
                coin19, coin2, coin3, coin4, coin5, coin6, coin7, coin8, coin9, coin13, coin14, coin15, coin16, coin17, coin18, coin19, coin2, coin20,                      coin21, coin22, coin23, coin24, coin25, coin26, coin27, coin28, coin29, coin3, coin30, coin31, coin32, coin33, coin34, coin35,coin36,coin37,                coin38, coin39, coin4, coin40, coin41, coin42, coin43, coin44, coin45, coin46, coin47, coin48, coin49, coin5, coin50, coin51, coin52,                       coin53, coin54, coin55, coin56, coin57, coin58, coin59, coin60, coin61, coin62,coin62 , coin63, coin8, coin9, coin64, coin65, coin66,                       coin67, coin68, coin69, coin70, coin71, coin72, coin73, coin74, coin75, pictureBox75, pictureBox74, pictureBox73, pictureBox72,                             pictureBox71, pictureBox70, pictureBox69, pictureBox68, pictureBox67, pictureBox66, pictureBox65, pictureBox64,pictureBox63, pictureBox62,                  pictureBox61, pictureBox60, pictureBox59, pictureBox58, pictureBox57, pictureBox56, pictureBox55, pictureBox54, pictureBox53, pictureBox52,                 pictureBox51, pictureBox50, pictureBox49, pictureBox48, pictureBox47, pictureBox46, pictureBox45, pictureBox44, pictureBox43, pictureBox42,                 pictureBox41,  pictureBox34, pictureBox33, pictureBox32, coin76, coin77, coin78, coin79, coin80, coin81, coin82, coin83, coin84, coin85,                    coin86, coin87, coin88, coin89, coin90, coin91, coin92, coin93, pictureBox19, pictureBox24, pictureBox29
            };

            bounds = new PictureBox[] {
                block1, block2, block3, block4, bound1, bound2, bound3, bound4, bound5, pictureBox1, pictureBox13, pictureBox14,                                            pictureBox15, pictureBox2, pictureBox25, pictureBox3,  pictureBox4, pictureBox40, pictureBox6, pictureBox7, pictureBox8, pictureBox9,                       pictureBox8, pictureBox30, pictureBox28, pictureBox27, pictureBox26, pictureBox23, pictureBox22, pictureBox21, pictureBox20,                                pictureBox18, pictureBox17, pictureBox16, pictureBox12, pictureBox11, pictureBox10, pictureBox39, pictureBox35, pictureBox36, pictureBox37,                 pictureBox38
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.SoundLocation = "../assest/sound.wav";
            player.Load();
            player.Play();

        }

        private void monsterMove1_Tick(object sender, EventArgs e)
        {

            int prev = monster3.Location.Y;

            if (monster1.Location.Y != 337 && monster1.Location.X == 256)
            {
                monster1.Location = new Point(monster1.Location.X, monster1.Location.Y + 81);
            }
            else if (monster1.Location.Y == 13)
            {
                monster1.Location = new Point(monster1.Location.X - 81, monster1.Location.Y);
            }
            else if (monster1.Location.X == 823)
            {
                monster1.Location = new Point(monster1.Location.X, monster1.Location.Y - 81);
            }
            else {
                monster1.Location = new Point(monster1.Location.X + 81, monster1.Location.Y);
            }



            if (monster2.Location.Y != 130 && monster2.Location.Y != 68 && monster2.Location.X == 76)
            {
                monster2.Location = new Point(monster2.Location.X, monster2.Location.Y - 31);
            }
            else if (monster2.Location.X != 200 && monster2.Location.Y == 130 && monster2.Location.X != 14)
            {
                monster2.Location = new Point(monster2.Location.X + 31, monster2.Location.Y);
            }
            else if (monster2.Location.X == 200 && monster2.Location.Y != 68)
            {
                monster2.Location = new Point(monster2.Location.X, monster2.Location.Y - 31);
            }
            else if (monster2.Location.Y == 68 && monster2.Location.X != 14) 
            {
                monster2.Location = new Point(monster2.Location.X - 31, monster2.Location.Y);
            }
            else if (monster2.Location.X == 14 && monster2.Location.Y != 347) 
            {
                monster2.Location = new Point(monster2.Location.X, monster2.Location.Y + 31);
            }
            else if (monster2.Location.Y == 347 && monster2.Location.X != 74)
            {
                monster2.Location = new Point(monster2.Location.X + 31, monster2.Location.Y);
            }



            if (monster4.Location.Y == 319 && monster4.Location.X != 1226)
            {
                monster4.Location = new Point(monster4.Location.X + 51, monster4.Location.Y);

            }
            else if (monster4.Location.X == 1226 && monster4.Location.Y != 64)
            {
                monster4.Location = new Point(monster4.Location.X, monster4.Location.Y - 51);

            }
            else if (monster4.Location.Y == 64 && monster4.Location.X != 869)
            {
                monster4.Location = new Point(monster4.Location.X - 51, monster4.Location.Y);
            }
            else if (monster4.Location.X == 869)
            {
                monster4.Location = new Point(monster4.Location.X, monster4.Location.Y + 51);
            }
            else if (monster4.Location.Y != 217)
            {
                monster4.Location = new Point(monster4.Location.X, monster4.Location.Y - 51);
            }



            if (monster1.Bounds.IntersectsWith(pac.Bounds) || monster2.Bounds.IntersectsWith(pac.Bounds) || monster3.Bounds.IntersectsWith                                  (pac.Bounds) || monster4.Bounds.IntersectsWith(pac.Bounds))
            {
                plives -= 1;
                lives.Text = plives.ToString();
                if (plives >= 1)
                {
                    pac.Location = new Point(pac.Location.X - pac.Location.X + 9, pac.Location.Y - pac.Location.Y + 9);
                }
                else
                {
                   
                    monster1Move1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Game Over");

                    uip.userScore(score.Text);
                    uip.Show();
                    this.Dispose();
                    player.Stop();

                    
                    
                }

            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (monster3.Location.X != 1241 && monster3.Location.Y == 494)
            {
                monster3.Location = new Point(monster3.Location.X + 61, monster3.Location.Y);

            }
            else if (monster3.Location.Y != 433 && monster3.Location.X == 1241)
            {
                monster3.Location = new Point(monster3.Location.X, monster3.Location.Y - 61);
            }

            else if (monster3.Location.Y == 433 && monster3.Location.X != 936)
            {
                monster3.Location = new Point(monster3.Location.X - 61, monster3.Location.Y);

            }
            else if (monster3.Location.X == 936 && monster3.Location.Y != 494)
            {
                monster3.Location = new Point(monster3.Location.X, monster3.Location.Y + 61);
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            monster3.Location = new Point(monster3.Location.X - 61, monster3.Location.Y);

            if (monster3.Location.X == 265) {
                timer3.Stop();
                timer2.Start();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

            Environment.Exit(0);
        }

    }


}
