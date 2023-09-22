using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using ServicesLayer.Interface;
using Xamarin.Essentials;
using DomainLayer.Models.User;
using RepositoryLayer.IRepository;

namespace ServicesLayer.Implementation
{
    public class EmailService : IEmail
    {
        private IEmailRepo<EmailModel> EmailRepository;
        public EmailService(IEmailRepo<EmailModel> EmailRepository)
        {
            this.EmailRepository = EmailRepository;

        }

        public void SendEmail(Message message)
        {
             EmailRepository.SendEmail(message);
        }
        

        
    }
}