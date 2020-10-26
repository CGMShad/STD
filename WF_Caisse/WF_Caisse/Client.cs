/* 
 * File : Client
 * Author : Clément Christensen
 * Date : 26.10.2020
 * Version : 1.0
 * Description : the Class Client control de movement of the client
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WF_Caisse
{
    class Client
    {
        //Constantes
        const int MARGIN = 20;
        const int SIZE = 20;
        const int SHOPPING = 0;
        const int SPEED_FACTOR = 5;
        const int WAITING = 1;
        const int CHECKOUT = 2;
        const int OUT = 3;

        int State;
        Timer Shopping;
        Timer Check;
        Stopwatch sw;
        //Caisse CaisseAttribue;
        PointF startLocation;
        PointF speed;
        Random rdm;
        PointF TargetPosition;
        public Caisse CaisseAttributed;
        public event EventHandler CaisseAttribution;
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

        /// <summary>
        /// Ctor of Client
        /// </summary>
        /// <param name="r"></param>
        public Client(Random r)
        {
            //StopWatch
            sw = new Stopwatch();
            sw.Start();

            //Unique random given by the magasin
            rdm = r;

            //Controle Client
            startLocation = new PointF(700, 200);

            //Timer Shopping
            Shopping = new Timer();
            Shopping.Interval = rdm.Next(10, 20) * 1000;
            Shopping.Enabled = true;
            Shopping.Tick += new EventHandler(CourseFinished);
            State = SHOPPING;

            //Timer Check
            Check = new Timer();
            Check.Interval = 100;
            Check.Enabled = true;
            Check.Tick += new EventHandler(CheckPath);

            GoTo(new PointF(rdm.Next(Properties.Settings.Default.SizeMagasin.Width), rdm.Next(Properties.Settings.Default.SizeMagasin.Height)));
        }
        public Client() : this(new Random()) { }

        /// <summary>
        /// Check if the Client has reach the objectiv give him a new one in fonction of his state 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPath(object sender, EventArgs e)
        {
            //If the client has reach the objectiv
            if ((Position.X < TargetPosition.X + MARGIN && Position.X > TargetPosition.X - MARGIN) && (Position.Y < TargetPosition.Y + MARGIN && Position.Y > TargetPosition.Y - MARGIN))
            {
                // Go to a new point in the magasin
                if (State == SHOPPING)
                {
                    GoTo(new PointF(rdm.Next(Properties.Settings.Default.SizeMagasin.Width), rdm.Next(Properties.Settings.Default.SizeMagasin.Height)));
                }
                // Go to the Caisse attibuted 
                else if (State == WAITING)
                {
                    State = CHECKOUT;
                    GoTo(new PointF(0, Properties.Settings.Default.SizeMagasin.Height));
                }
            }
        }

        /// <summary>
        /// When the Client finished his shopping
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CourseFinished(object sender, EventArgs e)
        {
            CaisseAttributed = null;
            State = WAITING;
            Shopping.Stop();
            //Call the event
            OnCaisseAttribution(EventArgs.Empty);
            //If the event goes wrong, then don't die
            if(CaisseAttributed == null)
            {
                Console.WriteLine("Pas de caisse");
                GoTo(new PointF(100, 100));
            }
            else
            {
                 GoTo(CaisseAttributed.Position);
            }
           
        }

        /// <summary>
        /// Manage the client's move 
        /// </summary>
        /// <param name="objectif"></param>
        public void GoTo(PointF objectif)
        {
            startLocation = Position;
            TargetPosition = objectif;
            //Change the speed to in direction of the objectiv 
            speed = new PointF(
                (TargetPosition.X - startLocation.X) / SPEED_FACTOR,
                (TargetPosition.Y - startLocation.Y) / SPEED_FACTOR);
            sw.Restart();
        }

        /// <summary>
        /// Display the Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e)
        {
            //Set the color in fonction of his state
            Color color;
            switch (State)
            {
                case SHOPPING:
                    color = Color.Blue;
                    break;
                case WAITING:
                case CHECKOUT:
                    color = Color.Red;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            RectangleF ellipseBounds = new RectangleF(Position, new SizeF(SIZE, SIZE)); 

            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillEllipse(brush, ellipseBounds);
            }
        }

        /// <summary>
        /// Invoke the event to got a caisse
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCaisseAttribution(EventArgs e)
        {
            CaisseAttribution?.Invoke(this, e);
        }

    }
}
