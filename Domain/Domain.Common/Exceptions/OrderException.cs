namespace Domain.Common.Exceptions;

public class OrderException : DomainException
{
    private OrderException(string message) : base(message) { }

    public static OrderException CancelOrderException()
        => new OrderException("Cannot cancel order which is already completed or cancelled");

    public static OrderException CompleteOrderException()
        => new OrderException("Cannot complete order which is already completed or cancelled");

    public static OrderException AddProductToCompletedOrCancelledOrder()
        => new OrderException("Cannot add product to completed or cancelled order");
}