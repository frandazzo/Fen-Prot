namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    partial class AppointmentCustomerSearchControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkNoCust = new DevExpress.XtraEditors.CheckEdit();
            this.lstCustomers = new DevExpress.XtraEditors.ListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmdAdd = new DevExpress.XtraEditors.SimpleButton();
            this.cmdRemove = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkNoCust.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // chkNoCust
            // 
            this.chkNoCust.Location = new System.Drawing.Point(18, 13);
            this.chkNoCust.Name = "chkNoCust";
            this.chkNoCust.Properties.Caption = "Elementi senza contatto";
            this.chkNoCust.Size = new System.Drawing.Size(153, 19);
            this.chkNoCust.TabIndex = 0;
            this.chkNoCust.ToolTip = "La selezione di questo flag consente la ricerca tra tutti quegli appuntamenti che" +
                " non sono assegnati a nessun cliente!";
            this.chkNoCust.CheckedChanged += new System.EventHandler(this.chkNoCust_CheckedChanged);
            // 
            // lstCustomers
            // 
            this.lstCustomers.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstCustomers.HorizontalScrollbar = true;
            this.lstCustomers.HotTrackItems = true;
            this.lstCustomers.Location = new System.Drawing.Point(20, 69);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(173, 136);
            this.lstCustomers.TabIndex = 1;
            this.lstCustomers.ToolTip = "Lista di filtro sui clienti. ";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Contatti selezionati";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(21, 212);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(69, 23);
            this.cmdAdd.TabIndex = 3;
            this.cmdAdd.Text = "Aggiungi";
            this.cmdAdd.ToolTip = "Aggiungi un cliente alla lista di filtro";
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Location = new System.Drawing.Point(118, 211);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(75, 23);
            this.cmdRemove.TabIndex = 4;
            this.cmdRemove.Text = "Rimuovi";
            this.cmdRemove.ToolTip = "Rimuove il cliente selezionato dalla lista";
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // AppointmentCustomerSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmdRemove);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstCustomers);
            this.Controls.Add(this.chkNoCust);
            this.Name = "AppointmentCustomerSearchControl";
            this.Size = new System.Drawing.Size(209, 261);
            ((System.ComponentModel.ISupportInitialize)(this.chkNoCust.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkNoCust;
        private DevExpress.XtraEditors.ListBoxControl lstCustomers;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton cmdAdd;
        private DevExpress.XtraEditors.SimpleButton cmdRemove;
    }
}
