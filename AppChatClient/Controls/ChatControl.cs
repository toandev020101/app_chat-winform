using AppChatClient.Models;
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

namespace AppChatClient.Controls
{
    public partial class ChatControl : UserControl
    {
        private Color fillColor1 = Color.FromArgb(250, 48, 90);
        private Color fillColor2 = Color.FromArgb(128, 36, 206);
        private Color fillColorDefault = Color.FromArgb(17, 22, 32);

        private FormMain formMain;
        public Label LbName;

        public ChatControl(Chat chat, bool isActived, string address, FormMain formMain)
        {
            InitializeComponent();
            InitView(chat, isActived, address);
            this.formMain = formMain;
            LbName = lbName;

            this.Click += ChangeActive_Click;
            gpnlChat.Click += ChangeActive_Click;
            for (int i = 0; i < gpnlChat.Controls.Count; i++)
            {
                gpnlChat.Controls[i].Click += ChangeActive_Click;
            }
        }

        private void ChangeActive_Click(object sender, EventArgs e)
        {
            if (formMain.chatActiveId != int.Parse(this.Tag.ToString()))
            {
                for (int i = 0; i < this.Parent.Controls.Count; i++)
                {
                    ChatControl chatControl = this.Parent.Controls[i] as ChatControl;
                    chatControl.DeActivedControl();
                }

                formMain.chatActiveId = int.Parse(this.Tag.ToString());
                this.ActivedControl();

                Chat chatActive = formMain.chats.FirstOrDefault(chat => chat.Id == formMain.chatActiveId);
                if (chatActive != null)
                {
                    formMain.UpdateChatHeaderPanel(chatActive);
                    formMain.UpdateMessagePanel(chatActive);

                    if (chatActive.Messes != null)
                    {
                        for (int i = 0; i < chatActive.Messes.Count; i++)
                        {
                            Mess mess = chatActive.Messes[i];
                            bool isReaded = mess.Readers.Contains(formMain.user);
                            if (!isReaded)
                            {
                                mess.Readers.Add(formMain.user);
                                chatActive.Messes[i] = mess;
                            }
                        }

                        int chatIndex = formMain.chats.FindIndex(chat => chat.Id == formMain.chatActiveId);
                        if (chatIndex != -1)
                        {
                            formMain.chats[chatIndex] = chatActive;
                            formMain.UpdateChat(chatActive);
                            formMain.UpdateChatPanel(chatActive);
                        }
                    }
                }
            }
        }

        private void InitView(Chat chat, bool isActived, string address)
        {
            this.Margin = new Padding(10, 0, 10, 10);
            this.Tag = chat.Id.ToString(); // Gán một định danh duy nhất cho mỗi control chat

            if (isActived)
            {
                ActivedControl();
            }

            if (chat.IsConnected)
            {
                btnConnected.Visible = true;
            }

            if (chat.Name == null)
            {
                User user = chat.Users.FirstOrDefault(u => u.Address != address);
                if (user != null)
                {
                    if (user.Avatar != null)
                    {
                        using (MemoryStream memoryStream = new MemoryStream(user.Avatar))
                        {
                            gpbAvatar.Image = Image.FromStream(memoryStream);
                        }
                    }
                    else
                    {
                        gpbAvatar.Image = Properties.Resources.no_avatar;
                    }

                    lbName.Text = user.FullName;
                }
            }
            else
            {
                if (chat.Avatar != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(chat.Avatar))
                    {
                        gpbAvatar.Image = Image.FromStream(memoryStream);
                    }
                }
                else
                {
                    gpbAvatar.Image = Properties.Resources.group_avatar_buddyboss;
                }

                lbName.Text = chat.Name;
            }

            if (chat.Messes != null)
            {
                Mess messLastest = chat.Messes.Last();
                lbSendAt.Visible = true;
                lbSendAt.Text = FormatTimeDifference(messLastest.SendAt);

                lbShortMessage.Visible = true;
                string lbText = "";

                if (chat.Users.Count > 2)
                {
                    if (formMain != null && messLastest.UserSend.Address == formMain.user.Address)
                    {
                        lbText += "Bạn: ";
                    }
                    else
                    {
                        lbText += messLastest.UserSend.FullName + ": ";
                    }
                }
                else
                {
                    if (formMain != null && messLastest.UserSend.Address == formMain.user.Address)
                    {
                        lbText += "Bạn: ";
                    }
                }

                if (messLastest.Option.Type.ToLower() == "text")
                {
                    lbText += messLastest.Content;
                }
                else if (messLastest.Option.Type.ToLower() == "image")
                {
                    lbText += "[Hình ảnh]";
                }
                else if (messLastest.Option.Type.ToLower() == "file")
                {
                    lbText += "[File: ] " + messLastest.Option.FileName;
                }

                lbShortMessage.Text = lbText;

                int notify = chat.Messes.Count(mess => mess.Readers.All(reader => reader.Address != address));
                if (notify > 0)
                {
                    btnNotify.Visible = true;
                    btnNotify.Text = notify.ToString();
                }
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

        public void DeActivedControl()
        {
            gpnlChat.FillColor = fillColorDefault;
            gpnlChat.FillColor2 = fillColorDefault;
        }

        public void ActivedControl()
        {
            gpnlChat.FillColor = fillColor1;
            gpnlChat.FillColor2 = fillColor2;
        }
    }
}
