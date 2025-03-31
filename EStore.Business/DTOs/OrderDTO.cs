using System.ComponentModel.DataAnnotations;

namespace EStore.Business.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        [Required(ErrorMessage = "Member Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string MemberEmail { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Require Date is required.")]
        public DateTime? RequireDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Freight must be a positive value.")]
        public decimal? Freight { get; set; }
    }
}
