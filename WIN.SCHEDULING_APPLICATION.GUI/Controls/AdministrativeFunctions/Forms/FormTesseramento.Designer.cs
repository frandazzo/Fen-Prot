namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions.Forms
{
    partial class FormTesseramento
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmdOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmdAnnulla = new DevExpress.XtraEditors.SimpleButton();
            this.spQuota = new DevExpress.XtraEditors.SpinEdit();
            this.spRichieste = new DevExpress.XtraEditors.SpinEdit();
            this.spCosto = new DevExpress.XtraEditors.SpinEdit();
            this.spAnno = new DevExpress.XtraEditors.SpinEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spQuota.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRichieste.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCosto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAnno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmdOk);
            this.layoutControl1.Controls.Add(this.cmdAnnulla);
            this.layoutControl1.Controls.Add(this.spQuota);
            this.layoutControl1.Controls.Add(this.spRichieste);
            this.layoutControl1.Controls.Add(this.spCosto);
            this.layoutControl1.Controls.Add(this.spAnno);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(267, 180, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(291, 157);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(12, 123);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(132, 22);
            this.cmdOk.StyleController = this.layoutControl1;
            this.cmdOk.TabIndex = 9;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdAnnulla
            // 
            this.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdAnnulla.Location = new System.Drawing.Point(148, 123);
            this.cmdAnnulla.Name = "cmdAnnulla";
            this.cmdAnnulla.Size = new System.Drawing.Size(131, 22);
            this.cmdAnnulla.StyleController = this.layoutControl1;
            this.cmdAnnulla.TabIndex = 8;
            this.cmdAnnulla.Text = "&Annulla";
            this.cmdAnnulla.Click += new System.EventHandler(this.cmdAnnulla_Click);
            // 
            // spQuota
            // 
            this.spQuota.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spQuota.Location = new System.Drawing.Point(97, 84);
            this.spQuota.Name = "spQuota";
            this.spQuota.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spQuota.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spQuota.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spQuota.Properties.Mask.EditMask = "c";
            this.spQuota.Size = new System.Drawing.Size(182, 20);
            this.spQuota.StyleController = this.layoutControl1;
            this.spQuota.TabIndex = 7;
            // 
            // spRichieste
            // 
            this.spRichieste.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spRichieste.Location = new System.Drawing.Point(97, 60);
            this.spRichieste.Name = "spRichieste";
            this.spRichieste.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spRichieste.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spRichieste.Properties.IsFloatValue = false;
            this.spRichieste.Properties.Mask.EditMask = "N00";
            this.spRichieste.Size = new System.Drawing.Size(182, 20);
            this.spRichieste.StyleController = this.layoutControl1;
            this.spRichieste.TabIndex = 6;
            // 
            // spCosto
            // 
            this.spCosto.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spCosto.Location = new System.Drawing.Point(97, 36);
            this.spCosto.Name = "spCosto";
            this.spCosto.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spCosto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spCosto.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spCosto.Properties.Mask.EditMask = "c";
            this.spCosto.Size = new System.Drawing.Size(182, 20);
            this.spCosto.StyleController = this.layoutControl1;
            this.spCosto.TabIndex = 5;
            // 
            // spAnno
            // 
            this.spAnno.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spAnno.Location = new System.Drawing.Point(97, 12);
            this.spAnno.Name = "spAnno";
            this.spAnno.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.spAnno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spAnno.Properties.IsFloatValue = false;
            this.spAnno.Properties.Mask.EditMask = "N00";
            this.spAnno.Size = new System.Drawing.Size(182, 20);
            this.spAnno.StyleController = this.layoutControl1;
            this.spAnno.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(291, 157);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.spAnno;
            this.layoutControlItem1.CustomizationFormText = "Anno";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(271, 24);
            this.layoutControlItem1.Text = "Anno";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.spCosto;
            this.layoutControlItem2.CustomizationFormText = "Costo tessera";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(271, 24);
            this.layoutControlItem2.Text = "Costo tessera";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.spRichieste;
            this.layoutControlItem3.CustomizationFormText = "Tessere richieste";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(271, 24);
            this.layoutControlItem3.Text = "Tessere richieste";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.spQuota;
            this.layoutControlItem4.CustomizationFormText = "Quota UIL";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(271, 24);
            this.layoutControlItem4.Text = "Quota UIL";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmdAnnulla;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(136, 111);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(135, 26);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cmdOk;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 111);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(136, 26);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 96);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(271, 15);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // FormTesseramento
            // 
            this.AcceptButton = this.cmdOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdAnnulla;
            this.ClientSize = new System.Drawing.Size(291, 157);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTesseramento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dati eesseramento";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spQuota.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spRichieste.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spCosto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spAnno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton cmdOk;
        private DevExpress.XtraEditors.SimpleButton cmdAnnulla;
        private DevExpress.XtraEditors.SpinEdit spQuota;
        private DevExpress.XtraEditors.SpinEdit spRichieste;
        private DevExpress.XtraEditors.SpinEdit spCosto;
        private DevExpress.XtraEditors.SpinEdit spAnno;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}