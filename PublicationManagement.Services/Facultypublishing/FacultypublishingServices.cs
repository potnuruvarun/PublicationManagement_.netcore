using PublicationManagement.data.FacultyPublishing;
using PublicationManagement.data.Publishing;
using PublicationManagement.Model.DropdownModels;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.Facultypublishing
{
    public class FacultypublishingServices : IFacultypublishingServices
    {
        IFacultyPublishing publishing;

        public FacultypublishingServices(IFacultyPublishing publishingRepo)
        {
            this.publishing = publishingRepo;
        }

        public async  Task<IEnumerable<FacultyRoleModels>> faculty()
        {
            return await publishing.faculty();
        }

        public async Task<int> Publish(FacultyPublishingModel model)
        {
            return await publishing.Publish(model);
        }

        public async  Task<IEnumerable<FacultyPublishingModel>> searchdata(string searchdata)
        {
            return await publishing.search(searchdata);
        }

        public async Task<IEnumerable<FacultyPublishingModel>> viewdata()
        {
            return await publishing.Viewdata();
        }
    }
}
