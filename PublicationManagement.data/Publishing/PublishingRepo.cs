using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PublicationManagement.Common.helpers;
using PublicationManagement.Model;
using PublicationManagement.Model.Config;
using PublicationManagement.Model.DropdownModels;
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

        public async Task<int> Delete(int id)
        {
            var param = new DynamicParameters();
            param.Add("@id",id);
           return await ExecuteAsync<PublishingModels>(StorageProcedure.deletepublishers, param, commandType: CommandType.StoredProcedure);
           
        }

        public async Task<IEnumerable<PublishingModels>> Edit(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id",id);
            return await QueryAsync<PublishingModels>(StorageProcedure.sp_edit,parameter, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<StudentRoleModels>> students()
        {
            return await QueryAsync<StudentRoleModels>(StorageProcedure.sp_Studnet, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> upload(upload upload)
        {
            var para = new DynamicParameters();
            para.Add("@UserName", upload.UserName);
            para.Add("@DocFile", upload.DocFile);
            para.Add("@Image", upload.Image);
            return await ExecuteAsync<upload>(StorageProcedure.upload,para,commandType: CommandType.StoredProcedure);
        }

        public async  Task<IEnumerable<PublishingModels>> Viewdata()
        {
            return await  QueryAsync<PublishingModels>(StorageProcedure.viewdata,commandType: CommandType.StoredProcedure);
        }
    }
}
