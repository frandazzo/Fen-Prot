namespace WIN.SCHEDULING_APP.GUI.Controls
{
    partial class BookingPaymentStats
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.paymentStatisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fieldIncasso1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldDaIncassare1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldAnno1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldMese1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldOperatore1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.fieldTipoPrenotazione1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentStatisticsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // commandBar1
            // 
            this.commandBar1.Size = new System.Drawing.Size(888, 109);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.simpleButton2);
            this.layoutControl1.Controls.Add(this.pivotGridControl1);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.comboBoxEdit1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(888, 475);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(888, 475);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(154, 12);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
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
            "2020"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(544, 20);
            this.comboBoxEdit1.StyleController = this.layoutControl1;
            this.comboBoxEdit1.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.comboBoxEdit1;
            this.layoutControlItem1.CustomizationFormText = "Seleziona anno di riferimento";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(690, 26);
            this.layoutControlItem1.Text = "Seleziona anno di riferimento";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(138, 13);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.print_16;
            this.simpleButton1.Location = new System.Drawing.Point(767, 12);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(109, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Esporta su excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.simpleButton1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(755, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(113, 26);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.DataSource = this.paymentStatisticsBindingSource;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.fieldIncasso1,
            this.fieldDaIncassare1,
            this.fieldAnno1,
            this.fieldMese1,
            this.fieldOperatore1,
            this.fieldTipoPrenotazione1});
            this.pivotGridControl1.Location = new System.Drawing.Point(12, 38);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(864, 425);
            this.pivotGridControl1.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pivotGridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(868, 429);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // paymentStatisticsBindingSource
            // 
            this.paymentStatisticsBindingSource.DataSource = typeof(WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.PaymentStatistics);
            // 
            // fieldIncasso1
            // 
            this.fieldIncasso1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldIncasso1.AreaIndex = 0;
            this.fieldIncasso1.Caption = "Incasso";
            this.fieldIncasso1.CellFormat.FormatString = "C2";
            this.fieldIncasso1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldIncasso1.FieldName = "Incasso";
            this.fieldIncasso1.Name = "fieldIncasso1";
            // 
            // fieldDaIncassare1
            // 
            this.fieldDaIncassare1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldDaIncassare1.AreaIndex = 1;
            this.fieldDaIncassare1.Caption = "Da Incassare";
            this.fieldDaIncassare1.CellFormat.FormatString = "C2";
            this.fieldDaIncassare1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.fieldDaIncassare1.FieldName = "DaIncassare";
            this.fieldDaIncassare1.Name = "fieldDaIncassare1";
            // 
            // fieldAnno1
            // 
            this.fieldAnno1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldAnno1.AreaIndex = 0;
            this.fieldAnno1.Caption = "Anno";
            this.fieldAnno1.FieldName = "Anno";
            this.fieldAnno1.Name = "fieldAnno1";
            // 
            // fieldMese1
            // 
            this.fieldMese1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldMese1.AreaIndex = 1;
            this.fieldMese1.Caption = "Mese";
            this.fieldMese1.FieldName = "Mese";
            this.fieldMese1.Name = "fieldMese1";
            // 
            // fieldOperatore1
            // 
            this.fieldOperatore1.AreaIndex = 0;
            this.fieldOperatore1.Caption = "Operatore";
            this.fieldOperatore1.FieldName = "Operatore";
            this.fieldOperatore1.Name = "fieldOperatore1";
            // 
            // fieldTipoPrenotazione1
            // 
            this.fieldTipoPrenotazione1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldTipoPrenotazione1.AreaIndex = 0;
            this.fieldTipoPrenotazione1.Caption = "Tipo Prenotazione";
            this.fieldTipoPrenotazione1.FieldName = "TipoPrenotazione";
            this.fieldTipoPrenotazione1.Name = "fieldTipoPrenotazione1";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = global::WIN.SCHEDULING_APP.GUI.Properties.Resources.search_16;
            this.simpleButton2.Location = new System.Drawing.Point(702, 12);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(61, 22);
            this.simpleButton2.StyleController = this.layoutControl1;
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Esegui";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.simpleButton2;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(690, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(65, 26);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // BookingPaymentStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.layoutControl1);
            this.Name = "BookingPaymentStats";
            this.Size = new System.Drawing.Size(888, 475);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            this.Controls.SetChildIndex(this.commandBar1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentStatisticsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private System.Windows.Forms.BindingSource paymentStatisticsBindingSource;
        private DevExpress.XtraPivotGrid.PivotGridField fieldIncasso1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldDaIncassare1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldAnno1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldMese1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldOperatore1;
        private DevExpress.XtraPivotGrid.PivotGridField fieldTipoPrenotazione1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}
