using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationManagement.Model.Publishmodel
{
    public class FacultyPublishingModel
    {
        public int id { get; set; }

        [Required]
        public string? Publicationdetail { get; set; }
        [Required]
        public string? Publishername { get; set; }

        //public DateAndTime? Dateofpublish { get; set; }
        
        public Nullable<System.DateTime> Dateofpublish { get; set; }
        [Required]
        public string? PublisherType { get; set; }
    }
}
