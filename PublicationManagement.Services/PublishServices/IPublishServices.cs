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
    }
}
