using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string? ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
        [Required]
        public double Discount { get; set; }
        [Required]
        public Order? Order { get; set; }

    }
}
