using Domain.Products;

namespace Domain.Orders;

public class LineItem
{
    private LineItem(Guid id, OrderId orderId, ProductId productId, int quantity, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public static LineItem Create(OrderId orderId, ProductId productId, int quantity, Money price)
    {
        if (quantity <= 0)
        {
            return null!;
        }

        return new LineItem(Guid.NewGuid(), orderId, productId, quantity, price);
    }
    public Guid Id { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public int Quantity { get; private set; }
    public Money Price { get; private set; }
}
