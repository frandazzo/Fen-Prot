namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class DocumentiClienteControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentiClienteControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriorityToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox5 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colNatureToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox6 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colContainsAttachments = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colScope = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContactList = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProtocol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cmdPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cmdPrintList = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Size = new System.Drawing.Size(819, 109);
            this.commandBar1.DelCommandPressed += new System.EventHandler(this.commandBar1_DelCommandPressed);
            this.commandBar1.NewCommandPressed += new System.EventHandler(this.commandBar1_NewCommandPressed);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.cmdPrint);
            this.layoutControl1.Controls.Add(this.cmdPrintList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 109);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(819, 310);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(24, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3,
            this.repositoryItemImageComboBox4,
            this.repositoryItemImageComboBox5,
            this.repositoryItemImageComboBox6});
            this.gridControl1.Size = new System.Drawing.Size(771, 216);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriorityToString,
            this.colNatureToString,
            this.colContainsAttachments,
            this.colScope,
            this.colSubject,
            this.colDate,
            this.colContactList,
            this.colOperator,
            this.colProtocol,
            this.colResponsable,
            this.colType});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Images = this.imageCollection1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText_1);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPriorityToString
            // 
            this.colPriorityToString.Caption = "Priorità";
            this.colPriorityToString.ColumnEdit = this.repositoryItemImageComboBox5;
            this.colPriorityToString.FieldName = "PriorityToString";
            this.colPriorityToString.Name = "colPriorityToString";
            this.colPriorityToString.OptionsColumn.AllowSize = false;
            this.colPriorityToString.OptionsColumn.FixedWidth = true;
            this.colPriorityToString.OptionsColumn.ShowCaption = false;
            this.colPriorityToString.OptionsFilter.AllowFilter = false;
            this.colPriorityToString.Visible = true;
            this.colPriorityToString.VisibleIndex = 0;
            this.colPriorityToString.Width = 30;
            // 
            // repositoryItemImageComboBox5
            // 
            this.repositoryItemImageComboBox5.AutoHeight = false;
            this.repositoryItemImageComboBox5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox5.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox5.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Normale", -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Alta", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Bassa", -1)});
            this.repositoryItemImageComboBox5.Name = "repositoryItemImageComboBox5";
            this.repositoryItemImageComboBox5.SmallImages = this.imageCollection1;
            // 
            // colNatureToString
            // 
            this.colNatureToString.Caption = "Tipo documento";
            this.colNatureToString.ColumnEdit = this.repositoryItemImageComboBox6;
            this.colNatureToString.FieldName = "NatureToString";
            this.colNatureToString.Name = "colNatureToString";
            this.colNatureToString.OptionsColumn.AllowSize = false;
            this.colNatureToString.OptionsColumn.FixedWidth = true;
            this.colNatureToString.OptionsColumn.ShowCaption = false;
            this.colNatureToString.OptionsFilter.AllowFilter = false;
            this.colNatureToString.Visible = true;
            this.colNatureToString.VisibleIndex = 1;
            this.colNatureToString.Width = 30;
            // 
            // repositoryItemImageComboBox6
            // 
            this.repositoryItemImageComboBox6.AutoHeight = false;
            this.repositoryItemImageComboBox6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox6.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Interno", 5),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "Esterno", 6)});
            this.repositoryItemImageComboBox6.Name = "repositoryItemImageComboBox6";
            this.repositoryItemImageComboBox6.SmallImages = this.imageCollection1;
            // 
            // colContainsAttachments
            // 
            this.colContainsAttachments.Caption = "Contiene allegati";
            this.colContainsAttachments.ColumnEdit = this.repositoryItemImageComboBox4;
            this.colContainsAttachments.FieldName = "ContainsAttachments";
            this.colContainsAttachments.Name = "colContainsAttachments";
            this.colContainsAttachments.OptionsColumn.AllowSize = false;
            this.colContainsAttachments.OptionsColumn.FixedWidth = true;
            this.colContainsAttachments.OptionsColumn.ShowCaption = false;
            this.colContainsAttachments.OptionsFilter.AllowFilter = false;
            this.colContainsAttachments.Visible = true;
            this.colContainsAttachments.VisibleIndex = 2;
            this.colContainsAttachments.Width = 30;
            // 
            // repositoryItemImageComboBox4
            // 
            this.repositoryItemImageComboBox4.AutoHeight = false;
            this.repositoryItemImageComboBox4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox4.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, -1)});
            this.repositoryItemImageComboBox4.Name = "repositoryItemImageComboBox4";
            this.repositoryItemImageComboBox4.SmallImages = this.imageCollection1;
            // 
            // colScope
            // 
            this.colScope.Caption = "Cartella";
            this.colScope.FieldName = "Scope";
            this.colScope.Name = "colScope";
            this.colScope.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colScope.Visible = true;
            this.colScope.VisibleIndex = 3;
            this.colScope.Width = 155;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Oggetto";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 4;
            this.colSubject.Width = 155;
            // 
            // colDate
            // 
            this.colDate.Caption = "Data";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 5;
            this.colDate.Width = 183;
            // 
            // colContactList
            // 
            this.colContactList.Caption = "Lista contatti";
            this.colContactList.FieldName = "ContactList";
            this.colContactList.Name = "colContactList";
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operatore";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            this.colOperator.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            // 
            // colProtocol
            // 
            this.colProtocol.Caption = "Protocollo";
            this.colProtocol.FieldName = "Protocol";
            this.colProtocol.Name = "colProtocol";
            // 
            // colResponsable
            // 
            this.colResponsable.Caption = "Responsabile";
            this.colResponsable.FieldName = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            // 
            // colType
            // 
            this.colType.Caption = "Causale";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "icons_44.gif");
            this.imageCollection1.Images.SetKeyName(1, "Status-mail-attachment-icon.png");
            this.imageCollection1.Images.SetKeyName(2, "icon-attachment-icon.png");
            this.imageCollection1.Images.SetKeyName(3, "imp-highbw.png");
            this.imageCollection1.Images.SetKeyName(4, "imp-high.png");
            this.imageCollection1.Images.SetKeyName(5, "Send Mail.png");
            this.imageCollection1.Images.SetKeyName(6, "Get Mail.png");
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Pianificato", "Pianificato", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("In_Scadenza", "In_Scadenza", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Scade_Oggi", "Scade_Oggi", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Scaduto", "Scaduto", 3),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Eseguito", "Eseguito", 4),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Concluso", "Concluso", 5)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Completata", "CompleteFlag", 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Urgente", "SuperRedFlag", 7),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Scade domani", "RedFlag", 8),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Scade prossimamente", "MinorRedFlag", 9),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Non urgente", "EmptyFlag", 14)});
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Priorità alta", "Alta", 12),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Priorità bassa", "Bassa", 13),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Priorità normale", "Normale", 15)});
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(382, 276);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(425, 22);
            this.cmdPrint.StyleController = this.layoutControl1;
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "&Stampa completa";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdPrintList
            // 
            this.cmdPrintList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrintList.Location = new System.Drawing.Point(12, 276);
            this.cmdPrintList.Name = "cmdPrintList";
            this.cmdPrintList.Size = new System.Drawing.Size(366, 22);
            this.cmdPrintList.StyleController = this.layoutControl1;
            this.cmdPrintList.TabIndex = 5;
            this.cmdPrintList.Text = "S&tampa lista";
            this.cmdPrintList.Click += new System.EventHandler(this.cmdPrintList_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(819, 310);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmdPrintList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 264);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(370, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmdPrint;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(370, 264);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(429, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Lista causali ";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(799, 264);
            this.layoutControlGroup2.Text = "Lista attività cliente";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(775, 220);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // DocumentiClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layoutControl1);
            this.Name = "DocumentiClienteControl";
            this.Size = new System.Drawing.Size(819, 419);
            this.Controls.SetChildIndex(this.commandBar1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton cmdPrint;
        private DevExpress.XtraEditors.SimpleButton cmdPrintList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPriorityToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox5;
        private DevExpress.XtraGrid.Columns.GridColumn colNatureToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox6;
        private DevExpress.XtraGrid.Columns.GridColumn colContainsAttachments;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox4;
        private DevExpress.XtraGrid.Columns.GridColumn colScope;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colContactList;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colProtocol;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}
