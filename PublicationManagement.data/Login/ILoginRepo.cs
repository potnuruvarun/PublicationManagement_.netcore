using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;

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

        Task<int> Registration(RegistartionModel models);

       Task <IEnumerable<RegistartionModel>> Registrationdata();


        Task<IEnumerable<RegistartionModel>> Profile();

        //void SendEmail(Message message);



    }
}
