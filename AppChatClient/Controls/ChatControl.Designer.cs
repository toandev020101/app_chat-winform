
namespace AppChatClient.Controls
{
    partial class ChatControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatControl));
            this.gpnlChat = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnConnected = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnNotify = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lbShortMessage = new System.Windows.Forms.Label();
            this.lbSendAt = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.gpbAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.gpnlChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // gpnlChat
            // 
            this.gpnlChat.BackColor = System.Drawing.Color.Transparent;
            this.gpnlChat.BorderRadius = 3;
            this.gpnlChat.Controls.Add(this.btnConnected);
            this.gpnlChat.Controls.Add(this.btnNotify);
            this.gpnlChat.Controls.Add(this.lbShortMessage);
            this.gpnlChat.Controls.Add(this.lbSendAt);
            this.gpnlChat.Controls.Add(this.lbName);
            this.gpnlChat.Controls.Add(this.gpbAvatar);
            this.gpnlChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gpnlChat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlChat.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlChat.Location = new System.Drawing.Point(3, 3);
            this.gpnlChat.Name = "gpnlChat";
            this.gpnlChat.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(22)))), ((int)(((byte)(32)))));
            this.gpnlChat.ShadowDecoration.Enabled = true;
            this.gpnlChat.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2, 2, 5, 7);
            this.gpnlChat.Size = new System.Drawing.Size(307, 71);
            this.gpnlChat.TabIndex = 2;
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
            this.btnConnected.Location = new System.Drawing.Point(52, 9);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnConnected.Size = new System.Drawing.Size(12, 12);
            this.btnConnected.TabIndex = 2;
            this.btnConnected.Visible = false;
            // 
            // btnNotify
            // 
            this.btnNotify.BackColor = System.Drawing.Color.Transparent;
            this.btnNotify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNotify.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotify.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotify.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotify.DisabledState.ForeColor = System.Drawing.Color.DarkGray;
            this.btnNotify.FillColor = System.Drawing.Color.Fuchsia;
            this.btnNotify.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotify.ForeColor = System.Drawing.Color.White;
            this.btnNotify.Location = new System.Drawing.Point(263, 35);
            this.btnNotify.Name = "btnNotify";
            this.btnNotify.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnNotify.Size = new System.Drawing.Size(28, 25);
            this.btnNotify.TabIndex = 2;
            this.btnNotify.Text = "5";
            this.btnNotify.Visible = false;
            // 
            // lbShortMessage
            // 
            this.lbShortMessage.AutoEllipsis = true;
            this.lbShortMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbShortMessage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShortMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbShortMessage.Location = new System.Drawing.Point(73, 40);
            this.lbShortMessage.Name = "lbShortMessage";
            this.lbShortMessage.Size = new System.Drawing.Size(183, 16);
            this.lbShortMessage.TabIndex = 1;
            this.lbShortMessage.Text = "Xin chào, mình là Đức Toàn\r\n";
            this.lbShortMessage.Visible = false;
            // 
            // lbSendAt
            // 
            this.lbSendAt.BackColor = System.Drawing.Color.Transparent;
            this.lbSendAt.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSendAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSendAt.Location = new System.Drawing.Point(228, 15);
            this.lbSendAt.Name = "lbSendAt";
            this.lbSendAt.Size = new System.Drawing.Size(69, 14);
            this.lbSendAt.TabIndex = 1;
            this.lbSendAt.Text = "17 giờ";
            this.lbSendAt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbSendAt.Visible = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(73, 15);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(64, 16);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Đức Toàn";
            // 
            // gpbAvatar
            // 
            this.gpbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.gpbAvatar.Image = ((System.Drawing.Image)(resources.GetObject("gpbAvatar.Image")));
            this.gpbAvatar.ImageRotate = 0F;
            this.gpbAvatar.Location = new System.Drawing.Point(13, 13);
            this.gpbAvatar.Name = "gpbAvatar";
            this.gpbAvatar.ShadowDecoration.Color = System.Drawing.Color.Fuchsia;
            this.gpbAvatar.ShadowDecoration.Enabled = true;
            this.gpbAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.gpbAvatar.Size = new System.Drawing.Size(45, 45);
            this.gpbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gpbAvatar.TabIndex = 0;
            this.gpbAvatar.TabStop = false;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gpnlChat);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(313, 77);
            this.gpnlChat.ResumeLayout(false);
            this.gpnlChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gpbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel gpnlChat;
        private Guna.UI2.WinForms.Guna2CircleButton btnConnected;
        private System.Windows.Forms.Label lbShortMessage;
        private System.Windows.Forms.Label lbSendAt;
        private System.Windows.Forms.Label lbName;
        private Guna.UI2.WinForms.Guna2CirclePictureBox gpbAvatar;
        private Guna.UI2.WinForms.Guna2CircleButton btnNotify;
    }
}
