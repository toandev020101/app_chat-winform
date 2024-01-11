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
    public partial class UserRadioControl : UserControl
    {
        private FormAddChat formAddChat;
        private Color fillColor1 = Color.FromArgb(255, 152, 93);
        private Color fillColor2 = Color.FromArgb(255, 61, 87);
        private Color fillColorDefault = Color.FromArgb(17, 22, 32);

        public Label LbFullName;
        public Label LbAddress;

        public UserRadioControl(User user, FormAddChat formAddChat)
        {
            InitializeComponent();
            this.formAddChat = formAddChat;
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
            btnRadio.Checked = user.Address == formAddChat.userAddress;

            this.Click += UserRadioControl_Click;
            gpnlUserRadioButton.Click += UserRadioControl_Click;
            for(int i = 0; i < gpnlUserRadioButton.Controls.Count; i++)
            {
                gpnlUserRadioButton.Controls[i].Click += UserRadioControl_Click;
            }
        }

        private void UserRadioControl_Click(object sender, EventArgs e)
        {
            if (!btnRadio.Checked)
            {
                formAddChat.userAddress = this.Tag.ToString();
                for(int i = 0; i < this.Parent.Controls.Count; i++)
                {
                    UserRadioControl userRadioControl = this.Parent.Controls[i] as UserRadioControl;
                    userRadioControl.DeActivedControl();
                }

                ActivedControl();
                formAddChat.BtnCreate.Enabled = true;
            }
        }

        public void DeActivedControl()
        {
            gpnlUserRadioButton.FillColor = fillColorDefault;
            gpnlUserRadioButton.FillColor2 = fillColorDefault;
            btnRadio.Checked = false;
        }

        public void ActivedControl()
        {
            gpnlUserRadioButton.FillColor = fillColor1;
            gpnlUserRadioButton.FillColor2 = fillColor2;
            btnRadio.Checked = true;
        }
    }
}
