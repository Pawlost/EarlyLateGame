using System;
using System.Drawing;
using System.Windows.Forms;
using EarlyLateGame.Entities;
using EarlyLateGame.Game;
using EarlyLateGame.GameObjects;

namespace EarlyLateGame
{
    public partial class Map1 : Form
    {
        public static PaintEventArgs p;
        private PlayerControl pc;
        public Graphics gameGraphic;
        private Player early;
        private Player late;
        private static GameGraphics background = new GameGraphics(GameVariables.BackgroundColor, 0, 0, GameVariables.mapSize * (GameVariables.groundSquareSize + GameVariables.borderSize), true);
        Ground[,] OverallMap = new Ground[GameVariables.mapSize, GameVariables.mapSize];

        public Map1()
        {
            InitializeComponent();
            //vrstva2[0, 1] =  new Prisera(2, 1);
            //vrstva2[2, 0] =  new Prisera(2, 2);

            //  hrac1 = new Hrac(60, 60);
            /*
             th = new Thread(new ThreadStart( vykresleniMapyATD));
            th.Name = "grafika";
            th.Start();*/
        }
        public void CreateMap()
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    Ground newGround = new Ground(x, y);
                    newGround.viewZone = new ViewZone(x, y, false, GameVariables.ZoneColor, GameVariables.zoneSquareSize);
                    OverallMap[x, y] = newGround;
                }
            }
        }
        public void Render_map()
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    OverallMap[x, y].gg.RenderFill(gameGraphic);
                    OverallMap[x, y].viewZone = new ViewZone(x, y, false, GameVariables.ZoneColor, GameVariables.zoneSquareSize);
                }
            }
        }
        public void Map1_Paint(object sender, PaintEventArgs e)
        {
            gameGraphic = CreateGraphics();
            CreateMap();
            background.RenderFill(gameGraphic);
            Render_map();
            CreateEntities();
        }
        public void CreateEntities()
        {
            
            Tree tree = new Tree(3,5);
            OverallMap[tree.posX, tree.posY].tree = tree;
            OverallMap[tree.posX, tree.posY].GameObjectOnGround(true, gameGraphic);

            Tree tree2 = new Tree(6, 5);
            OverallMap[tree.posX, tree.posY].tree = tree;
            OverallMap[tree.posX, tree.posY].GameObjectOnGround(true, gameGraphic);

    
            early = new Player(0, 0);
            OverallMap[early.posX, early.posY].PlayerOnGround(early, gameGraphic);

            late = new Player(7, 7);
            OverallMap[late.posX, late.posY].PlayerOnGround(late, gameGraphic);
        }
        ////////////////////////////////////
        public static void setText(string text)
        {
        }
        private void Map1_MouseClick(object sender, MouseEventArgs control)
        {
            pc = new PlayerControl(early);
            if (control.Button == MouseButtons.Left && pc.player.isSelected == false)
            {
                pc.SelectPlayer(OverallMap, gameGraphic, control.Location);
            }
            if (control.Button == MouseButtons.Left && pc.player.isSelected == true)
            {
                pc.MovePlayer(OverallMap, control.Location, gameGraphic);
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

