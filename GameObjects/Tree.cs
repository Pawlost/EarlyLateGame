using EarlyLateGame.Game;
using EarlyLateGame.Entities;
using System.Drawing;

namespace EarlyLateGame.GameObjects
{
    class Tree : Ground
    {

        private int health = GameVariables.lowerObjectHealth;
        public bool dead = false;
        private int xpReward = GameVariables.objectAverageXPReward;
        public static int objectSize = GameVariables.entitiSquareSize;
        public static Color lifeColor = GameVariables.TreeColor;
        public static Color deathColor = GameVariables.DeadEntity;

        public Tree(int posX, int posY) : base(posX, posY)
        {
            this.posX = posX;
            this.posY = posY;
        }
        public void CutDown(Player attacker)
        {
            if (dead)
            {

                gg.filling = deathColor;

                attacker.choppedTree += 1;
                attacker.AddExp(xpReward);

            }
        }
    
        public void Cut(int damage, Player attacker)
        {
            health -= damage; 
            if (health <= 0)
            {
                dead = true;
                CutDown(attacker);
            }
        }

    }
}
