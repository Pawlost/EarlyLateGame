using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarlyLateGame
{
    class Monster : Ground
    {
       
       // private bool visible;
       // private int width ;
       // private int height;
        private int xpReward = 50;
        private SolidBrush sbh = new SolidBrush(Color.Red);
        private bool alive = true;
        public Monster(int posX, int posY) : base(posX, posY,width:30,height:30, color: Color.Brown,visible:false)
        {
          //  this.visible = visible;
          
            //this.color = color;
            
        }
        
        public override void vykresleni(Graphics g)
        {

            if (base.getVisible())
            {
                g.FillRectangle(sbh, this.getPosX() * 60 + ((60 - 40) / 2), this.getPosY() * 60 + (60 - 40) / 2, 40, 40);
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.Gray), this.getPosX() * 60, this.getPosY() * 60, 60, 60);
                g.FillRectangle(sbh, this.getPosX() * 60 + 10, this.getPosY() * 60 + 10, 40, 40);

            }
        }
        public override void interact(Nepritel hrac)
        {

            if (alive)
            {
                hrac.prictiExpy(this.xpReward);
                this.alive = false;
            }
           // Form1.textOfbox;
            //Form1.debugText = "";
           
        }
     
    }
}
