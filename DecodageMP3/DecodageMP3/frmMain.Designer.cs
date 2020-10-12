namespace DecodageMP3
{
    partial class frmMain
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
            this.opfAudio = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadAudio = new System.Windows.Forms.Button();
            this.tbxDetailsAudio = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // opfAudio
            // 
            this.opfAudio.FileName = "openFileDialog1";
            // 
            // btnLoadAudio
            // 
            this.btnLoadAudio.Location = new System.Drawing.Point(12, 12);
            this.btnLoadAudio.Name = "btnLoadAudio";
            this.btnLoadAudio.Size = new System.Drawing.Size(331, 54);
            this.btnLoadAudio.TabIndex = 0;
            this.btnLoadAudio.Text = "Charger fichier";
            this.btnLoadAudio.UseVisualStyleBackColor = true;
            this.btnLoadAudio.Click += new System.EventHandler(this.btnLoadAudio_Click);
            // 
            // tbxDetailsAudio
            // 
            this.tbxDetailsAudio.Location = new System.Drawing.Point(12, 72);
            this.tbxDetailsAudio.Multiline = true;
            this.tbxDetailsAudio.Name = "tbxDetailsAudio";
            this.tbxDetailsAudio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDetailsAudio.Size = new System.Drawing.Size(331, 366);
            this.tbxDetailsAudio.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 450);
            this.Controls.Add(this.tbxDetailsAudio);
            this.Controls.Add(this.btnLoadAudio);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog opfAudio;
        private System.Windows.Forms.Button btnLoadAudio;
        private System.Windows.Forms.TextBox tbxDetailsAudio;
    }
}

