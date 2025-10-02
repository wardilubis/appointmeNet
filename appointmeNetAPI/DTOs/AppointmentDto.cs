using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace restAPI.DTOs;

public class CreateAppointmentDto
{
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
    [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Format waktu harus HH:mm (contoh: 14:30)")]
    public string Waktu { get; set; } = string.Empty;

    [StringLength(50)]
    public string Status { get; set; } = "Pending";
}

public class UpdateAppointmentDto
{
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
    [RegularExpression(@"^([01]?[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Format waktu harus HH:mm (contoh: 14:30)")]
    public string Waktu { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Status { get; set; } = string.Empty;
}

public class AppointmentDto
{
    public int Id { get; set; }
    public string NamaPemohon { get; set; } = string.Empty;
    public string EmailPemohon { get; set; } = string.Empty;
    public string NomorHpPemohon { get; set; } = string.Empty;
    public string NamaProfesor { get; set; } = string.Empty;
    public DateTime Hari { get; set; }
    public string Waktu { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}