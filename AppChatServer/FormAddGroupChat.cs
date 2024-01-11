using AppChatServer;
using AppChatServer.Controls;
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

namespace AppChatServer
{
    public partial class FormAddGroupChat : Form
    {
        public List<string> userAddresses = new List<string>();
        private FormMain formMain;
        public Guna.UI2.WinForms.Guna2GradientButton BtnCreate;
        private string avatarPath;

        public FormAddGroupChat(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            BtnCreate = btnCreate;
            InitUserPanel(formMain.clientUsers);
        }

        public void InitUserPanel(List<User> users)
        {
            flpUser.Controls.Clear(); // Xóa bỏ tất cả các control hiện có trong flpUser (nếu có)

            users.ForEach(user =>
            {
                if (user.Address != formMain.server.Address)
                {
                    UserCheckboxControl userRadioControl = new UserCheckboxControl(user, this);
                    flpUser.Controls.Add(userRadioControl);
                }
            });
        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchUser.Text.ToLower(); // Lấy văn bản từ TextBox và chuyển đổi sang chữ thường
            foreach (UserCheckboxControl control in flpUser.Controls)
            {
                if (!control.LbFullName.Text.ToLower().Contains(searchText) && !control.LbAddress.Text.ToLower().Contains(searchText)) // So sánh Tag của control với văn bản tìm kiếm
                {
                    control.Visible = false; // Ẩn control không khớp với văn bản tìm kiếm
                }
                else
                {
                    control.Visible = true; // Hiển thị control khớp với văn bản tìm kiếm
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                tbName.BorderColor = Color.FromArgb(211, 47, 47);
                lbNameError.Text = "Vui lòng nhập tên nhóm!";
                lbNameError.Visible = true;
            }
            else
            {
                List<User> users = formMain.clientUsers.Where(user => userAddresses.Contains(user.Address)).ToList();
                users.Add(formMain.server);

                byte[] avatar = null;
                if (!string.IsNullOrEmpty(avatarPath))
                {
                    using (FileStream fileStream = new FileStream(avatarPath, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            avatar = binaryReader.ReadBytes((int)fileStream.Length);
                        }
                    }
                }

                string groupName = tbName.Text;

                formMain.CreateGroupChat(avatar, groupName, users);
                this.Close();
            }
        }

        private void gpbAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    avatarPath = openFileDialog.FileName;
                    gpbAvatar.Image = new Bitmap(avatarPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            tbName.BorderColor = Color.FromArgb(213, 218, 223);
            lbNameError.Visible = false;
        }
    }
}
