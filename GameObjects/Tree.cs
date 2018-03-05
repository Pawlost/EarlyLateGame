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

        public static Image treeColor = GameVariables.TreeImage;

        public Tree(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;

            gg = new GameGraphics(posX, posY, false, treeColor);
        }
        public virtual void Cut(Player attacker, Graphics g)
        {
        }

    }
}
