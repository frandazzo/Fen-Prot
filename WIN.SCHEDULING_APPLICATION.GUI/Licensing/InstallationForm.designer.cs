namespace WIN.SCHEDULING_APP.GUI.Licensing
{
    partial class InstallationForm
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
            this.cmdInstall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRagSoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHardwareId = new System.Windows.Forms.TextBox();
            this.lblScadenza = new System.Windows.Forms.Label();
            this.txtLicenceType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTrial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdTrial = new System.Windows.Forms.Button();
            this.cmdAll = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdInstall
            // 
            this.cmdInstall.Location = new System.Drawing.Point(538, 260);
            this.cmdInstall.Name = "cmdInstall";
            this.cmdInstall.Size = new System.Drawing.Size(94, 26);
            this.cmdInstall.TabIndex = 0;
            this.cmdInstall.TabStop = false;
            this.cmdInstall.Text = "Salva";
            this.cmdInstall.UseVisualStyleBackColor = true;
            this.cmdInstall.Click += new System.EventHandler(this.cmdInstall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome azienda:";
            // 
            // txtRagSoc
            // 
            this.txtRagSoc.Location = new System.Drawing.Point(115, 14);
            this.txtRagSoc.Name = "txtRagSoc";
            this.txtRagSoc.Size = new System.Drawing.Size(362, 21);
            this.txtRagSoc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codice attivazione:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(115, 144);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(362, 21);
            this.txtCode.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtHardwareId);
            this.groupBox2.Controls.Add(this.lblScadenza);
            this.groupBox2.Controls.Add(this.txtLicenceType);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtTrial);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRagSoc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(498, 242);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati licenza";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Codice computer";
            // 
            // txtHardwareId
            // 
            this.txtHardwareId.Enabled = false;
            this.txtHardwareId.Location = new System.Drawing.Point(115, 77);
            this.txtHardwareId.Name = "txtHardwareId";
            this.txtHardwareId.Size = new System.Drawing.Size(362, 21);
            this.txtHardwareId.TabIndex = 15;
            // 
            // lblScadenza
            // 
            this.lblScadenza.AutoSize = true;
            this.lblScadenza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScadenza.ForeColor = System.Drawing.Color.Red;
            this.lblScadenza.Location = new System.Drawing.Point(112, 117);
            this.lblScadenza.Name = "lblScadenza";
            this.lblScadenza.Size = new System.Drawing.Size(103, 13);
            this.lblScadenza.TabIndex = 14;
            this.lblScadenza.Text = "La licenza scade";
            this.lblScadenza.Visible = false;
            // 
            // txtLicenceType
            // 
            this.txtLicenceType.Location = new System.Drawing.Point(115, 175);
            this.txtLicenceType.Name = "txtLicenceType";
            this.txtLicenceType.Size = new System.Drawing.Size(140, 21);
            this.txtLicenceType.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Tipo licenza:";
            // 
            // txtTrial
            // 
            this.txtTrial.Location = new System.Drawing.Point(115, 207);
            this.txtTrial.Name = "txtTrial";
            this.txtTrial.Size = new System.Drawing.Size(81, 21);
            this.txtTrial.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Giorni di prova:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(115, 45);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(362, 21);
            this.txtMail.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 20);
            this.label3.MaximumSize = new System.Drawing.Size(620, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "....";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 76);
            this.label4.MaximumSize = new System.Drawing.Size(620, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "...";
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(538, 294);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(93, 26);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Chiudi";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdTrial
            // 
            this.cmdTrial.Location = new System.Drawing.Point(424, 158);
            this.cmdTrial.Name = "cmdTrial";
            this.cmdTrial.Size = new System.Drawing.Size(208, 25);
            this.cmdTrial.TabIndex = 10;
            this.cmdTrial.Text = "Richiedi licenza di prova provvisoria";
            this.cmdTrial.UseVisualStyleBackColor = true;
            this.cmdTrial.Click += new System.EventHandler(this.cmdTrial_Click);
            // 
            // cmdAll
            // 
            this.cmdAll.Location = new System.Drawing.Point(424, 190);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.Size = new System.Drawing.Size(208, 25);
            this.cmdAll.TabIndex = 11;
            this.cmdAll.Text = "Inserisci un codice di attivazione";
            this.cmdAll.UseVisualStyleBackColor = true;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 164);
            this.label8.MaximumSize = new System.Drawing.Size(430, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "1) Se desidera  una licenza provvisoria di 30 giorni.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 196);
            this.label9.MaximumSize = new System.Drawing.Size(430, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(334, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "2) Se desidera una licenza definitiva inserisca il codice di attivazione.";
            // 
            // InstallationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 474);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmdAll);
            this.Controls.Add(this.cmdTrial);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InstallationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dati di installazione";
            this.Load += new System.EventHandler(this.InstallationForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button cmdInstall;
        internal System.Windows.Forms.TextBox txtRagSoc;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtMail;
        internal System.Windows.Forms.TextBox txtTrial;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdTrial;
        internal System.Windows.Forms.Button cmdAll;
        internal System.Windows.Forms.TextBox txtLicenceType;
        internal System.Windows.Forms.Label lblScadenza;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtHardwareId;
    }
}