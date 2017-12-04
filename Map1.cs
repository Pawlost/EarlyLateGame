using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using EarlyLateGame.Etities;
using EarlyLateGame.Game;

namespace EarlyLateGame
{
    public partial class Map1 : Form
    {
        BufferedGraphics buffer;
        Early EarlyPlayer;
        Late LatePlayer;

        GameGraphics OverallGraphics;
        Ground[,] OverallMap;
        //Ctverecek[,] vrstva2 = new Ctverecek[10, 10];  
        Graphics l;

        Pen p = new Pen(Color.Black, 3);
        
        

        public Map1()
        {
            InitializeComponent();

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {

                    mapa[y, x] = new Ground(x, y, 60, 60, Color.White, false);
                }
            }
            mapa[1, 1] = new Prisera(1, 1);
            //vrstva2[0, 1] =  new Prisera(2, 1);
            //vrstva2[2, 0] =  new Prisera(2, 2);
            mapa[5, 5] = new Strom(5, 5);

            //  hrac1 = new Hrac(60, 60);
            /*
             th = new Thread(new ThreadStart( vykresleniMapyATD));
            th.Name = "grafika";
            th.Start();*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = this.CreateGraphics();
            l = this.CreateGraphics();
            hrac1.zornePole(mapa);
            vykresleniMapyATD();




        }
        ////////////////////////////////////
        public static void setText(string text)
        {
            textOfbox += " \n " + text + " ";
        }
        public  int zaokrouhleni(int pos)
        {
            textBox1.Text = ((int)(pos / 60)).ToString();
            return ((int)(pos / 60));
        }
        ///////////////////////////////////////
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            movingByMose(e);
            /*
              
               for (int x = 0; x < 10; x++)
               {
                   hrac1.setToChangeValuPosY(x);
                   for (int y = 0; y < 10; y++)
                   {
                       hrac1.setToChangeValuPosX(y);
                       hrac1.zornePole(mapa);
                       vykresleniMapyATD();
                       Thread.Sleep(200);
                   }

               }
             */ 
        }
        public void movingByMose(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (hrac1.getSelected())
                {
                    if (e.X > 0 && e.X < 600 && e.Y > 0 && e.Y < 600)
                    {
                        if (zaokrouhleni(e.X) == hrac1.getPosX() + 1 && zaokrouhleni(e.Y) == hrac1.getPosY())
                        {
                            hrac1.setPosX(1);
                            hrac1.setSelected(false);
                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() - 1 && zaokrouhleni(e.Y) == hrac1.getPosY())
                        {
                            hrac1.setPosX(-1);
                            hrac1.setSelected(false);
                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() && zaokrouhleni(e.Y) == hrac1.getPosY() + 1)
                        {
                            hrac1.setPosY(1);
                            hrac1.setSelected(false);
                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() && zaokrouhleni(e.Y) == hrac1.getPosY() - 1)
                        {
                            hrac1.setPosY(-1);
                            hrac1.setSelected(false);
                        }
                        else
                        {
                            //break
                            hrac1.setSelected(false);
                        }
                        //g.Clear(Color.White);
                        hrac1.zornePole(mapa);
                        vykresleniMapyATD();

                    }

                }
                else if (hrac1.getPosX() == zaokrouhleni(e.X) && hrac1.getPosY() == zaokrouhleni(e.Y))
                {
                    hrac1.setSelected(true);

                }
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (hrac1.getSelected())
                { 
                    debugText.Text += "\n prave tlacitko";
                    if (e.X > 0 && e.X < 600 && e.Y > 0 && e.Y < 600)
                    {

                        if (zaokrouhleni(e.X) == hrac1.getPosX() + 1 && zaokrouhleni(e.Y) == hrac1.getPosY())
                        {
                           /// nepHrac.interact();
                            mapa[zaokrouhleni(e.Y), zaokrouhleni(e.X)].interact(hrac1);
                            hrac1.setSelected(false);

                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() - 1 && zaokrouhleni(e.Y) == hrac1.getPosY())
                        {
                            mapa[zaokrouhleni(e.Y), zaokrouhleni(e.X)].interact(hrac1);
                            hrac1.setSelected(false);
                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() && zaokrouhleni(e.Y) == hrac1.getPosY() + 1)
                        {
                            mapa[zaokrouhleni(e.Y), zaokrouhleni(e.X)].interact(hrac1);
                            hrac1.setSelected(false);
                        }
                        else if (zaokrouhleni(e.X) == hrac1.getPosX() && zaokrouhleni(e.Y) == hrac1.getPosY() - 1)
                        {
                            mapa[zaokrouhleni(e.Y), zaokrouhleni(e.X)].interact(hrac1);
                            hrac1.setSelected(false);

                        }else
                        {
                            hrac1.setSelected(false);
                        }
                    }

                }

                
            }
        }
        public void vykresleniMapyATD()
        {
            //textBox1.Text = Thread.CurrentThread.Name;


            debugText.Text = textOfbox;
            g.Clear(Color.White);
            //  Invalidate(new Rectangle(1,0,10,10) );
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    mapa[y, x].vykresleni(g);
                    mapa[y, x].setVisible(false);
                }
            }
            nepHrac.vykresleni(g);


            for (int i = 0; i < 602; i = i + 60)
            {
                l.DrawLine(p, i, 0, i, 601);
            }
            for (int i = 0; i < 602; i = i + 60)
            {
                l.DrawLine(p, 0, i, 601, i);
            }

            hrac1.vykresleni(g);
            //Thread.Sleep(1000);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_CursorChanged(object sender, EventArgs e)
        {
            

        }
        public   void  setDebug()
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "7012")
            {
                debugText.Enabled = true;
                debugText.Visible = true;
            }
        }
       /* public partial void  dalsidebugTextset(string text)
        {
            debugText.Text += "\n " + text;
        }
*/        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        public void debugText_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

