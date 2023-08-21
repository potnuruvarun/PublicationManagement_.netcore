using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;
using PublicationManagement.Services.PublishServices;

namespace PublicationManagement.Controllers
{
    public class PublishController : Controller
    {
        IPublishServices services;
        IFacultypublishingServices facultypublishingServices;
        public PublishController(IPublishServices publish,IFacultypublishingServices _facultypublishingServices)
        {
            services = publish;
            facultypublishingServices= _facultypublishingServices;
        }
        public async Task <IActionResult> Index()
        {
            return View(await services.viewdata());
        }
        public async Task<JsonResult> Getdata()
        {
            var data =await   services.viewdata();
      
            return Json(data);
        }
        public async Task<JsonResult> Getfacultydata()
        {
            var data = await facultypublishingServices.viewdata();

            return Json(data);
        }

        public async Task<JsonResult> Getalldata()
        {
            var data = await services.Alldata ();

            return Json(data);
        }
        public IActionResult newpublish()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult>newpublish(PublishingModels model)
        {
            await services.Publish(model);
            return RedirectToAction("Index");

           
        }
        public IActionResult Dashboard()
        {
            ViewBag.Mysession= HttpContext.Session.GetString("username");
         
            //string base64ProfilePhoto = HttpContext.Session.GetString("profilePhoto");
            //ViewBag.PhotoBytes = base64ProfilePhoto;
            return View();
        }

        public async Task<JsonResult> create(PublishingModels model)
        {
            var data=await services.Publish(model);
            return Json(data);


        }

        public async Task<JsonResult> student()
        {
            var data=await services.students();
            return Json(data);
        }







    }
}
