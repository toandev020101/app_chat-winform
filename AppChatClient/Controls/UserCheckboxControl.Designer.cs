
namespace AppChatClient.Controls
{
    partial class UserCheckboxControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserCheckboxControl));
            this.gpnlUser = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnConnected = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbFullName = new System.Windows.Forms.Label();
            this.gpbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnCheckbox = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.gpnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // gpnlUser
            // 
            this.gpnlUser.BackColor = System.Drawing.Color.Transparent;
            this.gpnlUser.BorderRadius = 3;
            this.gpnlUser.Controls.Add(this.btnConnected);
            this.gpnlUser.Controls.Add(this.lbAddress);
            this.gpnlUser.Controls.Add(this.lbFullName);
            this.gpnlUser.Controls.Add(this.gpbAvatar);
            this.gpnlUser.Controls.Add(this.btnCheckbox);
            this.gpnlUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gpnlUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUser.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUser.Location = new System.Drawing.Point(3, 3);
            this.gpnlUser.Name = "gpnlUser";
            this.gpnlUser.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUser.ShadowDecoration.Enabled = true;
            this.gpnlUser.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 7);
            this.gpnlUser.Size = new System.Drawing.Size(325, 71);
            this.gpnlUser.TabIndex = 6;
            // 
            // btnConnected
            // 
            this.btnConnected.BackColor = System.Drawing.Color.Transparent;
            this.btnConnected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConnected.BorderColor = System.Drawing.Color.White;
            this.btnConnected.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnConnected.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnConnected.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnConnected.DisabledState.ForeColor = System.Drawing.Color.DarkGray;
            this.btnConnected.FillColor = System.Drawing.Color.Lime;
            this.btnConnected.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnected.ForeColor = System.Drawing.Color.White;
            this.btnConnected.Location = new System.Drawing.Point(60, 10);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnConnected.Size = new System.Drawing.Size(12, 12);
            this.btnConnected.TabIndex = 3;
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.BackColor = System.Drawing.Color.Transparent;
            this.lbAddress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbAddress.Location = new System.Drawing.Point(86, 42);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(58, 15);
            this.lbAddress.TabIndex = 1;
            this.lbAddress.Text = "127.0.0.1";
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.BackColor = System.Drawing.Color.Transparent;
            this.lbFullName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.ForeColor = System.Drawing.Color.White;
            this.lbFullName.Location = new System.Drawing.Point(86, 17);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(64, 16);
            this.lbFullName.TabIndex = 1;
            this.lbFullName.Text = "Đức Toàn";
            // 
            // gpbAvatar
            // 
            this.gpbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.gpbAvatar.Image = ((System.Drawing.Image)(resources.GetObject("gpbAvatar.Image")));
            this.gpbAvatar.ImageRotate = 0F;
            this.gpbAvatar.Location = new System.Drawing.Point(18, 13);
            this.gpbAvatar.Name = "gpbAvatar";
            this.gpbAvatar.ShadowDecoration.Color = System.Drawing.Color.Fuchsia;
            this.gpbAvatar.ShadowDecoration.Enabled = true;
            this.gpbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gpbAvatar.Size = new System.Drawing.Size(45, 45);
            this.gpbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gpbAvatar.TabIndex = 0;
            this.gpbAvatar.TabStop = false;
            // 
            // btnCheckbox
            // 
            this.btnCheckbox.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCheckbox.CheckedState.BorderRadius = 2;
            this.btnCheckbox.CheckedState.BorderThickness = 0;
            this.btnCheckbox.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnCheckbox.Location = new System.Drawing.Point(5, 26);
            this.btnCheckbox.Name = "btnCheckbox";
            this.btnCheckbox.Size = new System.Drawing.Size(20, 20);
            this.btnCheckbox.TabIndex = 4;
            this.btnCheckbox.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnCheckbox.UncheckedState.BorderRadius = 2;
            this.btnCheckbox.UncheckedState.BorderThickness = 0;
            this.btnCheckbox.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnCheckbox.Visible = false;
            // 
            // UserCheckboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gpnlUser);
            this.Name = "UserCheckboxControl";
            this.Size = new System.Drawing.Size(331, 77);
            this.gpnlUser.ResumeLayout(false);
            this.gpnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel gpnlUser;
        private Guna.UI2.WinForms.Guna2CircleButton btnConnected;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbFullName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gpbAvatar;
        private Guna.UI2.WinForms.Guna2CustomCheckBox btnCheckbox;
    }
}
