using restAPI.DTOs;
using restAPI.models;

namespace restAPI.services;

public interface IAppointmentService
{
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync();
    Task<AppointmentDto?> GetAppointmentByIdAsync(int id);
    Task<AppointmentDto?> CreateAppointmentAsync(CreateAppointmentDto createAppointmentDto);
    Task<AppointmentDto?> UpdateAppointmentAsync(int id, UpdateAppointmentDto updateAppointmentDto);
    Task<bool> DeleteAppointmentAsync(int id);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByStatusAsync(string status);
    Task<IEnumerable<AppointmentDto>> GetAppointmentsByProfesorAsync(string namaProfesor);
}