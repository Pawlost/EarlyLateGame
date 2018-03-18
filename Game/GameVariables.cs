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

        public static int mapSize = 100;
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
        private static string baseTextureFolder = "C:/Users/balda/Desktop/MyProjects/EarlyLateGame/Textures/";
        private static string gameObjectsTextureFolder = baseTextureFolder + "GameObjects/";
        private static string entitiesTextureFolder = baseTextureFolder + "Entities/";

        private static string playerTextureFolder = entitiesTextureFolder + "Player/";
        private static string enemyPlayerTextureFolder = entitiesTextureFolder + "EnemyPlayer/";
        private static string monsterTextureFolder = entitiesTextureFolder + "Monster/";

        private static string treeTextureFolder = gameObjectsTextureFolder + "Tree/";
    
        public static Image LivePlayerImage = Image.FromFile(playerTextureFolder + "LivePlayer.png");
        public static Image LiveEnemyPlayerImage = Image.FromFile(enemyPlayerTextureFolder + "LiveEnemyPlayer.png", false);
        public static Image LiveMonsterImage = Image.FromFile(monsterTextureFolder + "LiveMonster.png", false);

        public static Image DeadPlayerImage = Image.FromFile(playerTextureFolder + "DeadPlayer.png");
        public static Image DeadEnemyPlayerImage = Image.FromFile(enemyPlayerTextureFolder + "DeadEnemyPlayer.png", false);
        public static Image DeadMonsterImage = Image.FromFile(monsterTextureFolder + "DeadMonster.png", false);

        public static Image GroundTexture = Image.FromFile(gameObjectsTextureFolder + "Ground.png", false);
        public static Image ControlZoneImage = Image.FromFile(gameObjectsTextureFolder + "ControlZone.png", false);
        public static Image TreeImage = Image.FromFile(treeTextureFolder + "Tree.png", false);

        public static Image RockImage = Image.FromFile(gameObjectsTextureFolder + "Rock.png", false);

        public static Image InvisibleTexture = GroundTexture;
    }
}
