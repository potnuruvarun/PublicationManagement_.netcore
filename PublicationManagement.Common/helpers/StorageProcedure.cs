using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Common.helpers
{
    public class StorageProcedure
    {
        public const string? login = "Sp_login";
        public const string? registration = "sp_Registration";
        public const string? registrationdata = "sp_viewregistrationdata";

        public const string? sp_profilephoto = "sp_profilephoto";


        #region MyRegion
        public const  string? publish = "sp_publishing";
        #endregion

        #region MyRegion
        public const string? viewdata = "sp_viewdata";
        public const string deletepublishers = "sp_delpublisherdata";
        public const string sp_edit = "sp_edit";


        #endregion

        #region MyRegion
        public const string? facultyviewdata = "sp_facultyviewdata";
        public const string? facultypublish = "sp_facultypublishing";

        public const string? alldata = "sp_Alldata";
        public const string? countfaculty = "sp_countfacultypublishers";
        public const string? countstudent = "sp_countpublishers";
        public const string? countall = "sp_countallpublishers";
        #endregion

        #region Dropdown
        public const string? sp_Studnet = "sp_Studnet";
        public const string? sp_faculty = "sp_Admin";
        #endregion

        #region searchdata
        public const string searchdata = "searchdata";
        #endregion
    }
}
