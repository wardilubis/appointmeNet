using System.ComponentModel.DataAnnotations;

namespace restAPI.models;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string NamaPemohon { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string EmailPemohon { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string NomorHpPemohon { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string NamaProfesor { get; set; } = string.Empty;

    [Required]
    public DateTime Hari { get; set; }

    [Required]
    [StringLength(5)] // Format HH:mm
    public string Waktu { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = "Pending"; // Default status

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}