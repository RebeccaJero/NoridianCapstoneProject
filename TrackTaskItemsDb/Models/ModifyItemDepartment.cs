using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackTaskItemsDb.Models
{
    //customized attributes for Item department
    [MetadataType(typeof(ItemDepartmentMetaData))]
    public partial class ItemDepartment
    {
        public class ItemDepartmentMetaData
        {

            public bool IsImpacted { get; set; }

            public int UserId { get; set; }
            [Display(Name = "Item Number")]
            public string ItemNumber { get; set; }

        }
    }
}