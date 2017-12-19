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

        public Player(int posX, int posY) : base(posX, posY, entitySize: GameVariables.entitiSquareSize, lifeColor: GameVariables.PlayerColor, deathColor: GameVariables.DeadEntity, visible: true)
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
            if (!dead && isSelected == true)
            {
                this.isSelected = true;
                gg.filling = Color.Black;
                gg.RenderSelect(g, 3);
                View(g);
            }
            else
            {
                this.isSelected = false;
                gg.filling = GameVariables.PlayerColor;
                gg.RenderSelect(g, 3);
                View(g);
                gg.CentreRenderFill(g);
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
            gg.SetRenderPositionF(posX, posY, GameVariables.entitiSquareSize, true);
            gg.CentreRenderFill(g);
            View(g);
        }

        public void Hurt(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                dead = true;
                isSelected = false;
                IsDying();
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
                            overallMap[posX + x, posY + y].viewZone.CanView(g, true);
                    }
                }
            }
        }
    }
}

