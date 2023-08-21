using PublicationManagement.data.Publishing;
using PublicationManagement.Model.DropdownModels;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.PublishServices
{
    public class PublishingServices : IPublishServices
    {
        IPublishingRepo publishing;

        public PublishingServices(IPublishingRepo publishingRepo)
        {
            this.publishing = publishingRepo;
        }

        public async Task<IEnumerable<int>> allcount()
        {
            return await  publishing.allcount();
        }

        public async Task<IEnumerable<PublishingModels>> Alldata()
        {
            return await publishing.Alldata();
        }

        public async Task<int> Delete(int id)
        {
            return await publishing.Delete(id);
        }

        public async Task<IEnumerable<PublishingModels>> Edit(int id)
        {
           return await publishing.Edit(id);
        }

        public async  Task<IEnumerable<PublishingModels>> facultycount()
        {
            return await publishing.facultycount();
        }

        public async Task<int> Publish(PublishingModels model)
        {
          return await publishing.Publish(model);
        }

        public async Task<IEnumerable<PublishingModels>> studentcount()
        {
            return await publishing.studentcount();
        }

        public async  Task<IEnumerable<StudentRoleModels>> students()
        {
            return await publishing.students();
        }

        public async Task<IEnumerable<PublishingModels>> viewdata()
        {
           return await publishing.Viewdata();
        }
    }
}
