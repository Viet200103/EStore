using System.ComponentModel.DataAnnotations;

namespace EStore.Business.DTOs
{
    public class MemberDTO
    {
        [Required]
        public int MemberId { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        
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