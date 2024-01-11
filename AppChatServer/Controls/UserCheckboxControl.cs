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
    public partial class UserCheckboxControl : UserControl
    {
        private FormAddGroupChat formAddGroupChat;
        private Color fillColor1 = Color.FromArgb(255, 152, 93);
        private Color fillColor2 = Color.FromArgb(255, 61, 87);
        private Color fillColorDefault = Color.FromArgb(17, 22, 32);

        public Label LbFullName;
        public Label LbAddress;

        public UserCheckboxControl(User user, FormAddGroupChat formAddGroupChat)
        {
            InitializeComponent();

            this.formAddGroupChat = formAddGroupChat;
            this.Tag = user.Address; // Gán một định danh duy nhất cho mỗi control chat
            LbFullName = lbFullName;
            LbAddress = lbAddress;

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

            lbFullName.Text = user.FullName;
            lbAddress.Text = user.Address;
            btnCheckbox.Checked = formAddGroupChat.userAddresses.Contains(user.Address);

            this.Click += UserCheckboxControl_Click;
            gpnlUser.Click += UserCheckboxControl_Click;
            for (int i = 0; i < gpnlUser.Controls.Count; i++)
            {
                gpnlUser.Controls[i].Click += UserCheckboxControl_Click;
            }
        }

        private void UserCheckboxControl_Click(object sender, EventArgs e)
        {
            if (!btnCheckbox.Checked)
            {
                formAddGroupChat.userAddresses.Add(this.Tag.ToString());
                ActivedControl();
                
            }
            else
            {
                formAddGroupChat.userAddresses.Remove(this.Tag.ToString());
                DeActivedControl();
            }

            formAddGroupChat.BtnCreate.Enabled = formAddGroupChat.userAddresses.Count > 1;
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
