using PublicationManagement.Model.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Login
{
    public interface IloginServices
    {
       Task <int> Login(loginModels logindata);

    }
}
