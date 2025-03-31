namespace EStore.Business.DTOs
{
    public class MemberDTO
    {
        public int MemberId { get; set; }

        public string Email { get; set; } = null!;

        public string? CompanyName { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }
    }
}