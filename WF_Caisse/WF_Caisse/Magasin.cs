/* 
 * File : Magasin
 * Author : Clément Christensen
 * Date : 26.10.2020
 * Version : 1.0
 * Description : the Class Magasin control the functionning of a magasin with customers (clients) and checkouts (caisse)
 */
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

        int counterControle;

        /// <summary>
        /// Ctor of magasin
        /// </summary>
        public Magasin()
        {
            rdm = new Random();
            ClosedCaisses = new List<Caisse>();
            OpenedCaisses = new List<Caisse>();
            Clients = new List<Client> { new Client(rdm) };
            counterControle = 0;

            //Timer Refresh
            timerRefresh = new Timer();
            timerRefresh.Interval = 1000 / 60; //60 fps
            timerRefresh.Enabled = true;
            timerRefresh.Tick += new EventHandler(OnTick);

            //Timer Spawn Client
            timerSpawnClient = new Timer();
            timerSpawnClient.Interval = 1000; // each second
            timerSpawnClient.Enabled = true;
            timerSpawnClient.Tick += new EventHandler(CreateClient);

            //Timer Controle Caisse
            timerControl = new Timer();
            timerControl.Interval = 100; // 10 times per second
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
                //If the caisse is empty 10 times, close it.
                counterControle++;
                if(counterControle == 10)
                {
                    CloseCaisse();
                    counterControle = 0;
                }
            }
            // Open the next caisse if all opened caisses had too much Clients
            else if (OpenedCaisses[OpenedCaisses.Count-1].AttenteClient.Count >= MAX_CLIENTS_PER_CAISSE)
            {
                OpenCaisse();
                counterControle = 0;
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
            c.CaisseAttribution += AttributionCaisse;
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

        /// <summary>
        /// Give a Caisse to a Client
        /// </summary>
        /// <param name="client"></param>
        /// <param name="e"></param>
        protected void AttributionCaisse(object client, EventArgs e)
        {
            Client cli = client as Client;
            foreach (Caisse c in OpenedCaisses)
            {
                if(c.AttenteClient.Count < MAX_CLIENTS_PER_CAISSE)
                {
                    Console.WriteLine(c.AttenteClient.Count);
                    cli.CaisseAttributed = c;
                    c.AttenteClient.Add(cli);
                    break;
                }
            }

        }

    }
}
