using FluentEmail.Core.Models;

namespace SHA.FluentEmail.Api
{
    public interface IEmailService
    {
        Task<SendResponse> SendEmail(string toEmail, string subject, string body);
      
    }
}
