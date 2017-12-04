using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame
{
    class Ctverecek
    {
        private int posX;
        private int posY;
        private int width;
        private int height;
        private Color color;
        private bool visible;

        SolidBrush bh;
        SolidBrush mrtvy = new SolidBrush(Color.Gray);//Color.FromArgb(125,0,0,0)); soo cool

        public Ctverecek(int posX, int posY, int width,int height, Color color,bool visible)
        {
            this.posX = posX;
            this.posY = posY;
            this.visible = visible;
            this.color = color;
            this.bh = new SolidBrush(color);
            this.height = height;
            this.width = width;
        }
        public virtual void vykresleni(Graphics g)
        {
            if (visible)
            {                
                g.FillRectangle(this.bh, posX *60 + ((60 - this.width) /2 ) , posY * 60 + (60 - this.height) / 2 , this.width, this.height);
            }
            else
            {
                g.FillRectangle(this.mrtvy, posX * 60 + ((60 - this.width) / 2), posY * 60 + (60 - this.height) / 2 , this.width, this.height);
            }
        }
        public void setBrush(Color color)
        {
            this.bh = new SolidBrush(color);
        }
        public virtual void setVisible(bool visible)
        {
            this.visible = visible;
        }
        public void setPosX(int posX)
        {
            this.posX = this.posX + posX;
        }
        public void setPosY(int posY)
        {
            this.posY = this.posY + posY;
        }
        public int getPosX()
        {
            return (this.posX);
        }
        public int getPosY()
        {
            return (this.posY);
        }

        public bool getVisible()
        {
            return this.visible;
        }
        public void setToChangeValuPosX(int posX)
        {
            this.posX =  posX;
        }
        public void setToChangeValuPosY(int posY)
        {
            this.posY = posY;
        }
        public virtual void interact(Hrac hrac)
        {
            MessageBox.Show("interagujes se ctvereckem", null, MessageBoxButtons.YesNo);
        }
            public void setColor()
        {

        }
        public Color getColor()
        {
            return this.color;
        }


    }
}
