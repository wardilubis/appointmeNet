using restAPI.Data;
using Microsoft.EntityFrameworkCore;
using restAPI.DTOs;
using restAPI.models;

namespace restAPI.services;

public class AppointmentService : IAppointmentService
{
    private readonly ApplicationDbContext _context;

    public AppointmentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();
        return appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            NamaPemohon = a.NamaPemohon,
            EmailPemohon = a.EmailPemohon,
            NomorHpPemohon = a.NomorHpPemohon,
            NamaProfesor = a.NamaProfesor,
            Hari = a.Hari,
            Waktu = a.Waktu,
            Status = a.Status,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt
        });
    }

    public async Task<AppointmentDto?> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
            return null;

        return new AppointmentDto
        {
            Id = appointment.Id,
            NamaPemohon = appointment.NamaPemohon,
            EmailPemohon = appointment.EmailPemohon,
            NomorHpPemohon = appointment.NomorHpPemohon,
            NamaProfesor = appointment.NamaProfesor,
            Hari = appointment.Hari,
            Waktu = appointment.Waktu,
            Status = appointment.Status,
            CreatedAt = appointment.CreatedAt,
            UpdatedAt = appointment.UpdatedAt
        };
    }

    public async Task<AppointmentDto?> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto)
    {
        var appointment = new Appointment
        {
            NamaPemohon = createAppointmentDto.NamaPemohon,
            EmailPemohon = createAppointmentDto.EmailPemohon,
            NomorHpPemohon = createAppointmentDto.NomorHpPemohon,
            NamaProfesor = createAppointmentDto.NamaProfesor,
            Hari = createAppointmentDto.Hari,
            Waktu = createAppointmentDto.Waktu,
            Status = createAppointmentDto.Status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return new AppointmentDto
        {
            Id = appointment.Id,
            NamaPemohon = appointment.NamaPemohon,
            EmailPemohon = appointment.EmailPemohon,
            NomorHpPemohon = appointment.NomorHpPemohon,
            NamaProfesor = appointment.NamaProfesor,
            Hari = appointment.Hari,
            Waktu = appointment.Waktu,
            Status = appointment.Status,
            CreatedAt = appointment.CreatedAt,
            UpdatedAt = appointment.UpdatedAt
        };
    }

    public async Task<AppointmentDto?> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
            return null;

        appointment.NamaPemohon = updateAppointmentDto.NamaPemohon;
        appointment.EmailPemohon = updateAppointmentDto.EmailPemohon;
        appointment.NomorHpPemohon = updateAppointmentDto.NomorHpPemohon;
        appointment.NamaProfesor = updateAppointmentDto.NamaProfesor;
        appointment.Hari = updateAppointmentDto.Hari;
        appointment.Waktu = updateAppointmentDto.Waktu;
        appointment.Status = updateAppointmentDto.Status;
        appointment.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return new AppointmentDto
        {
            Id = appointment.Id,
            NamaPemohon = appointment.NamaPemohon,
            EmailPemohon = appointment.EmailPemohon,
            NomorHpPemohon = appointment.NomorHpPemohon,
            NamaProfesor = appointment.NamaProfesor,
            Hari = appointment.Hari,
            Waktu = appointment.Waktu,
            Status = appointment.Status,
            CreatedAt = appointment.CreatedAt,
            UpdatedAt = appointment.UpdatedAt
        };
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
            return false;

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(string status)
    {
        var appointments = await _context.Appointments
            .Where(a => a.Status.ToLower() == status.ToLower())
            .ToListAsync();

        return appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            NamaPemohon = a.NamaPemohon,
            EmailPemohon = a.EmailPemohon,
            NomorHpPemohon = a.NomorHpPemohon,
            NamaProfesor = a.NamaProfesor,
            Hari = a.Hari,
            Waktu = a.Waktu,
            Status = a.Status,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt
        });
    }

    public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByProfesorAsync(string namaProfesor)
    {
        var appointments = await _context.Appointments
            .Where(a => a.NamaProfesor.ToLower().Contains(namaProfesor.ToLower()))
            .ToListAsync();

        return appointments.Select(a => new AppointmentDto
        {
            Id = a.Id,
            NamaPemohon = a.NamaPemohon,
            EmailPemohon = a.EmailPemohon,
            NomorHpPemohon = a.NomorHpPemohon,
            NamaProfesor = a.NamaProfesor,
            Hari = a.Hari,
            Waktu = a.Waktu,
            Status = a.Status,
            CreatedAt = a.CreatedAt,
            UpdatedAt = a.UpdatedAt
        });
    }
}