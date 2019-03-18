using System;
using EwuConnect.Domain.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Mentee> Mentee { get; set; }
        public DbSet<Mentor> Mentor { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mentee>().HasBaseType<User>();
            modelBuilder.Entity<Mentor>().HasBaseType<User>();

            modelBuilder.Entity<UserEducation>()
                .HasKey(ue => new { ue.UserId, ue.EducationId });

            modelBuilder.Entity<UserEducation>()
                .HasOne(ue => ue.Education);

            modelBuilder.Entity<UserWorkExperience>()
                .HasKey(ue => new { ue.UserId, ue.WorkExperienceId });

        }

    }
}
