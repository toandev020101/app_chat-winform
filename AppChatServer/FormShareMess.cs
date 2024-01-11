using AppChatServer.Controls;
using AppChatServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChatServer
{
    public partial class FormShareMess : Form
    {
        public List<Chat> chatShares = new List<Chat>();
        public FormMain formMain;
        public Guna.UI2.WinForms.Guna2GradientButton BtnShare;
        private Mess mess;

        public FormShareMess(Mess mess, FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            this.mess = mess;
            BtnShare = btnShare;
            InitUserPanel(formMain.chats.Where(chat => chat.Users.FindIndex(user => user.Address == formMain.server.Address) != -1).ToList());
        }

        public void InitUserPanel(List<Chat> chats)
        {
            flpUser.Controls.Clear(); // Xóa bỏ tất cả các control hiện có trong flpUser (nếu có)

            chats.ForEach(chat =>
            {
                ChatCheckboxControl chatCheckboxControl = new ChatCheckboxControl(chat, this);
                flpUser.Controls.Add(chatCheckboxControl);
            });
        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchUser.Text.ToLower(); // Lấy văn bản từ TextBox và chuyển đổi sang chữ thường
            foreach (ChatCheckboxControl control in flpUser.Controls)
            {
                if (!control.LbName.Text.ToLower().Contains(searchText)) // So sánh Tag của control với văn bản tìm kiếm
                {
                    control.Visible = false; // Ẩn control không khớp với văn bản tìm kiếm
                }
                else
                {
                    control.Visible = true; // Hiển thị control khớp với văn bản tìm kiếm
                }
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            List<Socket> clientSends = new List<Socket>();


            chatShares.ForEach(chatShare =>
            {
                if(chatShare.Messes == null)
                {
                    chatShare.Messes = new List<Mess>();
                }
                mess.Option.Handle = "send";
                mess.UserSend = formMain.server;
                chatShare.Messes.Add(mess);

                chatShare.Users.ForEach(userChat =>
                {
                    if(userChat.Address != formMain.server.Address)
                    {
                        int userIndex = formMain.clientUsers.FindIndex(clientUser => clientUser.Address == userChat.Address);
                        if(userIndex != -1)
                        {
                            clientSends.Add(formMain.clientSockets[userIndex]);
                        }
                    }
                });

                if (chatShare.Id != formMain.chatActiveId)
                {
                    string chatJson = JsonConvert.SerializeObject(chatShare);
                    formMain.Send(clientSends, "message", chatJson);
                }
                else
                {
                    formMain.HandleSend(clientSends, chatShare);
                }

                formMain.UpdateChatPanel(chatShare);
            });
            
            this.Close();
        }
    }
}
