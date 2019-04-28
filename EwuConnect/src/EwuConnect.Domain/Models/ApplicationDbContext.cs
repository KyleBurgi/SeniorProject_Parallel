using System;
using EwuConnect.Domain.Models.Chat;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Mentee> Mentees { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<WorkExperience> WorkExperience { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasMany<Message>();

            modelBuilder.Entity<Mentee>().HasBaseType<User>();
            modelBuilder.Entity<Mentor>().HasBaseType<User>();

        }

    }
}
