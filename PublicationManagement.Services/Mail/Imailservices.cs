using PublicationManagement.Model.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Mail
{
    public  interface Imailservices
    {
        Task SendEmailAsync(MailRequest mailrequest);

        Task SendEmail(string toEmail, string subject, string body);


    }
}
