using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrackTaskItemsDb.Validators;

namespace TrackTaskItemsDb.Models
{
    [MetadataType(typeof(QuarterMetaData))]
    public partial class Quarter
    {


        public class QuarterMetaData
        {
            [Display(Name = "Start Date")]
            public System.DateTime StartDate { get; set; }

            [Display(Name = "End Date")]
            public System.DateTime EndDate { get; set; }

            [Display(Name = "Quarter Descprition")]
            public string Quarter_Desc { get; set; }


        }

        


    }


     
}