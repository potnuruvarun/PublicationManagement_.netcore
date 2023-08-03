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
            if (await services.Login(logindata) ==1)
            {
                HttpContext.Session.SetString("username", logindata.Email);
                return RedirectToAction("Dashboard", "Publish");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
