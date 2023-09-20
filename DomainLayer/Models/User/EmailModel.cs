using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.User
{
    public class EmailModel
    {
        /*
        public  string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public EmailModel(String to,String subject,String content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
        /*/
        public string From { get; set; } = null!;
        public string SmtpServer { get; set; } = null!;
        public int Port { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
