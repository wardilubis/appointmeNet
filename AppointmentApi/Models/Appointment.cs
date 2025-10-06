namespace AppointmentApi.Models;

public class Appointment
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Location { get; set; } = string.Empty;
    public string AttendeeEmail { get; set; } = string.Empty;
    public string Status { get; set; } = "Scheduled";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
