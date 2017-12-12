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

        public Color lifeColor;
        public Color deathColor;
        public GameGraphics gg;

        public BasicEntity(int posX, int posY, int entitySize, Color lifeColor, Color deathColor, bool visible)
        {
            this.posX = posX;
            this.posY = posY;
            this.visible = visible;
            this.lifeColor = lifeColor;
            this.deathColor = deathColor;
            this.entitySize = entitySize;

            gg = new GameGraphics(lifeColor, posX, posY, entitySize, false);
            SetPosition(posX,posY);
        }

        public void IsDying()
        {
            if (dead || !visible)
            {
                gg.filling = deathColor;
            }
        }

        public void SetPosition(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public void SetDeathColor(Color color)
        {
            deathColor = color;
        }
        public void SetLiveColor(Color color)
        {
            lifeColor = color;
        }

        public virtual void SetVisible(bool visible)
        {
            this.visible = visible;
        }
    }
}
