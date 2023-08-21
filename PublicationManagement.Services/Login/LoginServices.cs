using PublicationManagement.data.Login;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Login
{
    public class LoginServices : IloginServices
    {
        ILoginRepo repo;

        public LoginServices(ILoginRepo _repo)
        {
            repo = _repo;
        }
        public async  Task< int> Login(loginModels logindata)
        {
          return await  repo.login(logindata);
        }

        public async Task<IEnumerable<RegistartionModel>> profilepic()
        {
            return await repo.Profile();
        }

        public async Task<IEnumerable<RegistartionModel>> Registartiondata()
        {
            return await repo.Registrationdata();
        }

        public async Task<int> registration(RegistartionModel models)
        {
            return await repo.Registration(models);
        }
    }
}
