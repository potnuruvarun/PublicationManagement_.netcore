using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicationManagement.Model;
using PublicationManagement.Model.Publishmodel;
using PublicationManagement.Services.Facultypublishing;
using PublicationManagement.Services.PublishServices;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PublishController : ControllerBase
    {
        IPublishServices services;
        IFacultypublishingServices facultypublishing;

        public PublishController(IPublishServices _services, IFacultypublishingServices _facultypublishing)
        {
            services = _services;
            facultypublishing = _facultypublishing;

        }

        [HttpGet("ExportExcel")]

        public async Task<IActionResult> GetExcelfile()
        {
            var employeeData = await GetEmployeedata();

            string base64String;

            using (var wb = new XLWorkbook())
            {
                var sheet = wb.AddWorksheet((System.Data.DataTable)employeeData, "Employee Records");

                // Apply font color to columns 1 to 5
                sheet.Columns(1, 5).Style.Font.FontColor = XLColor.Black;

                using (var ms = new MemoryStream())
                {
                    wb.SaveAs(ms);

                    // Convert the Excel workbook to a base64-encoded string
                    base64String = Convert.ToBase64String(ms.ToArray());
                }
            }

            // Return a CreatedResult with the base64-encoded Excel data
            return new CreatedResult(string.Empty, new
            {
               
                Data = base64String
            });

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await services.Alldata());
        }

        [NonAction]
        public async Task<DataTable> GetEmployeedata()
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "Employeelist";
            dataTable.Columns.Add("publicationdetail", typeof(string));
            dataTable.Columns.Add("dateofpublish", typeof(DateTime));
            dataTable.Columns.Add("publisherType", typeof(string));
            // Apply font color to columns 1 to 5
            var employeeData = await services.Alldata();
            foreach (var employee in employeeData)
            {
                DataRow row = dataTable.NewRow();
                row["publicationdetail"] = employee.Publicationdetail;
                row["dateofpublish"] = employee.Dateofpublish;
                row["publisherType"] = employee.PublisherType;
                dataTable.Rows.Add(row);
            }
            //foreach (var employee in employeeData)
            //{
            //    DataRow row = dataTable.NewRow();
            //    row["publicationdetail"] = employee.Publicationdetail;
            //    row["dateofpublish"] = employee.Dateofpublish;
            //    row["publisherType"] = employee.PublisherType;
            //    dataTable.Rows.Add(row);
            //}

            return dataTable;
        }


        [HttpGet]

        public async Task<IActionResult> Studentdata()
        {
            return Ok(await services.viewdata());
        }

        [HttpGet]


        public async Task<IActionResult> Facultydata()
        {
            return Ok(await facultypublishing.viewdata());

        }

        [HttpPost]
        public async Task<IActionResult> Studentpublish(PublishingModels model)
        {
            await services.Publish(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Studentdelete(int id)
        {
            return Ok(await services.Delete(id));
        }



        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> Edit(int id)
        {
            return Ok(await services.Edit(id));
        }

        //[HttpPost]
        //[Route("AddFileDetails")]
        //public async Task<IActionResult>Addfiles(upload upload)
        //{
        //    string result = "";
        //    await services.upload(upload);
        //    string fileName = null;
        //    string imageName = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    var postedImage = httpRequest.Files["ImageUpload"];
        //    var postedFile = httpRequest.Files["FileUpload"];
        //    objFile.UserName = httpRequest.Form["UserName"];
        //    if (postedImage != null)
        //    {
        //        imageName = new String(Path.GetFileNameWithoutExtension(postedImage.FileName).Take(10).ToArray()).Replace(" ", "-");
        //        imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedImage.FileName);
        //        var filePath = HttpContext.Current.Server.MapPath("~/Files/" + imageName);
        //        postedImage.SaveAs(filePath);
        //    }
        //    if (postedFile != null)
        //    {
        //        fileName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
        //        fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
        //        var filePath = HttpContext.Current.Server.MapPath("~/Files/" + fileName);
        //        postedFile.SaveAs(filePath);
        //    }
        //    objFile.Image = imageName;
        //    objFile.DocFile = fileName;
        //    objEntity.FileDetails.Add(objFile);
        //    int i = objEntity.SaveChanges();
        //    if (i > 0)
        //    {
        //        result = "File uploaded sucessfully";
        //    }
        //    else
        //    {
        //        result = "File uploaded faild";
        //    }

        //    return Ok();
        //}
        //public IActionResult AddFile()
        //{
        //    string result = "";
        //    try
        //    {
        //        AngularDBEntities objEntity = new AngularDBEntities();
        //        FileDetail objFile = new FileDetail();
        //        string fileName = null;
        //        string imageName = null;
        //        var httpRequest = HttpContext.Current.Request;
        //        var postedImage = httpRequest.Files["ImageUpload"];
        //        var postedFile = httpRequest.Files["FileUpload"];
        //        objFile.UserName = httpRequest.Form["UserName"];
        //        if (postedImage != null)
        //        {
        //            imageName = new String(Path.GetFileNameWithoutExtension(postedImage.FileName).Take(10).ToArray()).Replace(" ", "-");
        //            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedImage.FileName);
        //            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + imageName);
        //            postedImage.SaveAs(filePath);
        //        }
        //        if (postedFile != null)
        //        {
        //            fileName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
        //            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
        //            var filePath = HttpContext.Current.Server.MapPath("~/Files/" + fileName);
        //            postedFile.SaveAs(filePath);
        //        }
        //        objFile.Image = imageName;
        //        objFile.DocFile = fileName;
        //        objEntity.FileDetails.Add(objFile);
        //        int i = objEntity.SaveChanges();
        //        if (i > 0)
        //        {
        //            result = "File uploaded sucessfully";
        //        }
        //        else
        //        {
        //            result = "File uploaded faild";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    return Ok(result);
        //}



    }
}
