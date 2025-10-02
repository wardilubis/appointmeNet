using Microsoft.EntityFrameworkCore;
using restAPI.models;

namespace restAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.NamaPemohon).IsRequired().HasMaxLength(100);
            entity.Property(e => e.EmailPemohon).IsRequired().HasMaxLength(100);
            entity.Property(e => e.NomorHpPemohon).IsRequired().HasMaxLength(20);
            entity.Property(e => e.NamaProfesor).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Hari).IsRequired();
            entity.Property(e => e.Waktu).IsRequired().HasMaxLength(5); // Format HH:mm
            entity.Property(e => e.Status).IsRequired().HasMaxLength(50);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.UpdatedAt).IsRequired();
        });
    }
}