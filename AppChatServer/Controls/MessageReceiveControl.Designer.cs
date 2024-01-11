
namespace AppChatServer.Controls
{
    partial class MessageReceiveControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageReceiveControl));
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnForward = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbName = new System.Windows.Forms.Label();
            this.lbSendAt = new System.Windows.Forms.Label();
            this.gpbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.Transparent;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = global::AppChatServer.Properties.Resources.trash;
            this.btnRemove.ImageSize = new System.Drawing.Size(18, 18);
            this.btnRemove.Location = new System.Drawing.Point(116, 29);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 30);
            this.btnRemove.TabIndex = 19;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnForward
            // 
            this.btnForward.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForward.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnForward.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnForward.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnForward.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnForward.FillColor = System.Drawing.Color.Transparent;
            this.btnForward.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnForward.ForeColor = System.Drawing.Color.White;
            this.btnForward.Image = global::AppChatServer.Properties.Resources.forward_right;
            this.btnForward.ImageSize = new System.Drawing.Size(18, 18);
            this.btnForward.Location = new System.Drawing.Point(150, 29);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(30, 30);
            this.btnForward.TabIndex = 18;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // gpnlContent
            // 
            this.gpnlContent.AutoSize = true;
            this.gpnlContent.BorderRadius = 10;
            this.gpnlContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(93)))));
            this.gpnlContent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(61)))), ((int)(((byte)(87)))));
            this.gpnlContent.Location = new System.Drawing.Point(50, 25);
            this.gpnlContent.Name = "gpnlContent";
            this.gpnlContent.Size = new System.Drawing.Size(63, 37);
            this.gpnlContent.TabIndex = 17;
            // 
            // lbName
            // 
            this.lbName.AutoEllipsis = true;
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbName.Location = new System.Drawing.Point(53, 2);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(60, 15);
            this.lbName.TabIndex = 15;
            this.lbName.Text = "Đức Toàn";
            this.lbName.Visible = false;
            // 
            // lbSendAt
            // 
            this.lbSendAt.AutoEllipsis = true;
            this.lbSendAt.AutoSize = true;
            this.lbSendAt.BackColor = System.Drawing.Color.Transparent;
            this.lbSendAt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSendAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSendAt.Location = new System.Drawing.Point(52, 71);
            this.lbSendAt.Name = "lbSendAt";
            this.lbSendAt.Size = new System.Drawing.Size(58, 15);
            this.lbSendAt.TabIndex = 16;
            this.lbSendAt.Text = "12:49 PM";
            // 
            // gpbAvatar
            // 
            this.gpbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.gpbAvatar.Image = ((System.Drawing.Image)(resources.GetObject("gpbAvatar.Image")));
            this.gpbAvatar.ImageRotate = 0F;
            this.gpbAvatar.Location = new System.Drawing.Point(3, 26);
            this.gpbAvatar.Name = "gpbAvatar";
            this.gpbAvatar.ShadowDecoration.Color = System.Drawing.Color.Fuchsia;
            this.gpbAvatar.ShadowDecoration.Enabled = true;
            this.gpbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gpbAvatar.Size = new System.Drawing.Size(35, 35);
            this.gpbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gpbAvatar.TabIndex = 14;
            this.gpbAvatar.TabStop = false;
            // 
            // MessageReceiveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.gpnlContent);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.lbSendAt);
            this.Controls.Add(this.gpbAvatar);
            this.Name = "MessageReceiveControl";
            this.Size = new System.Drawing.Size(183, 91);
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnForward;
        private Guna.UI2.WinForms.Guna2GradientPanel gpnlContent;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbSendAt;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gpbAvatar;
    }
}
