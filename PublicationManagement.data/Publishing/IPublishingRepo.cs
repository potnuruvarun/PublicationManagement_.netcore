using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.Publishing
{
    public interface IPublishingRepo
    {
        Task<int>Publish(PublishingModels model);

        Task<IEnumerable<PublishingModels>> Viewdata();

    }
}
