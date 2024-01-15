using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public void Add(Product product, int quantity)
    {
        var lineItem = LineItem.Create(Id, product.Id, quantity, product.Price);
        if (lineItem is not null)
        {
            _lineItems.Add(lineItem);
        }
    }
}

public class LineItem
{
    private LineItem(Guid id, Guid orderId, Guid productId, int quantity, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public static LineItem Create(Guid orderId, Guid productId, int quantity, Money price)
    {
        if (quantity <= 0)
        {
            return null!;
        }

        return new LineItem(Guid.NewGuid(), orderId, productId, quantity, price);
    }
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
}
