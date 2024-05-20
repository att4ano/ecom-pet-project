using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class ProductCategory
{
    [Key]
    public Guid Id { get; } = Guid.NewGuid();
    
    public required string CategoryName { get; init; }
    
    public IEnumerable<Product> Products { get; } = new List<Product>();
}