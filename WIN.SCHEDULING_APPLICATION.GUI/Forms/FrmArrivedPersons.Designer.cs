namespace WIN.SCHEDULING_APP.GUI.Forms
{
    partial class FrmArrivedPersons
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.arrivedPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStanza = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCognomeCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomeCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNazioneCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciaCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComuneCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataNascitaCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNazionalitaCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciaNascitaCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvinciaNascitaSigla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComuneNascitaCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIndirizzoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCellulare1Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCellulare2Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaxCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMailCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDocumentoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumeroDocumentoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLuogoRilascioDocumentoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoteCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodiceFiscaleCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSessoCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivedPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dateEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(680, 442);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.print_16;
            this.simpleButton2.Location = new System.Drawing.Point(540, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(128, 22);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Stampa";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.arrivedPersonBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 38);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(656, 392);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // arrivedPersonBindingSource
            // 
            this.arrivedPersonBindingSource.DataSource = typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.ArrivedPerson);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStanza,
            this.colCognomeCliente,
            this.colNomeCliente,
            this.colNazioneCliente,
            this.colProvinciaCliente,
            this.colComuneCliente,
            this.colDataNascitaCliente,
            this.colNazionalitaCliente,
            this.colProvinciaNascitaCliente,
            this.colProvinciaNascitaSigla,
            this.colComuneNascitaCliente,
            this.colIndirizzoCliente,
            this.colCapCliente,
            this.colCellulare1Cliente,
            this.colCellulare2Cliente,
            this.colTelefonoCliente,
            this.colFaxCliente,
            this.colMailCliente,
            this.colTipoDocumentoCliente,
            this.colNumeroDocumentoCliente,
            this.colLuogoRilascioDocumentoCliente,
            this.colNoteCliente,
            this.colCodiceFiscaleCliente,
            this.colSessoCliente});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colStanza
            // 
            this.colStanza.FieldName = "Stanza";
            this.colStanza.Name = "colStanza";
            this.colStanza.OptionsColumn.ReadOnly = true;
            this.colStanza.Visible = true;
            this.colStanza.VisibleIndex = 0;
            this.colStanza.Width = 146;
            // 
            // colCognomeCliente
            // 
            this.colCognomeCliente.Caption = "Cognome";
            this.colCognomeCliente.FieldName = "CognomeCliente";
            this.colCognomeCliente.Name = "colCognomeCliente";
            this.colCognomeCliente.OptionsColumn.ReadOnly = true;
            this.colCognomeCliente.Visible = true;
            this.colCognomeCliente.VisibleIndex = 1;
            this.colCognomeCliente.Width = 244;
            // 
            // colNomeCliente
            // 
            this.colNomeCliente.Caption = "Nome";
            this.colNomeCliente.FieldName = "NomeCliente";
            this.colNomeCliente.Name = "colNomeCliente";
            this.colNomeCliente.OptionsColumn.ReadOnly = true;
            this.colNomeCliente.Visible = true;
            this.colNomeCliente.VisibleIndex = 2;
            this.colNomeCliente.Width = 248;
            // 
            // colNazioneCliente
            // 
            this.colNazioneCliente.Caption = "Nazione";
            this.colNazioneCliente.FieldName = "NazioneCliente";
            this.colNazioneCliente.Name = "colNazioneCliente";
            this.colNazioneCliente.OptionsColumn.ReadOnly = true;
            // 
            // colProvinciaCliente
            // 
            this.colProvinciaCliente.Caption = "Provincia";
            this.colProvinciaCliente.FieldName = "ProvinciaCliente";
            this.colProvinciaCliente.Name = "colProvinciaCliente";
            this.colProvinciaCliente.OptionsColumn.ReadOnly = true;
            // 
            // colComuneCliente
            // 
            this.colComuneCliente.Caption = "Comune";
            this.colComuneCliente.FieldName = "ComuneCliente";
            this.colComuneCliente.Name = "colComuneCliente";
            this.colComuneCliente.OptionsColumn.ReadOnly = true;
            // 
            // colDataNascitaCliente
            // 
            this.colDataNascitaCliente.Caption = "Data nascita";
            this.colDataNascitaCliente.FieldName = "DataNascitaCliente";
            this.colDataNascitaCliente.Name = "colDataNascitaCliente";
            this.colDataNascitaCliente.OptionsColumn.ReadOnly = true;
            // 
            // colNazionalitaCliente
            // 
            this.colNazionalitaCliente.Caption = "Nazionalità";
            this.colNazionalitaCliente.FieldName = "NazionalitaCliente";
            this.colNazionalitaCliente.Name = "colNazionalitaCliente";
            this.colNazionalitaCliente.OptionsColumn.ReadOnly = true;
            // 
            // colProvinciaNascitaCliente
            // 
            this.colProvinciaNascitaCliente.Caption = "Provincia nascita";
            this.colProvinciaNascitaCliente.FieldName = "ProvinciaNascitaCliente";
            this.colProvinciaNascitaCliente.Name = "colProvinciaNascitaCliente";
            this.colProvinciaNascitaCliente.OptionsColumn.ReadOnly = true;
            // 
            // colProvinciaNascitaSigla
            // 
            this.colProvinciaNascitaSigla.Caption = "Sigla provincia nascita";
            this.colProvinciaNascitaSigla.FieldName = "ProvinciaNascitaSigla";
            this.colProvinciaNascitaSigla.Name = "colProvinciaNascitaSigla";
            this.colProvinciaNascitaSigla.OptionsColumn.ReadOnly = true;
            // 
            // colComuneNascitaCliente
            // 
            this.colComuneNascitaCliente.Caption = "Comune nascita";
            this.colComuneNascitaCliente.FieldName = "ComuneNascitaCliente";
            this.colComuneNascitaCliente.Name = "colComuneNascitaCliente";
            this.colComuneNascitaCliente.OptionsColumn.ReadOnly = true;
            // 
            // colIndirizzoCliente
            // 
            this.colIndirizzoCliente.Caption = "Idirizzo";
            this.colIndirizzoCliente.FieldName = "IndirizzoCliente";
            this.colIndirizzoCliente.Name = "colIndirizzoCliente";
            this.colIndirizzoCliente.OptionsColumn.ReadOnly = true;
            // 
            // colCapCliente
            // 
            this.colCapCliente.Caption = "Cap";
            this.colCapCliente.FieldName = "CapCliente";
            this.colCapCliente.Name = "colCapCliente";
            this.colCapCliente.OptionsColumn.ReadOnly = true;
            // 
            // colCellulare1Cliente
            // 
            this.colCellulare1Cliente.Caption = "Cellulare1";
            this.colCellulare1Cliente.FieldName = "Cellulare1Cliente";
            this.colCellulare1Cliente.Name = "colCellulare1Cliente";
            this.colCellulare1Cliente.OptionsColumn.ReadOnly = true;
            // 
            // colCellulare2Cliente
            // 
            this.colCellulare2Cliente.Caption = "Cellulare2";
            this.colCellulare2Cliente.FieldName = "Cellulare2Cliente";
            this.colCellulare2Cliente.Name = "colCellulare2Cliente";
            this.colCellulare2Cliente.OptionsColumn.ReadOnly = true;
            // 
            // colTelefonoCliente
            // 
            this.colTelefonoCliente.Caption = "Telefono";
            this.colTelefonoCliente.FieldName = "TelefonoCliente";
            this.colTelefonoCliente.Name = "colTelefonoCliente";
            this.colTelefonoCliente.OptionsColumn.ReadOnly = true;
            // 
            // colFaxCliente
            // 
            this.colFaxCliente.Caption = "Fax";
            this.colFaxCliente.FieldName = "FaxCliente";
            this.colFaxCliente.Name = "colFaxCliente";
            this.colFaxCliente.OptionsColumn.ReadOnly = true;
            // 
            // colMailCliente
            // 
            this.colMailCliente.Caption = "Mail";
            this.colMailCliente.FieldName = "MailCliente";
            this.colMailCliente.Name = "colMailCliente";
            this.colMailCliente.OptionsColumn.ReadOnly = true;
            // 
            // colTipoDocumentoCliente
            // 
            this.colTipoDocumentoCliente.Caption = "Tipo documento";
            this.colTipoDocumentoCliente.FieldName = "TipoDocumentoCliente";
            this.colTipoDocumentoCliente.Name = "colTipoDocumentoCliente";
            this.colTipoDocumentoCliente.OptionsColumn.ReadOnly = true;
            // 
            // colNumeroDocumentoCliente
            // 
            this.colNumeroDocumentoCliente.Caption = "Numero documento";
            this.colNumeroDocumentoCliente.FieldName = "NumeroDocumentoCliente";
            this.colNumeroDocumentoCliente.Name = "colNumeroDocumentoCliente";
            this.colNumeroDocumentoCliente.OptionsColumn.ReadOnly = true;
            // 
            // colLuogoRilascioDocumentoCliente
            // 
            this.colLuogoRilascioDocumentoCliente.Caption = "Luogo rilascio documento";
            this.colLuogoRilascioDocumentoCliente.FieldName = "LuogoRilascioDocumentoCliente";
            this.colLuogoRilascioDocumentoCliente.Name = "colLuogoRilascioDocumentoCliente";
            this.colLuogoRilascioDocumentoCliente.OptionsColumn.ReadOnly = true;
            // 
            // colNoteCliente
            // 
            this.colNoteCliente.Caption = "Note";
            this.colNoteCliente.FieldName = "NoteCliente";
            this.colNoteCliente.Name = "colNoteCliente";
            this.colNoteCliente.OptionsColumn.ReadOnly = true;
            // 
            // colCodiceFiscaleCliente
            // 
            this.colCodiceFiscaleCliente.Caption = "Codice fiscale";
            this.colCodiceFiscaleCliente.FieldName = "CodiceFiscaleCliente";
            this.colCodiceFiscaleCliente.Name = "colCodiceFiscaleCliente";
            this.colCodiceFiscaleCliente.OptionsColumn.ReadOnly = true;
            // 
            // colSessoCliente
            // 
            this.colSessoCliente.Caption = "Sesso";
            this.colSessoCliente.FieldName = "SessoCliente";
            this.colSessoCliente.Name = "colSessoCliente";
            this.colSessoCliente.OptionsColumn.ReadOnly = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.search_16;
            this.simpleButton1.Location = new System.Drawing.Point(430, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Cerca";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(81, 12);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(345, 20);
            this.dateEdit1.StyleController = this.layoutControl1;
            this.dateEdit1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(680, 442);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dateEdit1;
            this.layoutControlItem1.CustomizationFormText = "Data di arrivo";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(418, 26);
            this.layoutControlItem1.Text = "Data di arrivo";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(418, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(110, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(660, 396);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(528, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(132, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // FrmArrivedPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 442);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmArrivedPersons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Persone arrivate";
            this.Load += new System.EventHandler(this.FrmArrivedPersons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivedPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource arrivedPersonBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colStanza;
        private DevExpress.XtraGrid.Columns.GridColumn colCognomeCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNomeCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNazioneCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colComuneCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colDataNascitaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNazionalitaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciaNascitaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colProvinciaNascitaSigla;
        private DevExpress.XtraGrid.Columns.GridColumn colComuneNascitaCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colIndirizzoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colCapCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colCellulare1Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn colCellulare2Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colFaxCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colMailCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumentoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNumeroDocumentoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colLuogoRilascioDocumentoCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colNoteCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colCodiceFiscaleCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colSessoCliente;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}