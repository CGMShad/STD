using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Caisse
{
    class Caisse
    {
        //Constantes
        const int DEFAULT_SIZE = 20;
        const int DEFAULT_TIME_TREATMENT = 3;
        public const int CLOSED = 0;
        public const int OPENED = 1;


        //Variables
        public int State;
        int Number;
        int Size;
        Client actualClient;
        Stopwatch TempsTraitement;
        Timer CheckTimer;
        
        public List<Client> AttenteClient;
        public PointF Position
        {
            get
            {
                return new PointF((Number * Size * 2), Properties.Settings.Default.SizeMagasin.Height - Size);
            }
        }

        /// <summary>
        /// Ctor of Caisse 
        /// </summary>
        /// <param name="number"></param> The number of the caisse
        public Caisse(int number)
        {
            Number = number;
            State = CLOSED;
            Size = DEFAULT_SIZE;
            AttenteClient = new List<Client>();
            actualClient = null;
            TempsTraitement = new Stopwatch();

            //Timer Check
            CheckTimer = new Timer();
            CheckTimer.Interval = 100;
            CheckTimer.Enabled = true;
            CheckTimer.Tick += new EventHandler(Check);
        }

        /// <summary>
        /// Check the time of the actual process or process a new client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check(object sender, EventArgs e)
        {
            if (TempsTraitement.IsRunning)
            {
                if(TempsTraitement.Elapsed.TotalSeconds >= DEFAULT_TIME_TREATMENT)
                {
                    TempsTraitement.Reset();
                    //TODO
                    //Détruit de client
                }
            }
            else
            {
                ProcessClient();
            }
        }

        /// <summary>
        /// Process a new Client if he's waiting
        /// </summary>
        public void ProcessClient()
        { 
            if(AttenteClient.Count != 0)
            {
                actualClient = AttenteClient[0];
                AttenteClient.RemoveAt(0);
                TempsTraitement.Start();
            } 
        }

        /// <summary>
        /// Change the state to Open
        /// </summary>
        public void Open()
        {
            State = OPENED;
        }

        /// <summary>
        /// Change the state to Close
        /// </summary>
        public void Close()
        {
            State = CLOSED;
        }

        /// <summary>
        /// Display the Caisse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Paint(object sender, PaintEventArgs e)
        {
            //Set the color in fonction of his state
            Color color = Color.Black;
            switch (State)
            {
                case CLOSED:
                    color = Color.Red;
                    break;
                case OPENED:
                    color = Color.Green;
                    break;
                default:
                    break;
            }
            RectangleF rectangle = new RectangleF(Position, new Size(Size, Size)); //like in your code sample

            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }
        }
    }
}