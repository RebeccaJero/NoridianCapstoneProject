//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackTaskItems
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskItem()
        {
            this.ItemDepartments = new HashSet<ItemDepartment>();
            this.QuarterItems = new HashSet<QuarterItem>();
            this.StrategicItems = new HashSet<StrategicItem>();
            this.Updates = new HashSet<Update>();
        }
    
        public int Id { get; set; }
        public int Status { get; set; }
        public bool IsMandate { get; set; }
        public string MandateComment { get; set; }
        public string Action { get; set; }
        public int IT_Project_Number { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime CompletedDate { get; set; }
        public System.DateTime StartDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemDepartment> ItemDepartments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuarterItem> QuarterItems { get; set; }
        public virtual Status Status1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StrategicItem> StrategicItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Update> Updates { get; set; }
    }
}
