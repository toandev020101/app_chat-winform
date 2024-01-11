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

namespace AppChatClient
{
    public partial class FormSetting : Form
    {
        private FormMain formMain;
        private string avatarPath;
        public FormSetting()
        {
            InitializeComponent();
            formMain = new FormMain();
            tbAddress.Text = formMain.ipAddress.ToString();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            string fullName = tbFullName.Text;
            if (string.IsNullOrEmpty(fullName))
            {
                tbFullName.BorderColor = Color.FromArgb(211, 47, 47);
                lbFullNameError.Text = "Vui lòng nhập họ và tên!";
                lbFullNameError.Visible = true;
            }
            else
            {
                this.Hide();
                User user = new User();

                if (!string.IsNullOrEmpty(avatarPath))
                {
                    using (FileStream fileStream = new FileStream(avatarPath, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            user.Avatar = binaryReader.ReadBytes((int)fileStream.Length);
                        }
                    }
                }

                user.FullName = tbFullName.Text;
                user.Address = tbAddress.Text;

                formMain.user = user;
                formMain.SaveUser();
                formMain.UpdateUserPanel();
                formMain.Show();
            }
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    avatarPath = openFileDialog.FileName;
                    btnUploadAvatar.Image = new Bitmap(avatarPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void tbFullName_TextChanged(object sender, EventArgs e)
        {
            tbFullName.BorderColor = Color.FromArgb(213, 218, 223);
            lbFullNameError.Visible = false;
        }
    }
}
