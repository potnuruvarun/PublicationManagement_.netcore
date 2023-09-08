using Api.Models;

namespace Api.Services.EmailServices
{
    public interface IEmailSeervices
    {
        void SendEmail(EmailDto email);
    }
}
