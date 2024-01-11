using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChatServer.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public byte[] Avatar { get; set; }
        public string Name { get; set; }
        public List<Mess> Messes {get; set;}
        public List<User> Users { get; set; }
        public bool IsConnected { get; set; }

        public Chat()
        {

        }

        public Chat(int id, byte[] avatar, string name, List<Mess> messes, List<User> users, bool isConnected)
        {
            Id = id;
            Avatar = avatar;
            Name = name;
            Messes = messes;
            Users = users;
            IsConnected = isConnected;
        }
    }
}
