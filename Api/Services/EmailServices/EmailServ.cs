using Api.Models;
using MimeKit.Text;
using MimeKit;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Api.Services.EmailServices
{
    public class EmailServ : IEmailSeervices
    {
        private readonly IConfiguration _configuration;
        public EmailServ(IConfiguration configuration) { 

            _configuration = configuration;
        }
        public void SendEmail(EmailDto email)
        {
            var Email = new MimeMessage();
            Email.From.Add(MailboxAddress.Parse("patrick3@ethereal.email "));
            Email.To.Add(MailboxAddress.Parse(email.To));
            Email.Subject = email.Subject;
            Email.Body = new TextPart(TextFormat.Html)
            {
                Text = email.Body
            };
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(Email);
            smtp.Disconnect(true);
        }
    }
}
