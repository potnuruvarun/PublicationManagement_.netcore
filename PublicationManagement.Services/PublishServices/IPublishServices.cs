using PublicationManagement.Model.DropdownModels;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services.PublishServices
{
    public  interface IPublishServices
    {
        Task<int>Publish(PublishingModels model);

        Task<IEnumerable<PublishingModels>> viewdata();
        Task<IEnumerable<PublishingModels>> Alldata();

        Task<IEnumerable<PublishingModels>> studentcount();
        Task<IEnumerable<PublishingModels>> facultycount();
        Task<IEnumerable<int>> allcount();

        Task<IEnumerable<StudentRoleModels>> students();
        
        Task<int> Delete(int id);

        Task<IEnumerable<PublishingModels>> Edit(int id);

    }
}
