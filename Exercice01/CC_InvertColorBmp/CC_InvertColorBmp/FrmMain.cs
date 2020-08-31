using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC_InvertColorBmp
{
    public partial class FrmMain : Form
    {
        Bitmap logo, invertLogo;
        public FrmMain()
        {
            InitializeComponent();

            opfImage.Title = "Open Bitmap";
            opfImage.Filter = "bmp files (*.bmp)|*.bmp";
            sfdNewImage.Filter = "bmp files (*.bmp)|*.bmp";
            sfdNewImage.FileName = "resultImage";
            btnInvert.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(sfdNewImage.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image.Save(sfdNewImage.FileName, ImageFormat.Bmp);
                logo = null;
                btnInvert.Enabled = false;
                pbImage.Image = null;
            }
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            pbImage.Image = null;
            invertLogo = logo;
            for (int x = 0; x < 1024; x++)
            {
                for (int y = 0; y < 1024; y++)
                {
                    invertLogo.SetPixel(x, y, Color.FromArgb(255 - invertLogo.GetPixel(x, y).ToArgb()));
                }
            }
            pbImage.Image = invertLogo;
        }

        private void btnPickImage_Click(object sender, EventArgs e)
        {
            if(opfImage.ShowDialog() == DialogResult.OK)
            {
                logo = new Bitmap(opfImage.FileName);
                if(logo != null)
                {
                    btnInvert.Enabled = true;
                    pbImage.Image = logo;
                }
            }
            
        }
    }
}
