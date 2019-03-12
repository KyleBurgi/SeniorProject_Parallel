using System;
using EwuConnect.Domain.Models.Profile;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Education> UserEducation { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
            
        }

    }
}
