using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVC.Models
{
    public class ProfileContext : DbContext
    {
        public ProfileContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile() { Id = 1, Name = "Ramu", Age = 28, Qualification = "B.E ECE", IsEmployed = true, NoticePeriod = "three months", CurrentCTC = 450000 }
                );

        }
    }
}

