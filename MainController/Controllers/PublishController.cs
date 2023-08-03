using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;
using PublicationManagement.Services.PublishServices;
using System.Text;

namespace PublicationManagement.Controllers
{
    public class PublishController : Controller
    {
        public Uri baseAddress = new Uri("http://localhost:5281/api/");
        private readonly HttpClient client;
        public PublishController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public async Task <IActionResult> Index()
        {
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress + "Publish/Studentdata").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                List<PublishingModels> publishingdata = JsonConvert.DeserializeObject<List<PublishingModels>>(result);
                return View(publishingdata);
            }
            return View();
        }
        public async Task<JsonResult> Getdata()
        {
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress + "Publish/Studentdata").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                List<FacultyPublishingModel> publishingdata = JsonConvert.DeserializeObject<List<FacultyPublishingModel>>(result);
                return Json(publishingdata);
            }
            return Json(null);
        }
        public async Task<JsonResult> Getfacultydata()
        {
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress + "Publish/Facultydata").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                List<FacultyPublishingModel> publishingdata = JsonConvert.DeserializeObject<List<FacultyPublishingModel>>(result);
                return Json(publishingdata);
            }
            return Json(null);
        }

        public async Task<JsonResult> Getalldata()
        {
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress + "Publish/Get").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                List<PublishingModels> publishingdata = JsonConvert.DeserializeObject<List<PublishingModels>>(result);
                return Json(publishingdata);
            }
            return Json(null);
        }
       
        public IActionResult newpublish()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult>newpublish(PublishingModels model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Publish/Studentpublish", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard", "Publish");
            }

            return View();

        }
        public IActionResult Dashboard()
        {
            return View();
        }
   


    }
}
