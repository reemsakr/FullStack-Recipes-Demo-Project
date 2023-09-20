﻿using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.User
{
    public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }

        public Message(string to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;


        }
    }
}
