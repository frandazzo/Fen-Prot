namespace WIN.SCHEDULING_APP.GUI.Forms
{
    partial class FormInformazioni
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInformazioni));
            this.Label4 = new System.Windows.Forms.Label();
            this.CustomPersistenceAssemblyNameLabel = new System.Windows.Forms.Label();
            this.DBTypeLabel = new System.Windows.Forms.Label();
            this.MaxCacheSizeLabel = new System.Windows.Forms.Label();
            this.lblDB = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblVers = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtConnextionStringparameters = new DevExpress.XtraEditors.MemoEdit();
            this.lblSwTitle = new DevExpress.XtraEditors.LabelControl();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnextionStringparameters.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Black;
            this.Label4.Location = new System.Drawing.Point(20, 335);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(283, 12);
            this.Label4.TabIndex = 50;
            this.Label4.Text = "Copyright © 2009 - 2011  NOESIS Technologies. Tutti i diritti riservati";
            // 
            // CustomPersistenceAssemblyNameLabel
            // 
            this.CustomPersistenceAssemblyNameLabel.AutoSize = true;
            this.CustomPersistenceAssemblyNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.CustomPersistenceAssemblyNameLabel.ForeColor = System.Drawing.Color.Black;
            this.CustomPersistenceAssemblyNameLabel.Location = new System.Drawing.Point(21, 130);
            this.CustomPersistenceAssemblyNameLabel.MaximumSize = new System.Drawing.Size(500, 0);
            this.CustomPersistenceAssemblyNameLabel.Name = "CustomPersistenceAssemblyNameLabel";
            this.CustomPersistenceAssemblyNameLabel.Size = new System.Drawing.Size(71, 18);
            this.CustomPersistenceAssemblyNameLabel.TabIndex = 49;
            this.CustomPersistenceAssemblyNameLabel.Text = "AsseblyName";
            this.CustomPersistenceAssemblyNameLabel.UseCompatibleTextRendering = true;
            // 
            // DBTypeLabel
            // 
            this.DBTypeLabel.AutoSize = true;
            this.DBTypeLabel.BackColor = System.Drawing.Color.Transparent;
            this.DBTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.DBTypeLabel.Location = new System.Drawing.Point(228, 83);
            this.DBTypeLabel.Name = "DBTypeLabel";
            this.DBTypeLabel.Size = new System.Drawing.Size(75, 13);
            this.DBTypeLabel.TabIndex = 48;
            this.DBTypeLabel.Text = "Tipo database";
            // 
            // MaxCacheSizeLabel
            // 
            this.MaxCacheSizeLabel.AutoSize = true;
            this.MaxCacheSizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MaxCacheSizeLabel.ForeColor = System.Drawing.Color.Black;
            this.MaxCacheSizeLabel.Location = new System.Drawing.Point(229, 105);
            this.MaxCacheSizeLabel.Name = "MaxCacheSizeLabel";
            this.MaxCacheSizeLabel.Size = new System.Drawing.Size(56, 13);
            this.MaxCacheSizeLabel.TabIndex = 47;
            this.MaxCacheSizeLabel.Text = "CacheSize";
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.BackColor = System.Drawing.Color.Transparent;
            this.lblDB.ForeColor = System.Drawing.Color.Black;
            this.lblDB.Location = new System.Drawing.Point(19, 105);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(100, 13);
            this.lblDB.TabIndex = 45;
            this.lblDB.Text = "Versionedatabase: ";
            this.lblDB.Click += new System.EventHandler(this.LabelDBVersion_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(19, 257);
            this.Label1.MaximumSize = new System.Drawing.Size(400, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(398, 52);
            this.Label1.TabIndex = 44;
            this.Label1.Text = resources.GetString("Label1.Text");
            // 
            // lblVers
            // 
            this.lblVers.AutoSize = true;
            this.lblVers.BackColor = System.Drawing.Color.Transparent;
            this.lblVers.ForeColor = System.Drawing.Color.Black;
            this.lblVers.Location = new System.Drawing.Point(18, 80);
            this.lblVers.Name = "lblVers";
            this.lblVers.Size = new System.Drawing.Size(98, 13);
            this.lblVers.TabIndex = 43;
            this.lblVers.Text = "Versione software:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(332, 324);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 23);
            this.simpleButton1.TabIndex = 52;
            this.simpleButton1.Text = "&Ok";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtConnextionStringparameters
            // 
            this.txtConnextionStringparameters.Location = new System.Drawing.Point(21, 179);
            this.txtConnextionStringparameters.Name = "txtConnextionStringparameters";
            this.txtConnextionStringparameters.Size = new System.Drawing.Size(402, 65);
            this.txtConnextionStringparameters.TabIndex = 53;
            // 
            // lblSwTitle
            // 
            this.lblSwTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwTitle.Location = new System.Drawing.Point(22, 12);
            this.lblSwTitle.Name = "lblSwTitle";
            this.lblSwTitle.Size = new System.Drawing.Size(110, 19);
            this.lblSwTitle.TabIndex = 54;
            this.lblSwTitle.Text = "labelControl1";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PictureBox1.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.lonNoesis;
            this.PictureBox1.Location = new System.Drawing.Point(237, 12);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(192, 50);
            this.PictureBox1.TabIndex = 51;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // FormInformazioni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 363);
            this.Controls.Add(this.lblSwTitle);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.CustomPersistenceAssemblyNameLabel);
            this.Controls.Add(this.DBTypeLabel);
            this.Controls.Add(this.MaxCacheSizeLabel);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblVers);
            this.Controls.Add(this.txtConnextionStringparameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInformazioni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informazioni";
            ((System.ComponentModel.ISupportInitialize)(this.txtConnextionStringparameters.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label CustomPersistenceAssemblyNameLabel;
        internal System.Windows.Forms.Label DBTypeLabel;
        internal System.Windows.Forms.Label MaxCacheSizeLabel;
        internal System.Windows.Forms.Label lblDB;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblVers;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.MemoEdit txtConnextionStringparameters;
        private DevExpress.XtraEditors.LabelControl lblSwTitle;
    }
}