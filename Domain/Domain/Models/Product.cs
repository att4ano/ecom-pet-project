using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class Product
{
    [Key]
    public Guid Id { get; } = Guid.NewGuid();
    public required string ProductName { get; init; }
    public required Guid CategoryId { get; set; }
    public required ProductCategory Category { get; init; }
    public required decimal Price { get; set; }
    public required string? Description { get; init; }
    public IEnumerable<OrderItem> Items { get; } = new List<OrderItem>();
}