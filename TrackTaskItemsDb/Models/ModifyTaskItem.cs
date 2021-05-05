using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TrackTaskItemsDb.Validators;

namespace TrackTaskItemsDb.Models
{
    //customized attributes for TaskItem
    [MetadataType(typeof(TaskItemMetaData))]
    public partial class TaskItem
    {

        public class TaskItemMetaData
        {
            public TaskItemMetaData()
            {

            }


            [Required(ErrorMessage = "Status is required")]
            [StatusCompleted("CompletedDate")]
            public int Status { get; set; }

            [Display(Name = "Mandate Required")]
            public bool IsMandate { get; set; }
            [StringLength(25, ErrorMessage = "MandateComment Maximum characters is 25.")]
            [Display(Name = "Mandate Comment")]
            public string MandateComment { get; set; }

            [Required(ErrorMessage = "Action is required")]
            [StringLength(250, ErrorMessage = "Action Maximum characters is 250.")]
            public string Action { get; set; }

            [Display(Name = "IT Project Number")]
            public string IT_Project_Number { get; set; }

            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> LastModifiedDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> CreatedDate { get; set; }

            [DisplayFormat(DataFormatString = "{0:d}")]
            [Display(Name = "Completed Date")]
            public Nullable<System.DateTime> CompletedDate { get; set; }

            [Required(ErrorMessage = "Start Date is required")]
            [DateGreaterThan("CompletedDate", ErrorMessage = "Completed date should be greater than start date")]
            [DisplayFormat(DataFormatString = "{0:d}")]
            [Display(Name = "Start Date")]
            public System.DateTime StartDate { get; set; }

            [Display(Name = "Budget Impact")]
            [DataType(DataType.Currency)]
            public Nullable<decimal> BudgetImpact { get; set; }


            [Required(ErrorMessage = "Outcome is required")]
            [StringLength(500, ErrorMessage = "Outcome Maximum characters is 500.")]
            [Display(Name = "Outcome")]
            public string Outcome { get; set; }

            [Required(ErrorMessage = "Strategic Pillar is required")]
            [Display(Name = "Strategic Pillar")]
            public int StrategicPillarId { get; set; }

            [Display(Name = "Created By")]
            public Nullable<int> CreatedBy { get; set; }

            [Display(Name = "Modified By")]
            public Nullable<int> ModifiedBy { get; set; }

            [Display(Name = "Mandate Date")]
            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> MandateDate { get; set; }
        }



    }

}