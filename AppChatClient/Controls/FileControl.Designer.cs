
namespace AppChatClient.Controls
{
    partial class FileControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileControl));
            this.lbSize = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbSize.Location = new System.Drawing.Point(73, 44);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(29, 13);
            this.lbSize.TabIndex = 4;
            this.lbSize.Text = "2MB";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(72, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(143, 16);
            this.lbName.TabIndex = 5;
            this.lbName.Text = "Lap-trinh-window.pdf";
            // 
            // btnDownload
            // 
            this.btnDownload.BorderRadius = 5;
            this.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDownload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDownload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDownload.FillColor = System.Drawing.Color.White;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Image = ((System.Drawing.Image)(resources.GetObject("btnDownload.Image")));
            this.btnDownload.ImageSize = new System.Drawing.Size(22, 22);
            this.btnDownload.Location = new System.Drawing.Point(230, 22);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(30, 30);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::AppChatClient.Properties.Resources.document;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(11, 14);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(50, 50);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "FileControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(278, 77);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.Label lbName;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}
