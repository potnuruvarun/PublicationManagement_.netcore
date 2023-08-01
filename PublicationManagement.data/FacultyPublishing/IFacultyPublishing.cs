using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.FacultyPublishing
{
    public interface IFacultyPublishing
    {
        Task<int> Publish(FacultyPublishingModel model);

        Task<IEnumerable<FacultyPublishingModel>> Viewdata();
    }
}
