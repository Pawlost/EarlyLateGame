using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EarlyLateGame.Game;
using System.Drawing;

namespace EarlyLateGame.GameObjects
{
    class ControlZone
    {
        public GameGraphics gg;
        private Bitmap textureImage;

        private int posX;
        private int posY;
        public bool visible;

        public ControlZone(int posX, int posY, bool visible, Bitmap textureImage, int entitySize)
        {
            this.posX = posX;
            this.posY = posY;
            this.textureImage = textureImage;

            this.visible = visible;

            gg = new GameGraphics(posX, posY, entitySize, true, textureImage);
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
