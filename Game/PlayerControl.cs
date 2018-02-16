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

        private int helpPosX;
        private int helpPosY;

        public PlayerControl(Player player)
        {
            this.player = player;    
        }
        public virtual void Attack(Ground[,] overallMap,Graphics g)
        {
            if (overallMap[helpPosX, helpPosY].tree.dead == false && overallMap[helpPosX, helpPosY].tree != null)
            {
                overallMap[helpPosX, helpPosY].tree.Cut(player, g);
            }
            else if (overallMap[helpPosX, helpPosY].tree != null)
            {
                overallMap[helpPosX, helpPosY].isObjectHere = false;
                overallMap[helpPosX, helpPosY].tree = null;
            }
        }
        public virtual void SelectPlayer(Ground[,] overallMap, Graphics g, Point mouseLocation)
        {
            if (PlayerLocation(mouseLocation))
            {
                if (!overallMap[player.posX, player.posY].player.isSelected)
                {
                    ReworkMap(overallMap, g);
                    overallMap[player.posX, player.posY].player.Select(true, overallMap, g);
                }
                else
                {
                    ReworkMap(overallMap, g);
                    overallMap[player.posX, player.posY].player.Select(false, overallMap, g);    
                }
            }
        }
        public bool PlayerLocation(Point mouseLocation)
        {
            float posX = player.gg.centrePositionF.X + player.gg.centrePositionF.Width;
            float posY = player.gg.centrePositionF.Y + player.gg.centrePositionF.Height;
            return mouseLocation.X > player.gg.centrePositionF.X && mouseLocation.X < posX && mouseLocation.Y > player.gg.centrePositionF.Y && mouseLocation.Y < posY;
        }

        public bool CanMove(Ground[,] overallMap, Point mouseLocation)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    ControlZone view = overallMap[x, y].viewZone;

                    float posX = view.gg.centrePositionF.X + view.gg.centrePositionF.Width;
                    float posY = view.gg.centrePositionF.Y + view.gg.centrePositionF.Height;

                    if (mouseLocation.X > view.gg.centrePositionF.X && mouseLocation.X < posX && mouseLocation.Y > view.gg.centrePositionF.Y && mouseLocation.Y < posY)
                    {
                        if (view.visible && overallMap[x, y].isPlayerHere == false && overallMap[x, y].isObjectHere == false)
                        {
                            helpPosX = x;
                            helpPosY = y;
                            return true;
                        }
                        else                
                        {
                            helpPosX = x;
                            helpPosY = y;
                        }
                    }
                }
            }
            return false;
        }
        public virtual void MovePlayer(Ground[,] overallMap, Graphics g)
        {
            player.Select(false, overallMap, g);
            overallMap[player.posX, player.posY].PlayerOnGround(null, g);
            ReworkMap(overallMap, g);
            player.MoveToPosition(overallMap[helpPosX, helpPosY].posX, overallMap[helpPosX, helpPosY].posY, g);
            player.gg.CentreRenderFill(g);
            overallMap[helpPosX, helpPosY].PlayerOnGround(player, g);
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
            player.isSelected = false;
        }
    }
}
