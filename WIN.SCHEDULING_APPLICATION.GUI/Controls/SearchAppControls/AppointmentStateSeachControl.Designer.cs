namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    partial class AppointmentStateSeachControl
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
            this.checkEdit0 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.chkClosed = new DevExpress.XtraEditors.CheckEdit();
            this.lstApp = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit0.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClosed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstApp)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit0
            // 
            this.checkEdit0.Location = new System.Drawing.Point(11, 16);
            this.checkEdit0.Name = "checkEdit0";
            this.checkEdit0.Properties.Caption = "Tutti";
            this.checkEdit0.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit0.Properties.RadioGroupIndex = 0;
            this.checkEdit0.Size = new System.Drawing.Size(138, 19);
            this.checkEdit0.TabIndex = 3;
            this.checkEdit0.TabStop = false;
            this.checkEdit0.CheckedChanged += new System.EventHandler(this.checkEdit0_CheckedChanged);
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(11, 65);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Eseguiti";
            this.checkEdit2.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit2.Properties.RadioGroupIndex = 0;
            this.checkEdit2.Size = new System.Drawing.Size(138, 19);
            this.checkEdit2.TabIndex = 5;
            this.checkEdit2.TabStop = false;
            this.checkEdit2.CheckedChanged += new System.EventHandler(this.checkEdit0_CheckedChanged);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(11, 41);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Non eseguiti";
            this.checkEdit1.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.checkEdit1.Properties.RadioGroupIndex = 0;
            this.checkEdit1.Size = new System.Drawing.Size(138, 19);
            this.checkEdit1.TabIndex = 4;
            this.checkEdit1.TabStop = false;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit0_CheckedChanged);
            // 
            // chkClosed
            // 
            this.chkClosed.Location = new System.Drawing.Point(14, 96);
            this.chkClosed.Name = "chkClosed";
            this.chkClosed.Properties.Caption = "Conclusi";
            this.chkClosed.Size = new System.Drawing.Size(96, 19);
            this.chkClosed.TabIndex = 6;
            this.chkClosed.CheckedChanged += new System.EventHandler(this.chkClosed_CheckedChanged);
            // 
            // lstApp
            // 
            this.lstApp.CheckOnClick = true;
            this.lstApp.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.lstApp.HorizontalScrollbar = true;
            this.lstApp.HotTrackItems = true;
            this.lstApp.Location = new System.Drawing.Point(15, 140);
            this.lstApp.Name = "lstApp";
            this.lstApp.Size = new System.Drawing.Size(158, 172);
            this.lstApp.TabIndex = 7;
            this.lstApp.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.lstApp_DrawItem);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Esiti appuntamento";
            // 
            // AppointmentStateSeachControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lstApp);
            this.Controls.Add(this.chkClosed);
            this.Controls.Add(this.checkEdit0);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.checkEdit1);
            this.Name = "AppointmentStateSeachControl";
            this.Size = new System.Drawing.Size(188, 324);
            this.Load += new System.EventHandler(this.AppointmentStateSeachControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit0.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkClosed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit0;
        private DevExpress.XtraEditors.CheckEdit checkEdit2;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private DevExpress.XtraEditors.CheckEdit chkClosed;
        private DevExpress.XtraEditors.CheckedListBoxControl lstApp;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
