using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Model.RegistrationModels
{
    public class RegistartionModel
    {

        public string? Fullname { get; set; }
        public string? MobileNumber { get; set; }

        public string? Email { get; set; }

        public string? password { get; set; }

        public string? Address { get; set; }

        public IFormFile photodata { get; set; }


        public byte[]? ProfilePhoto { get; set; }

        public int Active { get; set; }

    }
}
