using Domain.Abstractions.Orders;

namespace Domain.Models.Orders;

public class Order : IOrder
{
    public string OrderId { get; set;  }
    public string SenderCity { get; set; }
    public string SenderAddress { get; set; }
    public string ReceiverCity { get; set; }
    public string ReceiverAddress { get; set; }
    public double Weight { get; set; }
    public DateTime PickupDate { get; set; }

}