﻿using Microsoft.EntityFrameworkCore;
using TerrariumApi.Models;

namespace TerrariumApi.DataAccess
{
    public class TerrariumDbContext : DbContext
    {
        public DbSet<Terrarium> TerrariumSet { get; set; }
        public DbSet<TerrariumData> TerrariumDataSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<ScheduledTask> ScheduledTasksSet { get; set; }
        public DbSet<Profile> ProfileSet { get; set; }
        public DbSet<ProfileData> ProfileDataSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Terrarium.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}