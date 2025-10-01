using AppointmentApi.Data;
using AppointmentApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Create appointments table if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
    db.Database.EnsureCreated();
}

// GET all appointments
app.MapGet("/api/appointments", async (AppointmentDbContext db) =>
{
    return await db.Appointments.ToListAsync();
})
.WithName("GetAppointments")
.WithOpenApi();

// GET appointment by id
app.MapGet("/api/appointments/{id}", async (int id, AppointmentDbContext db) =>
{
    var appointment = await db.Appointments.FindAsync(id);
    return appointment is not null ? Results.Ok(appointment) : Results.NotFound();
})
.WithName("GetAppointment")
.WithOpenApi();

// POST new appointment
app.MapPost("/api/appointments", async (Appointment appointment, AppointmentDbContext db) =>
{
    appointment.CreatedAt = DateTime.UtcNow;
    db.Appointments.Add(appointment);
    await db.SaveChangesAsync();
    return Results.Created($"/api/appointments/{appointment.Id}", appointment);
})
.WithName("CreateAppointment")
.WithOpenApi();

// PUT update appointment
app.MapPut("/api/appointments/{id}", async (int id, Appointment updatedAppointment, AppointmentDbContext db) =>
{
    var appointment = await db.Appointments.FindAsync(id);
    if (appointment is null) return Results.NotFound();

    appointment.Title = updatedAppointment.Title;
    appointment.Description = updatedAppointment.Description;
    appointment.StartTime = updatedAppointment.StartTime;
    appointment.EndTime = updatedAppointment.EndTime;
    appointment.Location = updatedAppointment.Location;
    appointment.AttendeeEmail = updatedAppointment.AttendeeEmail;
    appointment.Status = updatedAppointment.Status;
    appointment.UpdatedAt = DateTime.UtcNow;

    await db.SaveChangesAsync();
    return Results.Ok(appointment);
})
.WithName("UpdateAppointment")
.WithOpenApi();

// DELETE appointment
app.MapDelete("/api/appointments/{id}", async (int id, AppointmentDbContext db) =>
{
    var appointment = await db.Appointments.FindAsync(id);
    if (appointment is null) return Results.NotFound();

    db.Appointments.Remove(appointment);
    await db.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteAppointment")
.WithOpenApi();

app.Run();
