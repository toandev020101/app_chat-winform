
namespace AppChatServer.Controls
{
    partial class MessageSendControl
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
            this.btnForward = new Guna.UI2.WinForms.Guna2Button();
            this.gpnlContent = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lbSendAt = new System.Windows.Forms.Label();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
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
            this.btnForward.Image = global::AppChatServer.Properties.Resources.forward_left;
            this.btnForward.ImageSize = new System.Drawing.Size(18, 18);
            this.btnForward.Location = new System.Drawing.Point(3, 6);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(30, 30);
            this.btnForward.TabIndex = 17;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // gpnlContent
            // 
            this.gpnlContent.AutoSize = true;
            this.gpnlContent.BorderRadius = 10;
            this.gpnlContent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.gpnlContent.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(165)))));
            this.gpnlContent.Location = new System.Drawing.Point(71, 2);
            this.gpnlContent.Name = "gpnlContent";
            this.gpnlContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpnlContent.Size = new System.Drawing.Size(61, 37);
            this.gpnlContent.TabIndex = 14;
            // 
            // lbSendAt
            // 
            this.lbSendAt.AutoEllipsis = true;
            this.lbSendAt.AutoSize = true;
            this.lbSendAt.BackColor = System.Drawing.Color.Transparent;
            this.lbSendAt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSendAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbSendAt.Location = new System.Drawing.Point(73, 48);
            this.lbSendAt.Name = "lbSendAt";
            this.lbSendAt.Size = new System.Drawing.Size(58, 15);
            this.lbSendAt.TabIndex = 13;
            this.lbSendAt.Text = "12:49 PM";
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
            this.btnRemove.Location = new System.Drawing.Point(37, 6);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 30);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // MessageSendControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.gpnlContent);
            this.Controls.Add(this.lbSendAt);
            this.Name = "MessageSendControl";
            this.Size = new System.Drawing.Size(135, 66);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnForward;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2GradientPanel gpnlContent;
        private System.Windows.Forms.Label lbSendAt;
    }
}
