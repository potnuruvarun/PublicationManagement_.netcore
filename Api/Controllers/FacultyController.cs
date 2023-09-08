using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;
using System.Net.Http.Headers;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        IFacultypublishingServices Services;
        public FacultyController(IFacultypublishingServices _services)
        {
            Services = _services;
        }

        [HttpPost]
        public async Task<IActionResult> Facultypublish(FacultyPublishingModel model)
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
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> upload()
        {
            
            try
            {

                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}
