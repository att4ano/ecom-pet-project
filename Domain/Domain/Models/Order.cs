using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common.Exceptions;
using Domain.Status;

namespace Domain.Models;

[Table("orders")]
public class Order
{
    public Order(
        string address, 
        string? description, 
        DateTime creationData)
    {
        Address = address;
        Description = description;
        CreationData = creationData;
    }

    [Key]
    public Guid Id { get; } = Guid.NewGuid();
    public string Address { get; init; }
    public string? Description { get; init; }
    public DateTime CreationData { get; init; }
    public OrderStatus Status { get; private set; } = OrderStatus.Created;
    public IList<OrderItem> Items { get; } = new List<OrderItem>();

    public void CancelOrder()
    {
        if (Status != OrderStatus.Created)
            throw OrderException.CancelOrderException();

        Status = OrderStatus.Cancelled;
    }

    public void CompleteOrder()
    {
        if (Status != OrderStatus.Created)
            throw OrderException.CompleteOrderException();

        Status = OrderStatus.Done;
    }
}