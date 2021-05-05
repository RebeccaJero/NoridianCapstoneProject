using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackTaskItemsDb.Models
{
    //customized attributes for department

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {

        public class DepartmentMetaData
        {
            [Display(Name = "Department Name")]
            public string Department_Name { get; set; }
            [Display(Name = "Department Code")]
            public string Code { get; set; }

        }
    }

}