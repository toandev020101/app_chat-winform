using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChatServer.Models
{
    public class Mess
    {
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime SendAt { get; set; }
        public User UserSend { get; set; }
        public List<User> Readers { get; set; }
        public MessOption Option { get; set; }

        public Mess()
        {

        }

        public Mess(byte[] avatar, string name, string content, DateTime sendAt, User userSend, List<User> readers, MessOption option)
        {
            Avatar = avatar;
            Name = name;
            Content = content;
            SendAt = sendAt;
            UserSend = userSend;
            Readers = readers;
            Option = option;
        }
    }
}
