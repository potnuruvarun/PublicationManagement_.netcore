using PublicationManagement.Model.DropdownModels;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Facultypublishing
{
    public interface IFacultypublishingServices
    {
        Task<int> Publish(FacultyPublishingModel model);

        Task<IEnumerable<FacultyPublishingModel>> viewdata();

        Task<IEnumerable<FacultyRoleModels>> faculty();
        Task<IEnumerable<FacultyPublishingModel>> searchdata(string searchdata);

    }
}
