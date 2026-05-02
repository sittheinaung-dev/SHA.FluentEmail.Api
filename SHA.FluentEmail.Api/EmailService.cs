using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace SHA.FluentEmail.Api
{
    public class EmailService : IEmailService
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public Task<SendResponse> SendEmail(string email, string subject, string message)
        {
            var htmlBody = message.Replace("\r\n", "<br />").Replace("\n", "<br />");

            return _fluentEmail
                .To(email)
                .Subject(subject)
                .Body(htmlBody, isHtml: true)
                .SendAsync();
        }
        //public Task SendEmail(string email, string subject, string message)
        //{

        //    var mail = "sittheinaung8@gmail.com";
        //    var password = "udov ldln okss lxrf";

        //    var client = new SmtpClient
        //    {
        //        // Depends on the smtp server of your email (gmail -> smtp.gmail.com)
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        Credentials = new System.Net.NetworkCredential(mail, password)
        //    };

        //    var mailMessage = new MailMessage
        //    {
        //        From = new MailAddress(mail),
        //        To = { new MailAddress(email) },
        //        Subject = subject,
        //        Body = message,
        //        IsBodyHtml = true,
        //    };

        //    return client.SendMailAsync(
        //        mailMessage
        //    );
        //}



    }
}
