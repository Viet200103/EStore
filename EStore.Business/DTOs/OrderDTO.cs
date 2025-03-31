using System.ComponentModel.DataAnnotations;

namespace EStore.Business.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Member is required.")]
        public int MemberId { get; set; }

        public string MemberEmail { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Freight must be a positive value.")]
        public decimal? Freight { get; set; }
    }
}
