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
    public class EfOrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public EfOrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<bool> AddOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Add(orderDetail);
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Delete(orderDetail);
            return await Task.FromResult<bool>(true);
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            var entity = _orderDetailRepository.Get(id);
            return await Task.FromResult(entity).Result;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsAsync()
        {
            var list = _orderDetailRepository.GetAll();
            return await Task.FromResult(list.AsEnumerable());
        }

        public async Task<bool> UpdateOrderDetailAsync(OrderDetail orderDetail)
        {
            await _orderDetailRepository.Edit(orderDetail);
            return await Task.FromResult<bool>(true);
        }
    }
}




