using API.DTO;
using Domain.Abstractions.Services;
using Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IOrderService orderService)
    : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(string id)
    {
        try
        {
            var order = await orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
    {
        try
        {
            var order = new OrderBuilder()
                .SetSenderCity(orderDto.SenderCity)
                .SetSenderAddress(orderDto.SenderAddress)
                .SetReceiverCity(orderDto.ReceiverCity)
                .SetReceiverAddress(orderDto.ReceiverAddress)
                .SetWeight(orderDto.Weight)
                .SetPickupDate(orderDto.PickupDate)
                .Build();
            
            var createdOrder = await orderService.CreateOrderAsync(order);

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, createdOrder);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        try
        {
            await orderService.DeleteOrderAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }
    
    [HttpGet("AllOrderIds")]
    public async Task<IActionResult> GetAllOrderIds()
    {
        try
        {
            var orders = await orderService.GetAllOrdersAsync();
            var orderIds = orders.Select(o => o?.OrderId);
            return Ok(orderIds);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }

}