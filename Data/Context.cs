using Microsoft.EntityFrameworkCore;
using origami_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace origami_backend.Data
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileComment> ProfileComments { get; set; }
        public DbSet<Origami> Origamis { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<OrigamiComment> OrigamiComments { get; set; }
        public DbSet<Study> Studies { get; set; }

        public Context(DbContextOptions<Context> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasOne(u => u.Profile).WithOne()
            base.OnModelCreating(builder);
        }
    }
}
