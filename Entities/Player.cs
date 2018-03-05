using EarlyLateGame.Game;
using EarlyLateGame.GameObjects;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Entities
{
    class Player : BasicEntity
    {
        public static int exp = 0;
        public static int health = GameVariables.playerAverageHealth;
        public int choppedTree = 0;
        public bool isSelected = false;
        private static int damage = GameVariables.playerAverageDamage;

        private Ground[,] overallMap = new Ground[10, 10];


        public Player(int posX, int posY) : base(posX, posY, entitySize: GameVariables.entitiSquareSize, lifeImage: GameVariables.LivePlayerImage, deathImage: GameVariables.DeadPlayerImage, visible: true)
        {
            this.posX = posX;
            this.posY = posY;
        }

        public int Attack()
        {
            return damage;
        }
        public virtual void Select(bool isSelected, Ground[,] overallMap, Graphics g)
        {
            this.overallMap = overallMap;
            //argument
            if (!dead && isSelected)
            {
                this.isSelected = isSelected;
                gg.setImage(lifeImage);
                gg.CentreRenderFill(g);
                gg.RenderSelect(g, isSelected);
                View(g);
            }
            else
            {
                this.isSelected = isSelected;
                gg.setImage(lifeImage);
                gg.RenderSelect(g, isSelected);
                gg.CentreRenderFill(g);
                View(g);
            }
        }

        public void AddExp(int experience)
        {
            exp += experience;
        }
        public virtual void MoveToPosition(int moveX, int moveY, Graphics g)
        {
            posX = moveX;
            posY = moveY;
            gg.setImage(lifeImage);
            gg.setPosition(moveX, moveY);
            gg.CentreRenderFill(g);
            View(g);
        }

        public void Hurt(int damage, Graphics g)
        {
            health -= damage;
            if (health <= 0)
            {
                dead = true;
                isSelected = false;
                IsDying(g);
            }
        }
        public virtual void View(Graphics g)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (posX + x >= 0 && posY + y >= 0 && posX + x < GameVariables.mapSize && posY + y < GameVariables.mapSize && isSelected)
                    {
                        if (posX + x != posX || posY + y != posY)
                            overallMap[posX + x, posY + y].viewZone.canView(g, true);
                    }
                }
            }
        }
    }
}

