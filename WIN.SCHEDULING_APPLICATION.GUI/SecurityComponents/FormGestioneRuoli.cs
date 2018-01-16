using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;
using WIN.SECURITY.Core;
using WIN.SCHEDULING_APP.GUI.Utility;
using WIN.BASEREUSE;
using WIN.TECHNICAL.PERSISTENCE;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FormGestioneRuoli : DevExpress.XtraEditors.XtraForm
    {
        private bool remivingRole = false;
           private IRole _currentRole;
         //  private IList<AssociationData> _associations   = new List<AssociationData>();
           private IList< WIN.BASEREUSE.Role>  _roles  = new List< WIN.BASEREUSE.Role>();
           private IList< WIN.BASEREUSE.User> _users  = new List< WIN.BASEREUSE.User>();
           private IList< WIN.BASEREUSE.Profile> _profiles   = new List< WIN.BASEREUSE.Profile>();
           private IList<WIN.BASEREUSE.Role> _deletedRoles   = new List<WIN.BASEREUSE.Role>();
        //   private IUser _cuttedUser  = null;


          private SecureDataManager secureDataAccess  = new SecureDataManager();


        public FormGestioneRuoli()
        {
            InitializeComponent();
        }

        private void FormGestioneRuoli_Load(object sender, EventArgs e)
        {
            LoadAll();
        }

        private void LoadAll()
        {
              _roles = secureDataAccess.GetNormalizedRoles();



              //WIN.BASEREUSE.Role role = null;
              foreach (WIN.BASEREUSE.Role elem in _roles)
              {
                  if (elem.Descrizione.Equals("ADMINISTRATORS"))
                  {
                      _roles.Remove(elem);
                      break;
                  }

              }

             secureDataAccess.BeginTransaction();
             try
             {
                LoadRoles();

                if (_roles.Count > 0)
                   LoadRole(_roles[0]);
             }
             catch (Exception)
             {
             }
        }

        private void LoadRole(WIN.BASEREUSE.Role role)
        {
            if (role == null)
                return;
            _currentRole = role;


            txtDescrizioneRole.Text = role.Descrizione;

            _users = new List<WIN.BASEREUSE.User>();
            foreach (WIN.BASEREUSE.User elem in _currentRole.Users)
            {
                _users.Add(elem);
            }


            _profiles = new List<WIN.BASEREUSE.Profile>();

            foreach (WIN.BASEREUSE.Profile elem in _currentRole.Profiles)
            {
                _profiles.Add(elem);
            }

            LoadUserAndProfiles();
        }

        private void LoadUserAndProfiles()
        {
            if (_currentRole == null)
                return;

            //carico gli utenti
            uxUsersListBox.Items.Clear();
            foreach (IUser item in _currentRole.Users)
            {
                uxUsersListBox.Items.Add(item.Username,7);
            }



            //carico i profili
            uxProfilesListBox.Items.Clear();
            foreach (IProfile item in _currentRole.Profiles)
            {
                uxProfilesListBox.Items.Add(item.Description, 3);
            }
        }

        private void LoadRoles()
        {
            uxRolesListBox.Items.Clear();
            foreach (IRole item in _roles)
	        {
                uxRolesListBox.Items.Add(item.Description);
	        }
        }


        private void OpenUserProperty()
        {
            try
            {
                if (_currentRole != null)
                {
                    if (uxUsersListBox.SelectedItems.Count == 1)
                    {
                        OpenUserPropertiesForm(GetUserByUserName(uxUsersListBox.SelectedItems[0].ToString()));
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void OpenUserPropertiesForm(IUser user)
        {
              FormUtente frm = new FormUtente(user as WIN.BASEREUSE.User);
              if (frm.ShowDialog() == DialogResult.OK)
              {
                 secureDataAccess.MarkDirty(user as WIN.BASEREUSE.AbstractPersistenceObject);
                 LoadUserAndProfiles();
              }
        }

        private IUser GetUserByUserName(string userName)
        {
            foreach (IUser elem in _currentRole.Users)
            {

                if (elem.Username.Equals(userName))
                    return elem as WIN.BASEREUSE.User;
            }
            return null;
        }

        private void OpenProfilesProperty()
        {
            try
            {
                if (_currentRole != null)
                {
                    if (uxProfilesListBox.SelectedItems.Count == 1)
                    {
                        OpenProfilePropertiesForm(GetProfileByDescription(uxProfilesListBox.SelectedItems[0].ToString()));
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void OpenProfilePropertiesForm(IProfile iProfile)
        {
            FormGestioneProfili frm = new FormGestioneProfili(iProfile as WIN.BASEREUSE.Profile);
            frm.ShowDialog();
        }

        private IProfile GetProfileByDescription(string profile)
        {
            foreach (IProfile elem in _currentRole.Profiles)
            {

                if (elem.Description.Equals(profile))
                    return elem as WIN.BASEREUSE.Profile;
            }
            return null;
        }

        private void Iren_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             try
             {
                 if (_currentRole == null)
                      return;
                 if (uxRolesListBox.SelectedIndex != -1)
                 {
                    FormDescrizioneProfilo frm = new FormDescrizioneProfilo(_currentRole.Description, "Descrizione ruolo");
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                       WIN.BASEREUSE.Role rol = GetRoleByName(frm.Descrizione);
                       if (rol != null) 
                            throw new Exception("Ruolo esistente");

                       _currentRole.Description = frm.Descrizione;
                       txtDescrizioneRole.Text = _currentRole.Description;
                       uxRolesListBox.Items[uxRolesListBox.SelectedIndex] = _currentRole.Description;
                       secureDataAccess.MarkDirty(_currentRole as WIN.BASEREUSE.AbstractPersistenceObject);
                    }
                 }
             }
             catch (Exception ex)
             {
                ErrorHandler.Show(ex);
             }
        }

        private WIN.BASEREUSE.Role GetRoleByName(string p)
        {
            foreach (IRole elem in _roles)
            {
                if (elem.Description.Equals(p))
                    return elem as WIN.BASEREUSE.Role;
            }
            return null;
        }


        private void CheckProfile(IProfile profile)
        {
            foreach (IProfile item in _currentRole.Profiles)
            {
                if (item.Description.Equals(profile.Description))
                    throw new Exception("Il profilo selezionato appartiene al ruolo");
            }
        }

        private void iNewRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (IRole elem in _roles)
            {
                if (elem.Description == "NUOVO RUOLO")
                {
                    XtraMessageBox.Show("Impossibile aggiungere un ruolo nuovo. Ruolo #Nuovo ruolo# esistente!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            WIN.BASEREUSE.Role role = new WIN.BASEREUSE.Role();
            _roles.Add(role);
            role.Descrizione = "Nuovo ruolo";
            secureDataAccess.MarkNew(role as WIN.BASEREUSE.AbstractPersistenceObject);
            uxRolesListBox.Items.Add(role.Descrizione);
        }

        private void INewUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_currentRole  != null)
                {
                    if (uxRolesListBox.SelectedIndex != -1)
                    {
                       FormUtente frm = new  FormUtente(_currentRole, true);
                       if (frm.ShowDialog() == DialogResult.OK)
                       {
                          WIN.BASEREUSE.User user;
                          user = frm.User as WIN.BASEREUSE.User;
                          secureDataAccess.MarkNew(user as WIN.BASEREUSE.AbstractPersistenceObject);
                          LoadUserAndProfiles();
                       }
                       frm.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);   
            }
        }

        private void iSaveRuolo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                 secureDataAccess.CommitTransaction();
                 XtraMessageBox.Show("Riavviare l'applicazione per rendere effettive le modifiche", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 LoadAll();
            }
            catch (Exception ex )
            {
                 LoadAll();
                 ErrorHandler.Show(ex);
            }
        }

        private void uxRolesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRole(GetRoleByName(uxRolesListBox.Text));
        }

        private void uxRolesListBox_Click(object sender, EventArgs e)
        {
            if (remivingRole)
                return;
             if (uxRolesListBox.SelectedValue != null)
             {
                _currentRole = GetRoleByName(uxRolesListBox.SelectedValue.ToString()) as WIN.BASEREUSE.Role;
                LoadRole(_currentRole as WIN.BASEREUSE.Role);
             }

        }

        private void iremoveUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRole != null)
            {
             if (uxUsersListBox.SelectedItems.Count == 1)
             {
                 if (XtraMessageBox.Show("Sicuro di procedere nella cancellazione dell'utente?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     object o = uxUsersListBox.SelectedItems[0];
                   string name = o.ToString();
                   WIN.BASEREUSE.User user = GetUserByUserName(name) as WIN.BASEREUSE.User;
                   if (user != null)
                   {
                      _currentRole.Users.Remove(user);
                      uxUsersListBox.Items.Remove(o);
                      secureDataAccess.MarkDelete(user as WIN.BASEREUSE.AbstractPersistenceObject);
                      LoadUserAndProfiles();
                   }
                 }
             }
            }
        }

        private void INewProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_currentRole != null)
                {
                    FormProfili frm = new FormProfili();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        IProfile prof = frm.SelectedProfile;
                        if (prof == null)
                            return;
                        CheckProfile(prof);
                        _currentRole.Profiles.Add(prof);
                        secureDataAccess.MarkNew(new RoleProfile(_currentRole, prof));
                        LoadUserAndProfiles();
                    }
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void IDelRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRole != null)
            {
                if (uxRolesListBox.SelectedIndex != -1)
                {
                    if (XtraMessageBox.Show("Sicuro di procedere nella cancellazione del ruolo selezionato?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        secureDataAccess.MarkDelete(_currentRole as WIN.BASEREUSE.AbstractPersistenceObject);
                        uxUsersListBox.Items.Clear();
                        uxProfilesListBox.Items.Clear();
                        _roles.Remove(_currentRole as WIN.BASEREUSE.Role);
                        remivingRole = true;
                        uxRolesListBox.Items.RemoveAt(uxRolesListBox.SelectedIndex);
                        remivingRole = false;
                        if (_roles.Count > 0)
                            LoadRole(_roles[0]);
                    }
                    
                }

             }
        }

        private void iremoveProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_currentRole != null)
            {
                 if (uxProfilesListBox.SelectedItems.Count == 1)
                 {
                     if (XtraMessageBox.Show("Sicuro di procedere nella cancellazione del profilo?", "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                     {
                         string item = uxProfilesListBox.SelectedItems[0].ToString();
                         IProfile profile = GetProfileByDescription(item);
                         if (profile != null)
                         {
                             _currentRole.Profiles.Remove(profile);
                             //secureDataAccess.MarkDelete(new RoleProfile(_currentRole, profile));
                             DataAccessServices.SimplePersistenceFacadeInstance().ExecuteScalar(String.Format("Delete from roleprofile where roleID = {0} and profileID = {1}", _currentRole.ID, profile.ID));
                             LoadUserAndProfiles();
                         }
                     }
                 }
            }
        }

        private void iViewProf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenUserProperty();
        }

        private void iviewut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenProfilesProperty();
        }


     
    }
}