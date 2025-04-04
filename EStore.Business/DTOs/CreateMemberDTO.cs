using System.ComponentModel.DataAnnotations;

namespace EStore.Business.DTOs
{
    public class CreateMemberDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(30)]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [MaxLength(40)]
        public string? CompanyName { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string? City { get; set; }
        
        [Required]
        [MaxLength(15)]
        public string? Country { get; set; }
    }
}