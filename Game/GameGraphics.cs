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
        //public Rectangle rectangleObjectI;//retype positionSizeF to int rectangle(int rectangle)
        public Color filling; //filling of rectagle

        private int posX;
        private int posY;
        private int rectangleSize;

        public GameGraphics(Color filling, int posX, int posY, int rectangleSize, bool renderBackground)
        { 
            this.posX = posX;
            this.posY = posY;
            this.filling = filling;
            this.rectangleSize = rectangleSize;

            if (renderBackground)
                //if true creates rectangle in background of map, it is used for border between grounds
                positionSizeF = new RectangleF(posX * (groundSize + GameVariables.borderSize), posY * (groundSize + GameVariables.borderSize), rectangleSize + GameVariables.borderSize, rectangleSize + GameVariables.borderSize);
            else
                SetRenderPositionF(posX, posY, rectangleSize, false);

            //Rectangle.Truncate(positionSizeF);
        }
        public void SetRenderPositionF(int posX, int posY, int rectangleSize, bool isCentr) {
            this.posX = posX;
            this.posY = posY;

            this.rectangleSize = rectangleSize;
            positionSizeF = new RectangleF((posX * (groundSize + GameVariables.borderSize)) + GameVariables.borderSize, (posY * (groundSize + GameVariables.borderSize)) + GameVariables.borderSize, rectangleSize, rectangleSize);
            if (isCentr)
                centrePositionF = new RectangleF(positionSizeF.X + (groundSize - rectangleSize) / 2, positionSizeF.Y + (groundSize - rectangleSize) / 2, rectangleSize, rectangleSize);
        }
        public virtual void RenderFill(Graphics g)
        {
            g.FillRectangle(new SolidBrush(filling), positionSizeF);
        }
        public virtual void CentreRenderFill(Graphics g)
        {
            SetRenderPositionF(posX, posY, rectangleSize, true);
            g.FillRectangle(new SolidBrush(filling), centrePositionF);
        }
        public virtual void RenderSelect(Graphics g, int penSize) {
            Pen p = new Pen(filling, penSize);
            g.DrawLine(p, centrePositionF.X, centrePositionF.Y, centrePositionF.X + centrePositionF.Width, centrePositionF.Y + centrePositionF.Height);
        }
    }
}
