namespace WIN.SCHEDULING_APP.GUI.Controls.AdministrativeFunctions
{
    partial class ImpegniReportControl
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
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cboAnno = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.impegnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRegione = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTessereRichieste = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfeb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colapr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgiu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collug = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colott = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldic = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImpegnoTotale = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.cmdPrintList = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.simpleSeparator1 = new DevExpress.XtraLayout.SimpleSeparator();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.colgenas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfebas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmaras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colapras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmagas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgiuas = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboAnno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impegnoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomizationMenu = false;
            this.layoutControl1.Controls.Add(this.cboAnno);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.cmdPrintList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(804, 400);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cboAnno
            // 
            this.cboAnno.EditValue = "2012";
            this.cboAnno.Location = new System.Drawing.Point(52, 43);
            this.cboAnno.Name = "cboAnno";
            this.cboAnno.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cboAnno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAnno.Properties.Items.AddRange(new object[] {
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cboAnno.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboAnno.Size = new System.Drawing.Size(195, 20);
            this.cboAnno.StyleController = this.layoutControl1;
            this.cboAnno.TabIndex = 10;
            this.cboAnno.SelectedIndexChanged += new System.EventHandler(this.cboAnno_SelectedIndexChanged_1);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.impegnoBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(24, 114);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.repositoryItemImageComboBox3});
            this.gridControl1.Size = new System.Drawing.Size(756, 262);
            this.gridControl1.TabIndex = 7;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // impegnoBindingSource
            // 
            this.impegnoBindingSource.DataSource = typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.Amministrazione.Impegno);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRegione,
            this.colProvincia,
            this.colTessereRichieste,
            this.colRate,
            this.colgen,
            this.colfeb,
            this.colmar,
            this.colapr,
            this.colmag,
            this.colgiu,
            this.collug,
            this.colago,
            this.colset,
            this.colott,
            this.colnov,
            this.coldic,
            this.colalt,
            this.colImpegnoTotale,
            this.colgenas,
            this.colfebas,
            this.colmaras,
            this.colapras,
            this.colmagas,
            this.colgiuas});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.SummariesIgnoreNullValues = true;
            this.gridView1.OptionsDetail.AllowZoomDetail = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colRegione
            // 
            this.colRegione.Caption = "Regione";
            this.colRegione.FieldName = "Regione";
            this.colRegione.Name = "colRegione";
            this.colRegione.Visible = true;
            this.colRegione.VisibleIndex = 0;
            // 
            // colProvincia
            // 
            this.colProvincia.Caption = "Provincia";
            this.colProvincia.FieldName = "Provincia";
            this.colProvincia.Name = "colProvincia";
            this.colProvincia.Visible = true;
            this.colProvincia.VisibleIndex = 1;
            // 
            // colTessereRichieste
            // 
            this.colTessereRichieste.FieldName = "TessereRichieste";
            this.colTessereRichieste.Name = "colTessereRichieste";
            this.colTessereRichieste.Visible = true;
            this.colTessereRichieste.VisibleIndex = 2;
            // 
            // colRate
            // 
            this.colRate.Caption = "Rate";
            this.colRate.FieldName = "Rate";
            this.colRate.Name = "colRate";
            this.colRate.OptionsColumn.ReadOnly = true;
            // 
            // colgen
            // 
            this.colgen.Caption = "Gennaio";
            this.colgen.FieldName = "gen";
            this.colgen.Name = "colgen";
            this.colgen.Visible = true;
            this.colgen.VisibleIndex = 3;
            // 
            // colfeb
            // 
            this.colfeb.Caption = "Febbraio";
            this.colfeb.FieldName = "feb";
            this.colfeb.Name = "colfeb";
            this.colfeb.Visible = true;
            this.colfeb.VisibleIndex = 4;
            // 
            // colmar
            // 
            this.colmar.Caption = "Marzo";
            this.colmar.FieldName = "mar";
            this.colmar.Name = "colmar";
            this.colmar.Visible = true;
            this.colmar.VisibleIndex = 5;
            // 
            // colapr
            // 
            this.colapr.Caption = "Aprile";
            this.colapr.FieldName = "apr";
            this.colapr.Name = "colapr";
            this.colapr.Visible = true;
            this.colapr.VisibleIndex = 6;
            // 
            // colmag
            // 
            this.colmag.Caption = "Maggio";
            this.colmag.FieldName = "mag";
            this.colmag.Name = "colmag";
            this.colmag.Visible = true;
            this.colmag.VisibleIndex = 7;
            // 
            // colgiu
            // 
            this.colgiu.Caption = "Giugno";
            this.colgiu.FieldName = "giu";
            this.colgiu.Name = "colgiu";
            this.colgiu.Visible = true;
            this.colgiu.VisibleIndex = 8;
            // 
            // collug
            // 
            this.collug.Caption = "Luglio";
            this.collug.FieldName = "lug";
            this.collug.Name = "collug";
            this.collug.Visible = true;
            this.collug.VisibleIndex = 9;
            // 
            // colago
            // 
            this.colago.Caption = "Agosto";
            this.colago.FieldName = "ago";
            this.colago.Name = "colago";
            this.colago.Visible = true;
            this.colago.VisibleIndex = 10;
            // 
            // colset
            // 
            this.colset.Caption = "Settembre";
            this.colset.FieldName = "set";
            this.colset.Name = "colset";
            this.colset.Visible = true;
            this.colset.VisibleIndex = 11;
            // 
            // colott
            // 
            this.colott.Caption = "Ottobre";
            this.colott.FieldName = "ott";
            this.colott.Name = "colott";
            this.colott.Visible = true;
            this.colott.VisibleIndex = 12;
            // 
            // colnov
            // 
            this.colnov.Caption = "Novembre";
            this.colnov.FieldName = "nov";
            this.colnov.Name = "colnov";
            this.colnov.Visible = true;
            this.colnov.VisibleIndex = 13;
            // 
            // coldic
            // 
            this.coldic.Caption = "Dicembre";
            this.coldic.FieldName = "dic";
            this.coldic.Name = "coldic";
            this.coldic.Visible = true;
            this.coldic.VisibleIndex = 14;
            // 
            // colalt
            // 
            this.colalt.Caption = "Altre date";
            this.colalt.FieldName = "altreDate";
            this.colalt.Name = "colalt";
            this.colalt.Visible = true;
            this.colalt.VisibleIndex = 15;
            // 
            // colImpegnoTotale
            // 
            this.colImpegnoTotale.FieldName = "ImpegnoTotale";
            this.colImpegnoTotale.Name = "colImpegnoTotale";
            this.colImpegnoTotale.Visible = true;
            this.colImpegnoTotale.VisibleIndex = 16;
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
            // cmdPrintList
            // 
            this.cmdPrintList.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.print_16;
            this.cmdPrintList.Location = new System.Drawing.Point(318, 43);
            this.cmdPrintList.Name = "cmdPrintList";
            this.cmdPrintList.Size = new System.Drawing.Size(462, 22);
            this.cmdPrintList.StyleController = this.layoutControl1;
            this.cmdPrintList.TabIndex = 5;
            this.cmdPrintList.Text = "S&tampa impegni";
            this.cmdPrintList.Click += new System.EventHandler(this.cmdPrintList_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleSeparator1,
            this.layoutControlGroup2,
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(804, 400);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // simpleSeparator1
            // 
            this.simpleSeparator1.AllowHotTrack = false;
            this.simpleSeparator1.CustomizationFormText = "simpleSeparator1";
            this.simpleSeparator1.Location = new System.Drawing.Point(0, 69);
            this.simpleSeparator1.Name = "simpleSeparator1";
            this.simpleSeparator1.Size = new System.Drawing.Size(784, 2);
            this.simpleSeparator1.Text = "simpleSeparator1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "Report appuntamenti";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(784, 69);
            this.layoutControlGroup2.Text = "Report impegni di pagamento";
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(227, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(67, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmdPrintList;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(294, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(466, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cboAnno;
            this.layoutControlItem1.CustomizationFormText = "Anno rimesse";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(227, 26);
            this.layoutControlItem1.Text = "Anno";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(25, 13);
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "Risultati";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 71);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(784, 309);
            this.layoutControlGroup3.Text = "Risultati";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(760, 266);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // colgenas
            // 
            this.colgenas.Caption = "Gennaio A.S.";
            this.colgenas.FieldName = "genas";
            this.colgenas.Name = "colgenas";
            this.colgenas.Visible = true;
            this.colgenas.VisibleIndex = 17;
            // 
            // colfebas
            // 
            this.colfebas.Caption = "Febbraio A.S.";
            this.colfebas.FieldName = "febas";
            this.colfebas.Name = "colfebas";
            this.colfebas.Visible = true;
            this.colfebas.VisibleIndex = 18;
            // 
            // colmaras
            // 
            this.colmaras.Caption = "Marzo A.S.";
            this.colmaras.FieldName = "maras";
            this.colmaras.Name = "colmaras";
            this.colmaras.Visible = true;
            this.colmaras.VisibleIndex = 19;
            // 
            // colapras
            // 
            this.colapras.Caption = "Arpile A.S.";
            this.colapras.FieldName = "apras";
            this.colapras.Name = "colapras";
            this.colapras.Visible = true;
            this.colapras.VisibleIndex = 20;
            // 
            // colmagas
            // 
            this.colmagas.Caption = "Maggio A.S.";
            this.colmagas.FieldName = "magas";
            this.colmagas.Name = "colmagas";
            this.colmagas.Visible = true;
            this.colmagas.VisibleIndex = 21;
            // 
            // colgiuas
            // 
            this.colgiuas.Caption = "Giugno A.S.";
            this.colgiuas.FieldName = "giuas";
            this.colgiuas.Name = "colgiuas";
            this.colgiuas.Visible = true;
            this.colgiuas.VisibleIndex = 22;
            // 
            // ImpegniReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ImpegniReportControl";
            this.Size = new System.Drawing.Size(804, 400);
            this.Load += new System.EventHandler(this.ImpegniReportControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboAnno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impegnoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleSeparator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboAnno;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private DevExpress.XtraEditors.SimpleButton cmdPrintList;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.BindingSource impegnoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRegione;
        private DevExpress.XtraGrid.Columns.GridColumn colProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colTessereRichieste;
        private DevExpress.XtraGrid.Columns.GridColumn colRate;
        private DevExpress.XtraGrid.Columns.GridColumn colgen;
        private DevExpress.XtraGrid.Columns.GridColumn colfeb;
        private DevExpress.XtraGrid.Columns.GridColumn colmar;
        private DevExpress.XtraGrid.Columns.GridColumn colapr;
        private DevExpress.XtraGrid.Columns.GridColumn colmag;
        private DevExpress.XtraGrid.Columns.GridColumn colgiu;
        private DevExpress.XtraGrid.Columns.GridColumn collug;
        private DevExpress.XtraGrid.Columns.GridColumn colago;
        private DevExpress.XtraGrid.Columns.GridColumn colset;
        private DevExpress.XtraGrid.Columns.GridColumn colott;
        private DevExpress.XtraGrid.Columns.GridColumn colnov;
        private DevExpress.XtraGrid.Columns.GridColumn coldic;
        private DevExpress.XtraGrid.Columns.GridColumn colalt;
        private DevExpress.XtraGrid.Columns.GridColumn colImpegnoTotale;
        private DevExpress.XtraGrid.Columns.GridColumn colgenas;
        private DevExpress.XtraGrid.Columns.GridColumn colfebas;
        private DevExpress.XtraGrid.Columns.GridColumn colmaras;
        private DevExpress.XtraGrid.Columns.GridColumn colapras;
        private DevExpress.XtraGrid.Columns.GridColumn colmagas;
        private DevExpress.XtraGrid.Columns.GridColumn colgiuas;
    }
}
