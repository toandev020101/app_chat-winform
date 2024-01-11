﻿using AppChatServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChatServer.Controls
{
    public partial class MessageSendControl : UserControl
    {
        private FormMain formMain;
        private Mess mess;
        public MessageSendControl(Mess mess, Size maxSize, string tag, FormMain formMain)
        {
            InitializeComponent();
            InitView(mess, maxSize);
            this.formMain = formMain;
            this.mess = mess;
            this.Tag = tag;
        }

        private void InitView(Mess mess, Size maxSize)
        {
            switch (mess.Option.Type.ToLower())
            {
                case "text":
                    Label lbContent = new Label();
                    lbContent.Text = mess.Content;
                    lbContent.AutoSize = true;
                    lbContent.MaximumSize = maxSize;
                    lbContent.BackColor = Color.Transparent;
                    lbContent.ForeColor = Color.White;
                    lbContent.Padding = new Padding(12);
                    lbContent.Font = new Font("Arial", 9);
                    gpnlContent.Controls.Add(lbContent);
                    break;
                case "image":
                    Guna.UI2.WinForms.Guna2PictureBox pbContent = new Guna.UI2.WinForms.Guna2PictureBox();
                    using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(mess.Content)))
                    {
                        pbContent.Image = Image.FromStream(memoryStream);
                    }

                    pbContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right; // Hoặc thay thế bằng Dock = DockStyle.Fill
                    pbContent.MaximumSize = maxSize;
                    pbContent.BackColor = Color.WhiteSmoke;
                    pbContent.SizeMode = PictureBoxSizeMode.Zoom;
                    pbContent.BorderRadius = 10;
                    pbContent.Size = pbContent.Image.Size;

                    gpnlContent.FillColor = Color.Transparent;
                    gpnlContent.FillColor2 = Color.Transparent;
                    gpnlContent.BorderThickness = 0;
                    gpnlContent.Controls.Add(pbContent);
                    break;
                case "file":
                    byte[] fileBytes = Convert.FromBase64String(mess.Content);
                    FileControl fileControl = new FileControl(fileBytes, mess.Option.FileName, mess.Option.FileSizeInMB, mess.Option.FileExtension);

                    // Hiển thị thông tin về tệp tin trên giao diện của bạn.
                    gpnlContent.Controls.Add(fileControl);

                    break;
                default:
                    break;
            }

            lbSendAt.Text = FormatTimeDifference(mess.SendAt);
            lbSendAt.Location = new Point(lbSendAt.Location.X, gpnlContent.Location.Y + gpnlContent.Height + 5);
            btnForward.Location = new Point(0, gpnlContent.Location.Y);
            btnRemove.Location = new Point(btnForward.Location.X + btnForward.Width + 5, btnForward.Location.Y);

            bool isDeleted = mess.Option.Removes != null && formMain != null &&  mess.Option.Removes.Contains(formMain.server);
            if (isDeleted)
            {
                IsDeleted();
            }
        }

        public string FormatTimeDifference(DateTime sendAt)
        {
            TimeSpan timeDifference = DateTime.Now - sendAt;

            if (timeDifference.TotalHours < 24)
            {
                return sendAt.ToString("hh:mm tt");
            }
            else
            {
                return sendAt.ToString("hh:mm tt dd tháng mm");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá tin nhắn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                IsDeleted();

                FlowLayoutPanel flowLayoutPanel = this.Parent as FlowLayoutPanel;
                int controlIndex = flowLayoutPanel.Controls.IndexOf(this);
                if (controlIndex != -1)
                {
                    Chat chatUpdate = formMain.chats.FirstOrDefault(chat => chat.Id == int.Parse(this.Tag.ToString()));
                    if (chatUpdate.Messes[controlIndex].Option.Removes == null)
                    {
                        chatUpdate.Messes[controlIndex].Option.Removes = new List<User>();
                    }

                    chatUpdate.Messes[controlIndex].Option.Removes.Add(formMain.server);
                }
            }
        }

        public void IsDeleted()
        {
            gpnlContent.Controls.Clear();
            gpnlContent.FillColor = Color.Transparent;
            gpnlContent.FillColor2 = Color.Transparent;
            gpnlContent.BorderThickness = 1;
            gpnlContent.BorderColor = Color.Silver;
            gpnlContent.Size = new Size(0, 0);

            Label lbContent = new Label();
            lbContent.Text = "Bạn đã xoá một tin nhắn";
            lbContent.AutoSize = true;
            lbContent.BackColor = Color.Transparent;
            lbContent.ForeColor = Color.White;
            lbContent.Padding = new Padding(12);
            lbContent.Font = new Font("Arial", 9);
            gpnlContent.Controls.Add(lbContent);
            lbSendAt.Location = new Point(lbContent.Location.X + btnRemove.Width + btnForward.Width + 5, lbContent.Location.Y + lbContent.Height + 5);

            btnRemove.Visible = false;
            btnForward.Visible = false;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            new FormShareMess(mess, formMain).ShowDialog();
        }
    }
}
