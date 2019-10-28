using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteAnimated
{
    class Background
    {
        private int x1, y1, x2, y2, BGposition;
        private Image img; 



        public Background(int x1, int x2, int y1, int y2, int slideSpeedX, Image img)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            this.img = img;
            BGposition = 0;
        }

        public void DrawBG(Graphics g)
        {
            g.DrawImage(img, BGposition, y1);
            if (BGposition > 0)
            {
                g.DrawImage(img, x1 - (img.Width - BGposition), y1);
            }
        
           
        }

        public int getBGpos()
        {
            return BGposition;
        }
        public void setBGpos(int x)
        {
            BGposition = BGposition + x;
        }

        public void resetBGpos(int x)
        {
            BGposition = x;
        }
    }
}
