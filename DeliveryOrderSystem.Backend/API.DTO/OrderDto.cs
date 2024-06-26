namespace API.DTO;

public class OrderDto
{
    public required string OrderId { get; set; }
    public required string SenderCity { get; set; }
    public required string SenderAddress { get; set; }
    public required string ReceiverCity { get; set; }
    public required string ReceiverAddress { get; set; }
    public required double Weight { get; set; }
    public required DateTime PickupDate { get; set; }
}