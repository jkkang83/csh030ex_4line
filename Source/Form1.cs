using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Ports;
using System.Threading;

namespace CSH030Ex
{
    public partial class PassFailInfromation : Form
    {
        public Global m__G = null;
        public F_Main MyOwner = null;
        public bool mForPW = false;
        private readonly bool mInitialForPW;
        private readonly bool mAuthOnly;

        public PassFailInfromation(bool forPW=false, bool authOnly=false)
        {
            InitializeComponent();
            mInitialForPW = forPW;
            mAuthOnly = authOnly;
            mForPW = forPW;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                mForPW = mInitialForPW;
                DialogResult = DialogResult.None;
                tbPassword.Clear();
                tbPasswordConfirm.Clear();
                lblPasswordValidation.Text = "";
                UpdatePasswordMode();
                tbPassword.Select();
            }

            base.OnVisibleChanged(e);
        }

        private void UpdatePasswordMode()
        {
            label1.Text = mForPW ? "New Password" : "Password";
            btnEnter.Text = mForPW ? "Save Password" :
                (mAuthOnly ? "Unlock Master Sample Tilt" : "Enter Admin Mode");
            btnChangePassword.Visible = !mForPW;
            lblPasswordConfirm.Visible = mForPW;
            tbPasswordConfirm.Visible = mForPW;
            lblPasswordValidation.Visible = mForPW;
            btnEnter.Location = new Point(32, mForPW ? 148 : 51);
            btnChangePassword.Location = new Point(32, mForPW ? 224 : 130);
            btnCancel.Location = new Point(312, mForPW ? 224 : 130);
            ClientSize = new Size(481, mForPW ? 264 : 178);
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (mForPW)
            {
                if (string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    lblPasswordValidation.Text = "Please enter a new password.";
                    tbPassword.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(tbPasswordConfirm.Text))
                {
                    lblPasswordValidation.Text = "Please confirm the new password.";
                    tbPasswordConfirm.Focus();
                    return;
                }

                if (!string.Equals(tbPassword.Text, tbPasswordConfirm.Text, StringComparison.Ordinal))
                {
                    lblPasswordValidation.Text = "Passwords do not match. Please re-enter the confirmation.";
                    tbPasswordConfirm.Clear();
                    tbPasswordConfirm.Focus();
                    return;
                }

                m__G.SetPassword(tbPassword.Text);
                tbPassword.Clear();
                tbPasswordConfirm.Clear();
                lblPasswordValidation.Text = "";
                MessageBox.Show("Password changed.", "Password");

                // Changing the password does not unlock Master Sample Tilt.
                if (mAuthOnly)
                    DialogResult = DialogResult.Cancel;

                Hide();
                return;
            }

            bool success = !string.IsNullOrEmpty(tbPassword.Text) &&
                tbPassword.Text == m__G.GetPassword();
            tbPassword.Clear();

            if (mAuthOnly)
            {
                if (!success)
                    MessageBox.Show("Incorrect Password");

                DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                Hide();
                return;
            }

            Hide();
            if (success)
            {
                MyOwner.ShowAdminMode();
            }
            else
            {
                MyOwner.ShowOperatorMode();
                MessageBox.Show("Incorrect Password");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text) ||
                tbPassword.Text != m__G.GetPassword())
            {
                tbPassword.Clear();
                MessageBox.Show("Incorrect Current Password");
                tbPassword.Focus();
                return;
            }

            mForPW = true;
            tbPassword.Clear();
            tbPasswordConfirm.Clear();
            lblPasswordValidation.Text = "";
            UpdatePasswordMode();
            tbPassword.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbPassword.Clear();
            tbPasswordConfirm.Clear();
            lblPasswordValidation.Text = "";
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void btnEnter_VisibleChanged(object sender, EventArgs e)
        {
            UpdatePasswordMode();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (mForPW && sender == tbPassword)
                    tbPasswordConfirm.Focus();
                else
                    btnEnter.PerformClick();
            }

        }
    }
}
