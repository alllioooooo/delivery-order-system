using System.ComponentModel.DataAnnotations;

namespace Infrastructure.DataAccess.Entities;

public class Order
{
    [Key]
    public string OrderId { get; set; }

    [Required, MaxLength(100)]
    public string SenderCity { get; set; }

    [Required, MaxLength(200)]
    public string SenderAddress { get; set; }

    [Required, MaxLength(100)]
    public string ReceiverCity { get; set; }

    [Required, MaxLength(200)]
    public string ReceiverAddress { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public DateTime PickupDate { get; set; }
}