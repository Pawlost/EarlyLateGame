using System;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Game
{
    //Color.FromArgb(125,0,0,0)); soo cool
    public class GameGraphics
    {
        private static float groundSize = GameVariables.groundSquareSize; //taking value from global values
        public RectangleF centrePositionF; //position for entities in center of field
        public RectangleF positionSizeF; //position of rectangle from top-left side (float rectangel)
  
        private int posX;
        private int posY;
        private int rectangleSize;
        private bool isCentred;

        private TextureBrush objectTexture;
        private Image image;

        public GameGraphics(int posX, int posY, int rectangleSize, bool isCentred, Bitmap image)
        { 
            SetRenderPositionF(posX, posY, rectangleSize, isCentred, image);
        }
        public void SetRenderPositionF(int posX, int posY, int rectangleSize, bool isCentred, Bitmap image) {
            this.posX = posX;
            this.posY = posY;
            this.rectangleSize = rectangleSize;
            this.image = image;

            positionSizeF = new RectangleF(posX * groundSize, posY * groundSize, rectangleSize, rectangleSize);
            objectTexture = new TextureBrush(image, positionSizeF);
            if (isCentred)
            {
                centrePositionF = new RectangleF(positionSizeF.X + (groundSize - rectangleSize) / 2, positionSizeF.Y + (groundSize - rectangleSize) / 2, rectangleSize, rectangleSize);
                objectTexture = new TextureBrush(image, centrePositionF);
            }
        }
        public virtual void RenderFill(Graphics g)
        {
            g.FillRectangle(objectTexture, positionSizeF);
        }
        public virtual void CentreRenderFill(Graphics g)
        {
            SetRenderPositionF(posX, posY, rectangleSize, true, image);
            g.FillRectangle(objectTexture, centrePositionF);
        }
        public virtual void RenderSelect(Graphics g, bool select) {
            if (select) {
                Pen p = new Pen(Color.Black, GameVariables.selectLineSize);
                g.DrawLine(p, centrePositionF.X, centrePositionF.Y, centrePositionF.X + centrePositionF.Width, centrePositionF.Y + centrePositionF.Height);
            }
            else{
                if (isCentred)
                    CentreRenderFill(g);
                else
                    RenderFill(g);             
            }       
        }
    }
}
