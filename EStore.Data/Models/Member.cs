namespace EStore.Data.Models;

public class Member
{
    public int MemberId { get; set; }

    public string Email { get; set; } = null!;
    
    public string? Password { get; set; }

    public string? CompanyName { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
