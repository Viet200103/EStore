using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequireDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public decimal? Freight { get; set; }

        public Member? Member { get; set; }

        public ICollection<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
