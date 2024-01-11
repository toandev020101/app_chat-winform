using AppChatClient.Controls;
using AppChatClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChatClient
{
    public partial class FormMain : Form
    {
        private Socket clientSocket;
        public IPAddress ipAddress;
        private byte[] buffer = new byte[1024 * 1000000]; // 1000 MB
        Thread receiveThread;
        private List<string> emojis = new List<string>
        {
            "😊", "😍", "😎", "😂", "😇","🤩","😘", "🥰",
            "😋", "🤗","🤔", "😉","😌", "😆", "🙃","😇",
            "😁", "😄","😅", "😆","😉", "😊", "😋", "😎",
            "😍","😘", "🤗", "🤓", "😛", "😝","😜", "😔",
            "😟", "😞", "😣","😢","😭", "😤", "😠", "😡",
            "🤬", "🤯","😳", "😱", "😨","😰", "😥", "😓",
            "😫", "🥵","🥶", "😩", "😮", "😯","😲","🥴",
            "😬", "🤐", "🤫", "🤥","😶", "😐", "😑", "😬",
            // Thêm các emoji khác vào đây nếu cần thiết
        };

        public User user;
        public List<Chat> chats = new List<Chat>();
        public int chatActiveId = 1;
        public List<User> clientUsers = new List<User>();
        private bool shouldStopThread = false;

        public FormMain()
        {
            InitializeComponent();
            StartSocket();
            InitializeEmojiPanel();
        }

        private string GenerateRandomIP(string baseIP)
        {
            Random rand = new Random();
            return $"{baseIP}.{rand.Next(1, 255)}.{rand.Next(1, 255)}";
        }

        private void StartSocket()
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ipAddress = IPAddress.Parse(GenerateRandomIP("127.0")); // Địa chỉ IP của server
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 8888);

            try
            {
                clientSocket.Connect(ipEndPoint);
                Console.WriteLine("Connected to server...");

                // Tạo một luồng riêng biệt để nhận dữ liệu từ server
                receiveThread = new Thread(SocketReceive);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("StartSocket Exception: " + ex.Message);
                StartSocket();
            }
        }

        private void SocketReceive()
        {
            try
            {
                while (!shouldStopThread)
                {
                    int receivedBytes = clientSocket.Receive(buffer);

                    if (receivedBytes > 0)
                    {
                        string receivedRequest = Encoding.Unicode.GetString(buffer, 0, receivedBytes);

                        // Xử lý dữ liệu nhận được từ server ở đây
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)delegate
                            {
                                ProcessReceivedData(receivedRequest);
                            });
                        }
                        else
                        {
                            ProcessReceivedData(receivedRequest);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SocketReceive Exception: " + ex.Message);
            }
        }

        public void Send(string ip, string header, string data)
        {
            try
            {
                string message = $"{ip}|{header}|{data}";
                byte[] messageBytes = Encoding.Unicode.GetBytes(message);
                clientSocket.Send(messageBytes, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in SendMessage: {ex.Message}");
            }
        }

        public void SaveUser()
        {
            string userJson = JsonConvert.SerializeObject(user);
            Send(ipAddress.ToString(), "saveUser", userJson);
        }

        public void GetAllUser()
        {
            Send(ipAddress.ToString(), "getAllUser", "");
        }

        private void ProcessReceivedData(string data)
        {
            string[] dataParts = data.Split('|');
            if (dataParts[0] == "saveUser")
            {
                chats = JsonConvert.DeserializeObject<List<Chat>>(dataParts[1]);
                if(chats.Count > 0)
                {
                    Chat chatActive = chats.FirstOrDefault();
                    chatActiveId = chatActive.Id;
                    UpdateChatHeaderPanel(chatActive);
                    UpdateMessagePanel(chatActive);
                }
                InitChatPanel();
                InitClientPanel();
            }
            else if (dataParts[0] == "message")
            {
                Chat chatUpdate = JsonConvert.DeserializeObject<Chat>(dataParts[1]);
                Mess mess = chatUpdate.Messes.LastOrDefault();
                mess.Option.Handle = "Receive";
                if (chatUpdate.Id == chatActiveId)
                {
                    mess.Readers.Add(user);
                    string chatJson = JsonConvert.SerializeObject(chatUpdate);
                    Send(ipAddress.ToString(), "updateChat", chatJson);
                    AddMessageReceive(mess, tag: chatUpdate.Id.ToString(), chatUpdate.Users.Count > 2);
                }

                int chatIndex = chats.FindIndex(chat => chat.Id == chatUpdate.Id);
                if (chatIndex != -1)
                {
                    chats[chatIndex] = chatUpdate;
                }

                UpdateChatPanel(chatUpdate);
            }else if (dataParts[0] == "updateChat")
            {
                Chat chatUpdate = JsonConvert.DeserializeObject<Chat>(dataParts[1]);
                int chatIndex = chats.FindIndex(chat => chat.Id == chatUpdate.Id);
                if (chatIndex != -1)
                {
                    chats[chatIndex] = chatUpdate;
                    UpdateChatPanel(chatUpdate);
                }
            }else if(dataParts[0] == "getAllUser")
            {
                clientUsers = JsonConvert.DeserializeObject<List<User>>(dataParts[1]);
            }else if(dataParts[0] == "createChat")
            {
                Chat newChat = JsonConvert.DeserializeObject<Chat>(dataParts[1]);
                chats.Add(newChat);
                AddChatPanel(newChat);
            }else if(dataParts[0] == "messageAny")
            {
                chats = JsonConvert.DeserializeObject<List<Chat>>(dataParts[1]);
                User server = JsonConvert.DeserializeObject<User>(dataParts[2]);
                Mess mess = JsonConvert.DeserializeObject<Mess>(dataParts[3]);

                Chat chatUpdate = chats.FirstOrDefault(chat => chat.Users.Count == 2 && chat.Users.FindIndex(u => u.Address == user.Address) != -1 && chat.Users.FindIndex(u => u.Address == server.Address) != -1);

                if(chatUpdate != null)
                {
                    if(chatUpdate.Messes == null)
                    {
                        chatUpdate.Messes = new List<Mess>();
                    }

                    chatUpdate.Messes.Add(mess);

                    if (chatUpdate.Id == chatActiveId)
                    {
                        mess.Readers.Add(user);
                        string chatJson = JsonConvert.SerializeObject(chatUpdate);
                        Send(ipAddress.ToString(), "updateChat", chatJson);
                        AddMessageReceive(mess, tag: chatUpdate.Id.ToString(), chatUpdate.Users.Count > 2);
                    }

                    int chatIndex = chats.FindIndex(chat => chat.Id == chatUpdate.Id);
                    if (chatIndex != -1)
                    {
                        chats[chatIndex] = chatUpdate;
                    }

                    UpdateChatPanel(chatUpdate);
                }
            }
        }

        private void AddMessageReceive(Mess mess, string tag, bool isGroup)
        {
            Size maxSize = new Size(flpMessage.Width - 300, flpMessage.Height - 300);
            MessageReceiveControl messageReceiveControl = new MessageReceiveControl(mess, maxSize, isGroup, tag, formMain: this);
            FlowLayoutPanel flpReceiveMessage = new FlowLayoutPanel();
            flpReceiveMessage.FlowDirection = FlowDirection.LeftToRight;
            flpReceiveMessage.Width = flpMessage.Width - 40;

            flpReceiveMessage.Controls.Add(messageReceiveControl);
            UpdateFlowLayoutPanelHeight(flpReceiveMessage);
            flpMessage.Controls.Add(flpReceiveMessage);
        }

        public void HandleSend(Chat chatUpdate)
        {
            string chatJson = JsonConvert.SerializeObject(chatUpdate);
            Send(ipAddress.ToString(), "message", chatJson);

            Mess mess = chatUpdate.Messes.Last();
            string tag = chatUpdate.Id.ToString();
            AddMessageSend(mess, tag);

            tbSendMessage.Clear();
            tbSendMessage.Focus();

            UpdateChatPanel(chatUpdate);
        }

        private void AddMessageSend(Mess mess, string tag)
        {
            Size maxSize = new Size(flpMessage.Width - 300, flpMessage.Height - 300);
            MessageSendControl messageSendControl = new MessageSendControl(mess, maxSize, tag, formMain: this);
            FlowLayoutPanel flpSenMessage = new FlowLayoutPanel();
            flpSenMessage.FlowDirection = FlowDirection.RightToLeft;
            flpSenMessage.Width = flpMessage.Width - 30;

            flpSenMessage.Controls.Add(messageSendControl);
            UpdateFlowLayoutPanelHeight(flpSenMessage);
            flpMessage.Controls.Add(flpSenMessage);
        }

        private void InitChatPanel()
        {
            chats.ForEach(chat =>
            {
                ChatControl newChatControl = new ChatControl(chat, chat.Id == chatActiveId, address: user.Address, formMain: this);
                flpChat.Controls.Add(newChatControl);
            });
        }

        private void InitClientPanel()
        {
            if (user.Avatar != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(user.Avatar))
                {
                    gpbAvatarClient.Image = Image.FromStream(memoryStream);
                }
            }
            else
            {
                gpbAvatarClient.Image = Properties.Resources.no_avatar;
            }

            lbFullNameClient.Text = user.FullName;
            lbAddressClient.Text = user.Address;
        }

        private void AddChatPanel(Chat chat)
        {
            ChatControl newChatControl = new ChatControl(chat, chat.Id == chatActiveId, address: user.Address, formMain: this);
            flpChat.Controls.Add(newChatControl);
        }

        public void UpdateChat(Chat chat)
        {
            string chatJson = JsonConvert.SerializeObject(chat);
            Send(ipAddress.ToString(), "updateChat", chatJson);
        }

        public void CreateChat(List<User> users)
        {
            string userJson = JsonConvert.SerializeObject(users);
            Send(ipAddress.ToString(), "createChat", userJson);
        }

        public void CreateGroupChat(byte[] avatar, string groupName, List<User> users)
        {
            Chat groupChat = new Chat(id: 0, avatar, name: groupName, messes:null, users, isConnected: true);

            string groupChatJson = JsonConvert.SerializeObject(groupChat);
            Send(ipAddress.ToString(), "createGroupChat", groupChatJson);
        }

        public void UpdateChatPanel(Chat chat)
        {
            ChatControl newChatControl = new ChatControl(chat, chat.Id == chatActiveId, address: user.Address, formMain: this);

            for (int i = 0; i < flpChat.Controls.Count; i++)
            {
                if (flpChat.Controls[i] is ChatControl currentChatControl && currentChatControl.Tag.ToString() == chat.Id.ToString())
                {
                    flpChat.Controls.RemoveAt(i);
                    flpChat.Controls.Add(newChatControl);
                    flpChat.Controls.SetChildIndex(newChatControl, i);
                    break;
                }
            }
        }

        public void UpdateUserPanel()
        {
            if(user.Avatar != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(user.Avatar))
                {
                    gpbAvatar.Image = Image.FromStream(memoryStream);
                }
            }else
            {
                gpbAvatar.Image = Properties.Resources.no_avatar;
            }
        }

        public void UpdateChatHeaderPanel(Chat chat)
        {
            if (string.IsNullOrEmpty(chat.Name))
            {
                User other = chat.Users.FirstOrDefault(userChat => userChat.Address != user.Address);

                if (other.Avatar != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(other.Avatar))
                    {
                        gpbAvatarChat.Image = Image.FromStream(memoryStream);
                    }
                }
                else
                {
                    gpbAvatarChat.Image = Properties.Resources.no_avatar;
                }

                lbNameChat.Text = other.FullName;
            }
            else
            {
                if (chat.Avatar != null)
                {
                    using (MemoryStream memoryStream = new MemoryStream(chat.Avatar))
                    {
                        gpbAvatarChat.Image = Image.FromStream(memoryStream);
                    }
                }
                else
                {
                    gpbAvatarChat.Image = Properties.Resources.no_avatar;
                }

                lbNameChat.Text = chat.Name;
            }

            btnConnected.Visible = chat.IsConnected;
            lbConnected.Text = chat.IsConnected ? "Đang hoạt động" : "Ngoại tuyến";
            lbConnected.ForeColor = chat.IsConnected ? Color.Lime : Color.Silver;
        }

        public void UpdateMessagePanel(Chat chat)
        {
            flpMessage.Controls.Clear();

            if (chat.Messes != null)
            {
                chat.Messes.ForEach(mess =>
                {
                    if (mess.UserSend.Address == user.Address)
                    {
                        AddMessageSend(mess, tag: chat.Id.ToString());
                    }
                    else
                    {
                        AddMessageReceive(mess, tag: chat.Id.ToString(), chat.Users.Count > 2);
                    }
                });
            }
        }

        private void UpdateFlowLayoutPanelHeight(FlowLayoutPanel flpItem)
        {
            int totalHeight = 0;
            foreach (Control control in flpItem.Controls)
            {
                totalHeight += control.Height + flpItem.Margin.Vertical;
            }
            flpItem.Height = totalHeight + flpItem.Padding.Vertical + 5; // 5 là để dự phòng khoảng cách
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = tbSendMessage.Text;
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                DateTime currentDate = DateTime.Now;
                List<User> readers = new List<User>()
                {
                    user
                };
                MessOption messOption = new MessOption(handle: "send", type: "text");
                Mess mess = new Mess(avatar: user.Avatar, name: user.FullName, content: message, sendAt: currentDate, user, readers, option: messOption);

                Chat chatUpdate = chats.FirstOrDefault(c => c.Id == chatActiveId);
                if (chatUpdate != null)
                {
                    if (chatUpdate.Messes == null)
                    {
                        chatUpdate.Messes = new List<Mess>();
                    }

                    chatUpdate.Messes.Add(mess);

                    HandleSend(chatUpdate);
                }
            }
        }
        private void InitializeEmojiPanel()
        {
            int columnCount = 8;
            int rowCount = (int)Math.Ceiling((double)emojis.Count / columnCount);
            int emojiIndex = 0;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    if (emojiIndex < emojis.Count)
                    {
                        Button emojiButton = new Button
                        {
                            Width = 35,
                            Height = 35,
                            Location = row == 0 && col == 0 ? new Point(5, 5) : new Point(5 + col * 35, 5 + row * 35),
                            Text = emojis[emojiIndex],
                            Font = new Font("Segoe UI Emoji", 15)
                        };
                        emojiButton.Click += EmojiButton_Click;

                        gpnlEmoji.Controls.Add(emojiButton);
                        emojiIndex++;
                    }
                }
            }

            gpnlEmoji.Location = new Point(gpnlBottomTool.Location.X + btnEmoji.Location.X + btnEmoji.Width / 2 - gpnlEmoji.Width, gpnlBottomTool.Location.Y - gpnlEmoji.Height);
            gpnlEmoji.BringToFront();
        }

        private void EmojiButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            tbSendMessage.Text += btn.Text;
        }

        private void btnEmoji_Click(object sender, EventArgs e)
        {
            gpnlEmoji.Visible = !gpnlEmoji.Visible;
            tbSendMessage.Focus();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp";
            openFileDialog.Title = "Chọn hình ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedImagePath = openFileDialog.FileName;

                    if (File.Exists(selectedImagePath))
                    {
                        byte[] imageBytes = null;
                        using (FileStream fileStream = new FileStream(selectedImagePath, FileMode.Open, FileAccess.Read))
                        {
                            using (BinaryReader binaryReader = new BinaryReader(fileStream))
                            {
                                imageBytes = binaryReader.ReadBytes((int)fileStream.Length);
                            }
                        }

                        DateTime currentDate = DateTime.Now;
                        List<User> readers = new List<User>()
                        {
                            user
                        };
                        MessOption messOption = new MessOption(handle: "send", type: "image");
                        Mess mess = new Mess(avatar: user.Avatar, name: user.FullName, content: Convert.ToBase64String(imageBytes), sendAt: currentDate, user, readers, option: messOption);

                        Chat chatUpdate = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (chatUpdate != null)
                        {
                            if (chatUpdate.Messes == null)
                            {
                                chatUpdate.Messes = new List<Mess>();
                            }
                            chatUpdate.Messes.Add(mess);

                            HandleSend(chatUpdate);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tệp hình ảnh!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*"; // Chọn tất cả các loại tệp tin
            openFileDialog.Title = "Chọn tệp tin";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFilePath = openFileDialog.FileName;

                    if (File.Exists(selectedFilePath))
                    {
                        string fileExtension = Path.GetExtension(selectedFilePath).ToLower();

                        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

                        string fileName = Path.GetFileName(selectedFilePath); // Lấy tên file từ đường dẫn đầy đủ
                        long fileSizeInBytes = new FileInfo(selectedFilePath).Length; // Kích thước tệp tin
                        double fileSizeInMB = (double)fileSizeInBytes / 1024 / 1024;

                        MessOption messOption;
                        if (imageExtensions.Contains(fileExtension))
                        {
                            messOption = new MessOption(handle: "send", type: "image");
                        }
                        else
                        {
                            messOption = new MessOption(handle: "send", type: "file", fileName, fileSizeInMB, fileExtension);
                        }

                        byte[] fileBytes = null;
                        using (FileStream fileStream = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                fileStream.CopyTo(memoryStream);
                                fileBytes = memoryStream.ToArray();
                            }
                        }

                        DateTime currentDate = DateTime.Now;
                        List<User> readers = new List<User>()
                        {
                            user
                        };
                        Mess mess = new Mess(avatar: user.Avatar, name: user.FullName, content: Convert.ToBase64String(fileBytes), sendAt: currentDate, user, readers, option: messOption);

                        Chat chatUpdate = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (chatUpdate != null)
                        {
                            if (chatUpdate.Messes == null)
                            {
                                chatUpdate.Messes = new List<Mess>();
                            }
                            chatUpdate.Messes.Add(mess);

                            HandleSend(chatUpdate);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tệp tin!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }

        }

        private void btnAddChat_Click(object sender, EventArgs e)
        {
            FormAddChat formAddChat = new FormAddChat(this);
            formAddChat.ShowDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send(ipAddress.ToString(), "disconnected", null);

            // Thiết lập biến hoặc cờ để yêu cầu dừng luồng
            shouldStopThread = true;

            // Kiểm tra xem kết nối socket có tồn tại không trước khi đóng
            if (clientSocket != null && clientSocket.Connected)
            {
                // Đóng kết nối socket và chờ cho đến khi luồng dừng hoàn toàn
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
                receiveThread.Join(); // Chờ cho đến khi luồng dừng hoàn toàn
            }
        }

        private void btnAddGroupChat_Click(object sender, EventArgs e)
        {
            FormAddGroupChat formAddGroupChat = new FormAddGroupChat(this);
            formAddGroupChat.ShowDialog();
        }

        private void tbSearchChat_TextChanged(object sender, EventArgs e)
        {
            string searchText = tbSearchChat.Text.ToLower(); // Lấy văn bản từ TextBox và chuyển đổi sang chữ thường
            foreach (ChatControl control in flpChat.Controls)
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
    }
}
