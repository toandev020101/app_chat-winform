using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppChatClient.Models
{
    public class MessOption
    {
        public string Handle { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public double FileSizeInMB { get; set; }
        public string FileExtension { get; set; }
        public List<User> Removes { get; set; }
        public MessOption()
        {
        }

        public MessOption(string handle, string type)
        {
            Handle = handle;
            Type = type;
        }

        public MessOption(string handle, string type, string fileName, double fileSizeInMB, string fileExtension)
        {
            Handle = handle;
            Type = type;
            FileName = fileName;
            FileSizeInMB = fileSizeInMB;
            FileExtension = fileExtension;
        }
    }
}
