using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService
{
    public class Email
    {
        public string SendMail()
        {
            EmailMessage message = new EmailMessage
            {
                Sender = new MailboxAddress("Self", "<enter sender mail id>"),
                Reciever = new MailboxAddress("Self", "<enter receiver mail id>"),
                Subject = "Welcome",
                Content = "Hello World!"
            };
            var mimeMessage = message.CreateMimeMessageFromEmailMessage(message);
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com",465, true);
                smtpClient.Authenticate("<enter sender gmail id>","<enter sender gmail password>");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            return "Email sent successfully";
        }
    }
}
