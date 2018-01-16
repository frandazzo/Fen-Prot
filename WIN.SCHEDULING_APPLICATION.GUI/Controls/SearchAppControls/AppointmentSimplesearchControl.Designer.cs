namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    partial class AppointmentSimplesearchControl
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtsubject = new DevExpress.XtraEditors.TextEdit();
            this.txtLoc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lstCau = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.lstRes = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lstOp = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtsubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOp)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Oggetto";
            // 
            // txtsubject
            // 
            this.txtsubject.Location = new System.Drawing.Point(15, 29);
            this.txtsubject.Name = "txtsubject";
            this.txtsubject.Size = new System.Drawing.Size(165, 20);
            this.txtsubject.TabIndex = 1;
            this.txtsubject.ToolTip = "Seleziona il testo dell\'oggetto dell\'appuntamento da ricercare. Se la ricerca rig" +
                "uarda una parola all\'interno dell\'oggetto e non la parte iniziale digitare il pr" +
                "efisso % prima del testo da digitare";
            // 
            // txtLoc
            // 
            this.txtLoc.Location = new System.Drawing.Point(15, 73);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.Size = new System.Drawing.Size(165, 20);
            this.txtLoc.TabIndex = 3;
            this.txtLoc.ToolTip = "Seleziona il testo del luogo dell\'appuntamento da ricercare. Se la ricerca riguar" +
                "da una parola all\'interno del luogo e non la parte iniziale digitare il prefisso" +
                " % prima del testo da digitare";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Luogo";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 101);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(38, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Causale";
            // 
            // lstCau
            // 
            this.lstCau.CheckOnClick = true;
            this.lstCau.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstCau.HorizontalScrollbar = true;
            this.lstCau.Location = new System.Drawing.Point(15, 120);
            this.lstCau.Name = "lstCau";
            this.lstCau.Size = new System.Drawing.Size(165, 80);
            this.lstCau.TabIndex = 5;
            this.lstCau.ToolTip = "Lista di causali per il filtraggio degli appuntamenti";
            this.lstCau.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstCau_DrawItem);
            // 
            // lstRes
            // 
            this.lstRes.CheckOnClick = true;
            this.lstRes.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstRes.HorizontalScrollbar = true;
            this.lstRes.Location = new System.Drawing.Point(15, 227);
            this.lstRes.Name = "lstRes";
            this.lstRes.Size = new System.Drawing.Size(165, 80);
            this.lstRes.TabIndex = 7;
            this.lstRes.ToolTip = "Lista di zone per il filtraggio degli appuntamenti";
            this.lstRes.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstRes_DrawItem);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(15, 208);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Risorsa";
            // 
            // lstOp
            // 
            this.lstOp.CheckOnClick = true;
            this.lstOp.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstOp.HorizontalScrollbar = true;
            this.lstOp.Location = new System.Drawing.Point(15, 334);
            this.lstOp.Name = "lstOp";
            this.lstOp.Size = new System.Drawing.Size(165, 80);
            this.lstOp.TabIndex = 9;
            this.lstOp.ToolTip = "Lista di operatori per il filtraggio degli appuntamenti";
            this.lstOp.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstOp_DrawItem);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(15, 315);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(50, 13);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Operatore";
            // 
            // AppointmentSimplesearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstOp);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstRes);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lstCau);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtsubject);
            this.Controls.Add(this.labelControl1);
            this.Name = "AppointmentSimplesearchControl";
            this.Size = new System.Drawing.Size(202, 437);
            this.Load += new System.EventHandler(this.AppointmentSimplesearchControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtsubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtsubject;
        private DevExpress.XtraEditors.TextEdit txtLoc;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckedListBoxControl lstCau;
        private DevExpress.XtraEditors.CheckedListBoxControl lstRes;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckedListBoxControl lstOp;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}
