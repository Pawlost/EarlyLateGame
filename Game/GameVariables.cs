using System.Drawing;

namespace EarlyLateGame.Game
{
    class GameVariables
    {
        public static int groundSquareSize = 55;
        public static int entitiSquareSize = 30;
        public static int zoneSquareSize = 40;


        public static int mapSize = 10;
        public static int turnsToEnd = 60;
        public static int curruntTurn = 1;
        public static int borderSize = 5;

        public static int monsterAverageXPReward = 20;
        public static int monsterAveregeDamage = 10;
        public static int monsterAverageHealth = 40;

        public static int lowerObjectHealth = 10;
        public static int objectAverageXPReward = 10;

        public static int playerAverageDamage = 20;
        public static int playerAverageHealth = 100;

        public static Color ZoneColor = Color.FromArgb(128,255,255,255);
        public static Color BorderColor = Color.Black;
        public static Color BackgroundColor = Color.Black;

        public static Color PlayerColor = Color.Blue;
        public static Color MonsterColor = Color.Brown;
        public static Color EnemyMobColor = Color.DarkRed;

        public static Color GroundColor = Color.Green;
        public static Color TreeColor = Color.DarkGreen;
        public static Color RockColor = Color.DarkGray;

        public static Color DestroyedObject = Color.Yellow;
        public static Color DeadEntity = Color.Tomato;
     }
}
