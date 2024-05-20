using Domain.Common.Exceptions;

namespace Domain.Models.Builder;

public class OrderItemBuilder
{
    private Guid _productId;
    private Product? _productItem;
    private Guid _orderId;
    private Order? _order;
    private int _amount = 1;

    public OrderItemBuilder WithProductItem(Product productItem)
    {
        _productItem = productItem;
        _productId = productItem.Id;
        return this;
    }

    public OrderItemBuilder WithOrder(Order order)
    {
        _order = order;
        _orderId = order.Id;
        return this;
    }

    public OrderItemBuilder WithAmount(int amount)
    {
        if (amount <= 0)
            throw OrderItemException.ItemAmountException();
        
        _amount = amount;
        return this;
    }

    public OrderItem Build()
    {
        return new OrderItem
        {
            ProductId = _productId,
            ProductItem = _productItem ?? throw new ArgumentNullException(nameof(_productItem), "cannot br null"),
            OrderId = _orderId,
            Order = _order ?? throw new ArgumentNullException(nameof(_order), "cannot be null"),
            Amount = _amount
        };
    }
}