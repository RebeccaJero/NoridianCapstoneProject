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
    
    public partial class ItemDepartment
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public int DepartmentId { get; set; }
        public bool IsImpacted { get; set; }
        public int UserId { get; set; }
        public string ItemNumber { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual TaskItem TaskItem { get; set; }
        public virtual User User { get; set; }
    }
}