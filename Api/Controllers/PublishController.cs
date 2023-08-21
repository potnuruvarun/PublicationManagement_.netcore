using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;
using PublicationManagement.Services.PublishServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        IPublishServices services;
        IFacultypublishingServices facultypublishing;

        public PublishController(IPublishServices _services, IFacultypublishingServices _facultypublishing)
        {
            services = _services;
            facultypublishing = _facultypublishing;

        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok(await services.Alldata());
        }


        [HttpGet]
        [Route("Studentdata")]
        public async Task<IActionResult> Studentdata()
        {
            return Ok(await services.viewdata());
        }

        [HttpGet]
        [Route("Facultydata")]

        public async Task<IActionResult> Facultydata()
        {
            return Ok(await facultypublishing.viewdata());

        }

        [HttpPost]
        public async Task<IActionResult> Studentpublish(PublishingModels model)
        {
            services.Publish(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delpublish(int id)
        {
            return Ok(await services.Delete(id));
        }



        [HttpPut]
        [Route("{id:int}")]

        public async Task <IActionResult> Edit(int id)
        {
            return Ok(await services.Edit(id));
        }





    }
}
