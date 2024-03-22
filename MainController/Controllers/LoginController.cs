using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Services.Login;

namespace PublicationManagement.Controllers
{
    public class LoginController : Controller
    {
        IloginServices services;

        public LoginController (IloginServices _services)
        {
            services = _services;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task <IActionResult> Login(loginModels logindata)
        {
            if (
                await services.Loginn(logindata) ==1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
