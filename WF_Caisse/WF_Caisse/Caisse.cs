using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Caisse
{
    class Caisse : Control
    {
        const int FERMEE = 0;
        const int OUVERT = 1;
        
        int Etat;
        int Number;
        int Size;

        List<Client> AttenteClient;
        Point Position
        {
            get
            {
                return new Point((Number * Size * 2), Properties.Settings.Default.Heigth-Size);
            }
        }
        Stopwatch TempsTraitement;

        public Caisse(int number)
        {
            Number = number;
            Etat = FERMEE;
            Size = 20;
        }

        public void TraiterClient()
        {

        }

        public void Ouvrir()
        {
            Etat = OUVERT;
        }
        public void Fermer()
        {
            Etat = FERMEE;
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.Black;
            switch (Etat)
            {
                case FERMEE:
                    color = Color.Red;
                    break;
                case OUVERT:
                    color = Color.Green;
                    break;
                default:
                    break;
            }
            Rectangle rectangle = new Rectangle(Position, new Size(Size, Size)); //like in your code sample

            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(brush, rectangle);
            }
        }


    }
}
