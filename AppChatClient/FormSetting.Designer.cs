
namespace AppChatClient
{
    partial class FormSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUploadAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbFullNameError = new System.Windows.Forms.Label();
            this.btnSetting = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tbFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.btnUploadAvatar);
            this.guna2Panel1.Controls.Add(this.lbFullNameError);
            this.guna2Panel1.Controls.Add(this.btnSetting);
            this.guna2Panel1.Controls.Add(this.tbAddress);
            this.guna2Panel1.Controls.Add(this.tbFullName);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(400, 600);
            this.guna2Panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(47, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 22);
            this.label2.TabIndex = 36;
            this.label2.Text = "Chào mừng đến với App Chat! 🚀\r\n";
            // 
            // btnUploadAvatar
            // 
            this.btnUploadAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadAvatar.Image = global::AppChatClient.Properties.Resources.no_avatar;
            this.btnUploadAvatar.ImageRotate = 0F;
            this.btnUploadAvatar.Location = new System.Drawing.Point(111, 85);
            this.btnUploadAvatar.Name = "btnUploadAvatar";
            this.btnUploadAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnUploadAvatar.Size = new System.Drawing.Size(180, 180);
            this.btnUploadAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUploadAvatar.TabIndex = 32;
            this.btnUploadAvatar.TabStop = false;
            this.btnUploadAvatar.Click += new System.EventHandler(this.btnUploadAvatar_Click);
            // 
            // lbFullNameError
            // 
            this.lbFullNameError.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullNameError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lbFullNameError.Location = new System.Drawing.Point(25, 362);
            this.lbFullNameError.Name = "lbFullNameError";
            this.lbFullNameError.Size = new System.Drawing.Size(352, 15);
            this.lbFullNameError.TabIndex = 22;
            this.lbFullNameError.Text = "error";
            this.lbFullNameError.Visible = false;
            // 
            // btnSetting
            // 
            this.btnSetting.BorderRadius = 3;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnSetting.DisabledState.CustomBorderColor = System.Drawing.Color.Silver;
            this.btnSetting.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.btnSetting.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSetting.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnSetting.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(24, 476);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(353, 45);
            this.btnSetting.TabIndex = 31;
            this.btnSetting.Text = "Lưu lại";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // tbFullName
            // 
            this.tbFullName.BorderRadius = 3;
            this.tbFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbFullName.DefaultText = "";
            this.tbFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbFullName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.tbFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFullName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFullName.ForeColor = System.Drawing.Color.White;
            this.tbFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbFullName.IconLeft = global::AppChatClient.Properties.Resources.user;
            this.tbFullName.Location = new System.Drawing.Point(25, 315);
            this.tbFullName.Margin = new System.Windows.Forms.Padding(4);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.PasswordChar = '\0';
            this.tbFullName.PlaceholderText = "Họ và tên *";
            this.tbFullName.SelectedText = "";
            this.tbFullName.Size = new System.Drawing.Size(353, 45);
            this.tbFullName.TabIndex = 27;
            this.tbFullName.TextChanged += new System.EventHandler(this.tbFullName_TextChanged);
            // 
            // tbAddress
            // 
            this.tbAddress.BorderRadius = 3;
            this.tbAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbAddress.DefaultText = "";
            this.tbAddress.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.tbAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.tbAddress.DisabledState.ForeColor = System.Drawing.Color.Silver;
            this.tbAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbAddress.Enabled = false;
            this.tbAddress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.tbAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.ForeColor = System.Drawing.Color.White;
            this.tbAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbAddress.IconLeft = global::AppChatClient.Properties.Resources.location;
            this.tbAddress.Location = new System.Drawing.Point(25, 381);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.PasswordChar = '\0';
            this.tbAddress.PlaceholderText = "Địa chỉ *";
            this.tbAddress.SelectedText = "";
            this.tbAddress.Size = new System.Drawing.Size(353, 45);
            this.tbAddress.TabIndex = 27;
            this.tbAddress.TextChanged += new System.EventHandler(this.tbFullName_TextChanged);
            // 
            // FormSetting
            // 
            this.AcceptButton = this.btnSetting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App Chat - Cấu hình";
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnUploadAvatar;
        private System.Windows.Forms.Label lbFullNameError;
        private Guna.UI2.WinForms.Guna2GradientButton btnSetting;
        private Guna.UI2.WinForms.Guna2TextBox tbFullName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbAddress;
    }
}