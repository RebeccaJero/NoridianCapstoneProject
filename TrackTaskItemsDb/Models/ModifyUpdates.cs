using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackTaskItemsDb.Models
{
    //customized attributes for Update Notes
    [MetadataType(typeof(UpdateMetaData))]
    public partial class Update
    {
        public class UpdateMetaData
        {
            [Required]
            [Display(Name = "Notes")]
            [StringLength(500, ErrorMessage = "Notes Maximum characters is 500.")]
            public string UpdateNotes { get; set; }
            [Required]
            public int TaskItemId { get; set; }
            [Required]
            public int UserId { get; set; }
            public Nullable<System.DateTime> LastModifiedDate { get; set; }
            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> CreatedDate { get; set; }
        }
    }
}