namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    partial class DocumentSearchControl
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
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lstOp = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lstCau = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProtocol = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.spYear = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lstCart = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProtocol.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(13, 26);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(154, 20);
            this.txtSubject.TabIndex = 16;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Oggetto";
            // 
            // lstOp
            // 
            this.lstOp.CheckOnClick = true;
            this.lstOp.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstOp.HorizontalScrollbar = true;
            this.lstOp.Location = new System.Drawing.Point(13, 391);
            this.lstOp.Name = "lstOp";
            this.lstOp.Size = new System.Drawing.Size(151, 87);
            this.lstOp.TabIndex = 20;
            this.lstOp.ToolTip = "Lista di operatori per il filtraggio degli appuntamenti";
            this.lstOp.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstOp_DrawItem);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 372);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(46, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Operatori";
            // 
            // lstCau
            // 
            this.lstCau.CheckOnClick = true;
            this.lstCau.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstCau.HorizontalScrollbar = true;
            this.lstCau.Location = new System.Drawing.Point(13, 281);
            this.lstCau.Name = "lstCau";
            this.lstCau.Size = new System.Drawing.Size(151, 80);
            this.lstCau.TabIndex = 18;
            this.lstCau.ToolTip = "Lista di causali per il filtraggio degli appuntamenti";
            this.lstCau.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstCau_DrawItem);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 262);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 17;
            this.labelControl3.Text = "Causali";
            // 
            // txtProtocol
            // 
            this.txtProtocol.Location = new System.Drawing.Point(13, 70);
            this.txtProtocol.Name = "txtProtocol";
            this.txtProtocol.Size = new System.Drawing.Size(154, 20);
            this.txtProtocol.TabIndex = 22;
            this.txtProtocol.EditValueChanged += new System.EventHandler(this.txtProtocol_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 21;
            this.labelControl1.Text = "Protocollo";
            // 
            // spYear
            // 
            this.spYear.EditValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.spYear.Location = new System.Drawing.Point(13, 114);
            this.spYear.Name = "spYear";
            this.spYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spYear.Properties.IsFloatValue = false;
            this.spYear.Properties.Mask.EditMask = "N00";
            this.spYear.Properties.MaxValue = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.spYear.Properties.MinValue = new decimal(new int[] {
            1980,
            0,
            0,
            0});
            this.spYear.Size = new System.Drawing.Size(100, 20);
            this.spYear.TabIndex = 23;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 97);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 13);
            this.labelControl4.TabIndex = 24;
            this.labelControl4.Text = "Anno";
            // 
            // lstCart
            // 
            this.lstCart.CheckOnClick = true;
            this.lstCart.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstCart.HorizontalScrollbar = true;
            this.lstCart.Location = new System.Drawing.Point(13, 168);
            this.lstCart.Name = "lstCart";
            this.lstCart.Size = new System.Drawing.Size(151, 88);
            this.lstCart.TabIndex = 26;
            this.lstCart.ToolTip = "Lista di causali per il filtraggio degli appuntamenti";
            this.lstCart.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstCart_DrawItem);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 149);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 25;
            this.labelControl6.Text = "Cartelle";
            // 
            // DocumentSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstCart);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.spYear);
            this.Controls.Add(this.txtProtocol);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstOp);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lstCau);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.labelControl2);
            this.Name = "DocumentSearchControl";
            this.Size = new System.Drawing.Size(184, 491);
            this.Load += new System.EventHandler(this.DocumentSearchControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProtocol.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedListBoxControl lstOp;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.CheckedListBoxControl lstCau;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtProtocol;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit spYear;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckedListBoxControl lstCart;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
