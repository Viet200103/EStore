using EStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.DTOs
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "Please select a category.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string? ProductName { get; set; }

        public string? Weight { get; set; }

        [Required(ErrorMessage = "Price of product is required.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Units in Stock is required.")]
        public int UnitslnStock { get; set; }
     
    }
}
