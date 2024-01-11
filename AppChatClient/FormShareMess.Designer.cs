
namespace AppChatClient
{
    partial class FormShareMess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShareMess));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnShare = new Guna.UI2.WinForms.Guna2GradientButton();
            this.flpUser = new System.Windows.Forms.FlowLayoutPanel();
            this.tbSearchUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.btnShare);
            this.guna2Panel1.Controls.Add(this.flpUser);
            this.guna2Panel1.Controls.Add(this.tbSearchUser);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.guna2Panel1.Location = new System.Drawing.Point(1, 1);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(380, 631);
            this.guna2Panel1.TabIndex = 2;
            // 
            // btnShare
            // 
            this.btnShare.BackColor = System.Drawing.Color.Transparent;
            this.btnShare.BorderRadius = 5;
            this.btnShare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShare.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnShare.DisabledState.CustomBorderColor = System.Drawing.Color.Silver;
            this.btnShare.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.btnShare.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnShare.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnShare.Enabled = false;
            this.btnShare.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShare.ForeColor = System.Drawing.Color.White;
            this.btnShare.Location = new System.Drawing.Point(22, 575);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(336, 45);
            this.btnShare.TabIndex = 32;
            this.btnShare.Text = "Chia sẻ";
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // flpUser
            // 
            this.flpUser.AutoScroll = true;
            this.flpUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.flpUser.Location = new System.Drawing.Point(22, 84);
            this.flpUser.Name = "flpUser";
            this.flpUser.Size = new System.Drawing.Size(355, 471);
            this.flpUser.TabIndex = 1;
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
            this.tbSearchUser.IconLeft = global::AppChatClient.Properties.Resources.search_interface_symbol;
            this.tbSearchUser.Location = new System.Drawing.Point(24, 25);
            this.tbSearchUser.Name = "tbSearchUser";
            this.tbSearchUser.PasswordChar = '\0';
            this.tbSearchUser.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbSearchUser.PlaceholderText = "Nhập tên tin nhắn";
            this.tbSearchUser.SelectedText = "";
            this.tbSearchUser.Size = new System.Drawing.Size(334, 36);
            this.tbSearchUser.TabIndex = 0;
            this.tbSearchUser.TextChanged += new System.EventHandler(this.tbSearchUser_TextChanged);
            // 
            // FormShareMess
            // 
            this.AcceptButton = this.btnShare;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 633);
            this.Controls.Add(this.guna2Panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShareMess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "App Chat - Chia sẻ tin nhắn";
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnShare;
        private System.Windows.Forms.FlowLayoutPanel flpUser;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchUser;
    }
}