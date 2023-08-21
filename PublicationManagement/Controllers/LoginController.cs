using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicationManagement.Model.LoginModels;
using PublicationManagement.Model.RegistrationModels;
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
        //public async Task<byte[]> GetProfilePhotoByEmail(string email)
        //{
        //    // Your database query logic here to fetch the profile photo byte array based on email
        //    // Example using Entity Framework Core:
        //    var user = await services.Registartiondata(x=>x.Email==email);
        //    if (user != null)
        //    {
        //        return user.ProfilePhoto; // Assuming ProfilePhoto is a byte[] property in your User model
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public Task<IActionResult>

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task <IActionResult> Login(loginModels logindata)
        {

            var data = await services.profilepic();
            ViewBag.data = data;
            if (await services.Login(logindata) ==1)
            {
                HttpContext.Session.SetString("username", logindata.Email);
                //byte[] profilePhotoBytes =data(model.ProfilePhoto);
                //string base64ProfilePhoto = Convert.ToBase64String(profilePhotoBytes);

                //HttpContext.Session.SetString("profilePhoto", base64ProfilePhoto);
                return RedirectToAction("Dashboard", "Publish");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return RedirectToAction("Error", "Home");
            }
        }

        public async Task <IActionResult> Data()
        {
            var data = await services.profilepic();
            ViewBag.data = data;
            return View();
        }

        public IActionResult Registartaion()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registartaion(IFormFile ProfilePhoto,RegistartionModel models)
        {
            if (ProfilePhoto == null || ProfilePhoto.Length == 0)
            {

                return View();

            }
            using (var ms = new MemoryStream())
            {
                ProfilePhoto.CopyToAsync(ms);
                models.ProfilePhoto = ms.ToArray();
            }

            await services.registration(models);
            return RedirectToAction("Login","Login");
        }




    }
}
