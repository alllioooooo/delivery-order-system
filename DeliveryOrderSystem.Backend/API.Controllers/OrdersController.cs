using API.DTO;
using AutoMapper;
using Domain.Abstractions.Services;
using Domain.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(string id)
    {
        try
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
    {
        try
        {
            Console.WriteLine("Starting to map DTO to Order.");
            var order = _mapper.Map<Order>(orderDto);
            Console.WriteLine($"DTO mapped successfully: {order}");

            Console.WriteLine("Calling service to create order.");
            var createdOrder = await _orderService.CreateOrderAsync(order);
            Console.WriteLine($"Order created successfully: {createdOrder}");

            var resultDto = _mapper.Map<OrderDto>(createdOrder);
            return CreatedAtAction(nameof(GetOrderById), new { id = resultDto.OrderId }, resultDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while creating order: {orderDto}. Exception: {ex.Message}");
            return StatusCode(500, "An internal server error occurred.");
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(string id)
    {
        try
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An internal server error occurred.");
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllOrderIds()
    {
        try
        {
            Console.WriteLine("Fetching all order IDs");
            var orders = await _orderService.GetAllOrdersAsync();
            var orderIds = orders.Select(o => o?.OrderId).ToList();

            if (!orderIds.Any())
            {
                Console.WriteLine("No order IDs found");
                return Ok(null);
            }

            Console.WriteLine($"Fetched {orderIds.Count} order IDs");
            return Ok(orderIds);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while fetching order IDs: {ex.Message}");
            return StatusCode(500, "An internal server error occurred.");
        }
    }

}