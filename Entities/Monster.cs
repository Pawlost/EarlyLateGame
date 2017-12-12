using System.Drawing;
using EarlyLateGame.Game;

namespace EarlyLateGame.Entities
{
    class Monster : BasicEntity
    {
        private int xpReward = GameVariables.monsterAverageXPReward;
        public int health = GameVariables.monsterAverageHealth;
        private int damege = GameVariables.monsterAveregeDamage; 

        public Monster(int posX, int posY) : base(posX, posY,entitySize:GameVariables.entitiSquareSize, lifeColor:GameVariables.MonsterColor,deathColor:GameVariables.DeadEntity,visible:true)
        {
            this.posX = posX;
            this.posY = posY;
        }    
    }
}
