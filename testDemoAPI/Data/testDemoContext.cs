using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testDemoAPI.Models;

namespace testDemoAPI.Data
{
    public class testDemoContext : DbContext
    {
        public testDemoContext(DbContextOptions options) : base(options) { }

        public DbSet<Platform> platforms { get; set; }
        public DbSet<PlatformDummy> platformDummies { get; set; }
        public DbSet<Well> wells { get; set; }
        public DbSet<WellDummy> wellDummies { get; set; }
        public DbSet<TableUser> tableUsers { get; set; }
        public DbSet<LoginRequest> loginRequests { get; set; }
        public DbSet<ChartDashboard> chartDashboards { get; set; }
        public DbSet<Dashboard> dashboards { get; set; }
        public DbSet<Error> errors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);

            //builder.Entity<WellDummy>()
            //   .Property(p => p.lastUpdated)
            //   .HasColumnType("datetime");
        }

    }
}
