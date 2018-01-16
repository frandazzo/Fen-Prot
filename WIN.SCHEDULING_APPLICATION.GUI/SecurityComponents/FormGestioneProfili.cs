using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SECURITY.Core;
using WIN.SCHEDULING_APPLICATION.HANDLERS.MainSubSystems;
using WIN.SECURITY.Attributes;
using WIN.SECURITY;
using WIN.BASEREUSE;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FormGestioneProfili : DevExpress.XtraEditors.XtraForm
    {
           private bool _removingProfile = false;
           private List<IPermission> _permissions ;
           private WIN.BASEREUSE.Profile _profile ;
           private bool _loading ;
           private bool _showFullMethodNames  = false;
           private SecureDataManager SecureDataAccess = new SecureDataManager();
           private IList<IProfile> _profiles  = new List<IProfile>();
           private bool looked   = false;

       public FormGestioneProfili(WIN.BASEREUSE.Profile Profile)
       {
          InitializeComponent();
          splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
          looked = true;
          bar1.Visible = false;

         // uxPermissionsListBox.Enabled = false;

          uxPermissionsListBox.Enabled = false;
          simpleButton1.Enabled = false;
          LoadProfile(Profile);
       }

       private void LoadProfile(WIN.BASEREUSE.Profile profile)
       {
            if (profile == null)
                return;
            
           _profile = profile;

            txtDescrizione.Text = profile.Descrizione;
            _permissions = new List<IPermission>(_profile.Permissions);
            LoadTreeView();
            uxPermissionsListBox.Items.Clear();
       }

       private void LoadTreeView()
       {
            uxTreeView.Nodes.Clear();
            uxTreeView.Columns.Clear();

           //add column
            uxTreeView.BeginUpdate();
            uxTreeView.Columns.Add();
            uxTreeView.Columns[0].Caption = "Descrizione profilo";
            uxTreeView.Columns[0].VisibleIndex = 0;
            uxTreeView.EndUpdate();

            uxTreeView.BeginUnboundLoad();


            foreach (KeyValuePair<string,Secure> item in SecurityManager.Instance.SecureMethods)
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode macronode = GetMacroNode(item.Value.MacroArea);
                CheckAreaNode(macronode, item.Value.Area);

            }

            uxTreeView.EndUnboundLoad();

            uxTreeView.ExpandAll();

       }

       private void CheckAreaNode(DevExpress.XtraTreeList.Nodes.TreeListNode macronode, string p)
       {
           DevExpress.XtraTreeList.Nodes.TreeListNode nullNode = null;
           if (macronode != null)
           {
               bool found = CheckNodeExist(macronode, p, ref nullNode);
               if (!found)
               {
                   DevExpress.XtraTreeList.Nodes.TreeListNode node = uxTreeView.AppendNode(new object[] { p }, macronode);
                   node.Tag = p;
               }
           }
       }

       private bool CheckNodeExist(DevExpress.XtraTreeList.Nodes.TreeListNode macronode, string p, ref DevExpress.XtraTreeList.Nodes.TreeListNode foundNode)
       {
           DevExpress.XtraTreeList.Nodes.TreeListNodes l;
           if (macronode == null)
               l = uxTreeView.Nodes;
           else
               l = macronode.Nodes;


           foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in l)
           {
               if (item.Tag != null)
               {
                   if (item.Tag.ToString().Equals(p))
                   {
                       foundNode = item;
                       return true;
                   }
               }
           }

           foundNode = null;
           return false;

       }

       private DevExpress.XtraTreeList.Nodes.TreeListNode GetMacroNode(string p)
       {
             DevExpress.XtraTreeList.Nodes.TreeListNode macroNode = null;

             bool found = CheckNodeExist(null, p, ref macroNode);


             if (!found) 
              {

                  macroNode = uxTreeView.AppendNode(new object[] { p },null);
                  macroNode.Tag = p;
                 
              }


             return macroNode;

       }

        public FormGestioneProfili()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
                _profiles = SecureDataAccess.GetProfiles();
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                SecureDataAccess.BeginTransaction();

                LoadProfiles();

                if (_profiles.Count > 0)
                   LoadProfile(_profiles[0] as WIN.BASEREUSE.Profile);
          
        }

        private void LoadProfiles()
        {
            uxProfilesListbox.Items.Clear();
            foreach (IProfile elem in _profiles)
	        {
		         uxProfilesListbox.Items.Add(elem.Description);
	        }
        }


           private void LoadPermissions(string macroarea , string area )
           {
              _loading = true;
              uxPermissionsListBox.Items.Clear();

              foreach (KeyValuePair<string,Secure> secure in SecurityManager.Instance.SecureMethods)
              {
                  if (secure.Value.MacroArea == macroarea)
                  {
                      if (secure.Value.Area == area)
                      {
                          secure.Value.FullToString = _showFullMethodNames;
                          uxPermissionsListBox.Items.Add(secure.Value, ProfileHasMethod(secure.Value.FullName));
                      }
                  }
              }
              _loading = false;
           }

           private bool ProfileHasMethod(string p)
           {
               foreach (IPermission elem in _profile.Permissions)
               {
                   if (elem.FullMethodName.Equals(p))
                        return true;
               }
               return false;
           }


        private bool ProfileContainsMethod(Secure Secure ) 
        {
              bool contains = false;

              foreach (IPermission permission in _profile.Permissions)
              {
                  if (permission.FullMethodName.Equals(Secure.FullName))
                  {
                      contains = true; break;
                  }
              }
              return contains;
          }
     



    
         private void DeletePermission(string fullName)
        {
              IPermission toRemove   = null;

                foreach (IPermission elem in _profile.Permissions)
	            {
            		 if (elem.FullMethodName.Equals(fullName))
                      {
                          toRemove = elem;
                      }
	            }

                if (toRemove != null)
                {
                    _profile.Permissions.Remove(toRemove);
                    SecureDataAccess.MarkDelete(toRemove as AbstractPersistenceObject);
                }

        }



        private IProfile GetProfileByName(string ProfileName) 
        {
              foreach (IProfile elem in _profiles)
              {
                 if (elem.Description == ProfileName)
                    return elem;
              }
              return null;
        }

        private void iSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             try
             {
                 SecureDataAccess.CommitTransaction();
                 //'SecureDataAccess.BeginTransaction()
                 XtraMessageBox.Show("Riavviare l'applicazione per rendere effettive le modifiche", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 LoadAll();
             }
             catch (Exception ex)
             {
                 LoadAll();
                 ErrorHandler.Show(ex);
             }
        }

        private void iDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_profile != null)
            {
                if (uxProfilesListbox.SelectedIndex != -1)
                {
                    _removingProfile = true;
                    uxProfilesListbox.Items.Remove(_profile.Descrizione);
                    _removingProfile = false;

                    SecureDataAccess.MarkDelete(_profile);
                    uxTreeView.Nodes.Clear();
                    uxPermissionsListBox.Items.Clear();
                    _profiles.Remove(_profile);
                     if (_profiles.Count > 0)
                        LoadProfile(_profiles[0] as WIN.BASEREUSE.Profile);
                    
                }

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_profile == null)
                    return;
                if (uxProfilesListbox.SelectedIndex != -1)
                {
                    FormDescrizioneProfilo frm = new FormDescrizioneProfilo(_profile.Descrizione, "Descriiozne profilo");
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        WIN.BASEREUSE.Profile prof   = GetProfileByName(frm.Descrizione) as WIN.BASEREUSE.Profile;
                        if (prof != null)
                            throw new Exception("Profilo esistente");

                        _profile.Descrizione = frm.Descrizione;
                        txtDescrizione.Text = _profile.Descrizione;
                        uxProfilesListbox.Items[uxProfilesListbox.SelectedIndex] = _profile.Descrizione;
                        SecureDataAccess.MarkDirty(_profile);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private void uxTreeView_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node == null)
                return;


            if (e.Node.ParentNode != null)
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode macroNode = e.Node.ParentNode;
                uxPermissionsListBox.Enabled = true;
                LoadPermissions(macroNode.Tag.ToString(), e.Node.Tag.ToString());
            }
            else
            {
                uxPermissionsListBox.Items.Clear();
                uxPermissionsListBox.Enabled = false;
            }
        }

        private void uxProfilesListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_removingProfile)
                LoadProfile(GetProfileByName(uxProfilesListbox.Text) as WIN.BASEREUSE.Profile);
        }

        private void iAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (IProfile elem in _profiles)
            {
                if (elem.Description == "NUOVO PROFILO")
                {
                    XtraMessageBox.Show("Impossibile aggiungere un profilo nuovo. Profilo #Nuovo profilo# esistente!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            WIN.BASEREUSE.Profile profile = new WIN.BASEREUSE.Profile();
            _profiles.Add(profile);
            profile.Descrizione = "Nuovo profilo";
            SecureDataAccess.MarkNew(profile);
            uxProfilesListbox.Items.Add(profile.Descrizione);
        }

        private void uxPermissionsListBox_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            if (_loading)
                return;

            if (looked)
            {
               
                //if (e.State == CheckState.Unchecked)
                //    uxPermissionsListBox.Items[e.Index].CheckState = CheckState.Checked;
                //else
                    uxPermissionsListBox.Items[e.Index].InvertCheckState();
                    //uxPermissionsListBox.Items[e.Index].CheckState = CheckState.Unchecked;
                return;
            }
             


                if (e.State == CheckState.Checked)
                {
                       Secure Secure = uxPermissionsListBox.Items[e.Index].Value as Secure;
                       WIN.BASEREUSE.Permission Permission = new WIN.BASEREUSE.Permission();
                       Permission.FullMethodName = Secure.FullName;
                       Permission.Profile = _profile;
                       _profile.Permissions.Add(Permission);
                       SecureDataAccess.MarkNew(Permission);
                }
                else
                {
                     Secure Secure   = uxPermissionsListBox.Items[e.Index].Value as Secure;
                     DeletePermission(Secure.FullName);

                }
        }

    







    }

}