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
    public partial class FileControl : UserControl
    {
        private byte[] fileBytes;
        private string fileName;
        private double fileSizeInMB;
        private string fileExtension;
        string[] fileDetails = {
            "Text Files (*.txt)|*.txt",
            "PDF Files (*.pdf)|*.pdf",
            "Image Files (*.jpg;*.png)|*.jpg;*.png",
            "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx",
            "Word Files (*.doc;*.docx)|*.doc;*.docx",
            "PowerPoint Files (*.ppt;*.pptx)|*.ppt;*.pptx",
            "Audio Files (*.mp3;*.wav)|*.mp3;*.wav",
            "Video Files (*.mp4;*.avi)|*.mp4;*.avi",
            "Compressed Files (*.zip;*.rar)|*.zip;*.rar"
            // Thêm các cặp tên tệp và định dạng tệp tin tương ứng vào đây
        };
        public FileControl(byte[] fileBytes, string fileName, double fileSizeInMB, string fileExtension)
        {
            InitializeComponent();
            this.fileBytes = fileBytes;
            this.fileName = fileName;
            this.fileSizeInMB = fileSizeInMB;
            this.fileExtension = fileExtension;
            InitView();
        }

        private void InitView()
        {
            lbName.Text = fileName;
            lbSize.Text = fileSizeInMB.ToString("F2") + "MB";
            btnDownload.Location = new Point(lbName.Location.X + lbName.Width + 15, btnDownload.Location.Y);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            string fileDetail = fileDetails.FirstOrDefault((fd) => fd.Contains(fileExtension));
            string filter = "All Files (*.*)|*.*";
            if (!string.IsNullOrEmpty(fileDetail))
            {
                filter = fileDetail + "|" + filter;
            }

            // Thiết lập các thuộc tính cho SaveFileDialog
            saveFileDialog.Filter = filter; // Lọc tất cả các loại file
            saveFileDialog.FileName = fileName; // Thiết lập tên mặc định cho tệp tin
            saveFileDialog.Title = "Lưu tệp tin"; // Tiêu đề của hộp thoại
            // Mở hộp thoại cho người dùng chọn nơi lưu và tên file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Ghi dữ liệu byte vào đường dẫn tệp tin đã chọn
                    File.WriteAllBytes(filePath, fileBytes);
                    MessageBox.Show("Lưu tệp tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
    }
}
