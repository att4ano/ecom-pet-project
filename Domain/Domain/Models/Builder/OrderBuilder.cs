namespace Domain.Models.Builder;

public class OrderBuilder
{
    private string? _address;
    private string? _description;
    private DateTime? _creationData;
    private readonly IList<OrderItem> _items = new List<OrderItem>();

    public OrderBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public OrderBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public OrderBuilder WithCreationData(DateTime creationData)
    {
        _creationData = creationData;
        return this;
    }

    public OrderBuilder AddItem(OrderItem orderItem)
    {
        _items.Add(orderItem);
        return this;
    }

    public Order Build()
    {
        var order = new Order(
            _address ?? throw new ArgumentNullException(nameof(_address), "cannot be null"),
            _description,
            _creationData ?? throw new ArgumentNullException(nameof(_creationData), "cannot be null"));

        foreach (var item in _items)
        {
            order.Items.Add(item);
        }

        return order;
    }
}