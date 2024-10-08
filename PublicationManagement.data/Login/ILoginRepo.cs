﻿using PublicationManagement.Model.LoginModels;
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
        Task<int> loginn(loginModels logindata);
        Task<loginresponse> login(loginModels logindata);

        Task<int> Registration(RegistartionModel models);

        Task<IEnumerable<RegistartionModel>> Registrationdata();


        Task<IEnumerable<RegistartionModel>> Profile();

        Task<int> otpverification(otpmodel model);
        Task<int> restpasssword(otpmodel model);

        Task<int> verify(loginModels models);


        //void SendEmail(Message message);



    }
}
