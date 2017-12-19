using EarlyLateGame.Game;
using EarlyLateGame.Entities;
using System.Drawing;

namespace EarlyLateGame.GameObjects
{
    class Tree
    {

        private static int xpReward = GameVariables.objectAverageXPReward;
        public static int objectSize = GameVariables.entitiSquareSize;
        private static int health = GameVariables.lowerObjectHealth;
        public int posX;
        public int posY;

        public bool dead = false;

        public GameGraphics gg;

        public static Color lifeColor = GameVariables.TreeColor;
        public static Color deathColor = GameVariables.DeadEntity;

        public Tree(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;

            gg = new GameGraphics(lifeColor, posX, posY, objectSize, false);
        }
        public virtual void Cut(Player attacker, Graphics g)
        {
            health -= attacker.Attack(); 
            if (health <= 0)
            {
                dead = true;
               
                gg.filling = deathColor;
                gg.CentreRenderFill(g);

                attacker.choppedTree += 1;
                attacker.AddExp(xpReward);
            }
        }

    }
}
