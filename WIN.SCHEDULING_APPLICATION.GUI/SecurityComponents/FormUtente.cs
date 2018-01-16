using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WIN.SECURITY.Core;
using WIN.SCHEDULING_APP.GUI.Utility;

namespace WIN.SCHEDULING_APP.GUI.SecurityComponents
{
    public partial class FormUtente : DevExpress.XtraEditors.XtraForm
    {
        private WIN.BASEREUSE.Role _role ;
        private WIN.BASEREUSE.User _user;
        bool _createNew = false;

        public FormUtente(IRole role, bool createNew)
        {
            InitializeComponent();
            _createNew = createNew;
            _role = role as WIN.BASEREUSE.Role;
            infoLabel.Text = String.Format("L'utente appartiene al ruolo: {0}", role.Description);
        }

        public FormUtente(WIN.BASEREUSE.User user)
        {
              InitializeComponent();
              _user = user;
              _role = user.Role as WIN.BASEREUSE.Role;
              uxUserNameTextBox.Text = user.Username;
              uxPasswordTextBox.Text = user.Password;
              uxNameTextBox.Text = user.Name;
              uxSurnameTextBox.Text = user.SurName;
              this.Text = this.Text + " " + user.Username;
              infoLabel.Text = String.Format("L'utente appartiene al ruolo: {0}", user.Role.Description);
        }


        public IUser User
        {
            get
            {
                return _user;
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                WIN.BASEREUSE.User user = GetUserByUserName(uxUserNameTextBox.Text) as WIN.BASEREUSE.User;
                if (user != null)
                    if (_createNew)
                        throw new Exception("Username già esistente");

                if (uxUserNameTextBox.Text == "")
                {
                    uxUserNameTextBox.Focus();
                    return;
                }

                if (uxPasswordTextBox.Text == "")
                {
                    uxPasswordTextBox.Focus();
                    return;
                }



                if (_user == null)
                    _user = new WIN.BASEREUSE.User(_role);



                _user.Username = uxUserNameTextBox.Text;
                _user.Password = uxPasswordTextBox.Text;
                _user.Name = uxNameTextBox.Text;
                _user.SurName = uxSurnameTextBox.Text;


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(ex);
            }
        }

        private IUser GetUserByUserName(string p)
        {
            foreach (IUser elem in _role.Users)
            {
                if (elem.Username.Equals(p))
                    return elem;
            }
            return null;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}