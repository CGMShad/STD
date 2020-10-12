using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecodageMP3
{
    public partial class frmMain : Form
    {
        FileStream fs;
        string header,text;
        const int TAILLE_HEADER = 10;

        public frmMain()
        {
            InitializeComponent();
            opfAudio.Title = "Open MP3 file";
            opfAudio.Filter = "mp3 files (*.mp3)|*.mp3";
            tbxDetailsAudio.ReadOnly = true;
            
        }

        private void btnLoadAudio_Click(object sender, EventArgs e)
        {
            if(opfAudio.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(opfAudio.FileName, FileMode.Open);
            }
            if(fs != null)
            {
                for (byte i = 0; i < TAILLE_HEADER; i++)
                {
                    header += fs.ReadByte();
                }
                text += $"Header : {header}{Environment.NewLine}";

                tbxDetailsAudio.Text = text;
            }
        }
    }
}
