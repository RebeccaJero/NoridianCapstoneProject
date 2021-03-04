//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackTaskItemsDb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class TaskItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskItem()
        {
            this.ItemDepartments = new HashSet<ItemDepartment>();
            this.QuarterItems = new HashSet<QuarterItem>();
            this.Updates = new HashSet<Update>();
        }
    
        public int Id { get; set; }
        [DisplayName("Status")]
        public int Status { get; set; }
        public bool IsMandate { get; set; }
        [StringLength(25, ErrorMessage = "Maximum length")]
        public string MandateComment { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length")]
        public string Action { get; set; }

        public string IT_Project_Number { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<decimal> OperationalBudgetImplications { get; set; }
        public Nullable<decimal> CapitolBudgetImplications { get; set; }
        public string Outcome { get; set; }
        public int StrategicPillarId { get; set; }
        public string BudgetDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemDepartment> ItemDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuarterItem> QuarterItems { get; set; }
        public virtual Status Status1 { get; set; }
        public virtual StrategicPillar StrategicPillar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Update> Updates { get; set; }
    }
}