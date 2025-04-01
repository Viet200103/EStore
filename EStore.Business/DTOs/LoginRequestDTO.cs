using System.ComponentModel.DataAnnotations;

namespace EStore.Business.DTOs;

public class LoginRequestDTO
{
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }
    
    [Required]
    [MaxLength(30)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}