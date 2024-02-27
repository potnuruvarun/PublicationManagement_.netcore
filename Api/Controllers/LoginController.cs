using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;
using PublicationManagement.Services.Login;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Net.Http.Json;
using Api.Services.EmailServices;
using Microsoft.VisualBasic;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IloginServices iloginServices;
        IConfiguration configuration;
        IEmailSeervices mailserv;
        public LoginController(IloginServices _iloginServices, IConfiguration configuration, IEmailSeervices _mailserv)
        {
            iloginServices = _iloginServices;
            this.configuration = configuration;
            mailserv = _mailserv;
        }
        private Dictionary<string, DateTime> _otpDict = new Dictionary<string, DateTime>();

        public class OtpData
        {
            public DateTime Expiration { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login(loginModels logindata)
        {
            IActionResult response = Unauthorized();
            AuthenticateUser(logindata);
            if (await iloginServices.Login(logindata) == 1)
            {
                var tokenString = GenerateJSONWebToken(logindata);
                response = Ok(new { token = tokenString });
                //return Ok();
            }
            return response;

        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Registration([FromForm] RegistartionModel models)
        {

            if (models.photodata != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await models.photodata.CopyToAsync(memoryStream);
                    models.ProfilePhoto = memoryStream.ToArray();
                }
            }

            if (await iloginServices.registration(models) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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

        private int GenerateRandomOtp()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999); // Generates a random 6-digit OTP
        }

        [HttpPost]
        [Route("{email}")]
        public async Task<IActionResult> SendOtp(string email)
        {

            var otp = GenerateRandomOtp();
            //DateTime expiration = DateAndTime.Now.AddMinutes(2);
            //_otpDict[email] = expiration;
            //OtpData data = new OtpData()
            //{
            //    Expiration = expiration
            //};
            var model = new otpmodel
            {
                email = email,
                otp = otp
            };

            // Send the OTP via email
            var subject = "Your One-Time Password (OTP)";
            var body = $"Your OTP is: {otp}";

            await mailserv.SendEmail(email, subject, body);
            if (
            await iloginServices.otpverify(model) == 1)
            {
                return Ok("OTP sent successfully");
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("reset")]
        public async Task<IActionResult> reset(otpmodel models)
        {
           
            if (await iloginServices.resetpassword(models) == 1)
            {
                return Ok("OTP sent successfully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Sendinmail")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await mailserv.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //[HttpPost("api/send-sms")]
        //public IActionResult SendSms(SmsMessage model)
        //{
        //    var message = MessageResource.Create(
        //        to: new PhoneNumber(model.To),
        //        from: new PhoneNumber(model.From),
        //        body: model.Message,
        //        client: _client); // pass in the custom client
        //    return Ok(message.Sid);
        //}





    }
}
