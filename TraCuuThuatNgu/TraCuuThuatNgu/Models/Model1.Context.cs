﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TraCuuThuatNgu.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TraCuuThuatNguEntities : DbContext
    {
        public TraCuuThuatNguEntities()
            : base("name=TraCuuThuatNguEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Synset> Synsets { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }
    }
}
