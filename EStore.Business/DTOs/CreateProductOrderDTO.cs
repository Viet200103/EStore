namespace EStore.Business.DTOs
{
    public class CreateProductOrderDTO
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string? ProductName { get; set; }

        public string? Weight { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitslnStock { get; set; }

        public int OrderQuantity { get; set; }

        public double Discount { get; set; }
    }
}
