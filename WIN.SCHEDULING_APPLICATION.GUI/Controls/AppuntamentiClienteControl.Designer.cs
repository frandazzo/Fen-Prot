namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class AppuntamentiClienteControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppuntamentiClienteControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.myAppointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStateToString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsClosed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperator = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcomeDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcomeDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutcomeCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysBeforeDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDaysAfterDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.myAppointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Size = new System.Drawing.Size(749, 109);
            this.commandBar1.DelCommandPressed += new System.EventHandler(this.commandBar1_DelCommandPressed);
            this.commandBar1.NewCommandPressed += new System.EventHandler(this.commandBar1_NewCommandPressed);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.cmdPrint);
            this.layoutControl1.Controls.Add(this.cmdPrintList);
            this.layoutControl1.Location = new System.Drawing.Point(3, 115);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(583, 285, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(749, 423);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.myAppointmentBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(31, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(694, 329);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // myAppointmentBindingSource
            // 
            this.myAppointmentBindingSource.DataSource = typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.MyAppointment);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStateToString,
            this.colStartDate,
            this.colSubject,
            this.colLabel,
            this.colResource,
            this.colLocation,
            this.colIsClosed,
            this.colCustomer,
            this.colDescription,
            this.colEndDate,
            this.colOperator,
            this.colOutcome,
            this.colOutcomeDate,
            this.colOutcomeDescription,
            this.colId,
            this.colOutcomeCreated,
            this.colDaysBeforeDeadline,
            this.colDaysAfterDeadline});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Images = this.imageCollection1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colStateToString
            // 
            this.colStateToString.Caption = "Stato";
            this.colStateToString.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStateToString.FieldName = "StateToString";
            this.colStateToString.Name = "colStateToString";
            this.colStateToString.Visible = true;
            this.colStateToString.VisibleIndex = 0;
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
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "planned16.png");
            this.imageCollection1.Images.SetKeyName(1, "deadline16.png");
            this.imageCollection1.Images.SetKeyName(2, "deadtoday16.png");
            this.imageCollection1.Images.SetKeyName(3, "dead16.png");
            this.imageCollection1.Images.SetKeyName(4, "executed16.png");
            this.imageCollection1.Images.SetKeyName(5, "closed16.png");
            // 
            // colStartDate
            // 
            this.colStartDate.Caption = "Data inizio";
            this.colStartDate.DisplayFormat.FormatString = "g";
            this.colStartDate.FieldName = "StartDate";
            this.colStartDate.Name = "colStartDate";
            this.colStartDate.Visible = true;
            this.colStartDate.VisibleIndex = 1;
            // 
            // colSubject
            // 
            this.colSubject.Caption = "Oggetto";
            this.colSubject.FieldName = "Subject";
            this.colSubject.Name = "colSubject";
            this.colSubject.Visible = true;
            this.colSubject.VisibleIndex = 2;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Causale";
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 3;
            // 
            // colResource
            // 
            this.colResource.Caption = "Zona";
            this.colResource.FieldName = "Resource";
            this.colResource.Name = "colResource";
            this.colResource.Visible = true;
            this.colResource.VisibleIndex = 4;
            // 
            // colLocation
            // 
            this.colLocation.Caption = "Luogo";
            this.colLocation.FieldName = "Location";
            this.colLocation.Name = "colLocation";
            // 
            // colIsClosed
            // 
            this.colIsClosed.Caption = "Impegno concluso";
            this.colIsClosed.FieldName = "IsClosed";
            this.colIsClosed.Name = "colIsClosed";
            // 
            // colCustomer
            // 
            this.colCustomer.Caption = "Cliente";
            this.colCustomer.FieldName = "Customer";
            this.colCustomer.Name = "colCustomer";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Note";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colEndDate
            // 
            this.colEndDate.Caption = "Data fine";
            this.colEndDate.DisplayFormat.FormatString = "g";
            this.colEndDate.FieldName = "EndDate";
            this.colEndDate.Name = "colEndDate";
            // 
            // colOperator
            // 
            this.colOperator.Caption = "Operatore";
            this.colOperator.FieldName = "Operator";
            this.colOperator.Name = "colOperator";
            // 
            // colOutcome
            // 
            this.colOutcome.Caption = "Esito";
            this.colOutcome.FieldName = "Outcome";
            this.colOutcome.Name = "colOutcome";
            // 
            // colOutcomeDate
            // 
            this.colOutcomeDate.Caption = "Data rapporto";
            this.colOutcomeDate.DisplayFormat.FormatString = "g";
            this.colOutcomeDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOutcomeDate.FieldName = "OutcomeDate";
            this.colOutcomeDate.Name = "colOutcomeDate";
            // 
            // colOutcomeDescription
            // 
            this.colOutcomeDescription.Caption = "Note rapporto";
            this.colOutcomeDescription.FieldName = "OutcomeDescription";
            this.colOutcomeDescription.Name = "colOutcomeDescription";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colOutcomeCreated
            // 
            this.colOutcomeCreated.Caption = "Rapporto creato";
            this.colOutcomeCreated.FieldName = "OutcomeCreated";
            this.colOutcomeCreated.Name = "colOutcomeCreated";
            // 
            // colDaysBeforeDeadline
            // 
            this.colDaysBeforeDeadline.Caption = "Giorni alla scadenza";
            this.colDaysBeforeDeadline.FieldName = "DaysBeforeDeadline";
            this.colDaysBeforeDeadline.Name = "colDaysBeforeDeadline";
            // 
            // colDaysAfterDeadline
            // 
            this.colDaysAfterDeadline.Caption = "Giorni dalla scadenza";
            this.colDaysAfterDeadline.FieldName = "DaysAfterDeadline";
            this.colDaysAfterDeadline.Name = "colDaysAfterDeadline";
            // 
            // cmdPrint
            // 
            this.cmdPrint.Location = new System.Drawing.Point(351, 389);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(386, 22);
            this.cmdPrint.StyleController = this.layoutControl1;
            this.cmdPrint.TabIndex = 6;
            this.cmdPrint.Text = "&Stampa completa";
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdPrintList
            // 
            this.cmdPrintList.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdPrintList.Location = new System.Drawing.Point(12, 389);
            this.cmdPrintList.Name = "cmdPrintList";
            this.cmdPrintList.Size = new System.Drawing.Size(335, 22);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(749, 423);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmdPrintList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 377);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(339, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmdPrint;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(339, 377);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(390, 26);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(729, 377);
            this.layoutControlGroup2.Text = "Lista appuntamenti cliente";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = " ";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(705, 333);
            this.layoutControlItem4.Text = " ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(3, 13);
            // 
            // AppuntamentiClienteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layoutControl1);
            this.Name = "AppuntamentiClienteControl";
            this.Size = new System.Drawing.Size(749, 535);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.commandBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myAppointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton cmdPrint;
        private DevExpress.XtraEditors.SimpleButton cmdPrintList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource myAppointmentBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSubject;
        private DevExpress.XtraGrid.Columns.GridColumn colLocation;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn colIsClosed;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraGrid.Columns.GridColumn colOperator;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcome;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcomeDate;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcomeDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colResource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colOutcomeCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colStateToString;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysBeforeDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colDaysAfterDeadline;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;

    }
}
