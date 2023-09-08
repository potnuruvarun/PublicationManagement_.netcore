using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Services.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IloginServices iloginServices;
        IConfiguration configuration;


        public LoginController(IloginServices _iloginServices, IConfiguration configuration)
        {
            iloginServices = _iloginServices;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(loginModels logindata)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(logindata);
            if (await iloginServices.Login(logindata) == 1)
            {
                var tokenString = GenerateJSONWebToken(logindata);
                response = Ok(new { token = tokenString });
                //return Ok();
            }
            return response;

        }
        private string GenerateJSONWebToken(loginModels logindata)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Email, logindata.Email),

          };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private loginModels AuthenticateUser(loginModels models)
        {
            loginModels user = null;

            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (models.Email != null)
            {
                user = new loginModels { Email = models.Email, password = models.password };
            }
            return user;
        }


    }
}
