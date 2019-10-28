using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteAnimated
{
    class Sprite
    {
        private float x, y, width, height, position;
        int frameTime;
        private Image img;

        public Sprite(float x, float y, Image img)
        {
            this.x = x;
            this.y = y;
            this.width = x + img.Width;
            this.height = y + img.Height;
            this.img = img;
            position = 0;
            frameTime = 0;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(img, x, y);
            
        }
        public void DrawSpriteSpecified(Graphics g, int width, int height)
        {
            g.DrawImage(img, x, y, width, height);
        }

        public void DrawTorpedo(Graphics g)
        {
            
            g.DrawImage(img, position, y);
        }

        public float getWidth()
        {
            return width;
        }

        public float getHeight()
        {
            return height;
        }

        public float getX()
        {
            return x;
        }

        public float getY()
        {
            return y;
        }

        public void setX(float x)
        {
            this.x = x;
        }

        public void setY(float y)
        {
            this.y = y;
        }

        public float getPos()
        {
            return position;
        }

        public void setPos(float pos)
        {
            position = position + pos;
        }

        public void resetPos(float pos)
        {
            position = pos;
        }
    }
}
