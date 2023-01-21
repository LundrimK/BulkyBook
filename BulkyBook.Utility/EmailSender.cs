using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;


            //var emailToSend = new MimeMessage();
            //emailToSend.From.Add(MailboxAddress.Parse("Hello@dotnetmastery.com"));
            //emailToSend.To.Add(MailboxAddress.Parse(email));
            //emailToSend.Subject = subject;
            //emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = htmlMessage
            //};

            ////send email
            //using(var emailClient=new SmtpClient())
            //{
            //    emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //    emailClient.Authenticate("ebookingusertest@gmail.com", "Password123!@#");
            //    emailClient.Send(emailToSend);
            //    emailClient.Disconnect(true);
            //}
            //return Task.CompletedTask;


            //gjithashtu ne mund te punojme me Session ne dotnet ne menyre me eficiente te punimit me emaila

        }
    }
}
