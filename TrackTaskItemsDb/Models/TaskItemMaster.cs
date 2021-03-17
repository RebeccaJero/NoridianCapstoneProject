using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TrackTaskItemsDb.Validators;

namespace TrackTaskItemsDb.Models
{
    public class TaskItemMaster
    {
        [Required(ErrorMessage = "Status is required")]
        [DisplayName("Status")]
        public int Status { get; set; }

        [DisplayName("Department")]
        public int Department { get; set; }

        [DisplayName("Impacted Department")]
        public List<int> ImpactedDepartments { get; set; }


        public bool IsMandate { get; set; }

        [DisplayName("StartQuarter")]
        [CompareQuarter("EndQuarter", ErrorMessage = "Start Quarter is less or Equal to End quarter")]
        public System.DateTime StartQuarter { get; set; }



        [DisplayName("EndQuarter")]
        //[System.ComponentModel.DataAnnotations.Compare("StartQuarter",ErrorMessage = "Start Quarter is Equal to End Quarter")]
        public System.DateTime EndQuarter { get; set; }
        [StringLength(25, ErrorMessage = "Maximum length 25 characters")]
        public string MandateComment { get; set; }



        [Required(ErrorMessage = "Action is required")]
        [StringLength(250, ErrorMessage = "Maximum length 250 characters")]
        public string Action { get; set; }

        [DefaultValue("N/A")]
        [DisplayName("IT Project Number")]
        public string IT_Project_Number { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        [DisplayName("Completed Date")]
        public Nullable<System.DateTime> CompletedDate { get; set; }

        [DisplayName("Start Date")]
        [Required(ErrorMessage = "Start Date Is Required")]
        [DateGreaterThan("CompletedDate", ErrorMessage = "Maximum length 250 characters")]
        public System.DateTime StartDate { get; set; }

        [DisplayName("Budget Impact")]
        public Nullable<decimal> OperationalBudgetImplications { get; set; }

        public Nullable<decimal> CapitolBudgetImplications { get; set; }

        [Required(ErrorMessage = "Outcome is required")]
        [DisplayName("Outcome")]
        [StringLength(500, ErrorMessage = "Maximum length 500 characters")]
        public string Outcome { get; set; }
        [DisplayName("Strategic Pillar")]
        public int StrategicPillarId { get; set; }

        [DisplayName("Budget Impact Description")]
        public string BudgetDesc { get; set; }
    }
}