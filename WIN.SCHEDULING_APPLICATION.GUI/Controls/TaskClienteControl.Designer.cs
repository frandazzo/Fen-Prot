namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class TaskClienteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskClienteControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.myTaskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPriorityToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivityStateToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentageCompleteness = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcomeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutlookDeadLineStateToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colActivityDeadlineStateToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colOutcomeDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysAfterDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysBeforeDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeadlineNotes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelContatti = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiscale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCell1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCell2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContatti = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmdPrint = new DevExpress.XtraEditors.SimpleButton();
            this.cmdPrintList = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTaskBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Size = new System.Drawing.Size(830, 109);
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
            this.layoutControl1.Size = new System.Drawing.Size(830, 308);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.myTaskBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.gridControl1.Size = new System.Drawing.Size(782, 214);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // myTaskBindingSource
            // 
            this.myTaskBindingSource.DataSource = typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.MyTask);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPriorityToString,
            this.colSubject,
            this.colActivityStateToString,
            this.colPercentageCompleteness,
            this.colStartDate,
            this.colEndDate,
            this.colCustomer,
            this.colOutcomeDate,
            this.colOutlookDeadLineStateToString,
            this.colActivityDeadlineStateToString,
            this.colOutcomeDescription,
            this.colDaysAfterDeadline,
            this.colDaysBeforeDeadline,
            this.colDeadlineNotes,
            this.colDescription,
            this.colTelContatti,
            this.colFiscale,
            this.colCell1,
            this.colCell2,
            this.colContatti,
            this.colOutcome});
            this.gridView1.GridControl = this.gridControl1;
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
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colPriorityToString
            // 
            this.colPriorityToString.ColumnEdit = this.repositoryItemImageComboBox3;
            this.colPriorityToString.FieldName = "PriorityToString";
            this.colPriorityToString.MinWidth = 10;
            this.colPriorityToString.Name = "colPriorityToString";
            this.colPriorityToString.OptionsColumn.AllowSize = false;
            this.colPriorityToString.OptionsColumn.ShowCaption = false;
            this.colPriorityToString.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colPriorityToString.Visible = true;
            this.colPriorityToString.VisibleIndex = 0;
            this.colPriorityToString.Width = 18;
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
            this.repositoryItemImageComboBox3.SmallImages = this.imageCollection1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "planned16.png");
            this.imageCollection1.Images.SetKeyName(1, "deadline16.png");
            this.imageCollection1.Images.SetKeyName(2, "deadtoday16.png");
            this.imageCollection1.Images.SetKeyName(3, "dead16.png");
            this.imageCollection1.Images.SetKeyName(4, "executed16.png");
            this.imageCollection1.Images.SetKeyName(5, "closed16.png");
            this.imageCollection1.Images.SetKeyName(6, "flg-compl.png");
            this.imageCollection1.Images.SetKeyName(7, "flag1.png");
            this.imageCollection1.Images.SetKeyName(8, "flag2.png");
            this.imageCollection1.Images.SetKeyName(9, "flag3.png");
            this.imageCollection1.Images.SetKeyName(10, "flag4.png");
            this.imageCollection1.Images.SetKeyName(11, "flag_empty1.png");
            this.imageCollection1.Images.SetKeyName(12, "imp-high.png");
            this.imageCollection1.Images.SetKeyName(13, "imp-low.png");
            this.imageCollection1.Images.SetKeyName(14, "flag_16.png");
            this.imageCollection1.Images.SetKeyName(15, "imp-norm1.png");
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Oggetto";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Like;
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 1;
            this.colSubject.Width = 100;
            // 
            // colActivityStateToString
            // 
            this.colActivityStateToString.Caption = "Stato";
            this.colActivityStateToString.FieldName = "ActivityStateToString";
            this.colActivityStateToString.Name = "colActivityStateToString";
            this.colActivityStateToString.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colActivityStateToString.Visible = true;
            this.colActivityStateToString.VisibleIndex = 2;
            this.colActivityStateToString.Width = 47;
            // 
            // colPercentageCompleteness
            // 
            this.colPercentageCompleteness.Caption = "% Completata";
            this.colPercentageCompleteness.FieldName = "PercentageCompleteness";
            this.colPercentageCompleteness.Name = "colPercentageCompleteness";
            this.colPercentageCompleteness.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colPercentageCompleteness.Visible = true;
            this.colPercentageCompleteness.VisibleIndex = 3;
            this.colPercentageCompleteness.Width = 57;
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "Data inizio";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 4;
            this.colStartDate.Width = 99;
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "Data fine";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            this.colEndDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colEndDate.Visible = true;
            this.colEndDate.VisibleIndex = 5;
            this.colEndDate.Width = 99;
            // 
            // colCustomer
            // 
            this.colCustomer.Caption = "Contatto";
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colCustomer.Visible = true;
            this.colCustomer.VisibleIndex = 6;
            this.colCustomer.Width = 107;
            // 
            // colOutcomeDate
            // 
            this.colOutcomeDate.Caption = "Data completamento";
            this.colOutcomeDate.FieldName = "OutcomeDate";
            this.colOutcomeDate.Name = "colOutcomeDate";
            this.colOutcomeDate.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.DateSmart;
            this.colOutcomeDate.OptionsFilter.ShowEmptyDateFilter = true;
            this.colOutcomeDate.Visible = true;
            this.colOutcomeDate.VisibleIndex = 7;
            this.colOutcomeDate.Width = 60;
            // 
            // colOutlookDeadLineStateToString
            // 
            this.colOutlookDeadLineStateToString.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colOutlookDeadLineStateToString.FieldName = "OutlookDeadLineStateToString";
            this.colOutlookDeadLineStateToString.MinWidth = 10;
            this.colOutlookDeadLineStateToString.Name = "colOutlookDeadLineStateToString";
            this.colOutlookDeadLineStateToString.OptionsColumn.AllowSize = false;
            this.colOutlookDeadLineStateToString.OptionsColumn.ShowCaption = false;
            this.colOutlookDeadLineStateToString.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colOutlookDeadLineStateToString.ToolTip = "Urgenza: indica le attività più critiche";
            this.colOutlookDeadLineStateToString.Visible = true;
            this.colOutlookDeadLineStateToString.VisibleIndex = 8;
            this.colOutlookDeadLineStateToString.Width = 15;
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
            this.repositoryItemImageComboBox2.SmallImages = this.imageCollection1;
            // 
            // colActivityDeadlineStateToString
            // 
            this.colActivityDeadlineStateToString.AppearanceHeader.Options.UseImage = true;
            this.colActivityDeadlineStateToString.Caption = "Scadenza";
            this.colActivityDeadlineStateToString.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colActivityDeadlineStateToString.FieldName = "ActivityDeadlineStateToString";
            this.colActivityDeadlineStateToString.Name = "colActivityDeadlineStateToString";
            this.colActivityDeadlineStateToString.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.colActivityDeadlineStateToString.Width = 60;
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
            this.repositoryItemImageComboBox1.SmallImages = this.imageCollection1;
            // 
            // colOutcomeDescription
            // 
            this.colOutcomeDescription.Caption = "Note finali";
            this.colOutcomeDescription.FieldName = "OutcomeDescription";
            this.colOutcomeDescription.Name = "colOutcomeDescription";
            // 
            // colDaysAfterDeadline
            // 
            this.colDaysAfterDeadline.Caption = "Giorni dalla scadenza";
            this.colDaysAfterDeadline.FieldName = "DaysAfterDeadline";
            this.colDaysAfterDeadline.Name = "colDaysAfterDeadline";
            // 
            // colDaysBeforeDeadline
            // 
            this.colDaysBeforeDeadline.Caption = "Giorni alla scadenza";
            this.colDaysBeforeDeadline.FieldName = "DaysBeforeDeadline";
            this.colDaysBeforeDeadline.Name = "colDaysBeforeDeadline";
            // 
            // colDeadlineNotes
            // 
            this.colDeadlineNotes.Caption = "Resoconto";
            this.colDeadlineNotes.FieldName = "DeadlineNotes";
            this.colDeadlineNotes.Name = "colDeadlineNotes";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Note";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colTelContatti
            // 
            this.colTelContatti.Caption = "Telefono";
            this.colTelContatti.Name = "colTelContatti";
            // 
            // colFiscale
            // 
            this.colFiscale.Caption = "Codice fiscale";
            this.colFiscale.Name = "colFiscale";
            // 
            // colCell1
            // 
            this.colCell1.Caption = "Cellulare1 contatto";
            this.colCell1.Name = "colCell1";
            // 
            // colCell2
            // 
            this.colCell2.Caption = "Cellulare2 contatto";
            this.colCell2.Name = "colCell2";
            // 
            // colContatti
            // 
            this.colContatti.Caption = "Indirizzo";
            this.colContatti.Name = "colContatti";
            // 
            // colOutcome
            // 
            this.colOutcome.Caption = "Esito";
            this.colOutcome.FieldName = "Outcome";
            this.colOutcome.Name = "colOutcome";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(387, 274);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(431, 22);
            this.cmdPrint.StyleController = this.layoutControl1;
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "&Stampa completa";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdPrintList
            // 
            this.cmdPrintList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrintList.Location = new System.Drawing.Point(12, 274);
            this.cmdPrintList.Name = "cmdPrintList";
            this.cmdPrintList.Size = new System.Drawing.Size(371, 22);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(830, 308);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmdPrintList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 262);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(375, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmdPrint;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(375, 262);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(435, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Lista causali ";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(810, 262);
            this.layoutControlGroup2.Text = "Lista attività contatto";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(786, 218);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // TaskClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layoutControl1);
            this.Name = "TaskClienteControl";
            this.Size = new System.Drawing.Size(830, 417);
            this.Controls.SetChildIndex(this.commandBar1, 0);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myTaskBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
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
        private System.Windows.Forms.BindingSource myTaskBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPriorityToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityStateToString;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentageCompleteness;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcomeDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOutlookDeadLineStateToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colActivityDeadlineStateToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcomeDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysAfterDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysBeforeDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colDeadlineNotes;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colTelContatti;
        private DevExpress.XtraGrid.Columns.GridColumn colFiscale;
        private DevExpress.XtraGrid.Columns.GridColumn colCell1;
        private DevExpress.XtraGrid.Columns.GridColumn colCell2;
        private DevExpress.XtraGrid.Columns.GridColumn colContatti;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcome;
    }
}
