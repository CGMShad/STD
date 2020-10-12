namespace WF_Caisse
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
            this.magasin1 = new WF_Caisse.Magasin();
            this.SuspendLayout();
            // 
            // magasin1
            // 
            this.magasin1.Location = new System.Drawing.Point(2, 3);
            this.magasin1.Name = "magasin1";
            this.magasin1.Size = new System.Drawing.Size(800, 450);
            this.magasin1.TabIndex = 0;
            this.magasin1.Text = "magasin1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.magasin1);
            this.Name = "frmMain";
            this.Text = "Magasin";
            this.ResumeLayout(false);

        }

        #endregion

        private Magasin magasin1;
    }
}

