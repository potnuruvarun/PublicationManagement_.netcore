using Api.Models;
using PublicationManagement.Model.LoginModels;

namespace Api.Services.EmailServices
{
    public interface IEmailSeervices
    {
        Task SendEmailAsync(MailRequest mailRequest);

        Task SendEmail(string toEmail, string subject, string body);

    }
}
