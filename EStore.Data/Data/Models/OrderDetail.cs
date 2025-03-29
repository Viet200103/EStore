namespace EStore.Data.Data.Models;

public class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public double Discount { get; set; }

    public Order? Order { get; set; }

    public Product Product { get; set; } = null!;
}
