using EarlyLateGame.Entities;
using EarlyLateGame.GameObjects;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame.Game
{
    class PlayerControl
    {
        public Player player;

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
        public virtual void selectPlayer(Ground[,] overallMap, Graphics g, Point mouseLocation)
        {
            if (PlayerLocation(mouseLocation))
            {
                if (!overallMap[player.posX, player.posY].player.isSelected)
                {
                    reworkMap(overallMap, g);
                    overallMap[player.posX, player.posY].player.Select(true, overallMap, g);
                }
                else
                {
                    reworkMap(overallMap, g);
                    overallMap[player.posX, player.posY].player.Select(false, overallMap, g);    
                }
            }
        }
        public bool PlayerLocation(Point mouseLocation)
        {
            float changedPosX = player.gg.centrePosX + player.gg.image.Width;
            float changedPosY = player.gg.centrePosY + player.gg.image.Height;
            return mouseLocation.X > player.gg.centrePosX && mouseLocation.X < changedPosX && mouseLocation.Y > player.gg.centrePosY && mouseLocation.Y < changedPosY;
        }

        public bool CanMove(Ground[,] overallMap, Point mouseLocation)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    ControlZone view = overallMap[x, y].viewZone;

                    float changedPosX = view.gg.posX + view.gg.image.Width;
                    float changedPosY = view.gg.posY + view.gg.image.Height;

                    if (mouseLocation.X > view.gg.posX && mouseLocation.X < changedPosX && mouseLocation.Y > view.gg.posY && mouseLocation.Y < changedPosY)
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
            reworkMap(overallMap, g);
            player.MoveToPosition(overallMap[helpPosX, helpPosY].posX, overallMap[helpPosX, helpPosY].posY, g);
            overallMap[helpPosX, helpPosY].PlayerOnGround(player, g);
        }

        public void reworkMap(Ground[,] overallMap, Graphics g)
        {
            for (int y = 0; y < GameVariables.mapSize; y++)
            {
                for (int x = 0; x < GameVariables.mapSize; x++)
                {
                    overallMap[x, y].viewZone.canView(g, false);
                  
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
