using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarlyLateGame.Game;
using System.Drawing;

namespace EarlyLateGame.GameObjects
{
    class ViewZone
    {
        private bool canWalk = true;
        public GameGraphics gg;
        private Color filling;

        private int posX;
        private int posY;
        public bool visible;

        public ViewZone(int posX, int posY, bool visible, Color filling, int squareSize)
        {
            this.posX = posX;
            this.posY = posY;
            this.filling = filling;

            this.visible = visible;

            gg = new GameGraphics(filling, posX, posY, squareSize, false);

        }
        public virtual void CanView(Graphics g, bool visible)
        {
            this.visible = visible;
            if (visible)
            {
                gg.filling = filling;
                gg.CentreRenderFill(g);
            }
            else
            {
                gg.filling = GameVariables.GroundColor;
                gg.CentreRenderFill(g);
            }
        }
    }
}
