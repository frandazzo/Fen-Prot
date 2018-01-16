namespace WIN.SCHEDULING_APP.GUI.Reports
{
    partial class BookingCalendarReport
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookingCalendarReport));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.verticalResourceHeaders1 = new DevExpress.XtraScheduler.Reporting.VerticalResourceHeaders();
            this.timelineCells1 = new DevExpress.XtraScheduler.Reporting.TimelineCells();
            this.reportTimelineView1 = new DevExpress.XtraScheduler.Reporting.ReportTimelineView();
            this.timelineScaleHeaders1 = new DevExpress.XtraScheduler.Reporting.TimelineScaleHeaders();
            this.calendarControl1 = new DevExpress.XtraScheduler.Reporting.CalendarControl();
            this.timeIntervalInfo1 = new DevExpress.XtraScheduler.Reporting.TimeIntervalInfo();
            this.schedulerControlPrintAdapter1 = new DevExpress.XtraScheduler.Reporting.SchedulerControlPrintAdapter();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.reportTimelineView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControlPrintAdapter1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.verticalResourceHeaders1,
            this.timelineScaleHeaders1,
            this.timelineCells1,
            this.calendarControl1,
            this.timeIntervalInfo1});
            this.Detail.HeightF = 650.0418F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand;
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // verticalResourceHeaders1
            // 
            this.verticalResourceHeaders1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 192.625F);
            this.verticalResourceHeaders1.Name = "verticalResourceHeaders1";
            this.verticalResourceHeaders1.Options.ImageAlign = DevExpress.XtraScheduler.HeaderImageAlign.Bottom;
            this.verticalResourceHeaders1.Options.ImageSize = new System.Drawing.Size(15, 15);
            this.verticalResourceHeaders1.Options.ImageSizeMode = DevExpress.XtraScheduler.HeaderImageSizeMode.StretchImage;
            this.verticalResourceHeaders1.Options.RotateCaption = false;
            this.verticalResourceHeaders1.SizeF = new System.Drawing.SizeF(87.29163F, 431.3753F);
            this.verticalResourceHeaders1.TimeCells = this.timelineCells1;
            this.verticalResourceHeaders1.View = this.reportTimelineView1;
            // 
            // timelineCells1
            // 
            this.timelineCells1.AppointmentDisplayOptions.AppointmentAutoHeight = true;
            this.timelineCells1.CanGrow = true;
            this.timelineCells1.LocationFloat = new DevExpress.Utils.PointFloat(87.29163F, 192.625F);
            this.timelineCells1.Name = "timelineCells1";
            this.timelineCells1.SizeF = new System.Drawing.SizeF(871.7084F, 431.3752F);
            this.timelineCells1.View = this.reportTimelineView1;
            this.timelineCells1.InitAppointmentImages += new DevExpress.XtraScheduler.AppointmentImagesEventHandler(this.timelineCells1_InitAppointmentImages);
            this.timelineCells1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.timelineCells1_CustomDrawAppointmentBackground);
            // 
            // reportTimelineView1
            // 
            this.reportTimelineView1.VisibleIntervalCount = 7;
            this.reportTimelineView1.VisibleResourceCount = 10;
            // 
            // timelineScaleHeaders1
            // 
            this.timelineScaleHeaders1.LocationFloat = new DevExpress.Utils.PointFloat(87.29163F, 140.625F);
            this.timelineScaleHeaders1.Name = "timelineScaleHeaders1";
            this.timelineScaleHeaders1.SizeF = new System.Drawing.SizeF(871.7084F, 52F);
            this.timelineScaleHeaders1.View = this.reportTimelineView1;
            // 
            // calendarControl1
            // 
            this.calendarControl1.LocationFloat = new DevExpress.Utils.PointFloat(558.25F, 0F);
            this.calendarControl1.Name = "calendarControl1";
            this.calendarControl1.SizeF = new System.Drawing.SizeF(400.75F, 140.625F);
            this.calendarControl1.TimeCells = this.timelineCells1;
            this.calendarControl1.View = this.reportTimelineView1;
            // 
            // timeIntervalInfo1
            // 
            this.timeIntervalInfo1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.timeIntervalInfo1.Name = "timeIntervalInfo1";
            this.timeIntervalInfo1.SizeF = new System.Drawing.SizeF(371.875F, 102.5F);
            this.timeIntervalInfo1.TimeCells = this.timelineCells1;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "planned.png");
            this.imageCollection1.Images.SetKeyName(1, "deadline.png");
            this.imageCollection1.Images.SetKeyName(2, "deadtoday.png");
            this.imageCollection1.Images.SetKeyName(3, "dead.png");
            this.imageCollection1.Images.SetKeyName(4, "executed.png");
            this.imageCollection1.Images.SetKeyName(5, "closed.png");
            // 
            // BookingCalendarReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.Landscape = true;
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.SchedulerAdapter = this.schedulerControlPrintAdapter1;
            this.Version = "11.1";
            this.Views.AddRange(new DevExpress.XtraScheduler.Reporting.ReportViewBase[] {
            this.reportTimelineView1});
            ((System.ComponentModel.ISupportInitialize)(this.reportTimelineView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControlPrintAdapter1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraScheduler.Reporting.ReportTimelineView reportTimelineView1;
        private DevExpress.XtraScheduler.Reporting.SchedulerControlPrintAdapter schedulerControlPrintAdapter1;
        private DevExpress.XtraScheduler.Reporting.VerticalResourceHeaders verticalResourceHeaders1;
        private DevExpress.XtraScheduler.Reporting.TimelineCells timelineCells1;
        private DevExpress.XtraScheduler.Reporting.TimelineScaleHeaders timelineScaleHeaders1;
        private DevExpress.XtraScheduler.Reporting.CalendarControl calendarControl1;
        private DevExpress.XtraScheduler.Reporting.TimeIntervalInfo timeIntervalInfo1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}
