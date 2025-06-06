﻿namespace EStore.Data.Models;

public class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequireDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public decimal? Freight { get; set; }

    public Member? Member { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
