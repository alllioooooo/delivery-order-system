using Domain.Abstractions.Orders;

namespace Domain.Models.Orders;

public class Order: IOrder
{
    public string OrderId { get; protected set; } = null!;
    public string SenderCity { get; protected set; } = null!;
    public string SenderAddress { get; protected set; } = null!;
    public string ReceiverCity { get; protected set; } = null!;
    public string ReceiverAddress { get; protected set; } = null!;
    public double Weight { get; protected set; }
    public DateTime PickupDate { get; protected set; }
    
}
