using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Model.mail
{
    public  class mailmodels
    {
        public string SenderAddress { get; set; }
        public string SenderDisplayName { get; set; }
        public string UserName { get; set; }
   
        public string Password { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string EnableSSl { get; set; }

        public string UseDefaultCredentials { get; set; }
        public string IsBodyHtml { get; set; }


        //public List<IFormFile> Attachments { get; set; }
    }
}
