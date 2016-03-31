using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using FragSwapperV2.Models.Db;

namespace FragSwapperV2.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementAdministrator> AdvertisementAdministrators { get; set; }
        public DbSet<AdvertisementHistory> AdvertisementHistory { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventAdministrator> EventAdministrators { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<HostStates> HostStates { get; set; }
        public DbSet<HostAdministrator> HostAdministrators { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<EventAttendance> EventAttendance { get; set; }

        


        public DbSet<v1Swapper> v1Swapper { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AdvertisementHistory>()
                .HasIndex(p => new { p.AdvertisementID, p.Year, p.Month })
                .IsUnique();

            builder.Entity<Event>() //  Index used by Rewriting Middleware
                .HasIndex(p => new { p.ID, p.Status })
                .IsUnique();
            builder.Entity<Event>() //  Index used by HourlyRun SP and Rewriting Middleware
                .HasIndex(p => new {p.Status});

            builder.Entity<Host>()
                .HasIndex(p => new { p.Name })
                .IsUnique();
            builder.Entity<Host>()
                .HasIndex(p => new { p.ShortName })
                .IsUnique();

            builder.Entity<v1Swapper>()
                .HasIndex(p => p.SwapperKey)
                .IsUnique();
        }
    }
}
