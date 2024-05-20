namespace Domain.Common.Exceptions;

public class OrderItemException : DomainException
{
    private OrderItemException(string message) : base(message) { }

    public static OrderItemException ItemAmountException()
    {
        return new OrderItemException("Item amount cannot be negative");
    }
}