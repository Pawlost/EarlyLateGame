using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace EarlyLateGame
{
    class Strom : Ctverecek
    {
        
        private int zivoty = 4;
        private bool alive = true;
        private bool visible;
        private int thatDay;
        private int xpReward = 10;
        //private int velikosXY = 20;

        public Strom(int posX, int posY) : base(posX, posY, height: 30, width: 30, color: Color.Green,visible:false)
        {
           
            this.visible = visible;
        }
        private void stillExist()
        {

        }
        public override void vykresleni(Graphics g)
        {
            if (base.getVisible())
            {
                if (alive)
                {
                    g.FillRectangle(new SolidBrush(base.getColor()), this.getPosX() * 60 + ((60 - 40) / 2), this.getPosY() * 60 + (60 - 40) / 2, 40, 40);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.Bisque), this.getPosX() * 60 + ((60 - 40) / 2), this.getPosY() * 60 + (60 - 40) / 2, 40, 40);
                }
           }
            else
            {
                if (alive)
                {
                    g.FillRectangle(new SolidBrush(Color.Gray), this.getPosX() * 60, this.getPosY() * 60, 60, 60);
                    g.FillRectangle(new SolidBrush(base.getColor()), this.getPosX() * 60 + 10, this.getPosY() * 60 + 10, 40, 40);
                }
                else
                {

                    g.FillRectangle(new SolidBrush(Color.Gray), this.getPosX() * 60, this.getPosY() * 60, 60, 60);
                    g.FillRectangle(new SolidBrush(Color.Bisque), this.getPosX() * 60 + 10, this.getPosY() * 60 + 10, 40, 40);
                }
            }
        }
        public void setHelthOfTree()
        {
            
            
        }
        public override void interact(Hrac hrac)
        {
            Form1.setText("sek! ");
            this.zivoty -= 1;
            if (this.zivoty == 1)
            {

                hrac.prictiExpy(hrac.getPocetPokacenychStromu() + this.xpReward);
                alive = false;
              
            }
            
        }


    }
}
