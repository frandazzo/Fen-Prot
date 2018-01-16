namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.uxCancelButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lblApp = new DevExpress.XtraEditors.LabelControl();
            this.lblVers = new DevExpress.XtraEditors.LabelControl();
            this.lblDB = new DevExpress.XtraEditors.LabelControl();
            this.uxUserTextBox = new DevExpress.XtraEditors.TextEdit();
            this.uxErrorLabel = new DevExpress.XtraEditors.LabelControl();
            this.uxPassTextBox = new DevExpress.XtraEditors.TextEdit();
            this.uxLogonButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxUserTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPassTextBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // uxCancelButton1
            // 
            this.uxCancelButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.uxCancelButton1.Location = new System.Drawing.Point(232, 110);
            this.uxCancelButton1.Name = "uxCancelButton1";
            this.uxCancelButton1.Size = new System.Drawing.Size(197, 22);
            this.uxCancelButton1.StyleController = this.layoutControl1;
            this.uxCancelButton1.TabIndex = 41;
            this.uxCancelButton1.Text = "Esci";
            this.uxCancelButton1.Click += new System.EventHandler(this.uxCancelButton1_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.BackColor = System.Drawing.Color.Silver;
            this.layoutControl1.Controls.Add(this.labelControl1);
            this.layoutControl1.Controls.Add(this.lblApp);
            this.layoutControl1.Controls.Add(this.lblVers);
            this.layoutControl1.Controls.Add(this.lblDB);
            this.layoutControl1.Controls.Add(this.uxUserTextBox);
            this.layoutControl1.Controls.Add(this.uxErrorLabel);
            this.layoutControl1.Controls.Add(this.uxPassTextBox);
            this.layoutControl1.Controls.Add(this.uxCancelButton1);
            this.layoutControl1.Controls.Add(this.uxLogonButton1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(561, 1, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(441, 205);
            this.layoutControl1.TabIndex = 46;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lblApp
            // 
            this.lblApp.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApp.Location = new System.Drawing.Point(12, 12);
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(207, 33);
            this.lblApp.StyleController = this.layoutControl1;
            this.lblApp.TabIndex = 48;
            this.lblApp.Text = "Titolo";
            // 
            // lblVers
            // 
            this.lblVers.Location = new System.Drawing.Point(223, 30);
            this.lblVers.Name = "lblVers";
            this.lblVers.Size = new System.Drawing.Size(206, 15);
            this.lblVers.StyleController = this.layoutControl1;
            this.lblVers.TabIndex = 47;
            this.lblVers.Text = "Versione applicazione";
            // 
            // lblDB
            // 
            this.lblDB.Location = new System.Drawing.Point(223, 12);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(206, 14);
            this.lblDB.StyleController = this.layoutControl1;
            this.lblDB.TabIndex = 46;
            this.lblDB.Text = "Versione database ";
            // 
            // uxUserTextBox
            // 
            this.uxUserTextBox.Location = new System.Drawing.Point(78, 49);
            this.uxUserTextBox.Name = "uxUserTextBox";
            this.uxUserTextBox.Size = new System.Drawing.Size(351, 20);
            this.uxUserTextBox.StyleController = this.layoutControl1;
            this.uxUserTextBox.TabIndex = 44;
            this.uxUserTextBox.Enter += new System.EventHandler(this.uxUserTextBox_Enter);
            // 
            // uxErrorLabel
            // 
            this.uxErrorLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxErrorLabel.Appearance.ForeColor = System.Drawing.Color.Red;
            this.uxErrorLabel.Location = new System.Drawing.Point(226, 136);
            this.uxErrorLabel.Name = "uxErrorLabel";
            this.uxErrorLabel.Size = new System.Drawing.Size(203, 16);
            this.uxErrorLabel.StyleController = this.layoutControl1;
            this.uxErrorLabel.TabIndex = 43;
            this.uxErrorLabel.Text = "Nome utente o password errati";
            this.uxErrorLabel.Visible = false;
            // 
            // uxPassTextBox
            // 
            this.uxPassTextBox.Location = new System.Drawing.Point(78, 73);
            this.uxPassTextBox.Name = "uxPassTextBox";
            this.uxPassTextBox.Properties.PasswordChar = '*';
            this.uxPassTextBox.Size = new System.Drawing.Size(351, 20);
            this.uxPassTextBox.StyleController = this.layoutControl1;
            this.uxPassTextBox.TabIndex = 45;
            this.uxPassTextBox.Enter += new System.EventHandler(this.uxPassTextBox_Enter);
            // 
            // uxLogonButton1
            // 
            this.uxLogonButton1.Location = new System.Drawing.Point(12, 110);
            this.uxLogonButton1.Name = "uxLogonButton1";
            this.uxLogonButton1.Size = new System.Drawing.Size(216, 22);
            this.uxLogonButton1.StyleController = this.layoutControl1;
            this.uxLogonButton1.TabIndex = 42;
            this.uxLogonButton1.Text = "Entra";
            this.uxLogonButton1.Click += new System.EventHandler(this.uxLogonButton1_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.emptySpaceItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(441, 205);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.uxUserTextBox;
            this.layoutControlItem1.CustomizationFormText = "Nome utente";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 37);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(421, 24);
            this.layoutControlItem1.Text = "Nome utente";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.uxPassTextBox;
            this.layoutControlItem2.CustomizationFormText = "Password";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 61);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(421, 24);
            this.layoutControlItem2.Text = "Password";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.uxCancelButton1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(220, 98);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(201, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.uxLogonButton1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(220, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 85);
            this.emptySpaceItem1.MaxSize = new System.Drawing.Size(357, 13);
            this.emptySpaceItem1.MinSize = new System.Drawing.Size(357, 13);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(421, 13);
            this.emptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.uxErrorLabel;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(214, 124);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(207, 20);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 124);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(214, 20);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lblDB;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(211, 0);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(96, 17);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(210, 18);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.lblVers;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(211, 18);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(106, 17);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(210, 19);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.lblApp;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.reminders;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(0, 37);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(47, 37);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(211, 37);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Right;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(12, 156);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(417, 37);
            this.labelControl1.StyleController = this.layoutControl1;
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = resources.GetString("labelControl1.Text");
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.labelControl1;
            this.layoutControlItem9.CustomizationFormText = "layoutControlItem9";
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 144);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(14, 17);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(421, 41);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "layoutControlItem9";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextToControlDistance = 0;
            this.layoutControlItem9.TextVisible = false;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.uxLogonButton1;
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.uxCancelButton1;
            this.ClientSize = new System.Drawing.Size(441, 205);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Benvenuto";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxUserTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPassTextBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton uxCancelButton1;
        private DevExpress.XtraEditors.SimpleButton uxLogonButton1;
        private DevExpress.XtraEditors.TextEdit uxUserTextBox;
        private DevExpress.XtraEditors.TextEdit uxPassTextBox;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.LabelControl lblVers;
        private DevExpress.XtraEditors.LabelControl lblDB;
        private DevExpress.XtraEditors.LabelControl lblApp;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.LabelControl uxErrorLabel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}