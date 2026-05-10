using Microsoft.EntityFrameworkCore;
using ReadingNook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<ReadingSession> ReadingSessions => Set<ReadingSession>();
        public DbSet<AppUser> Users => Set<AppUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(100);
                entity.Property(b => b.Genre).HasMaxLength(50);
            });

            modelBuilder.Entity<ReadingSession>(entity =>
            {
                entity.Property(s => s.Notes).HasMaxLength(1000);

                entity.HasOne(s => s.Book)
                    .WithMany(b => b.ReadingSessions)
                    .HasForeignKey(s => s.BookId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
