using System.Drawing;
using EarlyLateGame.Game;
namespace EarlyLateGame.Entities
{
    class BasicEntity
    {
        public int posX;
        public int posY;
        public int entitySize;

        protected bool dead = false;
        public bool visible;

        public GameGraphics gg;
        protected Bitmap lifeImage;
        protected Bitmap deathImage;

        public BasicEntity(int posX, int posY, int entitySize, Bitmap lifeImage, Bitmap deathImage, bool visible)
        {
            this.posX = posX;
            this.posY = posY;
            this.visible = visible;
            this.lifeImage = lifeImage;
            this.deathImage = deathImage;
            this.entitySize = entitySize;

            gg = new GameGraphics(posX, posY, entitySize, true, lifeImage);
            //SetPosition(posX,posY);
        }

        public void IsDying()
        {
            if (dead)
            {
                gg.SetRenderPositionF(posX, posY, entitySize, true, deathImage);
            }
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public void SetDeathTexture(Bitmap image)
        {
            deathImage = image;
        }
        public void SetLiveTexture(Bitmap image)
        {
            lifeImage = image;
        }

        public virtual void SetVisible(bool visible)
        {
            this.visible = visible;
        }
    }
}
