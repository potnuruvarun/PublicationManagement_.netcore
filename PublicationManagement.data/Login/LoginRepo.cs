using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublicationManagement.Common.helpers;
using PublicationManagement.Model.Config;
using PublicationManagement.Model.LoginModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
    }
}
