using PublicationManagement.Model.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.Login
{
    public interface ILoginRepo
    {
       Task <int> login(loginModels logindata);
    }
}
