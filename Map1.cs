using System;
using System.Drawing;
using System.Windows.Forms;
using EarlyLateGame.Entities;
using EarlyLateGame.Game;
using EarlyLateGame.GameObjects;
using System.Collections.Generic;
using System.IO;
//Primery code
namespace EarlyLateGame
{
    public partial class Map1 : Form
    {
        public static PaintEventArgs p;
        private PlayerControl pc;
        public Graphics gameGraphic;
        private Player player;
        private Player enemyPlayer;
        private static GameGraphics background = new GameGraphics(GameVariables.BackgroundColor, 0, 0, GameVariables.mapSize * (GameVariables.groundSquareSize + GameVariables.borderSize), true);
        Ground[,] OverallMap = new Ground[GameVariables.mapSize, GameVariables.mapSize];
        List<Tree> Wood = new List<Tree>();

        public Map1()
        {
            InitializeComponent();
            CreateEntities();
            CreateMap();
        }
        public void CreateMap()
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    Ground newGround = new Ground(x, y);
                    newGround.viewZone = new ControlZone(x, y, false, GameVariables.ZoneColor, GameVariables.zoneSquareSize);
                    OverallMap[x, y] = newGround;
                }
            }
        }
        public void Render_map(Graphics gameGraphic)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    OverallMap[x, y].gg.RenderFill(gameGraphic);
                    OverallMap[x, y].viewZone = new ControlZone(x, y, false, GameVariables.ZoneColor, GameVariables.zoneSquareSize);
                }
            }
        }
        public void Map1_Paint(object sender, PaintEventArgs e)
        {
            gameGraphic = CreateGraphics();
            background.RenderFill(gameGraphic);
                       
            Render_map(gameGraphic);
            RenderEntitiesPosition(gameGraphic);
        }
        public void CreateEntities()
        {
            Wood.Add(new Tree(3, 5));
            Wood.Add(new Tree(6, 5));

            player = new Player(0, 0);
            enemyPlayer = new Player(6, 6);
        }
        public virtual void RenderEntitiesPosition(Graphics gameGraphic)
        {
            //Trees
            foreach (Tree tree in Wood)
            {
                OverallMap[tree.posX, tree.posY].tree = tree;
                OverallMap[tree.posX, tree.posY].GameObjectOnGround(true, gameGraphic);
            }
            //Player
            OverallMap[player.posX, player.posY].PlayerOnGround(player, gameGraphic);
            //EnemyPlayer
            OverallMap[enemyPlayer.posX, enemyPlayer.posY].PlayerOnGround(enemyPlayer, gameGraphic);
        }    
        ////////////////////////////////////
        public static void setText(string text)
        {
        }
        private void Map1_MouseClick(object sender, MouseEventArgs control)
        {
            pc = new PlayerControl(player);
            int overallMapSize = GameVariables.mapSize * (GameVariables.groundSquareSize + GameVariables.borderSize);
            if (control.Button == MouseButtons.Left && control.Location.X <= overallMapSize && control.Location.Y <= overallMapSize)
            {
                if (pc.player.isSelected == false)
                {
                    pc.SelectPlayer(OverallMap, gameGraphic, control.Location);
                } else
                {
                    if (pc.CanMove(OverallMap, control.Location) == true && pc.PlayerLocation(control.Location) == false)
                    {
                        pc.MovePlayer(OverallMap, gameGraphic);
                    }else if (pc.PlayerLocation(control.Location) == true)
                    {
                        pc.SelectPlayer(OverallMap, gameGraphic, control.Location);
                    }
                     else
                    {
                        pc.Attack(OverallMap, gameGraphic);
                    }
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "7012")
            {
                debugText.Enabled = true;
                debugText.Visible = true;
            }
        }

        private void Map1_Load(object sender, EventArgs e)
        {

        }
    }
}

