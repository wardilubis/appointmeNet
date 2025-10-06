using AppointmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApi.Data;

public class AppointmentDbContext : DbContext
{
    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
        : base(options)
    {
    }

    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.AttendeeEmail).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
        });
    }
}
