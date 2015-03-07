using achievement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace achievement.DAL
{
    public class AchievementContext:DbContext
    {
        public AchievementContext() : base("AchievementContext") { }
        public DbSet<Achievement> Achievements { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}