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
        Bitmap bmp = null;
        Graphics g = null;
        Timer t;

        List<Caisse> Caisses;
        List<Client> Clients;
        Timer Heure;
        Random rdm;

        public Magasin()
        {
            rdm = new Random();
            Caisses = new List<Caisse>();
            Clients = new List<Client> { new Client(rdm) };

            //Timer
            t = new Timer();
            t.Interval = 1000 / 60;
            t.Enabled = true;
            t.Tick += new EventHandler(OnTick);
            DoubleBuffered = true;

            foreach (Client client in Clients)
            {
                Paint += client.Paint;
            }
            for (int i = 0; i < 8; i++)
            {
                Caisses.Add(new Caisse(i));
            }
            foreach (Caisse caisse in Caisses)
            {
                Paint += caisse.Paint;
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            Invalidate(true);
        }

        public void OuvrirCaisse()
        {

        }

        public void FermerCaisse()
        {

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
