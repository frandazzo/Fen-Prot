using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WIN.SCHEDULING_APPLICATION.HANDLERS.ComboHandlers;
using WIN.SCHEDULING_APPLICATION.HANDLERS;
using WIN.SCHEDULING_APPLICATION.HANDLERS.SearchDTOs;
using WIN.SCHEDULING_APPLICATION.DOMAIN;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Controls.CustomAppointmentFormAssets;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APP.GUI.Controls.CalendarUtils;
using DevExpress.XtraScheduler.Drawing;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.SECURITY.Exceptions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using WIN.SCHEDULING_APP.GUI.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using DevExpress.XtraPrinting;
using System.Collections;
using DevExpress.XtraReports.UI;


namespace WIN.SCHEDULING_APP.GUI.Controls
{
    [SecureContext]
    public partial class CalendarioControl : WIN.SCHEDULING_APP.GUI.Controls.BaseGUIControl
    {
        TimeInterval lastFetchedInterval = new TimeInterval();
        bool _initializing = false;
        GridHitInfo downHitInfo;
        MyTask _draggedTask;
        string fileLayout = "";

        public CalendarioControl(MainForm form)
            : base(form)
        {

            try
            {
                _initializing = true;

                InitializeComponent();

                if (Properties.Settings.Default.Main_ActivateTaskPanelOnCalendar)
                    splitContainerControl2.Collapsed = false;
                else
                    splitContainerControl2.Collapsed = true;
                

                schedulerStorage1.FetchAppointments +=new FetchAppointmentsEventHandler(schedulerStorage1_FetchAppointments);

                CustomGUI_SetCommandBarVisibility(false);
                //non permetto nessuna operazione dalla toolbar
                base.m_ChangeStateEnabled = false;
                schedulerControl1.Start = DateTime.Now;
                schedulerControl1.ActiveViewType = CalendarProperties.GetViewType(Properties.Settings.Default.Main_Calendar_ViewType);
                schedulerControl1.DayView.TopRowTime = new TimeSpan(8, 0, 0);
                schedulerControl1.WorkWeekView.TopRowTime = new TimeSpan(8, 0, 0);

                ResourceHandler h = new ResourceHandler();
                schedulerStorage1.Resources.DataSource = h.GetAll();

                //AppointmentHandler h1 = new AppointmentHandler();
                //h1.ExecuteQuery(new List<IsearchDTO>(), -1, Properties.Settings.Default.Main_DeadlineDaysBefore);
                //schedulerStorage1.Appointments.DataSource = h1.BindableResults;
                //schedulerStorage1.RefreshData();

                //imposto il raggruppamento del calendario
                if (Properties.Settings.Default.Main_CalendarGroupType == 0)
                {
                    schedulerControl1.GroupType = SchedulerGroupType.None;
                    comboBoxEdit1.SelectedIndex = 0;
                }
                else if (Properties.Settings.Default.Main_CalendarGroupType == 1)
                {
                    schedulerControl1.GroupType = SchedulerGroupType.Date;
                    comboBoxEdit1.SelectedIndex = 1;
                }
                else if (Properties.Settings.Default.Main_CalendarGroupType == 2)
                {
                    schedulerControl1.GroupType = SchedulerGroupType.Resource;
                    comboBoxEdit1.SelectedIndex = 2;
                }
                else
                {
                    schedulerControl1.GroupType = SchedulerGroupType.None;
                    comboBoxEdit1.SelectedIndex = 0;
                }
            }
            finally
            {
                _initializing = false;
            }


            PopulateGrid();

            
        }

      

        private void schedulerStorage1_AppointmentsInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {
            //gets the newly created Devexpress appointment;
            DevExpress.XtraScheduler.Appointment app = e.Objects[0] as DevExpress.XtraScheduler.Appointment;


            //*********************************************************
            //questo codice è inserito per risolvere il problema dell'assegnazione della risorsa 
            //dopo il grag drop
            DevExpress.XtraScheduler.Resource ee = app.ResourceId as DevExpress.XtraScheduler.Resource;
            //questa situazione si verifica quando lo scheduler non è stato in grado
            //di assegnare una risorsa all'appuntamento creato nella funzione GetDragData
            //e pertanto assegna la risorsa "All" all'appuntamento
            if (ee != null)
            {
                Customer ccc = app.GetValue(schedulerStorage1, "Customer") as Customer;
                if (ccc != null)
                {
                    app.SetValue(schedulerStorage1, "Resource", ccc.Resource);
                    app.ResourceId = ccc.Resource.Id;
                }
                else
                {
                    WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource t = new ResourceHandler().GetAll()[0] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
                    app.SetValue(schedulerStorage1, "Resource", t);
                    app.ResourceId = t.Id;
                }
            }
            else
            {
                app.SetValue (schedulerStorage1, "Resource", new ResourceHandler().GetElementById(app.ResourceId.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource);
            }
            //****************************************************************++

           

            //imposto per sicurezza il campo allday a false;
            app.AllDay = false;

            ////i get my custom object
            MyAppointment a = app.GetSourceObject(schedulerStorage1) as MyAppointment;

           



            ////i save on my db
            AppointmentHandler h = new AppointmentHandler();

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
            Key newId =  a.Key;
            app.SetValue(schedulerStorage1, "Key", newId);


            //Appointment app1 = app.Copy();
            //app1.Start = DateTime.Now.AddHours(2);

            //schedulerStorage1.Appointments.Add(app1);

            //foreach (Appointment item in schedulerStorage1 .Appointments.Items  )
            //{
            //    MyAppointment a1 = app.GetSourceObject(schedulerStorage1) as MyAppointment;

            //}


        }

        [Secure(Area = "Appuntamenti", Alias = "Crea da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForCreation()
        {
            SecurityManager.Instance.Check();
        }

        [Secure(Area = "Appuntamenti", Alias = "Cancella da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForDeletion()
        {
            SecurityManager.Instance.Check();
        }
        [Secure(Area = "Appuntamenti", Alias = "Aggiorna da calendario", MacroArea = "Applicativo")]
        protected override void Nested_CheckSecurityForChanging()
        {
            SecurityManager.Instance.Check();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.Appointment apt = e.Appointment;

            
            // Required to open the recurrence form via context menu.
            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);

            // Create a custom form.
            CustomAppForm myForm = new CustomAppForm((SchedulerControl)sender, apt, openRecurrenceForm);

            try
            {
                // Required for skins support.
                myForm.LookAndFeel.ParentLookAndFeel = schedulerControl1.LookAndFeel;

                e.DialogResult = myForm.ShowDialog();
                schedulerControl1.Refresh();
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
                //imposto per sicurezza il campo allday a false;
                app.AllDay = false;

                MyAppointment a = app.GetSourceObject(schedulerStorage1) as MyAppointment;

                //se ho cambiato risorsa dal calendario e non dal form
                //(il form tiene i valori sincronizzati) recupero la risorsa e la setto
                if (a.ResourceId != a.Resource.Id)
                {
                    ResourceHandler h1 = new ResourceHandler ();
                    WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource res = h1.GetElementById(a.ResourceId.ToString()) as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
                    a.Resource = res;
                    app.SetValue(schedulerStorage1,"Resource",res);
                }
                ////i save on my db
                AppointmentHandler h = new AppointmentHandler();

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
           

            if (XtraMessageBox.Show("Sicuro di procedere alla cancellazione dell'appuntamento?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DevExpress.XtraScheduler.Appointment app = e.Object as DevExpress.XtraScheduler.Appointment;

                MyAppointment a = app.GetSourceObject(schedulerStorage1) as MyAppointment;


                ////i save on my db
                AppointmentHandler h = new AppointmentHandler();

                h.Delete(a);

                return;
            }

            e.Cancel = true;
        }

        private void schedulerControl1_InitNewAppointment(object sender, AppointmentEventArgs e)
        {
            //////carico la data e l'ora iniziale
            

            e.Appointment.AllDay = false;
            e.Appointment.Subject = Properties.Settings.Default.Main_CalendarSubject;
            if (schedulerControl1.ActiveViewType != SchedulerViewType.Day && schedulerControl1.ActiveViewType != SchedulerViewType.WorkWeek)
            {
                
                AppointmentDateValidator v = AppointmentUtils.GetProposedDate(e.Appointment.Start );
                e.Appointment.Start = v.StartDate;
                e.Appointment.End = v.EndDate;
            }

            //dtpin.EditValue = v.StartDate;
            //dtpfin.EditValue = v.EndDate;

            //timin.Time = new DateTime(v.StartDate.TimeOfDay.Ticks);
            //timfin.Time = new DateTime(v.EndDate.TimeOfDay.Ticks);
        }

        private void schedulerControl1_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
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
                SchedulerMenuItem menuRecurrentApp = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringAppointment, false);
                SchedulerMenuItem menuRecurrentEv = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringEvent, false);

                menuAllDay.Visible = false;
                menuRecurrentApp.Visible = false;
                menuRecurrentEv.Visible = false;
                return;
            }

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
               
                WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler();

                IList<IsearchDTO> dtos = new List<IsearchDTO>();

                dtos.Add(new PeriodAppointmentDTO(PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Periodo, new WIN.BASEREUSE.DataRange(lastFetchedInterval.Start, lastFetchedInterval.End ), true,false));
               
                h.ExecuteQuery(dtos, -1, Properties.Settings.Default.Main_DeadlineDaysBefore);

             
                schedulerStorage1.Appointments.DataSource =  h.BindableResults;

          

                //schedulerStorage1.RefreshData();
                
            }
            //else
            //    schedulerStorage1.RefreshData();

        }

        private void schedulerControl1_InitAppointmentImages(object sender, AppointmentImagesEventArgs e)
        {
            MyAppointment a = e.Appointment.GetSourceObject(schedulerStorage1) as MyAppointment;


            if (a != null)
            {
                a.CalculateAppointmentInfo(Properties.Settings.Default.Main_DeadlineDaysBefore);

           
                AppointmentImageInfo info = new AppointmentImageInfo();
                info.Image = imageCollection1.Images[SelectImageIndex(a)];
                //AppointmentImageInfo info1 = new AppointmentImageInfo();
                //info1.Image = Properties.Resources.openHS;
                e.ImageInfoList.Add(info);
                //e.ImageInfoList.Add(info1);   
            }
        }

        private int SelectImageIndex(MyAppointment a)
        {
            switch (a.State)
            {
                case AppointmentState.Pianificato:
                    return 0;
                    
                case AppointmentState.In_Scadenza:
                    return 1;
                    
                case AppointmentState.Scade_Oggi:
                    return 2;
                    
                case AppointmentState.Scaduto:
                    return 3;
                    
                case AppointmentState.Eseguito:
                    return 4;
                    
                case AppointmentState.Concluso:
                    return 5;
                   
                default:
                    return 0;
                    
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_initializing)
                return;

            try
            {
                schedulerControl1.BeginUpdate();

                if (comboBoxEdit1.Text == "Nessun raggruppamento")
                {
                    schedulerControl1.GroupType = SchedulerGroupType.None;
                    Properties.Settings.Default.Main_CalendarGroupType = 0;
                    Properties.Settings.Default.Save();
                }
                else if (comboBoxEdit1.Text == "Data")
                {
                    schedulerControl1.GroupType = SchedulerGroupType.Date;
                    Properties.Settings.Default.Main_CalendarGroupType = 1;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    schedulerControl1.GroupType = SchedulerGroupType.Resource;
                    Properties.Settings.Default.Main_CalendarGroupType = 2;
                    Properties.Settings.Default.Save();
                }
            }
            finally
            {
                schedulerControl1.EndUpdate();
            }
            

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
            }
            catch (AccessDeniedException)
            {
                ErrorHandler.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato");
                e.Cancel = true;
            }
        }

        private void schedulerControl1_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e)
        {

            MyAppointment a = e.Appointment.GetSourceObject(schedulerStorage1) as MyAppointment;

            if (a == null)
                return;
            if (a.Customer != null)
            {
            //    e.Description = "Queste sono le note dell'appuntamento";
            //    e.Text = "prova per il 2";
                string resDes = "";
                if (a.Resource != null)
                {
                    //verifico che succede
                    resDes = a.Resource.Descrizione;
                    
                }

                e.Text = string.Format("{0} ({1} {2}-{3})", resDes, a.Customer.Cognome, a.Customer.Nome, e.Appointment.Location);
                 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (schedulerControl1.Services.SchedulerState.IsDataRefreshAllowed)
                {
                    WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler h = new WIN.SCHEDULING_APPLICATION.HANDLERS.AppointmentHandler();

                    IList<IsearchDTO> dtos = new List<IsearchDTO>();

                    dtos.Add(new PeriodAppointmentDTO(PeriodAppointmentDTO.PeriodAppointmentDTOEnum.Periodo, new WIN.BASEREUSE.DataRange(lastFetchedInterval.Start, lastFetchedInterval.End), true, false));

                    h.ExecuteQuery(dtos, -1, Properties.Settings.Default.Main_DeadlineDaysBefore);

                    schedulerControl1.BeginUpdate();
                    schedulerStorage1.BeginUpdate();


                    schedulerStorage1.Appointments.DataSource = h.BindableResults;

                    schedulerStorage1.EndUpdate() ;
                    schedulerControl1.EndUpdate();
                }
            }
            catch (Exception)
            {
               // non fa nulla
            }
            

                //schedulerStorage1.Appointments.DataSource = null;
                // = myAppointmentBindingSource;
                //schedulerStorage1.RefreshData();
                //IBindingList l = schedulerStorage1.Appointments.DataSource as IBindingList;

                //foreach (MyAppointment item in h.BindableResults )
                //{
                //    if (!Exsist(l, item))
                //        l.Add(item);
                //}


            //    //schedulerStorage1.RefreshData();
            //    //schedulerControl1.Storage.RefreshData();
            //    //schedulerControl1.Refresh();
            //}
           

        }

        private bool Exsist(IBindingList l, MyAppointment item)
        {
            foreach (MyAppointment elem in l)
            {
                if (elem.Id.Equals(item.Id))
                    return true;

            }

            return false;
        }

        private void schedulerControl1_VisibleIntervalChanged(object sender, EventArgs e)
        {

            PopulateGrid();

        }

        private void PopulateGrid()
        {

            if (splitContainerControl2.IsPanelCollapsed)
                return;

            try
            {
                if (_initializing)
                    return;

                DateTime m = DateTime.MinValue;

                TimeIntervalCollection l = schedulerControl1.ActiveView.GetVisibleIntervals();


                foreach (TimeInterval item in l)
                {
                    if (item.End.Date > m)
                    {
                        DateTime t = item.End.Date.AddMonths(1);
                        t = new DateTime(t.Year , t.Month, 1);
                        m = t;//.AddDays(-1);
                    }
                }


                gridControl1.DataSource = GetAttivita(m);


                try
                {
                    gridControl1.MainView.SaveLayoutToXml(fileLayout);
                }
                catch (Exception)
                {
                    //non fa nulla
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
            
        }

        private IBindingList GetAttivita(DateTime m)
        {
            TaskHandler h = new TaskHandler();


            List<IsearchDTO> dto = new List<IsearchDTO>();
            dto.Add(new SimpleTaskSearch("", "", DataRange.Empty(), true, true, true, true, true, true, m.AddDays(-1)));

            h.ExecuteQuery(dto, 0, Properties.Settings.Default.Main_DeadlineDaysBefore);

            return h.BindableResults;

        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "OutcomeDate")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.OutcomeDate == DateTime.MinValue)
                        e.DisplayText = "";
                }
            }
            else if (e.Column.FieldName == "PercentageCompleteness")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.PercentageCompleteness == 0)
                        e.DisplayText = "";
                }
            }
            else if (e.Column.Name == "colFiscale")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.CodiceFiscale;
                }
            }
            else if (e.Column.Name == "colContatti")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Residenza.ToString();
                }
            }
            else if (e.Column.Name == "colTelContatti")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.TelefonoUfficio;
                }
            }
            else if (e.Column.Name == "colCell1")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare1;
                }
            }
            else if (e.Column.Name == "colCell2")
            {
                MyTask app = gridView1.GetRow(e.RowHandle) as MyTask;
                if (app != null)
                {
                    if (app.Customer != null)
                        e.DisplayText = app.Customer.Comunicazione.Cellulare2;
                }
            }
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "OutlookDeadLineStateToString")
            {
                e.Info.Caption = string.Empty;
                e.Column.View.Images = imageCollection1;
                e.Column.ImageIndex = 11;
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                DoRowDoubleClick(view, pt);
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRowCell)
            {
                MyTask label = view.GetRow(view.FocusedRowHandle) as MyTask;
                if (label != null)
                    ShowDialogForm(label);
            }
        }

        private void ShowDialogForm(MyTask label)
        {
            TaskForm frm = new TaskForm(label);
            frm.CheckSecurityForView();
            frm.ShowDialog();
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GridView view = sender as GridView;
                downHitInfo = null;

                GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
                if (Control.ModifierKeys != Keys.None)
                    return;
                if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.HitTest != GridHitTest.RowIndicator)
                    downHitInfo = hitInfo;
            }
        }

        private void gridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                GridView view = sender as GridView;
                if (e.Button == MouseButtons.Left && downHitInfo != null)
                {
                    Size dragSize = SystemInformation.DragSize;
                    Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                        downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                    if (!dragRect.Contains(new Point(e.X, e.Y)))
                    {
                        view.GridControl.DoDragDrop(GetDragData(view), DragDropEffects.All);
                        downHitInfo = null;
                    }
                }
            }
        }

        private void schedulerControl1_AppointmentDrop(object sender, AppointmentDragEventArgs e)
        {


            if (_draggedTask == null)
            {
                e.Handled = true;
                return;

            }
         
               
                




                PostDragDropActions(e);

                e.Handled = true;

        }

        private void PostDragDropActions(AppointmentDragEventArgs e)
        {
            if (_draggedTask == null)
                return;

            try
            {
                

                if (Properties.Settings.Default.Main_MarkActivityCompletedafterDragDrop)
                {
                    //completo l'attività che è stata draggata
                    StartCompleteActivityActions(_draggedTask);
                }



                if (Properties.Settings.Default.Main_RenewActivityAfterDragDrop)
                {
                    //ne creo una nuova a partire da quella
                    StartRenewActivityActions(CreateTask());
                }

                e.Allow = true;
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
                e.Allow = false;
            }
            finally
            {
                _draggedTask = null;
            }
        }

     

        private void StartRenewActivityActions(MyTask task)
        {
            if (Properties.Settings.Default.Main_AskIfRenewActivityAfterDragDrop)
            {
                if (XtraMessageBox.Show(string.Format("Si desidera rinnovare l'attività tra {0} giorni?",Properties.Settings.Default.Main_DaysOfRenewTask.ToString()), "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TaskHandler hh = new TaskHandler();
                    hh.SaveOrUpdate(task);


                }
            }
            else
            {
                TaskHandler hh = new TaskHandler();
                hh.SaveOrUpdate(task);
            }

        }

        private void StartCompleteActivityActions(MyTask task)
        {
            if (Properties.Settings.Default.Main_AskIfActivityMustbeMarkedAsCompleted)
            {
                if (XtraMessageBox.Show("Si desidera marcare l'attività come completa?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CompleteTask(task);
                }
            }
            else
            {
                CompleteTask(task);
            }

        }

        private void CompleteTask(MyTask task)
        {
            TaskHandler hh = new TaskHandler();
            task.OutcomeDate = DateTime.Now;
            task.PercentageCompleteness = 100;
            task.ActivityState = ActivityState.Completata;

            hh.SaveOrUpdate(task);

            //una volta aggiornata l'attività la posso rimuovere dalla lista in griglia
            IBindingList b = gridView1.DataSource as IBindingList;
            b.Remove(_draggedTask);
        }

        private MyTask CreateTask()
        {
            MyTask t = new MyTask();

            t.Subject = _draggedTask.Subject;
            t.Description = _draggedTask.Description;
            t.StartDate = _draggedTask.StartDate.AddDays(Properties.Settings.Default.Main_DaysOfRenewTask);
            //artificio per evitare l'arrotondamento dei comandi ado su sql
            t.EndDate = _draggedTask.EndDate.AddDays(Properties.Settings.Default.Main_DaysOfRenewTask);
            t.Customer = _draggedTask.Customer;
            t.Priority = _draggedTask.Priority;
            

            return t;
        }




        SchedulerDragData GetDragData(GridView view)
        {
            int[] selection = view.GetSelectedRows();
            if (selection == null)
                return null;

            AppointmentBaseCollection appointments = new AppointmentBaseCollection();
            int count = selection.Length;
            for (int i = 0; i < count; i++)
            {
                int rowIndex = selection[i];
                MyTask myTask = view.GetRow(rowIndex) as MyTask;


                //imposto una variabile a livello 
                //di modulo per il richiamo alle successive azioni postdragdrop
                if (Properties.Settings.Default.Main_RenewActivityAfterDragDrop || Properties.Settings.Default.Main_MarkActivityCompletedafterDragDrop)
                    _draggedTask = myTask;
                else
                    _draggedTask = null;



                if (myTask == null)
                    break;
                
                Appointment apt = schedulerStorage1.CreateAppointment(AppointmentType.Normal);


                apt.AllDay = false;

                if (schedulerControl1.ActiveViewType != SchedulerViewType.Day && schedulerControl1.ActiveViewType != SchedulerViewType.WorkWeek)
                {
                    AppointmentDateValidator v = AppointmentUtils.GetProposedDate(apt.Start);
                    apt.Start = v.StartDate;
                    apt.End = v.EndDate;
                }
                else
                    apt.Duration = TimeSpan.FromHours(0.5);

                apt.Subject = myTask.Subject;
                //apt.LabelId = (int)view.GetRowCellValue(rowIndex, "Severity");
                //apt.StatusId = (int)view.GetRowCellValue(rowIndex, "Priority");
                //WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource r = new ResourceHandler().GetAll()[0] as WIN.SCHEDULING_APPLICATION.DOMAIN.ComboElements.Resource;
                ////apt.ResourceId = r.Id;
                //if (schedulerControl1.GroupType == SchedulerGroupType.None)
                //    apt.SetValue(schedulerStorage1, "Resource", r);
                apt.SetValue(schedulerStorage1, "Label", new LabelHandler().GetAll()[0]);
                if (myTask.Customer != null)
                {
                    apt.SetValue(schedulerStorage1, "Customer", myTask.Customer);
                    Customer c = myTask.Customer;
                    apt.Location = string.Format("{0} {1} {2}", c.Residenza.Via, c.Residenza.Cap, c.Residenza.Comune.Descrizione);
                    if (string.IsNullOrEmpty(myTask.Description))
                        apt.Description = c.OtherDataSummary;
                }
                if (!string.IsNullOrEmpty(myTask.Description))
                    apt.Description = myTask.Description;
                
                appointments.Add(apt);
                
            }

            return new SchedulerDragData(appointments, 0);
        }

        private void CalendarioControl_Load(object sender, EventArgs e)
        {
            fileLayout = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");

            FileInfo f = new FileInfo(fileLayout);


            fileLayout = f.DirectoryName;

            fileLayout += "\\LayoutSavings\\reportAttivita.xml";


            //verifico la presenza del file
            f = new FileInfo(fileLayout);


            try
            {
                if (f.Exists)
                {
                    gridControl1.ForceInitialize();
                    // Restore the previously saved layout
                    gridControl1.MainView.RestoreLayoutFromXml(fileLayout);
                }




            }
            catch (Exception)
            {
                //non fa nulla
            }

        }

        private void splitContainerControl2_SplitGroupPanelCollapsed(object sender, SplitGroupPanelCollapsedEventArgs e)
        {
            if (!e.Collapsed)
                PopulateGrid();
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Control.MousePosition);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                TaskForm frm = new TaskForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.CurrentTask != null)
                    {

                        IBindingList g = gridView1.DataSource as IBindingList;
                        g.Add(frm.CurrentTask);
                    }
                }
            }
            catch (AccessDeniedException)
            {
                XtraMessageBox.Show("Impossibile accedere alla funzionalità richiesta. Accesso negato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                foreach (int rowIndex in gridView1.GetSelectedRows())
                {
                    if (gridView1.IsDataRow(rowIndex))
                    {
                        TryDelete(gridView1.GetRow(rowIndex) as MyTask, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void TryDelete(MyTask myTask, int rowIndex)
        {
            if (myTask == null)
                return;

            if (XtraMessageBox.Show("Rimuovere l'attività selezionata?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TaskHandler h = new TaskHandler();
                h.Delete(myTask);

                IBindingList h1 = gridView1.DataSource as IBindingList;
                h1.Remove(myTask);
            }

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //gridControl1.ShowPrintPreview();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                link.Component = gridControl1;
                link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                link.ShowPreview();


            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            } 
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           Print();
        }

        public override void Print()
        {
            try
            {
                ArrayList l = GetVisibleRecords();

                if (l.Count > 0)
                {
                    Reports.TaskReport c = new WIN.SCHEDULING_APP.GUI.Reports.TaskReport();
                    c.DataSource = l;
                    c.ShowPreviewDialog();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }


        private ArrayList GetVisibleRecords()
        {
            ArrayList l = new ArrayList();
            if (gridView1.RowCount > 0)
            {
                gridView1.ExpandAllGroups();
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                int handle = gridView1.GetVisibleRowHandle(i);
                if (!gridView1.IsGroupRow(handle))
                {
                    MyTask a = gridView1.GetRow(handle) as MyTask;
                    if (a != null)
                        l.Add(a);

                }
            }
            return l;
        }

    }
}
