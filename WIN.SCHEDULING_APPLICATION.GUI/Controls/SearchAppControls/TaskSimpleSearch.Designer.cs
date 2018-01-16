namespace WIN.SCHEDULING_APP.GUI.Controls.SearchAppControls
{
    partial class TaskSimpleSearch
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtSub = new DevExpress.XtraEditors.TextEdit();
            this.cboPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chk0 = new DevExpress.XtraEditors.CheckEdit();
            this.chk1 = new DevExpress.XtraEditors.CheckEdit();
            this.chk2 = new DevExpress.XtraEditors.CheckEdit();
            this.chk3 = new DevExpress.XtraEditors.CheckEdit();
            this.chk4 = new DevExpress.XtraEditors.CheckEdit();
            this.dtpA = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new DevExpress.XtraEditors.LabelControl();
            this.dtpDa = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkDeadTasks = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtpAlla = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSub.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk0.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpA.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDa.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeadTasks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAlla.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAlla.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Stato attività";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 214);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Oggetto attività";
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(15, 233);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(168, 20);
            this.txtSub.TabIndex = 14;
            // 
            // cboPriority
            // 
            this.cboPriority.EditValue = "";
            this.cboPriority.Location = new System.Drawing.Point(15, 276);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPriority.Properties.Items.AddRange(new object[] {
            "",
            "Alta",
            "Normale",
            "Bassa"});
            this.cboPriority.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPriority.Size = new System.Drawing.Size(168, 20);
            this.cboPriority.TabIndex = 15;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 257);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Priorità";
            // 
            // chk0
            // 
            this.chk0.Location = new System.Drawing.Point(17, 27);
            this.chk0.Name = "chk0";
            this.chk0.Properties.Caption = "Non iniziata";
            this.chk0.Size = new System.Drawing.Size(85, 19);
            this.chk0.TabIndex = 17;
            this.chk0.CheckedChanged += new System.EventHandler(this.chk0_CheckedChanged);
            // 
            // chk1
            // 
            this.chk1.Location = new System.Drawing.Point(17, 50);
            this.chk1.Name = "chk1";
            this.chk1.Properties.Caption = "In corso";
            this.chk1.Size = new System.Drawing.Size(75, 19);
            this.chk1.TabIndex = 18;
            this.chk1.CheckedChanged += new System.EventHandler(this.chk1_CheckedChanged);
            // 
            // chk2
            // 
            this.chk2.Location = new System.Drawing.Point(17, 73);
            this.chk2.Name = "chk2";
            this.chk2.Properties.Caption = "Completata";
            this.chk2.Size = new System.Drawing.Size(85, 19);
            this.chk2.TabIndex = 19;
            this.chk2.CheckedChanged += new System.EventHandler(this.chk2_CheckedChanged);
            // 
            // chk3
            // 
            this.chk3.Location = new System.Drawing.Point(17, 96);
            this.chk3.Name = "chk3";
            this.chk3.Properties.Caption = "In attesa";
            this.chk3.Size = new System.Drawing.Size(75, 19);
            this.chk3.TabIndex = 20;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.Location = new System.Drawing.Point(19, 120);
            this.chk4.Name = "chk4";
            this.chk4.Properties.Caption = "Rinviata";
            this.chk4.Size = new System.Drawing.Size(75, 19);
            this.chk4.TabIndex = 21;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // dtpA
            // 
            this.dtpA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpA.EditValue = null;
            this.dtpA.Enabled = false;
            this.dtpA.Location = new System.Drawing.Point(45, 354);
            this.dtpA.Name = "dtpA";
            this.dtpA.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpA.Properties.NullText = "Nessuna data";
            this.dtpA.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpA.Size = new System.Drawing.Size(127, 20);
            this.dtpA.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(18, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(6, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "a";
            // 
            // dtpDa
            // 
            this.dtpDa.AllowDrop = true;
            this.dtpDa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDa.EditValue = null;
            this.dtpDa.Enabled = false;
            this.dtpDa.Location = new System.Drawing.Point(45, 330);
            this.dtpDa.Name = "dtpDa";
            this.dtpDa.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpDa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDa.Properties.NullText = "Nessuna data";
            this.dtpDa.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDa.Size = new System.Drawing.Size(127, 20);
            this.dtpDa.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(18, 334);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "da";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 308);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(115, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "Completata nel periodo:";
            // 
            // chkDeadTasks
            // 
            this.chkDeadTasks.EditValue = true;
            this.chkDeadTasks.Location = new System.Drawing.Point(19, 146);
            this.chkDeadTasks.Name = "chkDeadTasks";
            this.chkDeadTasks.Properties.Caption = "Scaduti";
            this.chkDeadTasks.Size = new System.Drawing.Size(75, 19);
            this.chkDeadTasks.TabIndex = 27;
            this.chkDeadTasks.CheckedChanged += new System.EventHandler(this.chkDeadTasks_CheckedChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(29, 181);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 28;
            this.labelControl5.Text = "fino a";
            // 
            // dtpAlla
            // 
            this.dtpAlla.EditValue = null;
            this.dtpAlla.Location = new System.Drawing.Point(62, 178);
            this.dtpAlla.Name = "dtpAlla";
            this.dtpAlla.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtpAlla.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpAlla.Properties.NullText = "Nessuna data";
            this.dtpAlla.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpAlla.Size = new System.Drawing.Size(110, 20);
            this.dtpAlla.TabIndex = 29;
            // 
            // TaskSimpleSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpAlla);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.chkDeadTasks);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.dtpA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chk4);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.chk0);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboPriority);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "TaskSimpleSearch";
            this.Size = new System.Drawing.Size(198, 384);
            ((System.ComponentModel.ISupportInitialize)(this.txtSub.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk0.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpA.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDa.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeadTasks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAlla.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpAlla.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSub;
        private DevExpress.XtraEditors.ComboBoxEdit cboPriority;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chk0;
        private DevExpress.XtraEditors.CheckEdit chk1;
        private DevExpress.XtraEditors.CheckEdit chk2;
        private DevExpress.XtraEditors.CheckEdit chk3;
        private DevExpress.XtraEditors.CheckEdit chk4;
        private DevExpress.XtraEditors.DateEdit dtpA;
        private DevExpress.XtraEditors.LabelControl label4;
        private DevExpress.XtraEditors.DateEdit dtpDa;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkDeadTasks;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit dtpAlla;
    }
}
