using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PublicationManagement.data;
using PublicationManagement.Model.mail;
using PublicationManagement.Services;
using System.Configuration;
using System.Text;

namespace Api
{
    public static class RegisterServices
    {
        public static void RegisterService(this IServiceCollection services)
        {
          
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServiceRegister.GetTypes());
        }

        public static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();
            services.AddMvc();
            services.AddHttpContextAccessor();
        }
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            services.AddMvc();
        }

       


    }
}
