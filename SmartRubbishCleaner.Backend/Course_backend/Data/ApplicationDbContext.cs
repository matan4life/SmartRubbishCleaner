using Course_backend.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Cleaning> Cleanings { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<User> SystemUsers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<TrashCan> TrashCans { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CleanerDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
