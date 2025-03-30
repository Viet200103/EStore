namespace EStore.Data.Models;

public class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? Weight { get; set; }

    public decimal? UnitPrice { get; set; }

    public int UnitslnStock { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
