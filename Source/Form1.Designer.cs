namespace CSH030Ex
{
    partial class PassFailInfromation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPasswordConfirm = new System.Windows.Forms.Label();
            this.tbPasswordConfirm = new System.Windows.Forms.TextBox();
            this.lblPasswordValidation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(32, 24);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(417, 21);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password";
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.Location = new System.Drawing.Point(32, 51);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(417, 70);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Enter Admin Mode";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.VisibleChanged += new System.EventHandler(this.btnEnter_VisibleChanged);
            this.btnEnter.Click += new System.EventHandler(this.Enter_Click);
            //
            // btnChangePassword
            //
            this.btnChangePassword.Location = new System.Drawing.Point(32, 130);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(270, 32);
            this.btnChangePassword.TabIndex = 3;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(312, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 32);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // lblPasswordConfirm
            //
            this.lblPasswordConfirm.AutoSize = true;
            this.lblPasswordConfirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPasswordConfirm.Location = new System.Drawing.Point(32, 58);
            this.lblPasswordConfirm.Name = "lblPasswordConfirm";
            this.lblPasswordConfirm.Size = new System.Drawing.Size(150, 12);
            this.lblPasswordConfirm.Text = "Confirm New Password";
            this.lblPasswordConfirm.Visible = false;
            //
            // tbPasswordConfirm
            //
            this.tbPasswordConfirm.Location = new System.Drawing.Point(32, 80);
            this.tbPasswordConfirm.Name = "tbPasswordConfirm";
            this.tbPasswordConfirm.PasswordChar = '*';
            this.tbPasswordConfirm.Size = new System.Drawing.Size(417, 21);
            this.tbPasswordConfirm.TabIndex = 1;
            this.tbPasswordConfirm.Visible = false;
            this.tbPasswordConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            //
            // lblPasswordValidation
            //
            this.lblPasswordValidation.ForeColor = System.Drawing.Color.LightCoral;
            this.lblPasswordValidation.Location = new System.Drawing.Point(32, 108);
            this.lblPasswordValidation.Name = "lblPasswordValidation";
            this.lblPasswordValidation.Size = new System.Drawing.Size(417, 32);
            this.lblPasswordValidation.Text = "";
            this.lblPasswordValidation.Visible = false;
            // 
            // PassFailInfromation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(481, 178);
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblPasswordConfirm);
            this.Controls.Add(this.tbPasswordConfirm);
            this.Controls.Add(this.lblPasswordValidation);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PassFailInfromation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pass Fail Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPasswordConfirm;
        private System.Windows.Forms.TextBox tbPasswordConfirm;
        private System.Windows.Forms.Label lblPasswordValidation;
    }
}
