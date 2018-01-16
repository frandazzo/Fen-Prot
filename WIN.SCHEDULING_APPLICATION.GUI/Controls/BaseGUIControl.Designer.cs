namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class BaseGUIControl
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.commandBar1 = new WIN.SCHEDULING_APP.GUI.Utility.CommandBar();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.commandBar1.Location = new System.Drawing.Point(0, 0);
            this.commandBar1.Name = "commandBar1";
            this.commandBar1.Size = new System.Drawing.Size(697, 109);
            this.commandBar1.TabIndex = 0;
            // 
            // BaseGUIControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.commandBar1);
            this.Name = "BaseGUIControl";
            this.Size = new System.Drawing.Size(697, 351);
            this.ResumeLayout(false);

        }

        #endregion

        protected WIN.SCHEDULING_APP.GUI.Utility.CommandBar commandBar1;

    }
}
