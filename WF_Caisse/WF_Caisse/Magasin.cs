using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Caisse
{
    class Magasin : Control
    {
        //Constantes
        const int MAX_CLIENTS_PER_CAISSE = 3;
        const int NUMBER_OF_CAISSES = 8;

        //Variables
        Bitmap bmp = null;
        Graphics g = null;
        Timer timerSpawnClient;
        Timer timerRefresh;
        Timer timerControl;

        List<Caisse> ClosedCaisses;
        List<Caisse> OpenedCaisses;
        List<Client> Clients;
        Random rdm;

        /// <summary>
        /// Ctor of magasin
        /// </summary>
        public Magasin()
        {
            rdm = new Random();
            ClosedCaisses = new List<Caisse>();
            OpenedCaisses = new List<Caisse>();
            Clients = new List<Client> { new Client(rdm) };

            //Timer Refresh
            timerRefresh = new Timer();
            timerRefresh.Interval = 1000 / 60;
            timerRefresh.Enabled = true;
            timerRefresh.Tick += new EventHandler(OnTick);

            //Timer Spawn Client
            timerSpawnClient = new Timer();
            timerSpawnClient.Interval = 1000;
            timerSpawnClient.Enabled = true;
            timerSpawnClient.Tick += new EventHandler(CreateClient);

            //Timer Controle Caisse
            timerControl = new Timer();
            timerControl.Interval = 1000 / 2;
            timerControl.Enabled = true;
            timerControl.Tick += new EventHandler(Controle);

            DoubleBuffered = true;

            //Display all clients
            foreach (Client client in Clients)
            {
                Paint += client.Paint;
            }
            //Create and display the Caisses
            for (int i = 0; i < NUMBER_OF_CAISSES; i++)
            {
                Caisse c = new Caisse(i);
                ClosedCaisses.Add(c);
                Paint += c.Paint;
            }

            //Open the first caisse
            OpenCaisse();

        }

        /// <summary>
        /// Manage the state of each Caisse in fonction of the number of clients waiting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Controle(object sender, EventArgs e)
        {
            //Close the last caisse if it don't have clients
            if(OpenedCaisses[OpenedCaisses.Count-1].AttenteClient.Count == 0 && OpenedCaisses.Count > 1)
            {
                CloseCaisse();
            }
            // Open the next caisse if all opened caisses had too much Clients
            else if (OpenedCaisses[OpenedCaisses.Count-1].AttenteClient.Count >= MAX_CLIENTS_PER_CAISSE)
            {
                OpenCaisse();
            }
        }

        /// <summary>
        /// Create a new Client and display it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateClient(object sender, EventArgs e)
        {
            Client c = new Client(rdm);
            Paint += c.Paint;
            Clients.Add(c);
        }

        private void OnTick(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        /// <summary>
        /// Open the next Caisse
        /// </summary>
        public void OpenCaisse()
        {
            ClosedCaisses[0].State = Caisse.OPENED;
            OpenedCaisses.Add(ClosedCaisses[0]);
            ClosedCaisses.RemoveAt(0);
        }

        /// <summary>
        /// Close the last Caisse
        /// </summary>
        public void CloseCaisse()
        {
            OpenedCaisses[OpenedCaisses.Count - 1].State = Caisse.CLOSED;
            ClosedCaisses.Insert(0, OpenedCaisses[OpenedCaisses.Count - 1]);
            OpenedCaisses.RemoveAt(OpenedCaisses.Count - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AssignCaisseToCustomer()
        {
            // TO DO with Event
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            bmp ??= new Bitmap(Size.Width, Size.Height);
            g ??= Graphics.FromImage(bmp);

            PaintEventArgs p = new PaintEventArgs(g, e.ClipRectangle);

            g.Clear(BackColor);

            base.OnPaint(p);
            
            e.Graphics.DrawImage(bmp, new Point(0, 0));
        }

    }
}
