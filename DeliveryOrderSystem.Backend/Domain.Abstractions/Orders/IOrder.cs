namespace Domain.Abstractions.Orders;

public interface IOrder
{
    string OrderId { get; }
    string SenderCity { get; }
    string SenderAddress { get; }
    string ReceiverCity { get; }
    string ReceiverAddress { get; }
    double Weight { get; }
    DateTime PickupDate { get; }
}