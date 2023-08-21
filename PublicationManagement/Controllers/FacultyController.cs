using Microsoft.AspNetCore.Mvc;
using PublicationManagement.data.FacultyPublishing;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;

namespace PublicationManagement.Controllers
{
    public class FacultyController : Controller
    {
        public IFacultypublishingServices services;

        public FacultyController(IFacultypublishingServices _services)
        {
            services = _services;
        }
        public async Task<IActionResult> Index()
        {
            return View(await services.viewdata());
        }
     
        public IActionResult newpublish()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> newpublish(FacultyPublishingModel model)
        {
            if (ModelState.IsValid)
            {
               
                
                await services.Publish(model);
                return RedirectToAction("DashBoard","Publish");
            }
            return View();


        }

        public async Task<JsonResult> faculty()
        {
            var data = await services.faculty();
            return Json(data);
        }
    }
}

