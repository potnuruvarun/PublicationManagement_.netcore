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


    }
}
