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
        private Image textureImage;

        private int posX;
        private int posY;
        public bool visible;

        public ControlZone(int posX, int posY, bool visible, Image textureImage, int entitySize)
        {
            this.posX = posX;
            this.posY = posY;
            this.textureImage = textureImage;

            this.visible = visible;

            gg = new GameGraphics(posX, posY, true, textureImage);
        }
        public virtual void canView(Graphics g, bool visible)
        {
            this.visible = visible;
            if (visible)
            {
                gg.setImage(GameVariables.ControlZoneImage);
                gg.CentreRenderFill(g);
            }
            else
            {
                gg.setImage(GameVariables.GroundTexture);
                gg.CentreRenderFill(g);
            }
        }
    }
}
