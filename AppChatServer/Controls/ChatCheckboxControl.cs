using AppChatServer.Models;
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
    public partial class ChatCheckboxControl : UserControl
    {
        private FormShareMess formShareMess;
        private Chat chat;
        private Color fillColor1 = Color.FromArgb(255, 152, 93);
        private Color fillColor2 = Color.FromArgb(255, 61, 87);
        private Color fillColorDefault = Color.FromArgb(17, 22, 32);

        public Label LbName;

        public ChatCheckboxControl(Chat chat, FormShareMess formShareMess)
        {
            InitializeComponent();

            this.formShareMess = formShareMess;
            this.chat = chat;
            this.Tag = chat.Id; // Gán một định danh duy nhất cho mỗi control chat
            LbName = lbName;

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
            

            if (string.IsNullOrEmpty(chat.Name))
            {
                User user = chat.Users.FirstOrDefault(userChat => userChat.Address != formShareMess.formMain.server.Address);
                
                if(user != null)
                {
                    lbName.Text = user.FullName;

                    if(chat.Users.Count == 2)
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
                    }
                }
            }
            else
            {
                lbName.Text = chat.Name;
            }

            btnCheckbox.Checked = formShareMess.chatShares.Contains(chat);

            this.Click += UserCheckboxControl_Click;
            gpnlUser.Click += UserCheckboxControl_Click;
            for (int i = 0; i < formShareMess.Controls.Count; i++)
            {
                gpnlUser.Controls[i].Click += UserCheckboxControl_Click;
            }
        }

        private void UserCheckboxControl_Click(object sender, EventArgs e)
        {
            if (!btnCheckbox.Checked)
            {
                formShareMess.chatShares.Add(chat);
                ActivedControl();
                
            }
            else
            {
                formShareMess.chatShares.Remove(chat);
                DeActivedControl();
            }

            formShareMess.BtnShare.Enabled = formShareMess.chatShares.Count > 0;
        }

        public void DeActivedControl()
        {
            gpnlUser.FillColor = fillColorDefault;
            gpnlUser.FillColor2 = fillColorDefault;
            btnCheckbox.Checked = false;
        }

        public void ActivedControl()
        {
            gpnlUser.FillColor = fillColor1;
            gpnlUser.FillColor2 = fillColor2;
            btnCheckbox.Checked = true;
        }
    }
}
