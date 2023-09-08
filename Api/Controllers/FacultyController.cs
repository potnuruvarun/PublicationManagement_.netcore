using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultypublishingServices Services;
        public FacultyController(IFacultypublishingServices _services)
        {
            Services = _services;  
        }

        [HttpPost]
        public async Task<IActionResult>Facultypublish(FacultyPublishingModel model)
        {
            Services.Publish(model);
            return Ok();
        }

        [HttpGet]
        [Route("{searchdata}")]
       
        public async Task<IActionResult> searchdata(string searchdata)
        {
            return Ok(await Services.searchdata(searchdata));

        }

    }
}
