using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APPLICATION.HANDLERS.Booking;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APP.GUI.Controls.CustomBookingFormAssets;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.SCHEDULING_APPLICATION.DOMAIN.Booking;
using WIN.BASEREUSE;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;
using WIN.SCHEDULING_APP.GUI.Reports;
using WIN.SCHEDULING_APP.GUI.Forms;
using WIN.TECHNICAL.PERSISTENCE;
using DevExpress.XtraReports.UI;
namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext()]
    public partial class BookingControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
  

        TimeInterval lastFetchedInterval = new TimeInterval();
        bool _initializing = false;
    

     

        public BookingControl(MainForm form)
            : base(form)
        {

            try
            {

                DataAccessServices.Instance().PersistenceFacade.EmptyCacheAll();

                _initializing = true;

                InitializeComponent();

               
                

                schedulerStorage1.FetchAppointments +=new FetchAppointmentsEventHandler(schedulerStorage1_FetchAppointments);

                CustomGUI_SetCommandBarVisibility(false);
                //non permetto nessuna operazione dalla toolbar
                base.m_ChangeStateEnabled = false;
                schedulerControl1.Start = DateTime.Now;
                schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;


                BookingResourceHandler h = new BookingResourceHandler();
                schedulerStorage1.Resources.DataSource = h.GetAll();


                ////imposto il raggruppamento del calendario
                //if (Properties.Settings.Default.Main_CalendarGroupType == 0)
                //{
                //    schedulerControl1.GroupType = SchedulerGroupType.None;
                //    comboBoxEdit1.SelectedIndex = 0;
                //}
                //else if (Properties.Settings.Default.Main_CalendarGroupType == 1)
                //{
                //    schedulerControl1.GroupType = SchedulerGroupType.Date;
                //    comboBoxEdit1.SelectedIndex = 1;
                //}
                //else if (Properties.Settings.Default.Main_CalendarGroupType == 2)
                //{
                    schedulerControl1.GroupType = SchedulerGroupType.Resource;
                   // comboBoxEdit1.SelectedIndex = 2;
                //}
                //else
                //{
                //    schedulerControl1.GroupType = SchedulerGroupType.None;
                //    comboBoxEdit1.SelectedIndex = 0;
                //}

                    if (Properties.Settings.Default.Main_ZoomTemporale != 0)
                    {
                        schedulerControl1.TimelineView.GetBaseTimeScale().Width = Properties.Settings.Default.Main_ZoomTemporale;
                        trackBarControl1.Value = Properties.Settings.Default.Main_ZoomTemporale;
                    }

                    if (Properties.Settings.Default.Main_ZoomSpaziale != 0)
                    {
                        schedulerControl1.TimelineView.AppointmentDisplayOptions.AppointmentHeight = Properties.Settings.Default.Main_ZoomSpaziale;
                        trackBarControl2.Value = Properties.Settings.Default.Main_ZoomSpaziale;
                    }

            }
            finally
            {
                _initializing = false;
            }
            
        }



        private void schedulerStorage1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            ///////*****************************
            ///////*****************************
            //gets the newly created Devexpress appointment;
            Appointment app = e.Objects[0] as Appointment;


            //*********************************************************
            //questo codice è inserito per risolvere il problema dell'assegnazione della risorsa 
            //dopo il grag drop
            DevExpress.XtraScheduler.Resource ee = app.ResourceId as DevExpress.XtraScheduler.Resource;
            //questa situazione si verifica quando lo scheduler non è stato in grado
            //di assegnare una risorsa all'appuntamento creato nella funzione GetDragData
            //e pertanto assegna la risorsa "All" all'appuntamento
            //if (ee != null)
            //{
            //    Customer ccc = app.GetValue(schedulerStorage1, "Customer") as Customer;
            //    if (ccc != null)
            //    {
            //        app.SetValue(schedulerStorage1, "Resource", ccc.Resource);
            //        app.ResourceId = ccc.Resource.Id;
            //    }
            //    else
            //    {
            //        WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource t = new ResourceHandler().GetAll()[0] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
            //        app.SetValue(schedulerStorage1, "Resource", t);
            //        app.ResourceId = t.Id;
            //    }
            //}
            //else
            //{
                app.SetValue(schedulerStorage1, "Resource", new BookingResourceHandler().GetElementById(app.ResourceId.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource);
            //}
            //****************************************************************++



            //imposto per sicurezza il campo allday a true;
            app.AllDay = true;

            ////i get my custom object
            Assignment a = app.GetSourceObject(schedulerStorage1) as Assignment;

            //i add the created assignment to the booking
            IBooking b = a.Booking;

            b.AddAssignment(a);



            ////i save on my db
            AssignmentHandler h = new AssignmentHandler();

            try
            {
                h.SaveOrUpdate(a);
            }
            catch (Exception ex)
            {
                WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);

                return;
            }


            //notifico l'id all'oggetto appena creato
            Key newId = a.Key;
            app.SetValue(schedulerStorage1, "Key", newId);
            ///////*****************************
            ///////*****************************
            ///////*****************************
            ///////*****************************

            //Appointment app1 = app.Copy();
            //app1.Start = DateTime.Now.AddHours(2);

            //schedulerStorage1.Appointments.Add(app1);

            //foreach (Appointment item in schedulerStorage1.Appointments.Items)
            //{
            //    MyAppointment a1 = app.GetSourceObject(schedulerStorage1) as MyAppointment;

            //}


        }

        [Secure(Area = "Prenotazioni", Alias = "Crea da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
        }

        [Secure(Area = "Prenotazioni", Alias = "Cancella da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForDeletion()
        {
            SecurityManager.Instance.Check();
        }
        [Secure(Area = "Prenotazioni", Alias = "Aggiorna da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForChanging()
        {
            SecurityManager.Instance.Check();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.Appointment apt = e.Appointment;

           

            // Required to open the recurrence form via context menu.
            bool isNewAppointment =  schedulerStorage1.Appointments.IsNewAppointment(apt);

            // Create a custom form.
            BookingForm myForm = new BookingForm((SchedulerControl)sender, apt, isNewAppointment);

            try
            {
                // Required for skins support.
                myForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel;

                //e.DialogResult = myForm.ShowDialog();
                myForm.ShowDialog();
                schedulerControl1.RefreshData();
                e.Handled = true;
            }
            finally
            {
                myForm.Dispose();
                MemoryHelper.ReduceMemory();
            }
        }

        private void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e)
        {
            try
            {
                Nested_CheckSecurityForChanging();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
                return;
            }


            foreach (DevExpress.XtraScheduler.Appointment app in e.Objects)
            {
                // DevExpress.XtraScheduler.Appointment app = e.Objects[0] as DevExpress.XtraScheduler.Appointment;
                //imposto per sicurezza il campo allday a true;
                app.AllDay = true;

                Assignment a = app.GetSourceObject(schedulerStorage1) as Assignment;

                //se ho cambiato risorsa dal calendario e non dal form
                //(il form tiene i valori sincronizzati) recupero la risorsa e la setto
                if (a.ResourceId != a.Resource.Id)
                {
                    BookingResourceHandler h1 = new BookingResourceHandler();
                    WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource res = h1.GetElementById(a.ResourceId.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.Booking.BookingResource;
                    a.Resource = res;
                    app.SetValue(schedulerStorage1, "Resource", res);
                }
                ////i save on my db
                AssignmentHandler h = new AssignmentHandler();

                try
                {
                    h.SaveOrUpdate(a);
                }
                catch (Exception ex)
                {
                    WIN.SCHEDULING_APP.GUI.Utility.ErrorHandler.Show(ex);
                }
            }
        }



        private void schedulerStorage1_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
        {
            try
            {
                Nested_CheckSecurityForDeletion();
            }
            catch (AccessDeniedException)
            {
                ErrorHandler.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato");
                e.Cancel = true;
                return;
            }


            //if (XtraMessageBox.Show("Sicuro di procedere alla cancellazione dell'assegnazione?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{

                DevExpress.XtraScheduler.Appointment app = e.Object as DevExpress.XtraScheduler.Appointment;

                Assignment a = app.GetSourceObject(schedulerStorage1) as Assignment;
                IBooking b = a.Booking;

               //aggiorno lo stato della prenotaizone
                a.Booking.RemoveAssignment(a);

                if (b.Assignments.Count == 0)
                {
                    //elimino l'intera prenotazione
                    BookingHandler h = new BookingHandler();

                    h.Delete(b.BaseObject);
                }
                else
                {
                    //elimino solo la assegnazione corrente
                    ////i save on my db
                    AssignmentHandler h = new AssignmentHandler();

                    h.Delete(a);
                }

               

            //    return;
            //}

            //e.Cancel = true;
        }

        private void schedulerControl1_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            ////carico la data e l'ora iniziale


            e.Appointment.AllDay = true;
            
            //e.Appointment.Subject = Properties.Settings.Default.Main_CalendarSubject;
            //if (schedulerControl1.ActiveViewType != SchedulerViewType.Day && schedulerControl1.ActiveViewType != SchedulerViewType.WorkWeek)
            //{

            //    AppointmentDateValidator v = AppointmentUtils.GetProposedDate(e.Appointment.Start);
            //    e.Appointment.Start = v.StartDate;
            //    e.Appointment.End = v.EndDate;
            //}

            
        }

        private void schedulerControl1_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            //if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            //{
            //    SchedulerPopupMenu menuLabel = e.Menu.GetPopupMenuById(SchedulerMenuItemId.LabelSubMenu, true);
            //    SchedulerPopupMenu menuStatus = e.Menu.GetPopupMenuById(SchedulerMenuItemId.StatusSubMenu, true);

            //    menuLabel.Visible = false;
            //    menuStatus.Visible = false;
            //    return;
            //}

            //if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu || e.Menu.Id == SchedulerMenuItemId.RulerMenu)
            //{

            //    SchedulerMenuItem menuAllDay = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent, false);
            //    SchedulerMenuItem menuRecurrentApp = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringAppointment, false);
            //    SchedulerMenuItem menuRecurrentEv = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringEvent, false);

            //    menuAllDay.Visible = false;
            //    menuRecurrentApp.Visible = false;
            //    menuRecurrentEv.Visible = false;
            //    return;
            //}

        }

        private void schedulerStorage1_FetchAppointments(object sender, FetchAppointmentsEventArgs e)
        {

            if (_initializing) 
                return;

            DateTime start = e.Interval.Start;
            DateTime end = e.Interval.End;

            // Check if the requested interval is outside the lastFetchedInterval
            if (start <= lastFetchedInterval.Start || end >= lastFetchedInterval.End)
            {
                lastFetchedInterval = new TimeInterval(start - TimeSpan.FromDays(31), end +
                    TimeSpan.FromDays(31));

                WIN.SCHEDULING_APPLICATION.HANDLERS.Booking.AssignmentHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.Booking.AssignmentHandler();

                IList<IsearchDTO> dtos = new List<IsearchDTO>();

                dtos.Add(new PeriodAppointmentDTO(PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Periodo, new WIN.BASEREUSE.DataRange(lastFetchedInterval.Start, lastFetchedInterval.End ), true,false));
               
                h.ExecuteQuery(dtos, -1);

             
                schedulerStorage1.Appointments.DataSource =  h.BindableResults;

            }
           

        }

        private void schedulerControl1_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
        {
            //MyAppointment a = e.Appointment.GetSourceObject(schedulerStorage1) as MyAppointment;


            //if (a != null)
            //{
            //    a.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);

           
            //    AppointmentImageInfo info = new AppointmentImageInfo();
            //    info.Image = imageCollection1.Images[SelectImageIndex(a)];
            //    //AppointmentImageInfo info1 = new AppointmentImageInfo();
            //    //info1.Image = Properties.Resources.openHS;
            //    e.ImageInfoList.Add(info);
            //    //e.ImageInfoList.Add(info1);   
            //}
        }

        //private int SelectImageIndex(MyAppointment a)
        //{
        //    switch (a.State)
        //    {
        //        case AppointmentState.Pianificato:
        //            return 0;
                    
        //        case AppointmentState.In_Scadenza:
        //            return 1;
                    
        //        case AppointmentState.Scade_Oggi:
        //            return 2;
                    
        //        case AppointmentState.Scaduto:
        //            return 3;
                    
        //        case AppointmentState.Eseguito:
        //            return 4;
                    
        //        case AppointmentState.Concluso:
        //            return 5;
                   
        //        default:
        //            return 0;
                    
        //    }
        //}

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_initializing)
            //    return;

            //try
            //{
            //    schedulerControl1.BeginUpdate();

            //    if (comboBoxEdit1.Text == "Nessun raggruppamento")
            //    {
            //        schedulerControl1.GroupType = SchedulerGroupType.None;
            //        //Properties.Settings.Default.Main_CalendarGroupType = 0;
            //        //Properties.Settings.Default.Save();
            //    }
            //    else if (comboBoxEdit1.Text == "Data")
            //    {
            //        schedulerControl1.GroupType = SchedulerGroupType.Date;
            //        //Properties.Settings.Default.Main_CalendarGroupType = 1;
            //        //Properties.Settings.Default.Save();
            //    }
            //    else
            //    {
            //        schedulerControl1.GroupType = SchedulerGroupType.Resource;
            //        //Properties.Settings.Default.Main_CalendarGroupType = 2;
            //        //Properties.Settings.Default.Save();
            //    }
            //}
            //finally
            //{
            //    schedulerControl1.EndUpdate();
            //}
            

        }

        private void schedulerStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
        {
            try
            {
                Nested_CheckSecurityForCreation();
                //foreach (Appointment  item in schedulerStorage1 .Appointments .Items )
                //{
                //    MyAppointment app = item.GetSourceObject(schedulerStorage1) as MyAppointment;
                //}
            }
            catch (AccessDeniedException)
            {
                ErrorHandler.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato");
                e.Cancel = true;
            }
        }

        private void schedulerStorage1_AppointmentChanging(object sender, PersistentObjectCancelEventArgs e)
        {
            try
            {
                Nested_CheckSecurityForChanging();
                
                //qui verifico che l'appuntamento può essere cambiato
                Appointment app = e.Object as Appointment;

                BookingResourceHandler bc = new BookingResourceHandler();
                BookingResource res = bc.GetElementById(app.ResourceId.ToString()) as BookingResource;

                Assignment ass = app.GetSourceObject(schedulerStorage1) as Assignment;

                AssignmentHandler hh = new AssignmentHandler();

                FreeRoomCheck cc = hh.IsRoomFree(app.Start, app.End, res,ass.Id );
                if (!cc.IsFree)
                {
                    XtraMessageBox.Show(cc.Message, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                    e.Cancel = true;
                }


                //if (XtraMessageBox.Show("Il prezzo verra' cambiato di conseguenza. Continuare?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                //{
                //    e.Cancel = true;
                //    return;
                //}

                //Appointment app1 = e.Object as Appointment;
                //Assignment aas1 = app1.GetSourceObject(schedulerStorage1) as Assignment;

                //if (aas1.Booking.Confirmed)
                //{
                    

                //    aas1.Booking.Payment.Total = aas1.Booking.Payment.Total + 10;
                //}


            }
            catch (AccessDeniedException)
            {
                ErrorHandler.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato");
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
                e.Cancel = true;
            }
        }

        private void schedulerControl1_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {

            //MyAppointment a = e.Appointment.GetSourceObject(schedulerStorage1) as MyAppointment;

            //if (a == null)
            //    return;
            //if (a.Customer != null)
            //{
            ////    e.Description = "Queste sono le note dell'appuntamento";
            ////    e.Text = "prova per il 2";
            //    string resDes = "";
            //    if (a.Resource != null)
            //    {
            //        //verifico che succede
            //        resDes = a.Resource.Descrizione;
                    
            //    }

            //    e.Text = string.Format("{0} ({1} {2}-{3})", resDes, a.Customer.Descrizione, a.Customer.Responsable, e.Appointment.Location);
                 
            //}
        }

        private void trackBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            schedulerControl1.TimelineView.GetBaseTimeScale().Width = trackBarControl1.Value;
            Properties.Settings.Default.Main_ZoomTemporale = trackBarControl1.Value;
            Properties.Settings.Default.Save();
        }

        private void trackBarControl2_EditValueChanged(object sender, EventArgs e)
        {
             
            schedulerControl1.TimelineView.AppointmentDisplayOptions.AppointmentHeight = Convert.ToInt32(trackBarControl2.Value);
            Properties.Settings.Default.Main_ZoomSpaziale = trackBarControl2.Value;
            Properties.Settings.Default.Save();
        }

        private void schedulerControl1_InitAppointmentImages_1(object sender, AppointmentImagesEventArgs e)
        {
            Assignment a = e.Appointment.GetSourceObject(schedulerStorage1) as Assignment;


            if (a != null)
            {
                


                AppointmentImageInfo info = new AppointmentImageInfo();
                info.Image = SelectImage(a);
                //AppointmentImageInfo info1 = new AppointmentImageInfo();
                //info1.Image = Properties.Resources.openHS;
                e.ImageInfoList.Add(info);
                //e.ImageInfoList.Add(info1);   

                if (a.CheckedIn)
                {
                    AppointmentImageInfo info1 = new AppointmentImageInfo();
                    info1.Image = Properties.Resources.Lock_Lock_icon16;
                    //AppointmentImageInfo info1 = new AppointmentImageInfo();
                    //info1.Image = Properties.Resources.openHS;
                    e.ImageInfoList.Add(info1);
                }
            }
        }

        private Image SelectImage(Assignment a)
        {
            BookingState state = a.Booking.State;
            switch (state)
            {
                case BookingState.NotConfirmed:
                    return imageCollection1.Images[1];
                   
                   
                case BookingState.ConfirmedWithAccont:
                    return imageCollection1.Images[5];
                   
                   
                case BookingState.ConfimedWithoutAccount:
                    return imageCollection1.Images[4];
                   
                   
                case BookingState.Closed:
                    return imageCollection1.Images[0];
                    
                   
                default:
                    return null;
                   
            }
        }

        private void schedulerControl1_PopupMenuShowing_1(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                SchedulerPopupMenu menuLabel = e.Menu.GetPopupMenuById(SchedulerMenuItemId.LabelSubMenu, true);
                SchedulerPopupMenu menuStatus = e.Menu.GetPopupMenuById(SchedulerMenuItemId.StatusSubMenu, true);

                menuLabel.Visible = false;
                menuStatus.Visible = false;
                return;
            }

            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu || e.Menu.Id == SchedulerMenuItemId.RulerMenu)
            {

                SchedulerMenuItem menuAllDay = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent, false);
                SchedulerMenuItem newApp = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment, false);
                SchedulerMenuItem gotoDate = e.Menu.GetMenuItemById(SchedulerMenuItemId.GotoDate, false);
                SchedulerPopupMenu switchViewMenu = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu);
                SchedulerPopupMenu switchto = e.Menu.GetPopupMenuById(SchedulerMenuItemId.TimeScaleEnable, true);
                SchedulerPopupMenu switchtoenabled = e.Menu.GetPopupMenuById(SchedulerMenuItemId.TimeScaleVisible, true);

                foreach (var item in switchtoenabled.Items)
                {
                    SchedulerMenuCheckItem o = item as SchedulerMenuCheckItem;
                    if (o != null)
                        if (o.Caption == "&Trimestre" || o.Caption == "&Anno" || o.Caption == "&Ora" || o.Caption == "00:15:00")
                            o.Visible = false;
                    
                }


                menuAllDay.Visible = false;
                newApp.Caption = "Nuova prenotazione";
                gotoDate.Visible = false;
                switchViewMenu.Visible = false;
                switchto.Visible = false;
                return;
            }
        }

        private void toolTipController1_BeforeShow(object sender, DevExpress.Utils.ToolTipControllerShowEventArgs e)
        {

            try
            {

            
                if (toolTipController1.ActiveObject is AppointmentViewInfo)
                {
                    Appointment apt = ((AppointmentViewInfo)toolTipController1.ActiveObject).Appointment;
                    Assignment ass = apt.GetSourceObject(schedulerStorage1) as Assignment;
                    IBooking book = ass.Booking;

                    string op ="" ;
                    if (book.Operator != null)
                        op = book.Operator.Descrizione;

                    float acconto = 0;
                    float saldo = 0;
                    float totale = 0;

                    if (book.Confirmed)
                    {
                        acconto = book.Payment.Accont;
                        saldo = book.Payment.RestOfPayment ;
                        totale = book.Payment.Total;
                    }


                    e.ToolTipType = ToolTipType.SuperTip;

                    SuperToolTip stt = new SuperToolTip();
                    ToolTipTitleItem ttiTitle = new ToolTipTitleItem();
                    ToolTipItem ttiBody = new ToolTipItem();
                    ToolTipItem ttiFooter = new ToolTipItem();
                    ToolTipItem ttiFooter1 = new ToolTipItem();

                    ttiTitle.Text = "Dati prenotazione";

                    ttiBody.AllowHtmlText = DefaultBoolean.True;
                    ttiBody.Text = string.Format("<b>Data:</b> {0} \n<b>Oggetto:</b> {1} \n<b>Tipo prenotazione:</b> {2}\n<b>Operatore:</b> {3}\n<b>Note:</b> {4} \n",
                        book.Date.ToShortDateString (), book.Notes, book.BookingType.Descrizione, op, book.Notes1 );
                    ttiBody.Image = SelectImage(ass);

                    ttiFooter.Text = "Pagamento";
                    ttiFooter.AllowHtmlText = DefaultBoolean.True;
                    ttiFooter.Image = Properties.Resources.wallet_16;


                    ttiFooter.Text = string.Format("<b>Acconto:</b> {0} \n<b>Saldo versato (da versare):</b> {1}({2})\n<b>Totale:</b> {3}",
                       acconto.ToString("c2"), saldo.ToString("c2") , (totale - acconto).ToString("c2"), totale.ToString("c2"));
                    //ttiFooter.Appearance.BackColor = Color.Red;
                    ttiFooter.Appearance.ForeColor = Color.FromArgb(0x66, 0x99, 0xFF);


                    ttiFooter1.Text = "Assegnazione camera";
                    ttiFooter1.AllowHtmlText = DefaultBoolean.True;
                    ttiFooter1.Image = Properties.Resources.label_16;


                    ttiFooter1.Text = string.Format("<b>Chek in:</b> {0} \n<b>Check out:</b> {1}\n<b>Letti:</b> {2}\n<b>Note:</b> {3}",
                       ass.StartDate.ToShortDateString (),  ass.EndDate.ToShortDateString () , ass.BedType.Descrizione , ass.Notes );
                    //ttiFooter.Appearance.BackColor = Color.Red;
                    ttiFooter1.Appearance.ForeColor = Color.FromArgb(0x66, 0x99, 0x66);

                    stt.Items.Add(ttiTitle);
                    stt.Items.AddSeparator();
                    stt.Items.Add(ttiBody);
                    stt.Items.AddSeparator();
                    stt.Items.Add(ttiFooter);
                    stt.Items.AddSeparator();
                    stt.Items.Add(ttiFooter1);

                    e.SuperTip = stt;
                }

            }
            catch (Exception)
            {


            }
        }

        private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            //AppointmentViewInfo aptViewInfo = e.ObjectInfo as AppointmentViewInfo;
            //Appointment apt = aptViewInfo.Appointment;

            //aptViewInfo.Appearance.BackColor = Color.FromArgb(0xFF, 0x33, 0xCC);
            //aptViewInfo.Appearance.BorderColor = Color.Black;
            //aptViewInfo.Appearance.BackColor2 = Color.Yellow;

            //e.Handled = true;
        }

        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            try
            {
                AppointmentViewInfo aptViewInfo = e.ViewInfo;
                Appointment apt = aptViewInfo.Appointment;

                Assignment ass = apt.GetSourceObject(schedulerStorage1) as Assignment;

                if (ass.Booking.ColorBookings)
                    aptViewInfo.Appearance.BackColor = Color.FromArgb(ass.Booking.Color);
            }
            catch (Exception)
            {
                
            }
            


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            

            FrmSelezionaIntervalloDate frm = new FrmSelezionaIntervalloDate(DateTime.Now , DateTime.Now.AddDays(7));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (BookingCalendarReport rpt = new BookingCalendarReport())
                {
                    if (!frm.checkEdit1.Checked )
                        rpt.SchedulerAdapter.TimeInterval = new TimeInterval(frm.dateEdit1.DateTime.Date, frm.dateEdit2.DateTime.Date);
                   
                    rpt.SchedulerAdapter.SetSourceObject(schedulerControl1);
                    rpt.ShowPreviewDialog();
                }
            }

            frm.Dispose();


            
        }

  

     
        //private bool Exsist(IBindingList l, MyAppointment item)
        //{
        //    foreach (MyAppointment elem in l)
        //    {
        //        if (elem.Id.Equals(item.Id))
        //            return true;

        //    }

        //    return false;
        //}

    }
}
