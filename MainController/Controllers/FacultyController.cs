using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicationManagement.Model.Publishmodel;
using System.Reflection;
using System.Text;

namespace PublicationManagement.Controllers
{
    public class FacultyController : Controller
    {
        public Uri baseAddress = new Uri("http://localhost:5281/api/");
        private readonly HttpClient client;
        public FacultyController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseTask = client.GetAsync(client.BaseAddress + "Publish/Facultydata").Result;
            if (responseTask.IsSuccessStatusCode)
            {
                var result = responseTask.Content.ReadAsStringAsync().Result;
                List<FacultyPublishingModel> publishingdata = JsonConvert.DeserializeObject<List<FacultyPublishingModel>>(result);
                return View(publishingdata);
            }
            return View();
        }
     
        public IActionResult newpublish()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> newpublish(FacultyPublishingModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Faculty/Facultypublish", content).Result;


            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Dashboard", "Publish");
            }

            return View();


        }
    }
}

