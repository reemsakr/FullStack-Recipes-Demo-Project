
using DomainLayer.Models;
using DomainLayer.Models.User;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace RepositoryLayer.Repository
{
    public class EmailRepo<T> : IEmailRepo<T> where T: EmailModel
    {
        private readonly EmailModel _config;
        
        public EmailRepo(EmailModel configuration)
        {
            _config = configuration;
            
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private MailMessage CreateEmailMessage(Message message)
        {
            MailMessage mailMessage = new MailMessage();
            //mailMessage.Attachments.Add(attachment);

            mailMessage.To.Add(message.To); //receiver email
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Content;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(_config.From);
            return mailMessage;
        }
        private void Send(MailMessage mailMessage)
        {
            using SmtpClient smtpClient = new SmtpClient(_config.SmtpServer, _config.Port);
            try
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(_config.Username, _config.Password);
                Console.WriteLine(mailMessage.To);
                smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}