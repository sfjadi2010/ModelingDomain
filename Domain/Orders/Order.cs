using Domain.Customers;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders;

public class Order
{
    private Order() { }
    private readonly HashSet<LineItem> _lineItems = new();
    public OrderId OrderId { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public Order Create(Customer customer)
    {
        return new Order
        {
            OrderId = new OrderId(Guid.NewGuid()),
            CustomerId = customer.Id
        };
    }
    public void Add(Product product, int quantity)
    {
        var lineItem = LineItem.Create(OrderId, product.Id, quantity, product.Price);
        if (lineItem is not null)
        {
            _lineItems.Add(lineItem);
        }
    }
}
