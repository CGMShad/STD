using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF_Caisse
{
    class Client
    {
        const int COURSE = 0;
        const int ATTENTE = 1;
        const int EN_CAISSE = 2;
        const int FINI = 3;

        int Etat;
        Timer Course;
        Stopwatch sw;
        Caisse CaisseAttribue;
        PointF startLocation;
        PointF speed;
        Random rdm;
        public PointF Position
        {
            get
            {
                return new PointF(
                    (speed.X / 1000 * (float)sw.Elapsed.TotalMilliseconds) + startLocation.X,
                    (speed.Y / 1000 * (float)sw.Elapsed.TotalMilliseconds) + startLocation.Y
                );
            }
            private set { }
        }

        public Client(Random r)
        {
            //StopWatch
            sw = new Stopwatch();
            sw.Start();

            rdm = r;

            //Controle Client
            speed = new PointF(30, 30);
            startLocation = new PointF(700, 200);

            //Timer Course
            Course = new Timer();
            Course.Interval = rdm.Next(10,20) * 1000;
            Course.Enabled = true;
            Course.Tick += new EventHandler(Finish);
            Etat = COURSE;

            Aller(new PointF(0, 0));
        }

        public Client() : this( new Random()) { }

        private void Finish(object sender, EventArgs e)
        {
            Etat = ATTENTE;
            Course.Stop();
        }

        public void Aller(PointF objectif)
        {
            int facteurVitesse = 5;
            startLocation = Position;
            speed = new PointF(
                (objectif.X - startLocation.X)/facteurVitesse,
                (objectif.Y - startLocation.Y)/facteurVitesse);
            sw.Restart();
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.Black;
            switch (Etat)
            {
                case COURSE:
                    color = Color.Blue;
                    break;
                case ATTENTE:
                case EN_CAISSE:
                    color = Color.Red;
                    break;
                default:
                    break;
            }
            RectangleF ellipseBounds = new RectangleF(Position,new SizeF(20,20)); //like in your code sample
            
            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillEllipse(brush, ellipseBounds);
            }
        }

    }
}
