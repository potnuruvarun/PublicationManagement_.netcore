using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Model.LoginModels
{
    public class loginModels
    {
        public string? Email { get; set; }
        public string? password { get; set; }
    }

    public class loginresponse
    {
        public int Active { get; set; }
        
    }
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string DisplayName { get; set; }

        public string Host { get; set; }

    }

    public class otpmodel
    {
        public string email { get; set; }
        public int otp { get; set; }
        public string password { get; set; }
    }
    public class GoogleAuthConfig
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
    public class GoogleSignInVM
    {
        [Required]
        public string IdToken { get; set; }
    }
}
