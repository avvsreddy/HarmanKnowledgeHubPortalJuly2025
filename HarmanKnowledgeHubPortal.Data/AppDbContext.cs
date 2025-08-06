using HarmanKnowledgeHubPortal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarmanKnowledgeHubPortal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Report> Reports { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(); // Can make a join table if needed

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Tags)
                .WithMany(); // Many-to-Many Tags

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany(); // 1 Category -> many Articles
        }
    }
}
