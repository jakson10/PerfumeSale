using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            return Ok(await _orderService.GetOrderById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(Order order)
        {
            await _orderService.AddOrderAsync(order);
            return Created("", order);
        }

        [HttpPut]
        public async Task<IActionResult> PutOrder(Order order)
        {
            await _orderService.UpdateOrderAsync(order);
            return Created("", order);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(await _orderService.GetOrderById(id));
            return NoContent();
        }
    }
}
