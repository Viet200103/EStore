﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.DTOs
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? Weight { get; set; }

        public decimal? UnitPrice { get; set; }

        public int UnitslnStock { get; set; }
    }
}
