using System;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WIN.SCHEDULING_APP.GUI.Reports
{
    public partial class BookingCalendarReport : DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
    {
        public BookingCalendarReport()
        {
            InitializeComponent();
        }

        private void timelineCells1_InitAppointmentImages(object sender, DevExpress.XtraScheduler.AppointmentImagesEventArgs e)
        {
            Appointment apt = e.Appointment;
            Assignment ass = apt.GetSourceObject(this.schedulerControlPrintAdapter1.SchedulerControl.Storage ) as Assignment ;
            AppointmentImageInfoCollection c = e.ImageInfoList;

            c.Clear();
            c.Images = imageCollection1 ;

            AddImageByIndex(c, SelectImage(ass));


            if (ass.CheckedIn)
            {
                AppointmentImageInfo info1 = new AppointmentImageInfo();
                info1.Image = Properties.Resources.Lock_Lock_icon16;
                //AppointmentImageInfo info1 = new AppointmentImageInfo();
                //info1.Image = Properties.Resources.openHS;
                c.Add(info1);
            }

        }

        private int SelectImage(Assignment a)
        {
            BookingState state = a.Booking.State;
            switch (state)
            {
                case BookingState.NotConfirmed:
                    return 1;


                case BookingState.ConfirmedWithAccont:
                    return 5;


                case BookingState.ConfimedWithoutAccount:
                    return 4;


                case BookingState.Closed:
                    return 0;


                default:
                    return 0;

            }
        }

        void AddImageByIndex(AppointmentImageInfoCollection c, int index)
        {
            AppointmentImageInfo info = new AppointmentImageInfo();
            info.ImageIndex = index;
            c.Add(info);
        }

        private void timelineCells1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            e.DrawDefault();
            AppointmentViewInfo vi = (AppointmentViewInfo)e.ObjectInfo;
            Appointment apt = vi.Appointment;

            Assignment ass = apt.GetSourceObject(this.schedulerControlPrintAdapter1.SchedulerControl.Storage ) as Assignment ;

            //vi.Appearance.BackColor = Color.FromArgb(ass.Booking.Color);
           
            Rectangle rect = vi.Bounds;
            rect.Inflate(-vi.LeftBorderBounds.Width, -vi.TopBorderBounds.Height);

            Brush brush = e.Cache.GetGradientBrush(rect, Color.FromArgb(ass.Booking.Color), Color.FromArgb(ass.Booking.Color), LinearGradientMode.Vertical);
            e.Cache.FillRectangle(brush, rect);
           // e.Handled = true;

            e.Handled = ass.Booking.ColorBookings;

        }
    }
}
