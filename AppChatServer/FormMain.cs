using AppChatServer.Controls;
using AppChatServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChatServer
{
    public partial class FormMain : Form
    {
        private const int MaxConnections = 100;
        private const int BufferSize = 1024 * 1000000;
        private Socket serverSocket;
        private readonly byte[] buffer = new byte[BufferSize];
        private CancellationTokenSource cancellationTokenSource;

        public User server = new User();
        List<string> emojis = new List<string>
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
        public readonly List<Socket> clientSockets = new List<Socket>();
        public List<User> clientUsers = new List<User>();
        private int chatId = 1;
        public List<Chat> chats = new List<Chat>();
        public int chatActiveId = 1;

        public FormMain()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            StartSocket();
            InitializeEmojiPanel();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat); // Thay đổi định dạng hình ảnh tùy theo nhu cầu của bạn
                return ms.ToArray();
            }
        }

        private void StartSocket()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Any;
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(ipAddress, 8888));
                serverSocket.Listen(MaxConnections);

                server.Address = ipAddress.ToString();
                server.FullName = "Server";
                server.Avatar = ImageToByteArray(Properties.Resources.avatar_admin);
                UpdateUserPanel();
                InitClientPanel();

                Task.Run(() => AcceptClients(serverSocket, cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private async Task AcceptClients(Socket serverSocket, CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    Socket clientSocket = await Task.Run(() => serverSocket.Accept());
                    Console.WriteLine("Client connected!");

                    clientSockets.Add(clientSocket);

                    _ = Task.Run(() => HandleClient(clientSocket));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        private void HandleClient(Socket clientSocket)
        {
            try
            {
                while (true)
                {
                    int bytesRead = clientSocket.Receive(buffer);
                    if (bytesRead > 0)
                    {
                        string receivedRequest = Encoding.Unicode.GetString(buffer, 0, bytesRead);

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
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                int clientIndex = clientSockets.FindIndex(client => client == clientSocket);
                if(clientIndex != -1 && clientUsers.Count > 0)
                {
                    clientUsers.RemoveAt(clientIndex);
                }
                clientSockets.Remove(clientSocket);
                clientSocket.Close();
                Console.WriteLine("Client disconnected!");
            }
        }

        public void Send(List<Socket> clientSends, string header, string data, string serverData = null, string more = null)
        {
            clientSends.ForEach(clientSend =>
            {
                byte[] dataBytes = Encoding.Unicode.GetBytes(header + "|" + data + "|" + serverData + "|" + more);
                clientSend.Send(dataBytes, SocketFlags.None);
            });
        }

        private void ProcessReceivedData(string data)
        {
            string[] dataParts = data.Split('|');

            if (dataParts[1] == "saveUser")
            {
                User user = JsonConvert.DeserializeObject<User>(dataParts[2]);
                int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == user.Address);
                if(userIndex == -1)
                {
                    clientUsers.Add(user);
                }else
                {
                    clientUsers[userIndex] = user;
                }

                List<Socket> clientSends = new List<Socket>() {
                    clientSockets[userIndex == -1 ? clientUsers.Count - 1 : userIndex]
                };

                bool isServer = false;
                chats.ForEach(chat =>
                {
                    isServer = chat.Users.FindIndex(userChat => userChat.Address == user.Address) != -1 && chat.Users.FindIndex(userChat => userChat.Address == server.Address) != -1;
                });

                if (!isServer)
                {
                    List<User> users = new List<User>()
                    {
                        user,
                        server
                    };

                    Chat serverChat = new Chat(id: chatId, avatar: null, name: null, messes: null, users, isConnected: true);
                    chats.Add(serverChat);

                    if(chatId == chatActiveId)
                    {
                        UpdateChatHeaderPanel(serverChat);
                        UpdateMessagePanel(serverChat);
                    }

                    chatId++;
                    AddChatPanel(serverChat);
                }else
                {
                    for(int i = 0; i < chats.Count; i++)
                    {
                        if (chats[i].Users.Contains(user))
                        {
                            chats[i].IsConnected = true;
                        }
                    }
                }

                List<Chat> userChats = chats.Where(chat => chat.Users.FindIndex(u => u.Address == user.Address) != -1).ToList();
                string userChatJson = JsonConvert.SerializeObject(userChats);
                Send(clientSends, dataParts[1], userChatJson);
            }
            else if (dataParts[1] == "message")
            {
                Chat chatUpdate = JsonConvert.DeserializeObject<Chat>(dataParts[2]);
                List<Socket> clientSends = new List<Socket>();

                bool isMessageServer = chatUpdate.Users.FindIndex(user => user.Address == server.Address) != -1;
                if (isMessageServer)
                {
                    int socketIndex = clientUsers.FindIndex(clientUser => clientUser.Address == dataParts[0]);
                    if (socketIndex != -1)
                    {
                        clientSends.Add(clientSockets[socketIndex]);
                    }
                    
                    Mess mess = chatUpdate.Messes.LastOrDefault();
                    mess.Option.Handle = "Receive";
                    if (chatUpdate.Id == chatActiveId)
                    {
                        mess.Readers.Add(server);
                        string chatJson = JsonConvert.SerializeObject(chatUpdate);
                        Send(clientSends, "updateChat", chatJson);
                        AddMessageReceive(mess, tag: chatUpdate.Id.ToString());
                    }
                    UpdateChatPanel(chatUpdate);
                }else
                {
                    chatUpdate.Users.ForEach(user =>
                    {
                        if(user.Address != dataParts[0])
                        {
                            int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == user.Address);

                            if (userIndex != -1)
                            {
                                clientSends.Add(clientSockets[userIndex]);
                            }
                        }
                    });

                    string chatJson = JsonConvert.SerializeObject(chatUpdate);
                    Send(clientSends, "message", chatJson);
                }

                int chatIndex = chats.FindIndex(chat => chat.Id == chatUpdate.Id);
                if (chatIndex != -1)
                {
                    chats[chatIndex] = chatUpdate;
                }

            }else if (dataParts[1] == "updateChat")
            {
                Chat chatUpdate = JsonConvert.DeserializeObject<Chat>(dataParts[2]);
                int chatIndex = chats.FindIndex(chat => chat.Id == chatUpdate.Id);
                if (chatIndex != -1)
                {
                    chats[chatIndex] = chatUpdate;
                    UpdateChatPanel(chatUpdate);
                }
            }else if(dataParts[1] == "getAllUser")
            {
                List<Socket> clientSends = new List<Socket>();
                int socketIndex = clientUsers.FindIndex(clientUser => clientUser.Address == dataParts[0]);
                if (socketIndex != -1)
                {
                    clientSends.Add(clientSockets[socketIndex]);
                }

                string clientUserJson = JsonConvert.SerializeObject(clientUsers);
                Send(clientSends, dataParts[1], clientUserJson);
            }else if (dataParts[1] == "createChat")
            {
                List<User> users = JsonConvert.DeserializeObject<List<User>>(dataParts[2]);

                Chat newChat = new Chat(id: chatId, avatar: null, name: null, messes: null, users, isConnected: true);
                chatId++;

                List<Socket> clientSends = new List<Socket>();
                users.ForEach(user =>
                {
                    int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == user.Address);
                    if (userIndex != -1)
                    {
                        clientSends.Add(clientSockets[userIndex]);
                    }
                });

                chats.Add(newChat);
                string chatJson = JsonConvert.SerializeObject(newChat);
                Send(clientSends, dataParts[1], chatJson);
            }
            else if (dataParts[1] == "createGroupChat")
            {
                Chat groupChat = JsonConvert.DeserializeObject<Chat>(dataParts[2]);

                groupChat.Id = chatId;
                chatId++;

                List<Socket> clientSends = new List<Socket>();
                groupChat.Users.ForEach(user =>
                {
                    int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == user.Address);
                    if (userIndex != -1)
                    {
                        clientSends.Add(clientSockets[userIndex]);
                    }
                });

                chats.Add(groupChat);
                string chatJson = JsonConvert.SerializeObject(groupChat);
                Send(clientSends, "createChat", chatJson);
            }else if(dataParts[1] == "disconnected")
            {
                int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == dataParts[0]);

                if (userIndex != -1)
                {
                    clientUsers.RemoveAt(userIndex);
                    clientSockets[userIndex].Close();
                    clientSockets.RemoveAt(userIndex);
                    Console.WriteLine("Client disconnected!");
                }
            }
        }

        private void AddMessageReceive(Mess mess, string tag)
        {
            Size maxSize = new Size(flpMessage.Width - 300, flpMessage.Height - 300);
            MessageReceiveControl messageReceiveControl = new MessageReceiveControl(mess, maxSize, isGroup: false, tag, formMain: this);
            FlowLayoutPanel flpReceiveMessage = new FlowLayoutPanel();
            flpReceiveMessage.FlowDirection = FlowDirection.LeftToRight;
            flpReceiveMessage.Width = flpMessage.Width - 40;

            flpReceiveMessage.Controls.Add(messageReceiveControl);
            UpdateFlowLayoutPanelHeight(flpReceiveMessage);
            flpMessage.Controls.Add(flpReceiveMessage);
        }

        public void HandleSend(List<Socket> clientSends, Chat chatUpdate)
        {
            string chatJson = JsonConvert.SerializeObject(chatUpdate);
            Send(clientSends, "message", chatJson);

            Chat chat = chats.FirstOrDefault(c => c.Id == chatActiveId);
            bool isSendAnyClient = chat != null && chat.Users.Count > 2;
            if (!isSendAnyClient)
            {
                Mess mess = chatUpdate.Messes.Last();
                string tag = chatUpdate.Id.ToString();
                AddMessageSend(mess, tag);
            }

            tbSendMessage.Clear();
            tbSendMessage.Focus();

            UpdateChatPanel(chatUpdate);
        }

        private void InitClientPanel()
        {
            if (server.Avatar != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(server.Avatar))
                {
                    gpbAvatarClient.Image = Image.FromStream(memoryStream);
                }
            }
            else
            {
                gpbAvatarClient.Image = Properties.Resources.no_avatar;
            }

            lbFullNameClient.Text = server.FullName;
            lbAddressClient.Text = server.Address;
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

        private void AddChatPanel(Chat chat)
        {
            ChatControl newChatControl = new ChatControl(chat, chat.Id == chatActiveId, address: server.Address, formMain: this);
            flpChat.Controls.Add(newChatControl);
        }

        public void CreateGroupChat(byte[] avatar, string groupName, List<User> users)
        {
            Chat groupChat = new Chat(id: chatId, avatar, name: groupName, messes: null, users, isConnected: true);
            chatId++;
            chats.Add(groupChat);
            AddChatPanel(groupChat);
        }

        public void UpdateChatPanel(Chat chat)
        {
            ChatControl newChatControl = new ChatControl(chat, chat.Id == chatActiveId, address: server.Address, formMain: this);
    
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
            if (server.Avatar != null)
            {
                using (MemoryStream memoryStream = new MemoryStream(server.Avatar))
                {
                    gpbAvatar.Image = Image.FromStream(memoryStream);
                }
            }
            else
            {
                gpbAvatar.Image = Properties.Resources.no_avatar;
            }
        }

        public void UpdateChatHeaderPanel(Chat chat)
        {
            if (string.IsNullOrEmpty(chat.Name))
            {
                User other = chat.Users.FirstOrDefault(userChat => userChat.Address != server.Address);

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

            if(chat.Messes != null)
            {
                chat.Messes.ForEach(mess =>
                {
                    if (mess.UserSend.Address == server.Address)
                    {
                        AddMessageSend(mess, tag: chat.Id.ToString());
                    }
                    else
                    {
                        AddMessageReceive(mess, tag: chat.Id.ToString());
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

        public void UpdateChat(Chat chat)
        {
            List<Socket> clientSends = new List<Socket>();
            User userChat = chat.Users.FirstOrDefault(user => user.Address != server.Address);
            int userIndex = clientUsers.FindIndex(user => user.Address == userChat.Address);
            if(userIndex != -1)
            {
                clientSends.Add(clientSockets[userIndex]);
            }

            string chatJson = JsonConvert.SerializeObject(chat);
            Send(clientSends, "updateChat", chatJson);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            List<Socket> clientSends = new List<Socket>();
            Chat chat = chats.FirstOrDefault(c => c.Id == chatActiveId);
            if(chat != null)
            {
                for (int i = 0; i < chat.Users.Count; i++)
                {
                    if (chat.Users[i].Address != server.Address)
                    {
                        int userIndex = clientUsers.FindIndex(clientUser => clientUser.Address == chat.Users[i].Address);

                        if(userIndex != -1)
                        {
                            clientSends.Add(clientSockets[userIndex]);
                        }
                    }
                }
            }

            string message = tbSendMessage.Text;
            if (!string.IsNullOrEmpty(message.Trim()))
            {
                DateTime currentDate = DateTime.Now;
                List<User> readers = new List<User>() {
                    server
                };
                MessOption messOption = new MessOption(handle: "send", type: "text");
                Mess mess = new Mess(avatar: server.Avatar, name: server.FullName, content: message, sendAt: currentDate, server, readers, option: messOption);

                Chat chatUpdate = chats.FirstOrDefault(c => c.Id == chatActiveId);
                if (chatUpdate != null)
                {
                    if(chatUpdate.Users.Count <= 2) // 1 - 1
                    {
                        if (chatUpdate.Messes == null)
                        {
                            chatUpdate.Messes = new List<Mess>();
                        }

                        chatUpdate.Messes.Add(mess);
                        HandleSend(clientSends, chatUpdate);
                    }
                    else // 1 - n
                    {
                        AddMessageSend(mess, chatUpdate.Id.ToString());
                        if(chatUpdate.Messes == null)
                        {
                            chatUpdate.Messes = new List<Mess>();
                        }
                        chatUpdate.Messes.Add(mess);
                        UpdateChatPanel(chatUpdate);
                        tbSendMessage.Clear();
                        tbSendMessage.Focus();

                        int chatIndex = chats.FindIndex(chatClient => chatClient.Id == chatUpdate.Id);
                        if(chatIndex!= -1)
                        {
                            chats[chatIndex] = chatUpdate;
                            string chatJson = JsonConvert.SerializeObject(chats);
                            string serverJson = JsonConvert.SerializeObject(server);
                            string messJson = JsonConvert.SerializeObject(mess);
                            Send(clientSends, "messageAny", chatJson, serverJson, messJson);
                        }
                    }
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
                        List<Socket> clientSends = new List<Socket>();
                        Chat chat = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (chat != null)
                        {
                            for (int i = 0; i < chat.Users.Count; i++)
                            {
                                if (chat.Users[i].Address != server.Address)
                                {
                                    clientSends.Add(clientSockets[i]);
                                }
                            }
                        }

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
                            server
                        };
                        MessOption messOption = new MessOption(handle: "send", type: "image");
                        Mess mess = new Mess(avatar: server.Avatar, name: server.FullName, content: Convert.ToBase64String(imageBytes), sendAt: currentDate, server, readers, option: messOption);

                        Chat newChat = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (newChat != null)
                        {
                            if (newChat.Users.Count <= 2) // 1 - 1
                            {
                                if (newChat.Messes == null)
                                {
                                    newChat.Messes = new List<Mess>();
                                }

                                newChat.Messes.Add(mess);
                                HandleSend(clientSends, newChat);
                            }
                            else // 1 - n
                            {
                                AddMessageSend(mess, newChat.Id.ToString());
                                if (newChat.Messes == null)
                                {
                                    newChat.Messes = new List<Mess>();
                                }
                                newChat.Messes.Add(mess);
                                UpdateChatPanel(newChat);
                                tbSendMessage.Clear();
                                tbSendMessage.Focus();

                                int chatIndex = chats.FindIndex(chatClient => chatClient.Id == newChat.Id);
                                if (chatIndex != -1)
                                {
                                    chats[chatIndex] = newChat;
                                    string chatJson = JsonConvert.SerializeObject(chats);
                                    string serverJson = JsonConvert.SerializeObject(server);
                                    string messJson = JsonConvert.SerializeObject(mess);
                                    Send(clientSends, "messageAny", chatJson, serverJson, messJson);
                                }
                            }
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
                        List<Socket> clientSends = new List<Socket>();
                        Chat chat = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (chat != null)
                        {
                            for (int i = 0; i < chat.Users.Count; i++)
                            {
                                if (chat.Users[i].Address != server.Address)
                                {
                                    clientSends.Add(clientSockets[i]);
                                }
                            }
                        }

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
                            server
                        };
                        Mess mess = new Mess(avatar: server.Avatar, name: server.FullName, content: Convert.ToBase64String(fileBytes), sendAt: currentDate, server, readers, option: messOption);

                        Chat newChat = chats.FirstOrDefault(c => c.Id == chatActiveId);
                        if (newChat != null)
                        {
                            if (newChat.Users.Count <= 2) // 1 - 1
                            {
                                if (newChat.Messes == null)
                                {
                                    newChat.Messes = new List<Mess>();
                                }

                                newChat.Messes.Add(mess);
                                HandleSend(clientSends, newChat);
                            }
                            else // 1 - n
                            {
                                AddMessageSend(mess, newChat.Id.ToString());
                                if (newChat.Messes == null)
                                {
                                    newChat.Messes = new List<Mess>();
                                }
                                newChat.Messes.Add(mess);
                                UpdateChatPanel(newChat);
                                tbSendMessage.Clear();
                                tbSendMessage.Focus();

                                int chatIndex = chats.FindIndex(chatClient => chatClient.Id == newChat.Id);
                                if (chatIndex != -1)
                                {
                                    chats[chatIndex] = newChat;
                                    string chatJson = JsonConvert.SerializeObject(chats);
                                    string serverJson = JsonConvert.SerializeObject(server);
                                    string messJson = JsonConvert.SerializeObject(mess);
                                    Send(clientSends, "messageAny", chatJson, serverJson, messJson);
                                }
                            }
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // Đóng tất cả các kết nối client
                foreach (Socket clientSocket in clientSockets)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }

                // Đóng server socket
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
                cancellationTokenSource.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception when closing server: " + ex.Message);
            }
        }

        private void btnSendAnyClient_Click(object sender, EventArgs e)
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
