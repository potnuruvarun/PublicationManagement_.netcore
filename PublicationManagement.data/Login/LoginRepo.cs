using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublicationManagement.Common.helpers;
using PublicationManagement.Model.Config;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.Login
{
    public class LoginRepo : BaseRepository, ILoginRepo
    {
        public IConfiguration configuration;
        public LoginRepo(IOptions<DataConfig> connectionString, IConfiguration config = null) : base(connectionString, config)
        {
            configuration=config;
        }

        public async Task <int> login(loginModels logindata)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", logindata.Email);
            parameters.Add("password", logindata.password);
            var data=await  QueryFirstOrDefaultAsync<int>(StorageProcedure.login, parameters,commandType:CommandType.StoredProcedure);
            if (data != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public async Task<int> otpverification(otpmodel model)
        {
            var para = new DynamicParameters();
            para.Add("@email", model.email);
            para.Add("@otp", model.otp);
            var data=await ExecuteAsync<int>(StorageProcedure._spotp,para,commandType:CommandType.StoredProcedure);
            if (data != 0)
            {
                return 1;
            }
            else
                return 0;
        }

        public async Task<int> restpasssword(otpmodel model)
        {
            var para = new DynamicParameters();
            para.Add("@email", model.email);
            para.Add("@otp", model.otp);
            para.Add("@password", model.password);
            var data = await ExecuteAsync<int>(StorageProcedure.sp_resetpassword, para, commandType: CommandType.StoredProcedure);
            if (data != 0)
            {
                return 1;
            }
            else
                return 0;
        }



        public async Task<IEnumerable<RegistartionModel>> Profile()
        {
            var parameter=new DynamicParameters();
            parameter.Add("@Email");
            return await QueryAsync<RegistartionModel>(StorageProcedure.sp_profilephoto,parameter,commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Registration(RegistartionModel models)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@Fullname", models.Fullname);
            parameters.Add("@MobileNumber", models.MobileNumber);
            parameters.Add("@Email", models.Email);
            parameters.Add("@password", models.password);
            parameters.Add("@Address", models.Address);
            parameters.Add("@Profilephoto", models.ProfilePhoto);
            var data = await ExecuteAsync<int>(StorageProcedure.registration, parameters, commandType: CommandType.StoredProcedure);
            if (data != 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        
        }

        public async Task<IEnumerable<RegistartionModel>> Registrationdata()
        {
           return await  QueryAsync<RegistartionModel>(StorageProcedure.registrationdata, commandType:CommandType.StoredProcedure);
        }


    }
}
