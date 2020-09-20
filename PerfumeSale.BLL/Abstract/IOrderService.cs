using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeSale.BLL.Abstract
{
    public interface IOrderService
    {
        Task<bool> AddOrderAsync(Order order);

        Task<bool> DeleteOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order order);

        Task<IEnumerable<Order>> GetOrdersAsync();

        Task<Order> GetOrderById(int id);
    }
}
