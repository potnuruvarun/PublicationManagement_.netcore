using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Services.Login;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IloginServices iloginServices;


        public LoginController(IloginServices _iloginServices)
        {
            iloginServices = _iloginServices;
        }

        [HttpPost]
        public async Task< IActionResult> Login(loginModels logindata)
        {

            if (await iloginServices.Login(logindata) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }





        }


    }
}
