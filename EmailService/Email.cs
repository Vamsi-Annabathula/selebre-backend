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
                Sender = new MailboxAddress("Self", "kavindersingh42@gmail.com"),
                Reciever = new MailboxAddress("Self", "kavindersingh42@gmail.com"),
                Subject = "Welcome",
                Content = "Hello World!"
            };
            var mimeMessage = message.CreateMimeMessageFromEmailMessage(message);
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com",465, true);
                smtpClient.Authenticate("kavindersingh42@gmail.com","dragoona127");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
            return "Email sent successfully";
        }
    }
}
