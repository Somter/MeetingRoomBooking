using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Slot> Slots { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Slot>()
            .HasOne(s => s.Resource)
            .WithMany(r => r.Slots)
            .HasForeignKey(s => s.ResourceId);

        modelBuilder.Entity<Slot>()
            .HasOne(s => s.BookedByUser)
            .WithMany()
            .HasForeignKey(s => s.BookedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Slot>()
            .Property(s => s.RowVersion)
            .IsRowVersion();
    }
}