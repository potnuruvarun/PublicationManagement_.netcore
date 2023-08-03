using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublicationManagement.Common.helpers;
using PublicationManagement.Model.Config;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.Publishing
{
    public class PublishingRepo : BaseRepository, IPublishingRepo
    {
        public IConfiguration configuration;
        public PublishingRepo(IOptions<DataConfig> connectionString, IConfiguration config = null) : base(connectionString, config)
        {
            this.configuration = config;

        }

        public async  Task<IEnumerable<int>> allcount()
        {
            return await QueryAsync<int>(StorageProcedure.countall, commandType: CommandType.StoredProcedure);
        }

        public async  Task<IEnumerable<PublishingModels>> Alldata()
        {
            return await QueryAsync<PublishingModels>(StorageProcedure.alldata, commandType: CommandType.StoredProcedure);
        }

        public async  Task<IEnumerable<PublishingModels>> facultycount()
        {
            return await QueryAsync<PublishingModels>(StorageProcedure.countfaculty, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> Publish(PublishingModels model)
        {
            var parameters = new DynamicParameters();            
            parameters.Add("@Publicationdetail", model.Publicationdetail);
            parameters.Add("@Publishername", model.Publishername);
            //parameters.Add("@Dateofpublish", model.Dateofpublish);
            parameters.Add("@PublisherType", model.PublisherType);
            var data=await ExecuteAsync<PublishingModels>(StorageProcedure.publish, parameters,commandType:CommandType.StoredProcedure);
            if(data != 0)
            {
                return 1;
            }
            else{
                return 0;

            }



        }

        public async  Task<IEnumerable<PublishingModels>> studentcount()
        {
            return await QueryAsync<PublishingModels>(StorageProcedure.countstudent, commandType: CommandType.StoredProcedure);
        }

        public async  Task<IEnumerable<PublishingModels>> Viewdata()
        {
            return await  QueryAsync<PublishingModels>(StorageProcedure.viewdata,commandType: CommandType.StoredProcedure);
        }
    }
}
