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
    
    public partial class Update
    {
        public int Id { get; set; }
        public string UpdateNotes { get; set; }
        public string UpdatedBy { get; set; }
        public int TaskItemId { get; set; }
        public int UserId { get; set; }
    
        public virtual TaskItem TaskItem { get; set; }
        public virtual UserTable UserTable { get; set; }
    }
}
