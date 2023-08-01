using PublicationManagement.data.Login;
using PublicationManagement.data.Publishing;
using PublicationManagement.Services.Facultypublishing;
using PublicationManagement.Services.Login;
using PublicationManagement.Services.PublishServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Services
{
    public  class ServiceRegister
    {

        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                { typeof(IloginServices),typeof(LoginServices)},
                 { typeof(IPublishServices),typeof(PublishingServices)},
                   { typeof(IFacultypublishingServices),typeof(FacultypublishingServices)},
            };
            return dictionary;
        }
    }
}
