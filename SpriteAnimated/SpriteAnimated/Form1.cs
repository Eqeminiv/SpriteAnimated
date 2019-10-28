using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SpriteAnimated
{
    public partial class Form1 : Form
    {
        Graphics g;
        Background first, second;
        Sprite rocket;
        Sprite[] fire;
        Sprite[] explosion;

        Sprite torpedo;
        bool torpedoFiredSwitch, isExplosion;

        int i, j, time;

        int BG1position, BG2position, torpedoPosition;


        public Form1()
        {
           
            
            InitializeComponent();
            i = 0;
            j = 0;
            time = 0;
            torpedoFiredSwitch = false;
            isExplosion = false;
            pictureBox1.Width = Properties.Resources.bg2.Width;
            pictureBox1.Height = 300;

          
            
            this.Width = pictureBox1.Width;
            this.Height = pictureBox1.Height;
            
            first = new Background(pictureBox1.Location.X, pictureBox1.Width, pictureBox1.Location.Y, pictureBox1.Height, 1, Properties.Resources.bg1);
            second = new Background(pictureBox1.Location.X, pictureBox1.Width, pictureBox1.Location.Y, pictureBox1.Height, 1, Properties.Resources.bg2);
            first.setBGpos(pictureBox1.Location.X);
            second.setBGpos(pictureBox1.Location.X);
            rocket = new Sprite((float)pictureBox1.Width*(float)(1.0/2.0), pictureBox1.Height/3, Properties.Resources.rocket);
            fire = new Sprite[13]
            {
                new Sprite(rocket.getWidth() - 5, rocket.getY() + 10, Properties.Resources.fire1__01),
                new Sprite(rocket.getWidth() - 5, rocket.getY() + 10, Properties.Resources.fire1__02),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__03),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__04),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__05),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__06),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__07),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__08),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__09),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__10),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__11),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__12),
                new Sprite(rocket.getWidth()-5, rocket.getY()+10, Properties.Resources.fire1__13)
            };
            explosion = new Sprite[10]
            {
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0000),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0001),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0002),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0003),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0004),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0005),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0006),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0007),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0008),
                new Sprite(rocket.getX(), rocket.getY(), Properties.Resources.E0009),
            };

            torpedo = new Sprite(rocket.getX() - (Properties.Resources.torpedo.Width), rocket.getY()-10, Properties.Resources.torpedo);
            torpedo.resetPos((int)rocket.getX() - (Properties.Resources.torpedo.Width));
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            first.setBGpos(2);
            second.setBGpos(10);
            if (torpedoFiredSwitch)
            {
                torpedo.setPos(-8);
                if (torpedo.getPos() <= pictureBox1.Location.X)
                {
                    torpedo.resetPos((int)rocket.getX() - (Properties.Resources.torpedo.Width));
                    isExplosion = true;
                    torpedoFiredSwitch = false;
                }
            }
            
            if (first.getBGpos() >= pictureBox1.Width)
            {
                first.resetBGpos(pictureBox1.Location.X);
                
            }
            if (second.getBGpos() >= pictureBox1.Width)
            {
                second.resetBGpos(pictureBox1.Location.X);
            }
            
            pictureBox1.Refresh();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            first.DrawBG(e.Graphics);
            second.DrawBG(e.Graphics);
            rocket.DrawSprite(e.Graphics);
            fire[i].DrawSprite(e.Graphics);
            
            if (i >= 12)
                i = 0;
            i++;

            if (isExplosion)
            {
                timer2.Start();
                if (j >= 9)
                {
                    timer2.Stop();
                    j = 0;
                    isExplosion = false;
                }
               

                if (time%2 == 0)
                {
                    explosion[j].setX(0);
                    explosion[j].DrawSpriteSpecified(e.Graphics, 100, 100);

                    
                    j++;
                }
                    
                
                
            }
           if (torpedoFiredSwitch)
            {
              //  torpedoFiredSwitch = false;
              //  torpedoHitWall = false;
                torpedo.DrawTorpedo(e.Graphics);
               
            }
            e.Graphics.DrawString("^", new Font("Arial", 20), Brushes.Red, 400, pictureBox1.Location.Y);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            torpedoFiredSwitch = true;
        }

    }
}
