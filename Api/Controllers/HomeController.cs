using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit;
using MimeKit.Text;
using System.Net.Mail;
using MailKit.Net.Smtp;
using Api.Services.EmailServices;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IEmailSeervices emailSeervices;
        public HomeController(IEmailSeervices  seervices )
        {
            emailSeervices = seervices;

        }


        [HttpPost]
        public IActionResult SendEmail(EmailDto email)
        {
            //var Email = new MimeMessage();
            //Email.From.Add(MailboxAddress.Parse("patrick3@ethereal.email "));
            //Email.To.Add(MailboxAddress.Parse("patrick3@ethereal.email "));
            //Email.Subject = "Test an email";
            //Email.Body = new TextPart(TextFormat.Html)
            //{
            //    Text = body
            //};
            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect("smtp.ethereal.email",587,MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate("patrick3@ethereal.email", "bJaKcfjMxnt211z14X");
            //smtp.Send(Email);
            //smtp.Disconnect(true);

            emailSeervices.SendEmail(email);

            return Ok();


        }
    }
}
