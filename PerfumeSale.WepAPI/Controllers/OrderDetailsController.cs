using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Entities;

namespace PerfumeSale.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        [EnableQuery] 
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            return Ok(await _orderDetailService.GetOrderDetailsAsync());
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<ActionResult<OrderDetail>> GetOrderDetailById(int id)
        {
            return Ok(await _orderDetailService.GetOrderDetailById(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderDetail(OrderDetail orderDetail)
        {
            await _orderDetailService.AddOrderDetailAsync(orderDetail);
            return Created("", orderDetail);
        }

    }
}
