using System.Drawing;
using EarlyLateGame.Game;

namespace EarlyLateGame.Entities
{
    class EnemyMob : BasicEntity
    {
        public EnemyMob(int posX, int posY) : base(posX, posY, entitySize: GameVariables.entitiSquareSize, lifeColor:GameVariables.EnemyMobColor, deathColor:GameVariables.DeadEntity, visible:true) {
            this.posX = posX;
            this.posY = posY;
        }
    }
}
