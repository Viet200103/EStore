namespace EStore.Data.Models
{
    public class SalesReport
    {
        public DateTime? OrderDate { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public double Discount { get; set; }
    }
}
