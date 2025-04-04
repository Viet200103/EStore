using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EStore.Business.DTOs
{
    public class AddCategoryDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
