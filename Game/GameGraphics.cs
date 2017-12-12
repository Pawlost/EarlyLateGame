using System;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Game
{
    //also for posx posY * 60 + (60 - this.height) / 2
    //Color.FromArgb(125,0,0,0)); soo cool
    public class GameGraphics
    {
        private static float groundSize = GameVariables.groundSquareSize;
        public RectangleF centrePositionF;
        public RectangleF positionSizeF;
        public Rectangle rectangleObjectI;
        public Color filling;

        private int posX;
        private int posY;
        private int squareSize;

        public GameGraphics(Color filling, int posX, int posY, int squareSize, bool renderBackground)
        { 
            this.posX = posX;
            this.posY = posY;
            this.filling = filling;
            this.squareSize = squareSize;

            if (renderBackground)
                positionSizeF = new RectangleF(posX * (groundSize + GameVariables.borderSize), posY * (groundSize + GameVariables.borderSize), squareSize + GameVariables.borderSize, squareSize + GameVariables.borderSize);
            else
                SetRenderPositionF(posX, posY, squareSize, false);

            Rectangle.Truncate(positionSizeF);
        }
        public void SetRenderPositionF(int posX, int posY, int squareSize,bool isCentr) {
            this.posX = posX;
            this.posY = posY;

            this.squareSize = squareSize;
            positionSizeF = new RectangleF((posX * (groundSize + GameVariables.borderSize)) + GameVariables.borderSize, (posY * (groundSize + GameVariables.borderSize)) + GameVariables.borderSize, squareSize, squareSize);
            if (isCentr)
                centrePositionF = new RectangleF(positionSizeF.X + (groundSize - squareSize) / 2, positionSizeF.Y + (groundSize - squareSize) / 2, squareSize, squareSize);
        }
        public virtual void RenderFill(Graphics g)
        {
            g.FillRectangle(new SolidBrush(filling), positionSizeF);
        }
        public virtual void CentreRenderFill(Graphics g)
        {
            SetRenderPositionF(posX, posY, squareSize, true);
            g.FillRectangle(new SolidBrush(filling), centrePositionF);
        }
        public virtual void RenderSelect(Graphics g, int penSize) {
            Pen p = new Pen(filling, penSize);
            g.DrawLine(p, centrePositionF.X, centrePositionF.Y, centrePositionF.X + centrePositionF.Width, centrePositionF.Y + centrePositionF.Height);
        }
    }
}
