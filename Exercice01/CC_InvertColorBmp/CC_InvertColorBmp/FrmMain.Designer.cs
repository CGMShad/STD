namespace CC_InvertColorBmp
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.opfImage = new System.Windows.Forms.OpenFileDialog();
            this.btnPickImage = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfdNewImage = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // opfImage
            // 
            this.opfImage.FileName = "openFileDialog1";
            // 
            // btnPickImage
            // 
            this.btnPickImage.Location = new System.Drawing.Point(354, 12);
            this.btnPickImage.Name = "btnPickImage";
            this.btnPickImage.Size = new System.Drawing.Size(167, 44);
            this.btnPickImage.TabIndex = 0;
            this.btnPickImage.Text = "Pick image";
            this.btnPickImage.UseVisualStyleBackColor = true;
            this.btnPickImage.Click += new System.EventHandler(this.btnPickImage_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(354, 74);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(167, 44);
            this.btnInvert.TabIndex = 1;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(284, 270);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(354, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(165, 44);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 301);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnPickImage);
            this.Name = "FrmMain";
            this.Text = "Invert Color bmp";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opfImage;
        private System.Windows.Forms.Button btnPickImage;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfdNewImage;
    }
}

