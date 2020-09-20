using PerfumeSale.BLL.Abstract;
using PerfumeSale.Core.Abstract;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Concrete.EntityFrameworkCore
{
    public class EfOrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public EfOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> AddOrderAsync(Order order)
        {
            await _orderRepository.Add(order);
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> DeleteOrderAsync(Order order)
        {
            await _orderRepository.Delete(order);
            return await Task.FromResult<bool>(true);
        }

        public async Task<Order> GetOrderById(int id)
        {
            var entity = _orderRepository.Get(id);
            return await Task.FromResult(entity).Result;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var list = _orderRepository.GetAll();
            return await Task.FromResult(list.AsEnumerable());
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            await _orderRepository.Edit(order);
            return await Task.FromResult<bool>(true);
        }
    }
}



