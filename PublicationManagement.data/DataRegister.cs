using PublicationManagement.data.FacultyPublishing;
using PublicationManagement.data.Login;
using PublicationManagement.data.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.data
{
    public class DataRegister
    {


        public static Dictionary<Type, Type> GetTypes()
        {
            var dictionary = new Dictionary<Type, Type>()
            {
                { typeof(ILoginRepo),typeof(LoginRepo)},
                  { typeof(IPublishingRepo),typeof(PublishingRepo)},
                    { typeof(IFacultyPublishing),typeof(FcaultyPublishing)},

            };
            return dictionary;
        }



    }
}
