using PublicationManagement.data.Publishing;
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

        
        public async Task<int> Publish(PublishingModels model)
        {
          return await publishing.Publish(model);
        }

        public async Task<IEnumerable<PublishingModels>> viewdata()
        {
           return await publishing.Viewdata();
        }
    }
}
