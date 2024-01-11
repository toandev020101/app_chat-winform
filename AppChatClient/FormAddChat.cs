using AppChatClient.Controls;
using AppChatClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AppChatClient
{
    public partial class FormAddChat : Form
    {
        public string userAddress = null;
        private Timer timer;
        private FormMain formMain;
        public Guna.UI2.WinForms.Guna2GradientButton BtnCreate;

        public FormAddChat(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
            BtnCreate = btnCreate;
            formMain.GetAllUser();

            timer = new Timer();
            timer.Interval = 500; // Ví dụ: Timer chạy sau 0.5 giây

            // Gán sự kiện Tick cho Timer
            timer.Tick += new EventHandler(timer_Tick);

            // Bắt đầu Timer
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            InitUserPanel(formMain.clientUsers);
            timer.Stop();
        }

        public void InitUserPanel(List<User> users)
        {
            flpUser.Controls.Clear(); // Xóa bỏ tất cả các control hiện có trong flpUser (nếu có)

            users.ForEach(user =>
            {
                if (user.Address != formMain.user.Address)
                {
                    UserRadioControl userRadioControl = new UserRadioControl(user, this);
                    flpUser.Controls.Add(userRadioControl);
                }
            });
        }

        private void tbSearchUser_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchUser.Text.ToLower(); // Lấy văn bản từ TextBox và chuyển đổi sang chữ thường
            foreach (UserRadioControl control in flpUser.Controls)
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
            List<User> users = formMain.clientUsers.Where(user => user.Address == userAddress).ToList();
            users.Add(formMain.user);
            formMain.CreateChat(users);
            this.Close();
        }
    }
}
