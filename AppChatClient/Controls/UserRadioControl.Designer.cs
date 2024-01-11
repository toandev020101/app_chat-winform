
namespace AppChatClient.Controls
{
    partial class UserRadioControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRadioControl));
            this.gpnlUserRadioButton = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnConnected = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbFullName = new System.Windows.Forms.Label();
            this.gpbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnRadio = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.gpnlUserRadioButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // gpnlUserRadioButton
            // 
            this.gpnlUserRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.gpnlUserRadioButton.BorderRadius = 3;
            this.gpnlUserRadioButton.Controls.Add(this.btnConnected);
            this.gpnlUserRadioButton.Controls.Add(this.lbAddress);
            this.gpnlUserRadioButton.Controls.Add(this.lbFullName);
            this.gpnlUserRadioButton.Controls.Add(this.gpbAvatar);
            this.gpnlUserRadioButton.Controls.Add(this.btnRadio);
            this.gpnlUserRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gpnlUserRadioButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUserRadioButton.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUserRadioButton.Location = new System.Drawing.Point(2, 2);
            this.gpnlUserRadioButton.Name = "gpnlUserRadioButton";
            this.gpnlUserRadioButton.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlUserRadioButton.ShadowDecoration.Enabled = true;
            this.gpnlUserRadioButton.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 7);
            this.gpnlUserRadioButton.Size = new System.Drawing.Size(325, 71);
            this.gpnlUserRadioButton.TabIndex = 5;
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
            // btnRadio
            // 
            this.btnRadio.CheckedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnRadio.CheckedState.BorderThickness = 0;
            this.btnRadio.CheckedState.FillColor = System.Drawing.Color.Fuchsia;
            this.btnRadio.CheckedState.InnerColor = System.Drawing.Color.White;
            this.btnRadio.Enabled = false;
            this.btnRadio.Location = new System.Drawing.Point(4, 26);
            this.btnRadio.Name = "btnRadio";
            this.btnRadio.Size = new System.Drawing.Size(20, 20);
            this.btnRadio.TabIndex = 2;
            this.btnRadio.Text = "guna2CustomRadioButton1";
            this.btnRadio.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.btnRadio.UncheckedState.BorderThickness = 2;
            this.btnRadio.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnRadio.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.btnRadio.Visible = false;
            // 
            // UserRadioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gpnlUserRadioButton);
            this.Name = "UserRadioControl";
            this.Size = new System.Drawing.Size(330, 76);
            this.gpnlUserRadioButton.ResumeLayout(false);
            this.gpnlUserRadioButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel gpnlUserRadioButton;
        private Guna.UI2.WinForms.Guna2CustomRadioButton btnRadio;
        private System.Windows.Forms.Label lbFullName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gpbAvatar;
        private Guna.UI2.WinForms.Guna2CircleButton btnConnected;
        private System.Windows.Forms.Label lbAddress;
    }
}
