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
    
    public partial class QuarterItem
    {
        public int Id { get; set; }
        public Nullable<int> StartQuarterId { get; set; }
        public int TaskItemId { get; set; }
        public bool isOriginal { get; set; }
        public bool isUpdated { get; set; }
        public Nullable<int> EndQuarterId { get; set; }
        public Nullable<System.DateTime> LastTimeModified { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual Quarter Quarter { get; set; }
        public virtual Quarter Quarter1 { get; set; }
        public virtual TaskItem TaskItem { get; set; }
    }
}