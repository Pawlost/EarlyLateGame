using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EarlyLateGame
{
    class Late : Ground
    {
        private int health = 1;
       // private bool visible;
       // private int width ;
       // private int height;
        private int xp = 50;
        private SolidBrush sbh = new SolidBrush(Color.Red);
        private bool alive = true;
        SolidBrush mrtvy = new SolidBrush(Color.Gray);//Color.FromArgb(125,0,0,0)); soo cool

        public Late(int posX, int posY) : base(posX, posY,width:30,height:30, color: Color.Brown,visible:false)
        {
          //  this.visible = visible;
          
            //this.color = color;
            
        }
        public int getHelth()
        {
            return health;
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
        public override void interact()
        {
            MessageBox.Show("interagujes se nepritelem", null, MessageBoxButtons.YesNo);
        }
        public void setHealth()
        {
            this.health -= 1;
            this.setBrush(Color.FromArgb(this.health * 51, 255, 0, 0));
            if (this.health == 0)
            {
                this.alive = false;
            }
            
        }
    }
}
