using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace EarlyLateGame
{
    class EnemyMob : Ground
    {
       // private int posX;
       // private int posY;
        private bool selected = false;
        private int expy = 0;
        private int pocetPokacenychStromu = 0;
        // private Graphics g;
        private SolidBrush bh = new SolidBrush(Color.Blue);

        SolidBrush mrtvy = new SolidBrush(Color.Gray);//Color.FromArgb(125,0,0,0)); soo cool

        public EnemyMob(int posX, int posY) :base(posX, posY, width:30, height:30, color: Color.Blue,visible:true)
        {
          
        }
        public void atttackPlayer(Nepritel nepratelskyHrac)
        {
            nepratelskyHrac.setVisible(false);
        }
      
        
        public void zornePole(Ctverecek[,] mapa)
        {
            
            mapa[this.getPosY(), this.getPosX()].setVisible(true);

            if (this.getPosY() - 1 >= 0)
            {
                mapa[this.getPosY() - 1, this.getPosX()].setVisible(true);
            }
           
            if (this.getPosY() + 1 <= mapa.GetLength(0)-1)
            {
                mapa[this.getPosY() + 1, this.getPosX()].setVisible(true);
            }
           
            if (this.getPosX()-1 >= 0)
            {
                mapa[this.getPosY(), this.getPosX() - 1].setVisible(true);
            }
           
            if(mapa.GetLength(1)-1 >= this.getPosX() + 1)
            {
                mapa[this.getPosY(), this.getPosX() + 1].setVisible(true);
            }
          
            
        }
          
       

        public void setSelected(bool selected)
        {
            this.selected = selected;
        }
        public bool getSelected()
        {
            return (this.selected);
        }

        public void prictiExpy(int xpReward)
        {
            this.expy += xpReward;
            Map1.setText(this.expy.ToString());
        }

        public int getPocetPokacenychStromu()
        {
            return (this.pocetPokacenychStromu);
        }

    }
}
