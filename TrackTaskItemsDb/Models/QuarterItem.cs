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
        public int QuarterId { get; set; }
        public int TaskItemDepId { get; set; }
        public bool isOriginal { get; set; }
        public bool isUpdated { get; set; }
        public bool isActive { get; set; }
    
        public virtual ItemDepartment ItemDepartment { get; set; }
        public virtual Quarter Quarter { get; set; }
    }
}
