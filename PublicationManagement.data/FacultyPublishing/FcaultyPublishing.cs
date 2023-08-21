using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublicationManagement.Common.helpers;
using PublicationManagement.Model.Config;
using PublicationManagement.Model.DropdownModels;
using PublicationManagement.Model.Publishmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data.FacultyPublishing
{
    public class FcaultyPublishing : BaseRepository, IFacultyPublishing
    {
        public IConfiguration configuration;
        public FcaultyPublishing(IOptions<DataConfig> connectionString, IConfiguration config = null) : base(connectionString, config)
        {
            configuration = config;

        }

        public async  Task<int> Publish(FacultyPublishingModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Publicationdetail", model.Publicationdetail);
            parameters.Add("@Publishername", model.Publishername);
            //parameters.Add("@Dateofpublish", model.Dateofpublish);
            parameters.Add("@PublisherType", model.PublisherType);
            var data = await ExecuteAsync<FacultyPublishingModel>(StorageProcedure.facultypublish, parameters, commandType: CommandType.StoredProcedure);
            if (data != 0)
            {
                return 1;
            }
            else
            {
                return 0;

            }
        }

        public async  Task<IEnumerable<FacultyRoleModels>> faculty()
        {
            return await QueryAsync<FacultyRoleModels>(StorageProcedure.sp_faculty, commandType: CommandType.StoredProcedure);

        }

        public async  Task<IEnumerable<FacultyPublishingModel>> Viewdata()
        {
            return await QueryAsync<FacultyPublishingModel>(StorageProcedure.facultyviewdata, commandType: CommandType.StoredProcedure);
        }
    }
}
