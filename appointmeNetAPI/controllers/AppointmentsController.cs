using Microsoft.AspNetCore.Mvc;
using restAPI.DTOs;
using restAPI.models;
using restAPI.services;

namespace restAPI.controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments()
    {
        var appointments = await _appointmentService.GetAllAppointmentsAsync();
        return Ok(appointments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentDto>> GetAppointment(int id)
    {
        var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        if (appointment == null)
        {
            return NotFound(new { message = $"Appointment dengan ID {id} tidak ditemukan!" });
        }

        return Ok(appointment);
    }

    [HttpPost]
    public async Task<ActionResult<AppointmentDto>> CreateAppointment(CreateAppointmentDto createAppointmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = await _appointmentService.CreateAppointmentAsync(createAppointmentDto);
        if (appointment == null)
        {
            return BadRequest(new { message = "Gagal membuat appointment" });
        }

        return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AppointmentDto>> UpdateAppointment(
        int id, 
        UpdateAppointmentDto updateAppointmentDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var appointment = await _appointmentService.UpdateAppointmentAsync(id, updateAppointmentDto);
        if (appointment == null)
        {
            return NotFound(new { message = $"Appointment dengan ID {id} tidak ditemukan!" });
        }

        return Ok(appointment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointment(int id)
    {
        var result = await _appointmentService.DeleteAppointmentAsync(id);
        if (!result)
        {
            return NotFound(new { message = $"Appointment dengan ID {id} tidak ditemukan!" });
        }

        return NoContent();
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByStatus(string status)
    {
        var appointments = await _appointmentService.GetAppointmentsByStatusAsync(status);
        return Ok(appointments);
    }

    [HttpGet("profesor/{namaProfesor}")]
    public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointmentsByProfesor(string namaProfesor)
    {
        var appointments = await _appointmentService.GetAppointmentsByProfesorAsync(namaProfesor);
        return Ok(appointments);
    }
}