using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common.Exceptions;

namespace Domain.Models;

[Table("orderitem")]
public class OrderItem
{
    [Key]
    public Guid Id { get; } = Guid.NewGuid();
    
    public required Guid ProductId { get; init; }
    
    public required Product ProductItem { get; init; }
    
    public required Guid OrderId { get; init; }
    
    public required Order Order { get; init; }

    public int Amount { get; set; } = 1;
    
}