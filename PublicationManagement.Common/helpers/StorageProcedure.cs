using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Common.helpers
{
    public class StorageProcedure
    {
        public const string login = "Sp_login";

        #region MyRegion
        public const  string? publish = "sp_publishing";
        #endregion

        #region MyRegion
        public const string? viewdata = "sp_viewdata";
        #endregion

        #region MyRegion
        public const string? facultyviewdata = "sp_facultyviewdata";
        public const string? facultypublish = "sp_facultypublishing";



        #endregion
    }
}
