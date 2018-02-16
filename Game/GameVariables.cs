using System;
using System.Drawing;

namespace EarlyLateGame.Game
{
    class GameVariables
    {
        public static int groundSquareSize = 55;
        public static int entitiSquareSize = 30;
        public static int zoneSquareSize = 55;
        public static int selectLineSize = 3;

        public static int mapSize = 10;
        public static int turnsToEnd = 60;
        public static int curruntTurn = 1;

        public static int monsterAverageXPReward = 20;
        public static int monsterAveregeDamage = 10;
        public static int monsterAverageHealth = 40;

        public static int lowerObjectHealth = 10;
        public static int objectAverageXPReward = 10;

        public static int playerAverageDamage = 20;
        public static int playerAverageHealth = 100;

        public static Color ZoneColor = Color.FromArgb(128, 255, 255, 255);
        //public static Color BackgroundColor = Color.Gold;

        //TEXTURES
        private static string baseTextureFolder = AppDomain.CurrentDomain.BaseDirectory + "Tsextures/";
        private static string gameObjectsTextureFolder = baseTextureFolder + "GameObjects/";
        private static string entitiesTextureFolder = baseTextureFolder + "Entities/";

        private static string playerTextureFolder = entitiesTextureFolder + "Player/";
        private static string enemyPlayerTextureFolder = entitiesTextureFolder + "EnemyPlayer/";
        private static string monsterTextureFolder = entitiesTextureFolder + "Monster/";

        private static string treeTextureFolder = entitiesTextureFolder + "Tree/";

        public static Bitmap LivePlayerImage = (Bitmap)Image.FromFile(playerTextureFolder + "LivePlayer.png");
        public static Bitmap LiveEnemyPlayerImage = (Bitmap)Image.FromFile(enemyPlayerTextureFolder + "LiveEnemyPlayer.png", false);
        public static Bitmap LiveMonsterImage = (Bitmap)Image.FromFile(monsterTextureFolder + "LiveMonster.png", false);

        public static Bitmap DeadPlayerImage = (Bitmap)Image.FromFile(playerTextureFolder + "DeadPlayer.png");
        public static Bitmap DeadEnemyPlayerImage = (Bitmap)Image.FromFile(enemyPlayerTextureFolder + "DeadEnemyPlayer.png", false);
        public static Bitmap DeadMonsterImage = (Bitmap)Image.FromFile(monsterTextureFolder + "DeadMonster.png", false);

        public static Bitmap GroundTexture = (Bitmap)Image.FromFile(gameObjectsTextureFolder + "Ground.png", false);
        public static Bitmap ControlZoneImage = (Bitmap)Image.FromFile(gameObjectsTextureFolder + "ControlZone.png", false);
        public static Bitmap TreeImage = (Bitmap)Image.FromFile(treeTextureFolder + "Tree.png", false);

        public static Bitmap RockImage = (Bitmap)Image.FromFile(baseTextureFolder + "Rock.png", false);

        public static Bitmap InvisibleTexture = GroundTexture;
    }
}
