namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class DocScopeControl
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.hyperLinkEdit1 = new DevExpress.XtraEditors.HyperLinkEdit();
            this.txtRespProtocol = new DevExpress.XtraEditors.TextEdit();
            this.txtResp = new DevExpress.XtraEditors.TextEdit();
            this.txtProtocol = new DevExpress.XtraEditors.TextEdit();
            this.cboColor = new DevExpress.XtraEditors.ColorEdit();
            this.txtDescrizione = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRespProtocol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProtocol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescrizione.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Size = new System.Drawing.Size(775, 109);
            this.commandBar1.NewCommandPressed += new System.EventHandler(this.commandBar1_NewCommandPressed);
            this.commandBar1.UndoCommandPressed += new System.EventHandler(this.commandBar1_UndoCommandPressed);
            this.commandBar1.SaveCommandPressed += new System.EventHandler(this.commandBar1_SaveCommandPressed);
            this.commandBar1.DelCommandPressed += new System.EventHandler(this.commandBar1_DelCommandPressed);
            this.commandBar1.InfoCommandPressed += new System.EventHandler(this.commandBar1_InfoCommandPressed);
            this.commandBar1.NewSearchCommandPressed += new System.EventHandler(this.commandBar1_NewSearchCommandPressed);
            this.commandBar1.FindElementIdCommandPressed += new System.EventHandler(this.commandBar1_FindElementIdCommandPressed);
            this.commandBar1.ViewElementCommandPressed += new System.EventHandler(this.commandBar1_ViewElementCommandPressed);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.checkedListBoxControl1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.hyperLinkEdit1);
            this.layoutControl1.Controls.Add(this.txtRespProtocol);
            this.layoutControl1.Controls.Add(this.txtResp);
            this.layoutControl1.Controls.Add(this.txtProtocol);
            this.layoutControl1.Controls.Add(this.cboColor);
            this.layoutControl1.Controls.Add(this.txtDescrizione);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 109);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(665, 141, 250, 350);
            this.layoutControl1.OptionsView.IsReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(775, 320);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 212);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 13);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Visiblità";
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Location = new System.Drawing.Point(12, 229);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(751, 51);
            this.checkedListBoxControl1.StyleController = this.layoutControl1;
            this.checkedListBoxControl1.TabIndex = 11;
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.folder_16;
            this.simpleButton1.Location = new System.Drawing.Point(440, 132);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(120, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "Seleziona percorso";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // hyperLinkEdit1
            // 
            this.hyperLinkEdit1.Location = new System.Drawing.Point(125, 132);
            this.hyperLinkEdit1.Name = "hyperLinkEdit1";
            this.hyperLinkEdit1.Size = new System.Drawing.Size(311, 20);
            this.hyperLinkEdit1.StyleController = this.layoutControl1;
            this.hyperLinkEdit1.TabIndex = 9;
            this.hyperLinkEdit1.OpenLink += new DevExpress.XtraEditors.Controls.OpenLinkEventHandler(this.hyperLinkEdit1_OpenLink);
            this.hyperLinkEdit1.EditValueChanged += new System.EventHandler(this.hyperLinkEdit1_EditValueChanged);
            this.hyperLinkEdit1.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(this.hyperLinkEdit1_CustomDisplayText);
            this.hyperLinkEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hyperLinkEdit1_MouseDown);
            // 
            // txtRespProtocol
            // 
            this.txtRespProtocol.Location = new System.Drawing.Point(125, 108);
            this.txtRespProtocol.Name = "txtRespProtocol";
            this.txtRespProtocol.Size = new System.Drawing.Size(435, 20);
            this.txtRespProtocol.StyleController = this.layoutControl1;
            this.txtRespProtocol.TabIndex = 8;
            this.txtRespProtocol.EditValueChanged += new System.EventHandler(this.txtRespProtocol_EditValueChanged);
            // 
            // txtResp
            // 
            this.txtResp.Location = new System.Drawing.Point(125, 84);
            this.txtResp.Name = "txtResp";
            this.txtResp.Size = new System.Drawing.Size(435, 20);
            this.txtResp.StyleController = this.layoutControl1;
            this.txtResp.TabIndex = 7;
            this.txtResp.EditValueChanged += new System.EventHandler(this.txtResp_EditValueChanged);
            // 
            // txtProtocol
            // 
            this.txtProtocol.Location = new System.Drawing.Point(125, 36);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(435, 20);
            this.txtProtocol.StyleController = this.layoutControl1;
            this.txtProtocol.TabIndex = 6;
            this.txtProtocol.EditValueChanged += new System.EventHandler(this.txtProtocol_EditValueChanged);
            // 
            // cboColor
            // 
            this.cboColor.EditValue = System.Drawing.Color.Empty;
            this.cboColor.Location = new System.Drawing.Point(125, 188);
            this.cboColor.Name = "cboColor";
            this.cboColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboColor.Size = new System.Drawing.Size(435, 20);
            this.cboColor.StyleController = this.layoutControl1;
            this.cboColor.TabIndex = 5;
            this.cboColor.EditValueChanged += new System.EventHandler(this.cboColor_EditValueChanged);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(125, 12);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(435, 20);
            this.txtDescrizione.StyleController = this.layoutControl1;
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.EditValueChanged += new System.EventHandler(this.txtDescrizione_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem4,
            this.emptySpaceItem3,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(775, 320);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtDescrizione;
            this.layoutControlItem1.CustomizationFormText = "Descrizione";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(552, 24);
            this.layoutControlItem1.Text = "Descrizione";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(110, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cboColor;
            this.layoutControlItem2.CustomizationFormText = "Colore";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 176);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(552, 24);
            this.layoutControlItem2.Text = "Colore";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(110, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(552, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(203, 200);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem2.MaxSize = new System.Drawing.Size(0, 24);
            this.emptySpaceItem2.MinSize = new System.Drawing.Size(10, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(552, 24);
            this.emptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtProtocol;
            this.layoutControlItem3.CustomizationFormText = "Codice protocollo";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(552, 24);
            this.layoutControlItem3.Text = "Codice protocollo";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(110, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtResp;
            this.layoutControlItem4.CustomizationFormText = "Responsabile";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(552, 24);
            this.layoutControlItem4.Text = "Responsabile";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(110, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtRespProtocol;
            this.layoutControlItem5.CustomizationFormText = "Codice protocolle resp.";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(552, 24);
            this.layoutControlItem5.Text = "Codice protocollo resp.";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(110, 13);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.CustomizationFormText = "emptySpaceItem4";
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 272);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(755, 28);
            this.emptySpaceItem4.Text = "emptySpaceItem4";
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.CustomizationFormText = "emptySpaceItem3";
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 146);
            this.emptySpaceItem3.MaxSize = new System.Drawing.Size(0, 30);
            this.emptySpaceItem3.MinSize = new System.Drawing.Size(10, 30);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(552, 30);
            this.emptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem3.Text = "emptySpaceItem3";
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.hyperLinkEdit1;
            this.layoutControlItem6.CustomizationFormText = "Cartella di default";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(428, 26);
            this.layoutControlItem6.Text = "Cartella di default";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(110, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.simpleButton1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(428, 120);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(124, 26);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.checkedListBoxControl1;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 217);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(755, 55);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.labelControl1;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 200);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(755, 17);
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // DocScopeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layoutControl1);
            this.Name = "DocScopeControl";
            this.Size = new System.Drawing.Size(775, 429);
            this.Controls.SetChildIndex(this.commandBar1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLinkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRespProtocol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProtocol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescrizione.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtRespProtocol;
        private DevExpress.XtraEditors.TextEdit txtResp;
        private DevExpress.XtraEditors.TextEdit txtProtocol;
        private DevExpress.XtraEditors.ColorEdit cboColor;
        private DevExpress.XtraEditors.TextEdit txtDescrizione;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLinkEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}
