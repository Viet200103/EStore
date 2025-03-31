using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.DTOs
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public double Discount { get; set; }

        public OrderDTO? Order { get; set; }

        public ProductDTO Product { get; set; } = null!;
    }
}
