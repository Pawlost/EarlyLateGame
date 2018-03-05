using System;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Game
{
    //Color.FromArgb(125,0,0,0)); soo cool
    public class GameGraphics
    {
        private static int groundSize = GameVariables.groundSquareSize; //taking value from global values
  
        public int posX;
        public int posY;
        public float centrePosX;
        public float centrePosY;
        private bool isCentred;

        public Image image;

        public GameGraphics(int posX, int posY, bool isCentred, Image image)
        {
            this.posX = posX * groundSize;
            this.posY = posY * groundSize;
            centrePosX = this.posX + (groundSize - image.Width) / 2;
            centrePosY = this.posY + (groundSize - image.Height) / 2;
            this.image = image;
            this.isCentred = isCentred;
        }
        //render rectangle
        public virtual void RenderFill(Graphics g)
        {
            g.DrawImage(image, posX, posY);
        }
        //render object in center of rectangle
        public virtual void CentreRenderFill(Graphics g)
        {
            g.DrawImage(image,centrePosX, centrePosY);
        }
        //for selected players
        public virtual void RenderSelect(Graphics g, bool select)
        {
            if (select)
            {
                Pen p = new Pen(Color.Black, GameVariables.selectLineSize);
                g.DrawLine(p,centrePosX, centrePosY, centrePosX + image.Width, centrePosY + image.Height);
            }
            else
            {
                if (isCentred)
                {
                    CentreRenderFill(g);
                }
                else
                {
                    RenderFill(g);
                }
            }
        }
        public void setImage(Image image)
        {
            this.image = image;
        }
        public void setPosition(int posX, int posY) {
            this.posX = posX * groundSize;
            this.posY = posY * groundSize;
            centrePosX = this.posX + (groundSize - image.Width) / 2;
            centrePosY = this.posY + (groundSize - image.Height) / 2;
        }
    }
}
