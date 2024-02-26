using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Login
{
    public interface IloginServices
    {
        Task<int> Login(loginModels logindata);
        Task<int> registration(RegistartionModel models);


        Task<IEnumerable<RegistartionModel>> Registartiondata();

        Task<IEnumerable<RegistartionModel>> profilepic();

        Task<int> otpverify(otpmodel model);

        Task<int> resetpassword(otpmodel model);

    }
}
