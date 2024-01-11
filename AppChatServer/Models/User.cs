using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChatServer.Models
{
    public class User
    {
        public byte[] Avatar { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public User()
        {

        }
    }
}
