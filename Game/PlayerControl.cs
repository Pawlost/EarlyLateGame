using EarlyLateGame.Entities;
using EarlyLateGame.GameObjects;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Game
{
    class PlayerControl
    {
        public Player player;
        private Point playerLocation;

        public PlayerControl(Player player)
        {
            this.player = player;    
        }
        public virtual void SelectPlayer(Ground[,] overallMap, Graphics g, Point mouseLocation)
        {
            float posX = player.gg.centrePositionF.X + player.gg.centrePositionF.Width;
            float posY = player.gg.centrePositionF.Y + player.gg.centrePositionF.Height;
            if (mouseLocation.X > player.gg.centrePositionF.X && mouseLocation.X < posX && mouseLocation.Y > player.gg.centrePositionF.Y && mouseLocation.Y < posY)
            {

                if (overallMap[player.posX, player.posY].player.isSelected == false)
                {
                    overallMap[player.posX, player.posY].player.Select(true, overallMap, g);
                }
                else
                {
                    overallMap[player.posX, player.posY].player.Select(false, overallMap, g);
                }
            }
        }
        public virtual void MovePlayer(Ground[,] overallMap, Point mouseLocation, Graphics g)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    ViewZone view = overallMap[x, y].viewZone;

                    float posX = view.gg.centrePositionF.X + view.gg.centrePositionF.Width;
                    float posY = view.gg.centrePositionF.Y + view.gg.centrePositionF.Height;

                    if (mouseLocation.X > view.gg.centrePositionF.X && mouseLocation.X < posX && mouseLocation.Y > view.gg.centrePositionF.Y && mouseLocation.Y < posY)
                    {
                        if (view.visible && overallMap[x, y].isPlayerHere == false && overallMap[x, y].isObjectHere == false)
                        {
                            player.Select(false, overallMap, g);
                            overallMap[player.posX, player.posY].PlayerOnGround(null, g);
                            ReworkMap(overallMap, g);
                            player.MoveToPosition(overallMap[x, y].posX, overallMap[x, y].posY, g);
                            player.gg.CentreRenderFill(g);
                            overallMap[x, y].PlayerOnGround(player, g);
                        }
                    }
                }
            }
        }
        public void ReworkMap(Ground[,] overallMap, Graphics g)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    overallMap[x, y].viewZone.CanView(g, false);
                    if (overallMap[x, y].isPlayerHere)
                    {
                        overallMap[x, y].PlayerOnGround(overallMap[x, y].player, g);
                    }
                    else if (overallMap[x, y].isObjectHere)
                    {
                        overallMap[x, y].GameObjectOnGround(true, g);
                    }
                }
            }
        }

        public void FindObject(MouseEventArgs control, Ground[,] overallMap, Graphics g) {
            if (control.Button == MouseButtons.Left)
            {
                for (int y = 0; y < GameVariables.mapSize; y++)
                {
                    for (int x = 0; x < GameVariables.mapSize; x++)
                    {
                        Ground ground = overallMap[x, y];

                        float posX = ground.gg.centrePositionF.X + ground.gg.centrePositionF.Width;
                        float posY = ground.gg.centrePositionF.Y + ground.gg.centrePositionF.Height;

                        if (control.Location.X > ground.gg.centrePositionF.X && control.Location.X < posX && control.Location.Y > ground.gg.centrePositionF.Y && control.Location.Y < posY)
                        {
                            if (ground.isPlayerHere)
                            {
                                if (overallMap[x, y].player.isSelected == false)
                                {
                                    overallMap[x, y].player.Select(true, overallMap, g);
                                }
                                else
                                {
                                    overallMap[x, y].player.Select(false, overallMap, g);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void newPlayerLocation(int posX, int posY)
        {
            player.posX = posX;
            player.posY = posY;
            playerLocation = new Point(posX, posY);
        }
    }
}
