using System.Drawing;
using EarlyLateGame.Game;
using EarlyLateGame.Entities;

namespace EarlyLateGame.GameObjects
{
    class Ground
    {
        public int posX;
        public int posY;

        public bool isPlayerHere;
        public bool isObjectHere;

        protected bool isDestructable =false;

        public Player player;
        public Tree tree;
        public GameGraphics gg;
        public ControlZone viewZone;

        public Ground(int posX, int posY)
        {
            gg = new GameGraphics( posX, posY, false, GameVariables.GroundTexture);

            this.posX = posX;
            this.posY = posY;   
        }
        public virtual void PlayerOnGround(Player player, Graphics g)
        {
            if (player != null)
            {
                player.gg.setImage(GameVariables.LivePlayerImage);
                player.gg.CentreRenderFill(g);
                this.player = player;
                isPlayerHere = true;
            }
            else
            {
                this.player.gg.setImage(GameVariables.GroundTexture);
                this.player.gg.CentreRenderFill(g);
                this.player.gg.RenderSelect(g, true);
                this.player = null;
                isPlayerHere = false;
            }
        }
        public virtual void GameObjectOnGround(bool isObjectHere, Graphics g)
        {
            this.isObjectHere = isObjectHere;
            if (isObjectHere) {
                if (tree != null) {
                    tree.gg.setImage(GameVariables.TreeImage);
                    tree.gg.CentreRenderFill(g);
                }
            }
        }
    }
}
