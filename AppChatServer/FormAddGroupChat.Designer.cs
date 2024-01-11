
namespace AppChatServer
{
    partial class FormAddGroupChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddGroupChat));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lbNameError = new System.Windows.Forms.Label();
            this.gpbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnCreate = new Guna.UI2.WinForms.Guna2GradientButton();
            this.flpUser = new System.Windows.Forms.FlowLayoutPanel();
            this.tbName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tbSearchUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.lbNameError);
            this.guna2Panel1.Controls.Add(this.gpbAvatar);
            this.guna2Panel1.Controls.Add(this.btnCreate);
            this.guna2Panel1.Controls.Add(this.flpUser);
            this.guna2Panel1.Controls.Add(this.tbName);
            this.guna2Panel1.Controls.Add(this.tbSearchUser);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.guna2Panel1.Location = new System.Drawing.Point(1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(380, 631);
            this.guna2Panel1.TabIndex = 2;
            // 
            // lbNameError
            // 
            this.lbNameError.BackColor = System.Drawing.Color.Transparent;
            this.lbNameError.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.lbNameError.Location = new System.Drawing.Point(113, 76);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(243, 15);
            this.lbNameError.TabIndex = 34;
            this.lbNameError.Text = "error";
            this.lbNameError.Visible = false;
            // 
            // gpbAvatar
            // 
            this.gpbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.gpbAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gpbAvatar.Image = global::AppChatServer.Properties.Resources.group_avatar_buddyboss;
            this.gpbAvatar.ImageRotate = 0F;
            this.gpbAvatar.Location = new System.Drawing.Point(28, 18);
            this.gpbAvatar.Name = "gpbAvatar";
            this.gpbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gpbAvatar.Size = new System.Drawing.Size(70, 70);
            this.gpbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gpbAvatar.TabIndex = 33;
            this.gpbAvatar.TabStop = false;
            this.gpbAvatar.Click += new System.EventHandler(this.gpbAvatar_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.BorderRadius = 5;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnCreate.DisabledState.CustomBorderColor = System.Drawing.Color.Silver;
            this.btnCreate.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.btnCreate.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCreate.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnCreate.Enabled = false;
            this.btnCreate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(22, 575);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(336, 45);
            this.btnCreate.TabIndex = 32;
            this.btnCreate.Text = "Tạo nhóm tin nhắn";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // flpUser
            // 
            this.flpUser.AutoScroll = true;
            this.flpUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.flpUser.Location = new System.Drawing.Point(22, 162);
            this.flpUser.Name = "flpUser";
            this.flpUser.Size = new System.Drawing.Size(355, 393);
            this.flpUser.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.Transparent;
            this.tbName.BorderColor = System.Drawing.Color.Silver;
            this.tbName.BorderRadius = 3;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.DefaultText = "";
            this.tbName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.tbName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbName.ForeColor = System.Drawing.Color.White;
            this.tbName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbName.Location = new System.Drawing.Point(113, 38);
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbName.PlaceholderText = "Nhập tên nhóm";
            this.tbName.SelectedText = "";
            this.tbName.Size = new System.Drawing.Size(243, 36);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // tbSearchUser
            // 
            this.tbSearchUser.BackColor = System.Drawing.Color.Transparent;
            this.tbSearchUser.BorderColor = System.Drawing.Color.Silver;
            this.tbSearchUser.BorderRadius = 3;
            this.tbSearchUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearchUser.DefaultText = "";
            this.tbSearchUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearchUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearchUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchUser.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.tbSearchUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchUser.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbSearchUser.ForeColor = System.Drawing.Color.White;
            this.tbSearchUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchUser.IconLeft = global::AppChatServer.Properties.Resources.search_interface_symbol;
            this.tbSearchUser.Location = new System.Drawing.Point(24, 105);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.PasswordChar = '\0';
            this.tbSearchUser.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbSearchUser.PlaceholderText = "Nhập họ và tên hoặc địa chỉ";
            this.tbSearchUser.SelectedText = "";
            this.tbSearchUser.Size = new System.Drawing.Size(334, 36);
            this.tbSearchUser.TabIndex = 0;
            this.tbSearchUser.TextChanged += new System.EventHandler(this.tbSearchUser_TextChanged);
            // 
            // FormAddGroupChat
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 633);
            this.Controls.Add(this.guna2Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddGroupChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App Chat - Tạo nhóm tin nhắn";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnCreate;
        private System.Windows.Forms.FlowLayoutPanel flpUser;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchUser;
        private Guna.UI2.WinForms.Guna2TextBox tbName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gpbAvatar;
        private System.Windows.Forms.Label lbNameError;
    }
}