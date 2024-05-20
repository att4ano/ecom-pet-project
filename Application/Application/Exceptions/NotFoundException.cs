namespace Application.Exceptions;

public class NotFoundException : ApplicationException
{
    private NotFoundException(string message) : base(message) { }

    public static NotFoundException OrderNotFoundException()
        => new NotFoundException("Order not found");

    public static NotFoundException OrderItemNotFoundException()
        => new NotFoundException("Item not found");

    public static NotFoundException ProductNotFoundException()
        => new NotFoundException("Product not found");  
}