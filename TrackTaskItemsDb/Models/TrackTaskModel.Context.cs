﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TrackTasksEntities : DbContext
    {
        public TrackTasksEntities()
            : base("name=TrackTasksEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<ItemDepartment> ItemDepartments { get; set; }
        public virtual DbSet<QuarterItem> QuarterItems { get; set; }
        public virtual DbSet<Quarter> Quarters { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StrategicGoal> StrategicGoals { get; set; }
        public virtual DbSet<StrategicPillar> StrategicPillars { get; set; }
        public virtual DbSet<TaskItem> TaskItems { get; set; }
        public virtual DbSet<Update> Updates { get; set; }
        public virtual DbSet<UserDepartment> UserDepartments { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}