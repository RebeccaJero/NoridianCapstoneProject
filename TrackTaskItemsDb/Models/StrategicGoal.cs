
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
    
public partial class StrategicGoal
{

    public int Id { get; set; }

    public string Goals { get; set; }

    public int StrategicPillarId { get; set; }



    public virtual StrategicPillar StrategicPillar { get; set; }

}

}
